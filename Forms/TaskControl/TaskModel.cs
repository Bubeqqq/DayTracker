using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.Forms.Day;
using DayTracker.LoadedData;
using DayTracker.Navigation;

namespace DayTracker.Forms.TaskControl
{
    internal class TaskModel : ITaskModel
    {
        public INavigationService NavigationService { get; set; }
        public ILoadedDataService LoadedDataService { get; }
        private readonly IDatabaseService _databaseService;
        
        public TaskModel(INavigationService navigationService, ILoadedDataService loadedDataService, IDatabaseService databaseService)
        {
            LoadedDataService = loadedDataService;
            NavigationService = navigationService;
            _databaseService = databaseService;
            
        }
        public int GetCalendarId()
        {
            return _databaseService.CurrentCalendarID;
        }
        public Dictionary<string, bool> GetDefaultCategories()
        {
            Dictionary<string, bool> categories = new Dictionary<string, bool> { { "IsHard", false }, { "IsOutdoor", false },
                { "IsSport", false }, { "IsWork", false }, { "IsRelax", false }, { "IsEducation", false }, { "IsRepetetive", false } };
            return categories;
        }
        public Dictionary<string, bool> SetCategoriesFromEvent(CalendarEvent calendarEvent)
        {           
            Dictionary<string, bool> categories = GetDefaultCategories();
            categories["IsHard"] = calendarEvent.IsHard;
            categories["IsOutdoor"] = calendarEvent.IsOutdoor;
            categories["IsSport"] = calendarEvent.IsSport;
            categories["IsWork"] = calendarEvent.IsWork;
            categories["IsRelax"] = calendarEvent.IsRelax;
            categories["IsEducation"] = calendarEvent.IsEducation;
            categories["IsRepetetive"] = calendarEvent.IsRepetetive;
            return categories;
        }
        public void SetAllCategoriesToFalse(CalendarEvent calendarEvent)
        {
            calendarEvent.IsHard = false;
            calendarEvent.IsOutdoor = false;
            calendarEvent.IsSport = false;
            calendarEvent.IsWork = false;
            calendarEvent.IsRelax = false;
            calendarEvent.IsEducation = false;
            calendarEvent.IsRepetetive = false;
        }
        public void SetEventCategories(List<string> checkedCategories, CalendarEvent calendarEvent)
        {
            Dictionary<string, bool> categories = GetDefaultCategories();
            SetAllCategoriesToFalse(calendarEvent);
            foreach (string checkedCategory in checkedCategories)
            {
                categories[checkedCategory] = true;
            }
            calendarEvent.IsHard = categories["IsHard"];
            calendarEvent.IsOutdoor = categories["IsOutdoor"];
            calendarEvent.IsSport = categories["IsSport"];
            calendarEvent.IsWork = categories["IsWork"];
            calendarEvent.IsRelax = categories["IsRelax"];
            calendarEvent.IsEducation = categories["IsEducation"];
            calendarEvent.IsRepetetive =categories["IsRepetetive"];
        }
        public bool ValidateMinute(string minuteStr)
        {
            return !int.TryParse(minuteStr, out int minute) || minute < 0 || minute >= 60;
        }
        public bool ValidateHour(string hourStr)
        {
            return !int.TryParse(hourStr, out int hour) || hour < 0 || hour >= 24;
        }
        public bool ValidateDay(string dayStr)
        {
            return !int.TryParse(dayStr, out int day) || day < 1;
        }
        public bool ValidateDurationDays(string daysStr)
        {
            return !int.TryParse(daysStr, out int day) || day < 0;
        }
        public bool ValidateMonth(string monthStr)
        {
            return !int.TryParse(monthStr, out int month) || month < 1 || month > 12;
        }
        public bool ValidateYear(string yearStr)
        {
            return !int.TryParse(yearStr, out int year) || year < 2000 || year > 2100;
        }
        public bool TryCalculateDaysInMonth(string monthStr, string yearStr, out int daysInMonth)
        {
            if (!int.TryParse(monthStr, out int month) || !int.TryParse(yearStr, out int year))
            {
                daysInMonth = default;
                return false;
            }
            daysInMonth = DateTime.DaysInMonth(year, month);
            return true;
        }
        public bool TryGetDate(string minuteStr, string hourStr, string dayStr, string monthStr, string yearStr, out DateTime newDate, string secondsStr = "0")
        {
            try
            {
                int seconds = int.Parse(secondsStr);
                int minute = int.Parse(minuteStr);
                int hour = int.Parse(hourStr);
                int day = int.Parse(dayStr);
                int month = int.Parse(monthStr);
                int year = int.Parse(yearStr);

                newDate = new DateTime(year, month, day, hour, minute, seconds);
                return true;
            }
            catch (Exception ex)
            {
                newDate = default;
                return false;
            }
        }
        public bool TryGetDuration(string minutesStr, string hoursStr, string daysStr, out TimeSpan duration, string secondsStr = "0")
        {

            try
            {
                int seconds = int.Parse(secondsStr);
                int durationMinutes = int.Parse(minutesStr);
                int durationHours = int.Parse(hoursStr);
                int durationDays = int.Parse(daysStr);
                duration = new TimeSpan(durationDays, durationHours, durationMinutes, seconds);
                return true;
            }
            catch (Exception ex)
            {
                duration = default;
                return false;
            }
        }

        public async Task AddCalendarEvent(CalendarEvent calendarEvent)
        {

            
            calendarEvent.Id = -1;
            calendarEvent.CalendarId = _databaseService.CurrentCalendarID;
            if (calendarEvent.StartTime.Kind != DateTimeKind.Utc)
            {
                throw new Exception("StartTime must be in UTC");
            }
            //MessageBox.Show("Adding Event: " + calendarEvent.Title);
            await _databaseService.AddAsync(calendarEvent);
        }
        public async Task<TodoItem> AddToDoItem(TodoItem todoItem)
        {

            //MessageBox.Show("Adding ToDoItem: " + todoItem.Description);
            return await _databaseService.AddAsync(todoItem);



        }
        public async Task ModifyCalendarEvent(CalendarEvent calendarEvent)
        {
            calendarEvent.CalendarId = _databaseService.CurrentCalendarID;
            DateTime comeBackDate = calendarEvent.GetLocalStartTime();
            //MessageBox.Show("Modyfying Event: " + calendarEvent.Title);
            if(calendarEvent.StartTime.Kind != DateTimeKind.Utc)
            {
                throw new Exception("StartTime must be in UTC");
            }
            await _databaseService.UpdateByType<CalendarEvent>(calendarEvent.Id, (e) =>
            {
                e.Title = calendarEvent.Title;
                e.Description = calendarEvent.Description;
                e.CalendarId = calendarEvent.CalendarId;

                e.TodoId = calendarEvent.TodoId;

                e.StartTime = calendarEvent.StartTime;
                e.Duration = calendarEvent.Duration;

                e.IsHard = calendarEvent.IsHard;
                e.IsOutdoor = calendarEvent.IsOutdoor;
                e.IsSport = calendarEvent.IsSport;
                e.IsWork = calendarEvent.IsWork;
                e.IsRelax = calendarEvent.IsRelax;
                e.IsEducation = calendarEvent.IsEducation;
                e.IsRepetetive = calendarEvent.IsRepetetive;

            });

            NavigationService.NavigateTo<DayPresenter, DateTime>(comeBackDate.Date);

        }
        public async Task<TodoItem> ModifyToDoItem(TodoItem todoItem)
        {
            //MessageBox.Show("Modify ToDoItem: " + todoItem.Description);
            return await _databaseService.UpdateByType<TodoItem>(todoItem.Id, (e) =>
            {
                e.Description = todoItem.Description;
            });
        }
        public async Task DeleteToDoItem(int todoItemID)
        {
            //MessageBox.Show("Deleting ToDoItem: " + todoItem.Description);
            await _databaseService.RemoveByType<TodoItem>(todoItemID);
        }
        public bool GetModifyPermission()
        {
            PermissionType currentPermission = LoadedDataService.GetCurrentPermisions();
            if (currentPermission == PermissionType.ReadOnly)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task ProcessSavedChanges(CalendarEvent calendarEvent,bool isEditMode,string toDoDescription,CalendarEvent originalEvent)
        {
            
            if (isEditMode)
            {
                calendarEvent.CalendarId = _databaseService.CurrentCalendarID;
                calendarEvent.Id = originalEvent.Id;
                calendarEvent.TodoId = originalEvent.TodoId;
                if (!string.IsNullOrEmpty(toDoDescription))
                {
                    if (calendarEvent.TodoId != null)
                    {
                        TodoItem toDoItem = new TodoItem(toDoDescription, _databaseService.CurrentCalendarID);
                        toDoItem.Id = (int)calendarEvent.TodoId;
                        

                        toDoItem = await ModifyToDoItem(toDoItem);
                        calendarEvent.TodoId = toDoItem.Id;

                    }
                    else
                    {
                        TodoItem toDoItem = new TodoItem(toDoDescription, _databaseService.CurrentCalendarID);
                        toDoItem = await AddToDoItem(toDoItem);
                        //MessageBox.Show("presenter ToDoItem: " + toDoItem.Description);
                        calendarEvent.TodoId = toDoItem.Id;

                    }

                }
                else
                {
                    
                    if (calendarEvent.TodoId != null)
                    {
                        MessageBox.Show("Deleting ToDoItem: ");

                        calendarEvent.CalendarId = _databaseService.CurrentCalendarID;
                       
                        //MessageBox.Show("Modyfying Event: " + calendarEvent.Title);
                        if (calendarEvent.StartTime.Kind != DateTimeKind.Utc)
                        {
                            throw new Exception("StartTime must be in UTC");
                        }
                        int toDoId = (int)calendarEvent.TodoId;
                        MessageBox.Show("Uptading calendar event with id: "+ calendarEvent.Id);
                        await _databaseService.UpdateByType<CalendarEvent>(calendarEvent.Id, (e) =>
                        {
                            

                            e.TodoId = null;
                            e.Todo = null;


                        });
                        calendarEvent.TodoId = null;
                        await DeleteToDoItem(toDoId);


                    }
                }
                calendarEvent.Id = originalEvent.Id;

                await ModifyCalendarEvent(calendarEvent);
                DateTime comeBackDate = calendarEvent.GetLocalStartTime();
                NavigationService.NavigateTo<DayPresenter, DateTime>(comeBackDate.Date);
            }
            else
            {
                if (!string.IsNullOrEmpty(toDoDescription))
                {
                    TodoItem toDoItem = new TodoItem(toDoDescription, _databaseService.CurrentCalendarID);
                    //MessageBox.Show("presenter2 ToDoItem: " + toDoItem.Description);
                    toDoItem = await AddToDoItem(toDoItem);
                    //MessageBox.Show("presenter2 ToDoItem: " + toDoItem.Description);
                    calendarEvent.TodoId = toDoItem.Id;
                }
                await AddCalendarEvent(calendarEvent);
                DateTime comeBackDate = calendarEvent.GetLocalStartTime();
                NavigationService.NavigateTo<DayPresenter, DateTime>(comeBackDate.Date);
            }
        }
       
            
    }
}
