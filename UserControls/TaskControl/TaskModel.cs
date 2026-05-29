using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.TaskControl
{
    internal class TaskModel:ITaskModel
    {
        public INavigationService NavigationService { get; set; }
        public TaskModel() { }
        public bool ValidateMinute(string minuteStr)
        {
            return (!int.TryParse(minuteStr, out int minute) || minute < 0 || minute >= 60);
        }
        public bool ValidateHour(string hourStr)
        {
            return (!int.TryParse(hourStr, out int hour) || hour < 0 || hour >= 24);
        }
        public bool ValidateDay(string dayStr)
        {
            return(!int.TryParse(dayStr, out int day) || day < 1);
        }
        public bool ValidateDurationDays(string daysStr)
        {
            return (!int.TryParse(daysStr, out int day) || day < 0);
        }
        public bool ValidateMonth(string monthStr)
        {
            return (!int.TryParse(monthStr, out int month) || month < 1 || month > 12);
        }
        public bool ValidateYear(string yearStr)
        {
            return (!int.TryParse(yearStr, out int year) || year < 2000 || year > 2100);
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



    }
}
