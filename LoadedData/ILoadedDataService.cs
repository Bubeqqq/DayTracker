using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.LoadedData
{
    internal interface ILoadedDataService
    {
        event Action OnCalendarEventsChanged;
        event Action OnTodoItemsChanged;
        event Action OnSleepsChanged;
        event Action OnPermissionsChanged;

        List<CalendarEvent> GetCalendarEvents();
        List<TodoItem> GetTodoItems();
        List<Sleep> GetSleeps();
        List<Permission> GetPermissions();

        User? GetCurrentUser();

        PermissionType GetCurrentPermisions();

        Task Initialize();
    }
}
