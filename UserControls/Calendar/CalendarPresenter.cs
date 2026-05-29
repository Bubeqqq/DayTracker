using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Day;

namespace WinFormsApp1.Calendar
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
            TestTask task = new TestTask(1, "test1", new DateTime(2026, 5, 5), "XD", new TimeSpan(1, 5, 0));
            TestTask task2 = new TestTask(1, "test2", new DateTime(2026, 5, 30), "XD", new TimeSpan(2, 5, 0));
            List<TestTask> tasks = new List<TestTask>();
            tasks.Add(task);
            tasks.Add(task2);
            GenerateMonth(tasks);
        }
        private void GenerateMonth(List<TestTask> allTasks)
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

                    List<string> tasks = _model.GetStringTaskList(allTasks, currentDate);

                    int position = offset + (day - 1);
                    int column = position % 7;
                    int row = position / 7;

                    _view.CreateAndAddDayCell(currentDate, tasks, column, row);

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
            //_model.NavigationService.NavigateTo<DayPresenter, DateTime>(e.Date);
        }
        private void OnSelectedDateChanged(object sender, EventArgs e) {
            TestTask task = new TestTask(1, "test1", new DateTime(2026, 5, 5), "XD", new TimeSpan(2, 5, 0));
            TestTask task2 = new TestTask(1, "test2", new DateTime(2026, 4, 30), "XD", new TimeSpan(2, 4, 0));
            List<TestTask> tasks = new List<TestTask>();
            tasks.Add(task);
            tasks.Add(task2);
            GenerateMonth(tasks);
        }
        private void NextButtonClicked(object sender, EventArgs e) {
            _view.AddMonthToDate(1);
            
        }
        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            _view.AddMonthToDate(-1);
        }
    }
}
