using DayTracker.LoadedData;
using DayTracker.Database.Datatypes;
using DayTracker.Common;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal class SelectCalendarModel : ISelectCalendarModel
    {
        private readonly ILoadedDataService _loadedDataService;

        public SelectCalendarModel(ILoadedDataService loadedDataService)
        {
            _loadedDataService = loadedDataService;
        }

        public OperationResult<string> GetUserFirstName()
        {
            if (_loadedDataService.GetCurrentUser() is User user)
            {
                return OperationResult<string>.Success(user.FirstName);
            }

            return OperationResult<string>.Failure("Current user is not set correctly!");
        }

        public void SetCurrentCalendar(int calendarId)
        {
            _loadedDataService.LoadCalendar(calendarId);
        }

        public async Task<OperationResult> SetCurrentCalendarToUserCalendar()
        {
            if (_loadedDataService.GetCurrentUser() is User user)
            {
                await _loadedDataService.LoadCalendar(user.CalendarId);
                return OperationResult.Success();   
            }

            return OperationResult.Failure("Current user is not set correctly!");
        }

        public OperationResult<List<(int CalendarId, string DisplayName)>> GetUserSharedCalendars()
        {
            if (_loadedDataService.GetCurrentUser() is User currentUser)
            {
                var sharedCalendarIds = _loadedDataService.GetPermissions()
                    .Where(p => p.UserId == currentUser.Id && p.CalendarId != currentUser.CalendarId)
                    .Select(p => p.CalendarId).ToList();

                var sharedCalendars = _loadedDataService.GetUsers()
                    .Where(u => sharedCalendarIds.Contains(u.CalendarId))
                    .Select(u => (CalendarId: u.CalendarId, DisplayName: $"{u.FirstName} {u.LastName}'s Calendar"))
                    .ToList();

                return OperationResult<List<(int CalendarId, string DisplayName)>>.Success(sharedCalendars);
            }

            return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Current user is not set correctly!");
        }
    }
}