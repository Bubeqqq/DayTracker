// Plik: MainFormModel.cs
using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.Forms.LoginForm;
using DayTracker.LoadedData;
using DayTracker.LoginServices;
using DayTracker.Navigation;

namespace DayTracker.Forms.MainForm
{
    internal class MainFormModel : IMainFormModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;
        private readonly ILoadedDataService _loadedDataService;

        public MainFormModel(IDatabaseService databaseService, INavigationService navigationService, ILoginService loginService, ILoadedDataService loadedDataService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _loadedDataService = loadedDataService ?? throw new ArgumentNullException(nameof(loadedDataService));
        }

        public event Action OnAppExitRequest;

        public async Task AddUser(string email, string role)
        {
            List<User> users = _loadedDataService.GetUsers().Where(user => user.email == email).ToList();

            if (users.Count != 1)
            {
                return;
            }

            Permission permission = new Permission();
            permission.UserId = users[0].Id;
            permission.CalendarId = _databaseService.CurrentCalendarID;
            
            switch(role)
            {
                case "Admin":
                    permission.PermissionName = PermissionType.Admin;
                    break;
                case "Edit":
                    permission.PermissionName = PermissionType.Edit;
                    break;
                case "Read Only":
                    permission.PermissionName = PermissionType.ReadOnly;
                    break;
                case "Blocked":
                    permission.PermissionName = PermissionType.Blocked;
                    break;
                default:
                    throw new ArgumentException("Invalid role.");
            }

            await _databaseService.AddAsync(permission);
        }

        public void ChangeBarVisibility(bool visible)
        {
            //_navigationService.ShowOnMouseEnterUserBar(visible);
        }

        public async Task ChangePermission(string email, string role, string old)
        {
            List<User> newUsers = _loadedDataService.GetUsers().Where(user => user.email == email).ToList();
            List<User> oldUsers = _loadedDataService.GetUsers().Where(user => user.email == old).ToList();


            if (newUsers.Count != 1)
            {
                if(oldUsers.Count != 1)
                {
                    return;
                }
                else
                {
                    Permission? p = _loadedDataService.GetPermissions().Where(permission => permission.UserId == oldUsers[0].Id).ToList()[0];
                    if (p == null)
                    {
                        return;
                    }
                    await _databaseService.RemoveByType<Permission>(p.Id);
                    return;
                }
            }

            if (email == old)
            {
                Permission? p = _loadedDataService.GetPermissions().Where(permission => permission.UserId == newUsers[0].Id).ToList()[0];

                if(p == null)
                {
                    return;
                }

                await _databaseService.UpdateByType<Permission>(p.Id, (p) =>
                {
                    switch (role)
                    {
                        case "Admin":
                            p.PermissionName = PermissionType.Admin;
                            break;
                        case "Edit":
                            p.PermissionName = PermissionType.Edit;
                            break;
                        case "Read Only":
                            p.PermissionName = PermissionType.ReadOnly;
                            break;
                        case "Blocked":
                            p.PermissionName = PermissionType.Blocked;
                            break;
                        default:
                            throw new ArgumentException("Invalid role.");
                    }
                });

                return;
            }

            if(oldUsers.Count != 1)
            {
                await AddUser(email, role);
            }
            else
            {
                Permission? p = _loadedDataService.GetPermissions().Where(permission => permission.UserId == oldUsers[0].Id).ToList()[0];

                if (p == null)
                {
                    return;
                }

                await _databaseService.UpdateByType<Permission>(p.Id, (p) => p.UserId = newUsers[0].Id);
            }
        }

        public async Task ClearList()
        {
            List<int> ints = [];

            foreach (Permission p in _loadedDataService.GetPermissions())
            {
                if (p.PermissionName == PermissionType.Admin)
                    continue;

                ints.Add(p.Id);
            }

            foreach(int i in ints)
                await _databaseService.RemoveByType<Permission>(i);
        }

        public void Exit()
        {
            OnAppExitRequest?.Invoke();
        }

        public List<SimplePermission> GetPermissionsList()
        {
            var permissions = _loadedDataService.GetPermissions();
            var users = _loadedDataService.GetUsers();
            var result = new List<SimplePermission>();

            foreach (var p in permissions)
            {
                var user = users.FirstOrDefault(u => u.Id == p.UserId);
                if (user != null)
                {
                    string roleName = p.PermissionName switch
                    {
                        PermissionType.Admin => "Admin",
                        PermissionType.Edit => "Edit",
                        PermissionType.ReadOnly => "Read Only",
                        PermissionType.Blocked => "Blocked",
                        _ => "Blocked"
                    };

                    result.Add(new SimplePermission
                    {
                        Email = user.email,
                        Permission = roleName
                    });
                }
            }

            return result;
        }

        public void Logout()
        {
            _loginService.Logout();
            _loadedDataService.LoadCalendar(-1);
            _navigationService.NavigateTo<LoginPresenter>();
        }

        public async Task RemoveUser(string email)
        {
            List<User> users = _loadedDataService.GetUsers().Where(user => user.email == email).ToList();

            if (users.Count != 1)
            {
                return;
            }

            Permission? p = _loadedDataService.GetPermissions().Where(permission => permission.UserId == users[0].Id).ToList()[0];
            if (p == null)
            {
                return;
            }

            await _databaseService.RemoveByType<Permission>(p.Id);

        }

        public async Task ResetCalendar()
        {
            throw new NotImplementedException();
        }
    }
}