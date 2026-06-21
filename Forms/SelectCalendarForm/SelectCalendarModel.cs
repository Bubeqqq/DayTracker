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

        private async Task<OperationResult<List<Permission>>> GetUserPermissions(int calendarId)
        {
            if (_loadedDataService.GetCurrentUser() is not User user)
                return OperationResult<List<Permission>>.Failure("Current user is not set correctly!");

            if (await _databaseService.GetType<Permission>(p => p.UserId == user.Id && p.CalendarId == calendarId) is not List<Permission> permissions)
                return OperationResult<List<Permission>>.Failure("Error while fetching permissions from database.");

            return OperationResult<List<Permission>>.Success(permissions);
        }
        public async Task<OperationResult> SetCurrentCalendar(int calendarId)
        {
            var permissionsResult = await GetUserPermissions(calendarId);

            if (!permissionsResult.IsSuccess)
                return OperationResult.Failure(permissionsResult.ErrorMsg!);

            if (permissionsResult.Data!.Any(p => p.PermissionName == PermissionType.Blocked) || permissionsResult.Data!.Count == 0)
                return OperationResult.Failure("You don't have access to this calendar.");

            await _loadedDataService.LoadCalendar(calendarId);
            return OperationResult.Success();
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
            if (_loadedDataService.GetCurrentUser() is not User currentUser)
                return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Current user is not set correctly!");

            if (await _databaseService.GetType<Permission>(p => p.UserId == currentUser.Id && p.CalendarId != currentUser.CalendarId) is not List<Permission> permissions)
                return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Error while fetching permissions from database.");

            if (permissions.Count == 0)
                return OperationResult<List<(int CalendarId, string DisplayName)>>.Success(new List<(int CalendarId, string DisplayName)>());

            var sharedCalendarIds = permissions.Select(p => p.CalendarId).ToList();

            if (await _databaseService.GetUsersAsync(u => sharedCalendarIds.Contains(u.CalendarId)) is not List<User> permissionsOwners)
                return OperationResult<List<(int CalendarId, string DisplayName)>>.Failure("Error while fetching users from database.");

            var availableCalendars = permissionsOwners.Join(
                permissions, 
                u => u.CalendarId,
                p => p.CalendarId, 
                (u, p) => (CalendarId: u.CalendarId, DisplayName: $"{u.FirstName} {u.LastName}'s Calendar" + (p.PermissionName == PermissionType.Blocked ? " [BLOCKED]" : ""))
            ).ToList();

            return OperationResult<List<(int CalendarId, string DisplayName)>>.Success(availableCalendars);
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
                var userPermissionsResult = await GetUserPermissions(calendarId);
                if (!userPermissionsResult.IsSuccess)
                    return OperationResult.Failure(userPermissionsResult.ErrorMsg!);

                var userPermissions = userPermissionsResult.Data!;
                if (userPermissions.Any())
                    return OperationResult.Failure($"You permissions for calendar are already set.");
                
                await _databaseService.AddAsync<Permission>(new Permission(currentUser.Id, calendarId, _defaultPermissionType));
                return OperationResult.Success();
            }
            return OperationResult.Failure("Current user is not set correctly!");
        }
    }
}