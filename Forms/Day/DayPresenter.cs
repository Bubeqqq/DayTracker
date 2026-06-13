using DayTracker.Database.Datatypes;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.Day.TaskPreview;
using DayTracker.Forms.TaskControl;

namespace DayTracker.Forms.Day
{
    internal class DayPresenter : IPresenter<DateTime>// TODO to musi dostać dzień i na jego podstawie powinno liczyć gdzie dać taski
    {//TODO Dodać przycisk dodaj
        private readonly IDayView _view;
        private readonly IDayModel _model;
        public IModel Model => _model;
        public IView View => _view;
        private DateTime _date;
        private List<CalendarEvent> _eventList;
        private bool canModify;
        public DayPresenter(DayUserControl view, DayModel model)
        {
            _view = view;
            _model = model;
            canModify = _model.CanModify();
            _model.LoadedDataService.OnCalendarEventsChanged += () =>
            {
                _view.ClearControls();
                _view.SetDateLabel(_date);
                _eventList = _model.GetEventsForDay(_date);
                LayoutEvents(_eventList);
            };
            _model.LoadedDataService.OnTodoItemsChanged += () =>
            {
                _view.ClearControls();
                _view.SetDateLabel(_date);
                _eventList = _model.GetEventsForDay(_date);
                LayoutEvents(_eventList);
            };
            _model.LoadedDataService.OnPermissionsChanged += () =>
            {
                canModify = _model.CanModify();
            };
            _view.BackToCalendarClicked += (sender, args) => _model.NavigationService.NavigateTo<CalendarPresenter>();
            _view.SizeChanged += OnSizeChanged;
            _view.CalendarEventClicked += OnCalendarEventClicked;
            _view.DeleteClicked += OnDeleteClicked;
            _view.AddClicked += OnAddClicked;

        }
        public void LoadArgs(DateTime args)
        {
            _date = args;
            _view.SetDateLabel(_date);
            _eventList = _model.GetEventsForDay(_date);

            LayoutEvents(_eventList);


        }
        private void LayoutEvents(List<CalendarEvent> events)
        {
            if (_eventList.Count != 0)
            {
                List<List<CalendarEvent>> columns = _model.CalculateColumns(events);

                int columnsCount = columns.Count;

                int eventWidth = CalculateEventWidth(columnsCount, _view.TotalWidth, _view.LeftMargin);

                for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    foreach (var calendarEvent in columns[columnIndex])
                    {

                        int x = _model.CalculateX(_view.LeftMargin, columnIndex, eventWidth);

                        int y = _model.CalculateY(calendarEvent.StartTime, _view.PixelsPerHour, _date) + _view.TopMargin;
                        int height = _model.CalculateHeight(calendarEvent.StartTime, calendarEvent.Duration, _view.PixelsPerHour, _date);
                        if (_date.Date > calendarEvent.StartTime)
                        {
                            _view.CreateAndPlaceTaskControl(calendarEvent, x, y, eventWidth, height, _model.GetEventColor(calendarEvent), calendarEvent.StartTime.ToShortDateString());
                        }
                        else
                        {
                            _view.CreateAndPlaceTaskControl(calendarEvent, x, y, eventWidth, height, _model.GetEventColor(calendarEvent));
                        }
                    }
                }
            }
        }
        private int CalculateEventWidth(int columnsCount, int totalWidth, int leftMargin)
        {
            int availableWidth = _view.TotalWidth - _view.LeftMargin;

            if (availableWidth <= 0)
            {
                throw new ArgumentException();
            }

            int taskWidth = availableWidth / columnsCount;
            return taskWidth;
        }
        private void UpdateEvents(List<CalendarEvent> events)
        {
            if (_eventList.Count != 0)
            {
                List<List<CalendarEvent>> columns = _model.CalculateColumns(events);

                int columnsCount = columns.Count;
                int eventWidth = CalculateEventWidth(columnsCount, _view.TotalWidth, _view.LeftMargin);

                int index = 0;
                for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {

                    foreach (var calendarEvent in columns[columnIndex])
                    {
                        int x = _model.CalculateX(_view.LeftMargin, columnIndex, eventWidth);
                        int y = _model.CalculateY(calendarEvent.StartTime, _view.PixelsPerHour, _date) + _view.TopMargin;
                        int height = _model.CalculateHeight(calendarEvent.StartTime, calendarEvent.Duration, _view.PixelsPerHour, _date);

                        _view.ModifyControl(index, x, y, eventWidth, height, _model.GetEventColor(calendarEvent));
                        index++;
                    }
                }
            }
        }
        private void OnAddClicked(object sender, EventArgs e)
        {
            if(!canModify)
            {
                _view.ShowMessage("You don't have permissions to modify this calendar");
                return;
            }
            CalendarEvent calendarEvent = _model.CreateDefualutCalendarEvent(_date);
            _model.NavigationService.NavigateTo<TaskPresenter, CalendarEvent>(calendarEvent);
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {
            UpdateEvents(_eventList);

        }

        private void OnCalendarEventClicked(object sender, CalendarEventClickedEventArgs e)
        {

            _model.NavigationService.NavigateTo<TaskPresenter, CalendarEvent>(e.CalendarEvent);
        }
        private void OnDeleteClicked(object sender, CalendarEventClickedEventArgs e)
        {
            if (!canModify)
            {
                _view.ShowMessage("You don't have permissions to modify this calendar");
                return;
            }
            bool yesDecision = _view.YesNoMessage("Are you sure you want to delete this task?");
            if (yesDecision)
            {
                _model.DeleteCalendarEvent(e.CalendarEvent);
                _eventList.Remove(e.CalendarEvent);

            }
        }
    }
}
