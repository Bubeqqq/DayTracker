using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DayTracker.Forms.Day
{
    internal class DayModel:IDayModel
    {
        private readonly ILoadedDataService _loadedDataService;
        public INavigationService NavigationService { get; set; }
        public DayModel(INavigationService navigationService, ILoadedDataService loadedDataService)
        {
            _loadedDataService = loadedDataService;
            NavigationService = navigationService;
        }
        public List<CalendarEvent> GetEventsForDay(DateTime date)
        {
            date = date.Date;
            List<CalendarEvent> events = _loadedDataService.GetCalendarEvents();
            

            return events.Where(e => e.StartTime < date.AddDays(1) && e.StartTime.Add(e.Duration) > date).ToList();
        }
        public List<List<CalendarEvent>> CalculateColumns(List<CalendarEvent> events)
        {
            var sortedEvents = events.OrderBy(e => e.StartTime).ThenBy(e => e.StartTime.Add(e.Duration)).ToList();


            List<List<CalendarEvent>> columns = new List<List<CalendarEvent>>();

            foreach (var calendarEvent in sortedEvents)
            {
                bool placed = false;

                foreach (var column in columns)
                {
                    if (column.Last().StartTime.Add(column.Last().Duration) <= calendarEvent.StartTime)
                    {
                        column.Add(calendarEvent);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    columns.Add(new List<CalendarEvent> { calendarEvent });
                }
            }
            return columns;
        }
        public int CalculateY(DateTime date,int pixelPerHour)
        {
            if (date == null)
            {
                throw new ArgumentNullException("Date can't be null");
            }
            return Convert.ToInt32(date.Hour * pixelPerHour + date.Minute * pixelPerHour / 60.0);
            
        }
        public int CalculateHeight(TimeSpan duration, int pixelPerHour)
        {
            if (duration == null)
            {
                throw new ArgumentNullException("duration can't be null");
            }
            return Convert.ToInt32(duration.TotalMinutes * pixelPerHour / 60.0);
        }
        public int CalculateX(int leftMargin ,int columnIndex,int taskWidth)
        {
            return leftMargin + columnIndex * taskWidth;
        }
    }
}
