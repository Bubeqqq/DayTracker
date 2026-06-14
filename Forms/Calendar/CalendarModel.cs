using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Calendar
{
    internal class CalendarModel:ICalendarModel
    {
        public INavigationService NavigationService { get; set; }

        public ILoadedDataService LoadedDataService { get; }
        public bool CanModify { get; private set; }
        public CalendarModel(INavigationService navigationService, ILoadedDataService loadedDataService)
        {
            
            LoadedDataService = loadedDataService;       
            NavigationService = navigationService;
            CanModify = GetModifyPermission();
            LoadedDataService.OnPermissionsChanged += () =>
            {
                CanModify = GetModifyPermission();
            };


        }
        public int CalculateOffset(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek;
            if (offset == 0)
            {
                offset = 7;
            }
            offset -= 1;
            return offset; 
        }
        public List<CalendarEvent> GetCalendarEvents()
        {
            return LoadedDataService.GetCalendarEvents();
        }
        public List<string> GetStringTaskList(DateTime date, List<CalendarEvent> events) 
        {
  
            List<CalendarEvent> dailyEvents = events
                        .Where(e => e.GetLocalStartTime().Date == date.Date)
                        .ToList();
            return dailyEvents.ConvertAll(t => $"- {t.Title}");
            
        }
        private bool GetModifyPermission()
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
    }
}
