using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.Forms.Day;
using DayTracker.Forms.TaskControl;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DayTracker.Forms.Calendar
{
    internal class CalendarPresenter:IPresenter//TODO to musi jakos pobrać liste taskow dla danego miesiąca
    {
        private readonly ICalendarView _view;
        private readonly ICalendarModel _model;
        public IModel Model => _model;
        public IView View => _view;
        private List<CalendarEvent> _events;


        public  CalendarPresenter(ICalendarView calendarView, CalendarModel calendarModel)
        {

            _view = calendarView;
            _view.CalendarLoad += async () => await OnCalendarLoad();
            _model = calendarModel;
            _model.NavigationService.ShowBar();
            _events = new List<CalendarEvent>();
            

            _model.LoadedDataService.OnCalendarEventsChanged += () =>
            {
                _events = _model.GetCalendarEvents();
                GenerateMonth();
            };
            
            _view.DayClicked += OnDayClicked;
            _view.SelectedDateChanged += OnSelectedDateChanged;
            _view.NextButtonClicked += NextButtonClicked;
            _view.PreviousButtonClicked += PreviousButtonClicked;
            _view.AddEventButtonClicked += OnAddEventButtonClicked;
            _view.EditSleepButtonClicked += async () => await OnEditSleepClicked();
            _events = _model.GetCalendarEvents();
            

            GenerateMonth();
        }
        private void GenerateMonth()
        {
            _view.ClearCalendarControls();
            try
            {

                _view.SuspendAndClearCalendar();
                
                DateTime date = _view.SelectedDate;
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                int offset = _model.CalculateOffset(date);


                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime currentDate = new DateTime(date.Year, date.Month, day);
                    
                    List<string> events = _model.GetStringTaskList(currentDate,_events);

                    int position = offset + (day - 1);
                    int column = position % 7;
                    int row = position / 7;

                    _view.CreateAndAddDayCell(currentDate, events, column, row);

                }


                _view.ResumeCalendarLayout();
            }
            catch (Exception ex)
            {
                _view.ShowMessage(ex.Message);
            }
        }
        private void OnDayClicked(object sender, DayClickedEventArgs e)
        {
            _model.NavigationService.NavigateTo<DayPresenter, DateTime>(e.Date);
        }
        private void OnSelectedDateChanged(object sender, EventArgs e) {
            
            GenerateMonth();
        }
        private void NextButtonClicked(object sender, EventArgs e) {
            _view.AddMonthToDate(1);
            
        }
        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            _view.AddMonthToDate(-1);
        }
        private void OnAddEventButtonClicked(object sender, EventArgs e)
        {
            if (!_model.CanModify)
            {
                _view.ShowMessage("You don't have permissions to modify this calendar");
                return;
            }
            _model.NavigationService.NavigateTo<TaskPresenter, CalendarEvent>(null);
        }
        private async Task OnEditSleepClicked()
        {


            if (!_model.SleepSubmited())
            {

                Tuple<DateTime, DateTime> sleep = _view.GetUserSleep("Edit Sleep Hours", DateTime.MinValue, DateTime.MinValue);
                while (sleep != null && !_model.SleepValid(sleep))
                {
                    _view.ShowMessage("Sleep is incorrect");
                    sleep = _view.GetUserSleep("Sleep Hours", DateTime.MinValue, DateTime.MinValue);
                }
                await _model.AddSleep(sleep);
            }
            else
            {
                Tuple<DateTime, DateTime> latestSleep = _model.GetLatestSleep();
                Tuple<DateTime, DateTime> sleep = _view.GetUserSleep("Edit Sleep Hours", latestSleep.Item1, latestSleep.Item2);
                while (sleep != null && !_model.SleepValid(sleep))
                {
                    _view.ShowMessage("Sleep is incorrect");
                    sleep = _view.GetUserSleep("Sleep Hours", DateTime.MinValue, DateTime.MinValue);
                }
                await _model.EditSleep(sleep);
            }

        }
        private async Task OnCalendarLoad()
        {
            if (DateTime.Now>DateTime.Now.Date.AddHours(6)&&!_model.SleepSubmited())
            {
                Tuple<DateTime, DateTime> sleep = _view.GetUserSleep("Sleep Hours", DateTime.MinValue, DateTime.MinValue);

                while (sleep != null && !_model.SleepValid(sleep))
                {
                    _view.ShowMessage("Sleep is incorrect");
                    sleep=_view.GetUserSleep("Sleep Hours", DateTime.MinValue, DateTime.MinValue);
                }
                await _model.AddSleep(sleep);
            }
        }
    }
}
