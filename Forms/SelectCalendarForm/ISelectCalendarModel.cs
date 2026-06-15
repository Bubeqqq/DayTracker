using DayTracker.Common;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal interface ISelectCalendarModel : IModel
    {
        OperationResult<string> GetUserFirstName();
        Task<OperationResult<List<(int CalendarId, string DisplayName)>>> GetUserSharedCalendars();
        Task<OperationResult> SetCurrentCalendarToUserCalendar();
        Task<OperationResult> SetCurrentCalendar(int calendarId);
        Task<OperationResult<int?>> GetCalendarIdByInvitationCode(string invitationCode);
        Task<OperationResult> AddCalendarAccess(int calendarId);
    }
}
