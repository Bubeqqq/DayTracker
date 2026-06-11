using DayTracker.Common;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal interface ISelectCalendarModel : IModel
    {
        OperationResult<string> GetUserFirstName();
        OperationResult<List<(int CalendarId, string DisplayName)>> GetUserSharedCalendars();
        Task<OperationResult> SetCurrentCalendarToUserCalendar();
        void SetCurrentCalendar(int calendarId);
    }
}
