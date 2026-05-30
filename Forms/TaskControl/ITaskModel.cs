using DayTracker.Forms;

namespace DayTracker.Forms.TaskControl
{
    internal interface ITaskModel : IModel
    {
        bool ValidateMinute(string minuteStr);


        bool ValidateHour(string hourStr);

        bool ValidateDay(string dayStr);
        bool ValidateDurationDays(string daysStr);
        bool ValidateMonth(string monthStr);
        bool ValidateYear(string yearStr);
        bool TryCalculateDaysInMonth(string monthStr, string yearStr, out int daysInMonth);
        public bool TryGetDate(string minuteStr, string hourStr, string dayStr, string monthStr, string yearStr, out DateTime newDate, string secondsStr = "0");
        bool TryGetDuration(string minutesStr, string hoursStr, string daysStr, out TimeSpan duration, string secondsStr = "0");
    }
}
