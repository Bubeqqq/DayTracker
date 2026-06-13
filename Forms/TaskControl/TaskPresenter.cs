using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.Forms.Day;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.Forms.TaskControl
{
    internal class TaskPresenter:IPresenter<CalendarEvent>
    {
        private readonly ITaskModel _model;
        private readonly ITaskView _view;
        public IModel Model => _model;
        public IView View => _view;
        private CalendarEvent defaultTask;
        private CalendarEvent _task;
        private bool _editMode;
        private bool canModify;
        public TaskPresenter(ITaskView view,ITaskModel model) {
            _view=view;
            _model=model;
            canModify = _model.CanModify();
            _model.LoadedDataService.OnPermissionsChanged += () =>
            {
                canModify = _model.CanModify();
            };
            _view.FieldValidation += OnFieldValidation;
            _view.ConfirmClicked += async ()=>await OnConfirmClicked();
            _view.SetCheckedListBoxItems(_model.GetDefaultCategories());
            Initialize();

        }
        private void Initialize()
        {

            _view.SetToDoList("");
            if (_task != null&& _task.Id == -1)
            {
                _editMode = false;
                SetTaskFields(_task);
            }else if (_task != null)
            {
                _editMode = true;
                //MessageBox.Show($"{_task.StartTime.Kind.ToString()}");
                SetTaskFields(_task);
            }

            else
            {
                _editMode = false;
                CalendarEvent defaultCalendarEvent = new CalendarEvent("Title", "Description", _model.GetCalendarId(), DateTime.Now.ToUniversalTime(), new TimeSpan(1, 1, 1, 0));
                SetTaskFields(defaultCalendarEvent);
            }
        }

        private void SetTaskFields(CalendarEvent calendarEvent)
        {

            _view.SetTaskInfoFields(calendarEvent.Title, calendarEvent.Description);

            DateTime startDate = calendarEvent.GetLocalStartTime();
            _view.SetStartDate(startDate.Hour.ToString(),startDate.Minute.ToString(),startDate.Day.ToString(),startDate.Month.ToString(),startDate.Year.ToString());

            TimeSpan duration= calendarEvent.Duration;
            _view.SetDuration(duration.Days.ToString(), duration.Hours.ToString(), duration.Minutes.ToString());

            DateTime endDate = calendarEvent.GetLocalStartTime().Add(duration);
            _view.SetEndDate(endDate.Hour.ToString(), endDate.Minute.ToString(), endDate.Day.ToString(), endDate.Month.ToString(), endDate.Year.ToString());
            SetCategories(calendarEvent);
            if (calendarEvent.Todo != null)
            {
                _view.SetToDoList(calendarEvent.Todo.Description);
            }
        }
        private void SetCategories(CalendarEvent calendarEvent)
        {
            Dictionary<string, bool> categories = _model.GetDefaultCategories();
            categories["IsHard"] = calendarEvent.IsHard;
            categories["IsOutdoor"] = calendarEvent.IsOutdoor;
            categories["IsSport"] = calendarEvent.IsSport;
            categories["IsWork"] = calendarEvent.IsWork;
            categories["IsRelax"] = calendarEvent.IsRelax;
            categories["IsEducation"] = calendarEvent.IsEducation;            
            _view.SetCheckedListBoxItems(categories);
        }
        public void LoadArgs(CalendarEvent args)
        {            
            _task =args;
            Initialize();
        }
        private void ValidateField(FieldValidationEventArgs e)
        {
            switch (e.Field)
            {
                case TaskField.StartMinute or TaskField.EndMinute or TaskField.DurationMinutes:
                    {
                        if (_model.ValidateMinute(e.NewValue))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Minute field has to be a number between 0 and 59";
                        }
                        break;
                    }
                case TaskField.StartHour or TaskField.EndHour or TaskField.DurationHours:
                    {
                        if (_model.ValidateHour(e.NewValue))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Hour field has to be a number between 0 and 23";
                        }
                        break;
                    }
                case TaskField.DurationDays:
                    {
                        string daysStr = e.NewValue;
                        if (_model.ValidateDurationDays(daysStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage= "Day field has to be a number greater or equal 0";
                        }
                        break;
                    }
                case TaskField.StartDay:
                    {
                        string dayStr = e.NewValue;
                        if (_model.ValidateDay(dayStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Day field has to be a number greater than 0";
                        }

                        else if (!_model.TryCalculateDaysInMonth(_view.StartMonth, _view.StartYear, out int daysInMonth) || !int.TryParse(dayStr, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"This date doesn't exist. This month has {daysInMonth} days";
                        }
                        break;
                    }
                case TaskField.EndDay:
                    {
                        string dayStr = e.NewValue;
                        if (_model.ValidateDay(dayStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Day field has to be a number greater than 0";
                        }
                        else if (!_model.TryCalculateDaysInMonth(_view.EndMonth, _view.EndYear, out int daysInMonth) || !int.TryParse(dayStr, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"This date doesn't exist. This month has {daysInMonth} days";
                        }
                        break;
                    }
                case TaskField.StartMonth:
                    {
                        string monthStr = e.NewValue;
                        if (_model.ValidateMonth(monthStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Month field has to be a number between 1 and 12";
                        }
                        else if (!_model.TryCalculateDaysInMonth(monthStr, _view.StartYear, out int daysInMonth) || !int.TryParse(_view.StartDay, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            _view.StartDay = daysInMonth.ToString();
                        }
                        break;
                    }
                case TaskField.EndMonth:
                    {
                        string monthStr = e.NewValue;
                        if (_model.ValidateMonth(monthStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Month field has to be a number between 1 and 12";
                            
                        }
                        else if (!_model.TryCalculateDaysInMonth(monthStr, _view.EndYear, out int daysInMonth) || !int.TryParse(_view.EndDay, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            _view.EndDay = daysInMonth.ToString();
                        }
                        break;
                    }
                case TaskField.StartYear:
                    {
                        string yearStr = e.NewValue;
                        if (_model.ValidateYear(yearStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Year field has to be a number beetwen 2000 and 2100";
                        }
                        else if (!_model.TryCalculateDaysInMonth(_view.StartMonth, yearStr, out int daysInMonth) || !int.TryParse(_view.StartDay, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            _view.StartDay = daysInMonth.ToString();
                        }
                        break;
                    }
                case TaskField.EndYear:
                    {
                        string yearStr = e.NewValue;
                        if (_model.ValidateYear(yearStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Year field has to be a number beetwen 2000 and 2100";
                        }
                        else if (!_model.TryCalculateDaysInMonth(_view.EndMonth, yearStr, out int daysInMonth) || !int.TryParse(_view.EndDay, out int day))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = $"Wrong Data Format";
                        }
                        else if (day > daysInMonth)
                        {
                            _view.EndDay = daysInMonth.ToString();
                        }
                        break;
                    }
            }
        }
        private void OnFieldValidation(object sender, FieldValidationEventArgs e)
        {
            ValidateField(e);
            switch (e.Field)
            {
                case TaskField.StartMinute or TaskField.StartHour or TaskField.StartDay or TaskField.StartMonth or TaskField.StartYear:
                    {
                        if (_model.TryGetDate(_view.StartMinute, _view.StartHour, _view.StartDay, _view.StartMonth, _view.StartYear, out DateTime startDate) &&
                            _model.TryGetDuration(_view.DurationMinutes, _view.DurationHours, _view.DurationDays, out TimeSpan duration))
                        {
                            SetNewEndDate(startDate, duration);
                        }
                        break;//change EndDate
                    }
                case TaskField.EndMinute or TaskField.EndHour or TaskField.EndDay or TaskField.EndMonth or TaskField.EndYear:
                    {
                        if (_model.TryGetDate(_view.StartMinute, _view.StartHour, _view.StartDay, _view.StartMonth, _view.StartYear, out DateTime startDate) &&
                            _model.TryGetDuration(_view.DurationMinutes, _view.DurationHours, _view.DurationDays, out TimeSpan duration)&&
                            _model.TryGetDate(_view.EndMinute, _view.EndHour, _view.EndDay, _view.EndMonth, _view.EndYear, out DateTime endDate)
                            )
                        {
                            if (DateTime.Compare(startDate,endDate)<0)
                            {
                                SetNewDuration(startDate, endDate);
                            }
                            else
                            {
                                SetNewStartDate(duration, endDate);
                            }
                        }
                            break;//Change duration unless enddate<startDate change StartDate
                    }
                case TaskField.DurationMinutes or TaskField.DurationHours or TaskField.DurationDays:
                    {
                        if (_model.TryGetDate(_view.StartMinute, _view.StartHour, _view.StartDay, _view.StartMonth, _view.StartYear, out DateTime startDate) &&
                            _model.TryGetDuration(_view.DurationMinutes, _view.DurationHours, _view.DurationDays, out TimeSpan duration))
                        {
                            SetNewEndDate(startDate, duration);
                        }
                        break;//change EndDate
                    }
            }
        }
        private void SetNewEndDate(DateTime startDate, TimeSpan duration)
        {
            DateTime newEndDate = startDate.Add(duration);
            _view.SetEndDate(newEndDate.Hour.ToString(), newEndDate.Minute.ToString(), newEndDate.Day.ToString(), newEndDate.Month.ToString(), newEndDate.Year.ToString());
        }
        private void SetNewDuration(DateTime startDate,DateTime endDate)
        {
            TimeSpan newDuration = endDate - startDate;
            _view.SetDuration(newDuration.Days.ToString(), newDuration.Hours.ToString(), newDuration.Minutes.ToString());
        }
        private void SetNewStartDate(TimeSpan duration,DateTime endDate)
        {
            DateTime newStartDate = endDate.Subtract(duration);
            _view.SetStartDate(newStartDate.Hour.ToString(), newStartDate.Minute.ToString(), newStartDate.Day.ToString(), newStartDate.Month.ToString(), newStartDate.Year.ToString());
        }
       
      private async Task OnConfirmClicked()
        {
            if (!canModify)
            {
                _view.ShowMessage("You don't have permissions to modify this calendar");
                return;
            }else
            if (_model.TryGetDate(_view.StartMinute, _view.StartHour, _view.StartDay, _view.StartMonth, _view.StartYear, out DateTime startTime) &&
                _model.TryGetDuration(_view.DurationMinutes, _view.DurationHours, _view.DurationDays, out TimeSpan duration) &&
                !string.IsNullOrEmpty(_view.Title))
            {

                CalendarEvent calendarEvent = new CalendarEvent(_view.Title, _view.Descritpion, _model.GetCalendarId(), startTime.ToUniversalTime(), duration);
                string toDoDescription = _view.GetToDoList();

                List<string> checkedCategories = _view.GetCheckedItems();
                _model.SetEventCategories(checkedCategories, calendarEvent);
                if (_editMode)
                {
                    if (!string.IsNullOrEmpty(toDoDescription))
                    {
                        if (calendarEvent.Todo != null)
                        {
                            TodoItem toDoItem = calendarEvent.Todo;
                            toDoItem.Description = toDoDescription;

                            toDoItem = await _model.ModifyToDoItem(toDoItem);
                            calendarEvent.Todo = toDoItem;
                            calendarEvent.TodoId = calendarEvent.Todo.Id;

                        }
                        else
                        {
                            TodoItem toDoItem = new TodoItem(toDoDescription);
                            toDoItem = await _model.AddToDoItem(toDoItem);
                            //MessageBox.Show("presenter ToDoItem: " + toDoItem.Description);
                            calendarEvent.Todo = toDoItem;
                            calendarEvent.TodoId = calendarEvent.Todo.Id;

                        }

                    }
                    else
                    {
                        if (calendarEvent.Todo != null)
                        {
                            await _model.DeleteToDoItem(calendarEvent.Todo);
                            calendarEvent.Todo = null;
                            calendarEvent.TodoId = null;

                        }
                    }
                    calendarEvent.Id = _task.Id;

                    await _model.ModifyCalendarEvent(calendarEvent);
                    DateTime comeBackDate = calendarEvent.GetLocalStartTime();
                    _model.NavigationService.NavigateTo<DayPresenter, DateTime>(comeBackDate.Date);
                }
                else
                {
                    if (!string.IsNullOrEmpty(toDoDescription))
                    {
                        TodoItem toDoItem = new TodoItem(toDoDescription);
                        //MessageBox.Show("presenter2 ToDoItem: " + toDoItem.Description);
                        toDoItem = await _model.AddToDoItem(toDoItem);
                        //MessageBox.Show("presenter2 ToDoItem: " + toDoItem.Description);
                        calendarEvent.Todo = toDoItem;
                        calendarEvent.TodoId = calendarEvent.Todo.Id;
                    }
                    await _model.AddCalendarEvent(calendarEvent);
                    DateTime comeBackDate = calendarEvent.GetLocalStartTime();
                    _model.NavigationService.NavigateTo<DayPresenter, DateTime>(comeBackDate.Date);
                }

            }

            
        }
        
    }
}
