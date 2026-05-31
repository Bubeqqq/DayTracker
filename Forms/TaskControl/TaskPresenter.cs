using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DayTracker.UserControls.TestTask_usunac;

namespace DayTracker.Forms.TaskControl
{
    internal class TaskPresenter:IPresenter<TestTask>
    {
        private readonly ITaskModel _model;
        private readonly ITaskView _view;
        public IModel Model => _model;
        public IView View => _view;
        public TaskPresenter(ITaskView view,ITaskModel model) {
            _view=view;
            _model=model;
            _view.FieldValidation += OnFieldValidation;
            TestTask task = new TestTask(1, "test1", new DateTime(2026, 5, 25), "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new TimeSpan(1, 1, 0));
            DateTime endTime = task.Date.Add(task.Duration);
            _view.SetTaskInfoFields(task.Title, task.Description, task.Date, task.Duration, endTime);
        }
        public void LoadArgs(TestTask args)
        {

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
      
        
    }
}
