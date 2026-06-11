using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.LoginServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.LoadedData
{
    internal class LoadedDataService : ILoadedDataService
    {
        private readonly ILoginService _loginService;
        private readonly IDatabaseService _databaseService;

        private List<CalendarEvent> _calendarEvents;
        private List<Permission> _permissions;
        private List<Sleep> _sleeps;
        private List<TodoItem> _todoItems;
        private List<User> _users;

        public LoadedDataService(ILoginService loginService, IDatabaseService databaseService)
        {
            _loginService = loginService;
            _databaseService = databaseService;

            _databaseService.OnEntityChanged += async (e, o) => await UpdateDatabase(e, o);
        }

        public event Action OnCalendarEventsChanged;
        public event Action OnTodoItemsChanged;
        public event Action OnSleepsChanged;
        public event Action OnPermissionsChanged;
        public event Action OnUsersChanged;

        private async Task UpdateDatabase(string entityName, EntityState entityState)
        {
            switch (entityName)
            {
                case nameof(CalendarEvent):
                    _calendarEvents = await _databaseService.GetType<CalendarEvent>();
                    Console.WriteLine(_calendarEvents.Count);
                    OnCalendarEventsChanged?.Invoke();
                    break;
                case nameof(TodoItem):
                    _todoItems = await _databaseService.GetType<TodoItem>();
                    OnTodoItemsChanged?.Invoke();
                    break;
                case nameof(Sleep):
                    _sleeps = await _databaseService.GetType<Sleep>();
                    OnSleepsChanged?.Invoke();
                    break;
                case nameof(Permission):
                    _permissions = await _databaseService.GetType<Permission>();
                    OnPermissionsChanged?.Invoke();
                    break;
                case nameof(User):
                    _users = await _databaseService.GetUsersAsync(u => true);
                    OnUsersChanged?.Invoke();
                    break;
            }
        }

        public async Task Initialize()
        {
            _calendarEvents = await _databaseService.GetType<CalendarEvent>();
            _permissions = await _databaseService.GetType<Permission>();
            _sleeps = await _databaseService.GetType<Sleep>();
            _todoItems = await _databaseService.GetType<TodoItem>();
            _users = await _databaseService.GetUsersAsync(u => true);
        }

        public List<CalendarEvent> GetCalendarEvents()
        {
            return _calendarEvents;
        }

        public PermissionType GetCurrentPermisions()
        {
            if(GetCurrentUser() == null) return PermissionType.Blocked;

            Permission? permission = _permissions.FirstOrDefault(p => p.UserId == GetCurrentUser()?.Id);
            return permission == null ? PermissionType.Blocked : permission.PermissionName;
        }

        public User? GetCurrentUser()
        {
            return _loginService.GetUser();
        }

        public List<Permission> GetPermissions()
        {
            return _permissions;
        }

        public List<Sleep> GetSleeps()
        {
            return _sleeps;
        }

        public List<TodoItem> GetTodoItems()
        {
            return _todoItems;
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public async Task LoadCalendar(int CalendarID)
        {
            _databaseService.CurrentCalendarID = CalendarID;
            await Initialize();
        }
    }
}
