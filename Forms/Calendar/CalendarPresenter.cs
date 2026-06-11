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
        public CalendarPresenter(ICalendarView calendarView,CalendarModel calendarModel)
        {
            _view = calendarView;
            _model = calendarModel;
            _view.DayClicked += OnDayClicked;
            _view.SelectedDateChanged += OnSelectedDateChanged;
            _view.NextButtonClicked += NextButtonClicked;
            _view.PreviousButtonClicked += PreviousButtonClicked;
            _view.AddEventButtonClicked += OnAddEventButtonClicked;
            GenerateMonth();
        }
        private void GenerateMonth()
        {
            try
            {
                _view.SuspendAndClearCalendar();
                DateTime date = _view.SelectedDate;
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                int offset = _model.CalculateOffset(date);


                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime currentDate = new DateTime(date.Year, date.Month, day);

                    List<string> events = _model.GetStringTaskList(currentDate);


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
            _model.NavigationService.NavigateTo<TaskPresenter, CalendarEvent>(null);
        }
    }
}
