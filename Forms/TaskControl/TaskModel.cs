using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.Day;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TaskControl
{
    internal class TaskModel:ITaskModel
    {
        public INavigationService NavigationService { get; set; }
        private readonly ILoadedDataService _loadedDataService;
        private readonly IDatabaseService _databaseService;
        private bool _isSaving = false;
        public TaskModel(INavigationService navigationService, ILoadedDataService loadedDataService ,IDatabaseService databaseService)
        {
            _loadedDataService = loadedDataService;
            NavigationService = navigationService;
            _databaseService = databaseService;
        }
        public Dictionary<string, bool> GetDefaultCategories()
        {
            Dictionary<string, bool> categories = new Dictionary<string, bool> { { "IsHard", false }, { "IsOutdoor", false },
                { "IsSport", false }, { "IsWork", false }, { "IsRelax", false }, { "IsEducation", false } };
            return categories;
        }
        public void SetAllCategoriesToFalse(CalendarEvent calendarEvent)
        {
            calendarEvent.IsHard = false;
            calendarEvent.IsOutdoor = false;
            calendarEvent.IsSport = false;
            calendarEvent.IsWork = false;
            calendarEvent.IsRelax = false;
            calendarEvent.IsEducation = false;
        }
        public void SetEventCategories(List<string> checkedCategories,CalendarEvent calendarEvent)
        {
            Dictionary<string, bool> categories = GetDefaultCategories();
            SetAllCategoriesToFalse(calendarEvent);
            foreach (string checkedCategory in checkedCategories)
            {
                categories[checkedCategory] = true;
            }
            calendarEvent.IsHard = categories["IsHard"];
            calendarEvent.IsOutdoor = categories["IsOutdoor"];
            calendarEvent.IsSport = categories["IsSport"];
            calendarEvent.IsWork = categories["IsWork"];
            calendarEvent.IsRelax = categories["IsRelax"];
            calendarEvent.IsEducation = categories["IsEducation"];
        }
        public bool ValidateMinute(string minuteStr)
        {
            return !int.TryParse(minuteStr, out int minute) || minute < 0 || minute >= 60;
        }
        public bool ValidateHour(string hourStr)
        {
            return !int.TryParse(hourStr, out int hour) || hour < 0 || hour >= 24;
        }
        public bool ValidateDay(string dayStr)
        {
            return!int.TryParse(dayStr, out int day) || day < 1;
        }
        public bool ValidateDurationDays(string daysStr)
        {
            return !int.TryParse(daysStr, out int day) || day < 0;
        }
        public bool ValidateMonth(string monthStr)
        {
            return !int.TryParse(monthStr, out int month) || month < 1 || month > 12;
        }
        public bool ValidateYear(string yearStr)
        {
            return !int.TryParse(yearStr, out int year) || year < 2000 || year > 2100;
        }
        public bool TryCalculateDaysInMonth(string monthStr, string yearStr,out int daysInMonth)
        {
            if (!int.TryParse(monthStr, out int month) || !int.TryParse(yearStr, out int year))
            {
                daysInMonth = default;
                return false;
            }
            daysInMonth=DateTime.DaysInMonth(year, month);
            return true;
        }
        public bool TryGetDate(string minuteStr,string hourStr,string dayStr,string monthStr,string yearStr,out DateTime newDate, string secondsStr = "0")
        {
            try
            {
                int seconds = int.Parse(secondsStr);
                int minute = int.Parse(minuteStr);
                int hour = int.Parse(hourStr);
                int day = int.Parse(dayStr);
                int month = int.Parse(monthStr);
                int year = int.Parse(yearStr);

                newDate = new DateTime(year, month, day, hour, minute, seconds);
                return true;
            }
            catch (Exception ex)
            {
                newDate = default;
                return false;
            }
        }
        public bool TryGetDuration(string minutesStr, string hoursStr, string daysStr, out TimeSpan duration,string secondsStr="0")
        {
            
            try
            {
                int seconds = int.Parse(secondsStr);
                int durationMinutes = int.Parse(minutesStr);
                int durationHours = int.Parse(hoursStr);
                int durationDays = int.Parse(daysStr);
                duration = new TimeSpan(durationDays, durationHours, durationMinutes, seconds);
                return true;
            }
            catch (Exception ex)
            {
                duration = default;
                return false;
            }
        }

        public async Task AddCalendarEvent(CalendarEvent calendarEvent)
        {
            if (_isSaving) { return; } 
            _isSaving = true;
            try
            {
                calendarEvent.CalendarId = _databaseService.CurrentCalendarID;
            calendarEvent.StartTime=calendarEvent.StartTime.ToUniversalTime();
            
            await _databaseService.AddAsync(calendarEvent);

             NavigationService.NavigateTo<DayPresenter,DateTime>(calendarEvent.StartTime);
            }
            finally
            {
                _isSaving = false; 
                
            }
        }

    }
}
