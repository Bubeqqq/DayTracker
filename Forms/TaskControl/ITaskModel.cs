using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.LoadedData;
using DayTracker.Navigation;

namespace DayTracker.Forms.TaskControl
{
    internal interface ITaskModel : IModel
    {
        INavigationService NavigationService { get; set; }
        ILoadedDataService LoadedDataService { get; }
        
        int GetCalendarId();
        Dictionary<string, bool> GetDefaultCategories();
        bool ValidateMinute(string minuteStr);

        bool GetModifyPermission();
        bool ValidateHour(string hourStr);

        bool ValidateDay(string dayStr);
        bool ValidateDurationDays(string daysStr);
        bool ValidateMonth(string monthStr);
        bool ValidateYear(string yearStr);
        bool TryCalculateDaysInMonth(string monthStr, string yearStr, out int daysInMonth);
        public bool TryGetDate(string minuteStr, string hourStr, string dayStr, string monthStr, string yearStr, out DateTime newDate, string secondsStr = "0");
        bool TryGetDuration(string minutesStr, string hoursStr, string daysStr, out TimeSpan duration, string secondsStr = "0");
        void SetEventCategories(List<string> checkedCategories, CalendarEvent calendarEvent);
        void SetAllCategoriesToFalse(CalendarEvent calendarEvent);
        Dictionary<string, bool> SetCategoriesFromEvent(CalendarEvent calendarEvent);
        Task AddCalendarEvent(CalendarEvent calendarEvent);
        Task ModifyCalendarEvent(CalendarEvent calendarEvent);
        Task<TodoItem> ModifyToDoItem(TodoItem todoItem);
        Task DeleteToDoItem(TodoItem todoItem);
        Task<TodoItem> AddToDoItem(TodoItem todoItem);
        Task ProcessSavedChanges(CalendarEvent calendarEvent, bool isEditMode, string toDoDescription, CalendarEvent originalEvent);


    }
}
