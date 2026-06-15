using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.Common;
using DayTracker.LoadedData;
using System.Windows.Navigation;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal class SelectCalendarModel : ISelectCalendarModel
    {
        private readonly ILoadedDataService _loadedDataService;
        private readonly IDatabaseService _databaseService;
        private readonly PermissionType _defaultPermissionType;

        public SelectCalendarModel(IDatabaseService databaseService, ILoadedDataService loadedDataService   )
        {
            _databaseService = databaseService;
            _loadedDataService = loadedDataService;
            _defaultPermissionType = PermissionType.ReadOnly;
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

        public async Task<OperationResult<List<(int CalendarId, string DisplayName)>>> GetUserSharedCalendars()
        {
            if (_loadedDataService.GetCurrentUser() is User currentUser)
            {
                if (await _databaseService.GetType<Permission>(p => p.UserId == currentUser.Id && p.CalendarId != currentUser.CalendarId) is List<Permission> permissions)
                {
                    var sharedCalendarIds = permissions.Select(p => p.CalendarId).ToList();

                    if (await _databaseService.GetUsersAsync(u => sharedCalendarIds.Contains(u.CalendarId)) is List<User> permissionsOwners)
                    {
                        var availableCalendars = permissionsOwners.Select(u => (CalendarId: u.CalendarId, DisplayName: $"{u.FirstName} {u.LastName}'s Calendar")).ToList();
                        return OperationResult<List<(int CalendarId, string DisplayName)>>.Success(availableCalendars);
                    }
                    return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Error while fetching users from database.");
                }
                return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Error while fetching permissions from database.");
            }
            return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Current user is not set correctly!");
        }
        public async Task<OperationResult<int?>> GetCalendarIdByInvitationCode(string invitationCode)
        {
            if (await _databaseService.GetUsersAsync(u => u.invitationCode == invitationCode) is List<User> result)
            {
                if (result.Count == 0)
                    return OperationResult<int?>.Success(null);

                return OperationResult<int?>.Success(result[0].CalendarId);
            }
            return OperationResult<int?>.Failure("Error while fetching users from database.");
        }
        public async Task<OperationResult> AddCalendarAccess(int calendarId)
        {
            if (_loadedDataService.GetCurrentUser() is User currentUser)
            {
                var userPermissions = await _databaseService.GetType<Permission>(p => p.UserId == currentUser.Id && p.CalendarId == calendarId);
                if (userPermissions.Any())
                {
                    return OperationResult.Failure($"You permissions for calendar are already set. Currently your permission type is: {userPermissions[0].PermissionName}");
                }

                await _databaseService.AddAsync<Permission>(new Permission { UserId = currentUser.Id, CalendarId = calendarId, PermissionName = _defaultPermissionType });
                return OperationResult.Success();
            }
            return OperationResult.Failure("Current user is not set correctly!");
        }
    }
}