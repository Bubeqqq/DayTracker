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

        public OperationResult<List<(int, string)>> GetUserSharedCalendars()
        {
            // work in progress
            if (_loadedDataService.GetCurrentUser() is User currentUser)
            {
                var sharedCalendarIds = _loadedDataService.GetPermissions()
                    .Where(p => p.UserId == currentUser.Id && p.CalendarId != currentUser.CalendarId)
                    .Select(p => p.CalendarId).ToList();

                if (sharedCalendarIds.Count == 0)
                    return OperationResult<List<(int, string)>>.Failure("No shared calendars found");

                //var sharedCalendars = _loadedDataService.GetPermissions()
                //    .Where(p => sharedCalendarIds.Contains(p.CalendarId) && p.PermissionName == PermissionType.Admin)
                //    .
            }

            return OperationResult<List<(int, string)>>.Failure("Current user is not set correctly!");
        }
    }
}