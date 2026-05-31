using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTracker.Forms.Day.TaskPreview;
using DayTracker.UserControls.TestTask_usunac;
using DayTracker.Forms.TaskControl;

namespace DayTracker.Forms.Day
{
    internal class DayPresenter : IPresenter<DateTime>// TODO to musi dostać dzień i na jego podstawie powinno liczyć gdzie dać taski
    {//TODO Dodać przycisk dodaj
        private readonly IDayView _view; 
        private readonly IDayModel _model;
        public IModel Model => _model;
        public IView View => _view;
        private List<TestTask> tasks;//wyjebac
        private DateTime _date;
        public DayPresenter(DayUserControl view, DayModel model) {
            _view = view;
            _model = model;
            _view.SizeChanged += OnSizeChanged;
            _view.TaskClicked += OnTaskClicked;
            _view.DeleteClicked += OnDeleteClicked;
            TestTask task = new TestTask(1, "test1", new DateTime(2026, 5, 25), "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new TimeSpan(1,1,0));
            TestTask task2 = new TestTask(1, "test2", new DateTime(2026, 5, 25), "XD",new TimeSpan(2, 5, 0));
            TestTask task3 = new TestTask(1, "test1", new DateTime(2026, 5, 25), "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new TimeSpan(1, 1, 0));
            TestTask task4 = new TestTask(1, "test2", new DateTime(2026, 5, 25), "XD", new TimeSpan(2, 5, 0));
            TestTask task5 = new TestTask(1, "test1", new DateTime(2026, 5, 25), "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new TimeSpan(1, 1, 0));
            TestTask task6 = new TestTask(1, "test2", new DateTime(2026, 5, 25), "XD", new TimeSpan(2, 5, 0));
            TestTask task7 = new TestTask(1, "test1", new DateTime(2026, 5, 25), "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new TimeSpan(1, 1, 0));
            TestTask task8 = new TestTask(1, "test2", new DateTime(2026, 5, 25), "XD", new TimeSpan(2, 5, 0));
            tasks = new List<TestTask>();
            tasks.Add(task);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);
            tasks.Add(task6);
            tasks.Add(task7);
            tasks.Add(task8);
            LayoutTasks(tasks);
        }
        public void LoadArgs(DateTime args)
        {
            _date = args;
        }
        private void LayoutTasks(List<TestTask> tasks)
        {

            List<List<TestTask>> columns = _model.CalculateColumns(tasks);

            int columnsCount = columns.Count;

            int taskWidth = CalculateTaskWidth(columnsCount, _view.TotalWidth, _view.LeftMargin);

            for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
            {
                foreach (var task in columns[columnIndex])
                {

                    int x = _model.CalculateX(_view.LeftMargin, columnIndex, taskWidth);

                    int y = _model.CalculateY(task.Date, _view.PixelsPerHour);
                    int height = _model.CalculateHeight(task.Duration,_view.PixelsPerHour);
                    _view.CreateAndPlaceTaskControl(task, x, y, taskWidth, height);
                }
            }
        }
        private int CalculateTaskWidth(int columnsCount,int totalWidth, int leftMargin)
        {
            int availableWidth = _view.TotalWidth - _view.LeftMargin;

            if (columnsCount == 0 || availableWidth <= 0)
            {
                throw new ArgumentException();
            }

            int taskWidth = availableWidth / columnsCount;
            return taskWidth;
        }
        private void UpdateTasks(List<TestTask> tasks)
        {
            List<List<TestTask>> columns = _model.CalculateColumns(tasks);

            int columnsCount = columns.Count;
            int taskWidth = CalculateTaskWidth(columnsCount, _view.TotalWidth, _view.LeftMargin);

            int index = 0;
            for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
            {
                foreach (var task in columns[columnIndex])
                {
                    int x = _model.CalculateX(_view.LeftMargin,columnIndex , taskWidth);
                    int y = _model.CalculateY(task.Date, _view.PixelsPerHour);
                    int height = _model.CalculateHeight(task.Duration, _view.PixelsPerHour);
                    
                    _view.ModifyControl(index, x, y, taskWidth, height);
                    index++;
                }
            }
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {
            UpdateTasks(tasks);

        }

        private void OnTaskClicked(object sender, TaskClickedEventArgs e)
        {
            
            _model.NavigationService.NavigateTo<TaskPresenter, TestTask>(e.Task);
        }
        private void OnDeleteClicked(object sender, TaskClickedEventArgs e)
        {
            bool yesDecision=_view.YesNoMessage("Are you sure you want to delete this task?");
        }
    }
}
