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

        private readonly ILoadedDataService _loadedDataService;
        public CalendarModel(INavigationService navigationService, ILoadedDataService loadedDataService)
        {
            _loadedDataService = loadedDataService;       
            NavigationService = navigationService;
            
        }
        public int CalculateOffset(DateTime date)
        {
            if(date == null)
            {
                throw new ArgumentNullException("Date can't be null");
            }
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
            return _loadedDataService.GetCalendarEvents();
        }
        public List<string> GetStringTaskList(DateTime date, List<CalendarEvent> events) 
        {
            
                   
           
            List<CalendarEvent> dailyEvents = events
                        .Where(e => e.StartTime.Date == date.ToUniversalTime().Date)
                        .ToList();
            return dailyEvents.ConvertAll(t => $"- {t.Title}");
            
        }
    }
}
