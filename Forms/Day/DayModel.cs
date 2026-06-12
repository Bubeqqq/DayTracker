using DayTracker.Database;
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
    internal class DayModel : IDayModel
    {
        private readonly ILoadedDataService _loadedDataService;
        private readonly IDatabaseService _databaseService;

        public INavigationService NavigationService { get; set; }
        private Color blue1;
        private Color blue2;
        private Color blue3;
        private Color blue4;

        private Color green1;
        private Color green2;
        private Color green3;
        private Color green4;
        public DayModel(INavigationService navigationService, ILoadedDataService loadedDataService, IDatabaseService databaseService)
        {
            _loadedDataService = loadedDataService;
            NavigationService = navigationService;
            _databaseService = databaseService;

            blue1 = Color.FromArgb(41, 128, 185);
            blue2 = Color.FromArgb(52, 152, 219);
            blue3 = Color.FromArgb(93, 173, 226);
            blue4 = Color.FromArgb(133, 193, 233);

            green1 = Color.FromArgb(39, 174, 96);
            green2 = Color.FromArgb(46, 204, 113);
            green3 = Color.FromArgb(88, 214, 141);
            green4 = Color.FromArgb(130, 224, 170);
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
        public int CalculateY(DateTime startTime, int pixelPerHour, DateTime date)
        {

            if (date.Date > startTime)
            {
                return 0;
            }

            return Convert.ToInt32(startTime.Hour * pixelPerHour + startTime.Minute * pixelPerHour / 60.0);

        }
        public int CalculateHeight(DateTime startTime, TimeSpan duration, int pixelPerHour, DateTime date)
        {
            if (date.Date.ToUniversalTime() > startTime)
            {
                TimeSpan newDuration = duration - (date.Date - startTime);
                return Convert.ToInt32(newDuration.TotalMinutes * pixelPerHour / 60.0);
            }
            else
            if (startTime.Add(duration) > date.Date.AddDays(1))
            {
                TimeSpan newDuration = date.Date.AddDays(1) - startTime;
                return Convert.ToInt32(newDuration.TotalMinutes * pixelPerHour / 60.0);
            }
            return Convert.ToInt32(duration.TotalMinutes * pixelPerHour / 60.0);
        }
        public int CalculateX(int leftMargin, int columnIndex, int taskWidth)
        {
            return leftMargin + columnIndex * taskWidth;
        }
        public CalendarEvent CreateDefualutCalendarEvent(DateTime date)
        {
            CalendarEvent calendarEvent = new CalendarEvent("Title", "Description", _databaseService.CurrentCalendarID, date.Date, new TimeSpan(1, 1, 1, 0));

            return calendarEvent;
        }
        public Color GetEventColor(CalendarEvent calendarEvent)
        {
            if (calendarEvent.IsHard)
            {
                if (IsFun(calendarEvent)&&(calendarEvent.IsWork|| calendarEvent.IsEducation))
                {
                    return blue3;
                }
                else if (IsFun(calendarEvent))
                {
                    return blue4;
                }
                else if (calendarEvent.IsWork || calendarEvent.IsEducation)
                {
                    return blue1;
                }
                else 
                {
                    return blue2;
                }
            }
            else
            {
                if (IsFun(calendarEvent) && (calendarEvent.IsWork || calendarEvent.IsEducation))
                {
                    return green3;
                }
                else if (IsFun(calendarEvent))
                {
                    return green4;
                }
                else if (calendarEvent.IsWork || calendarEvent.IsEducation)
                {
                    return green1;
                }
                else
                {
                    return green2;
                }
            }
        }
        private bool IsFun(CalendarEvent calendarEvent)
        {
            if (calendarEvent.IsOutdoor || calendarEvent.IsSport || calendarEvent.IsRelax)
            {
                return true;
            }
            return false;
        }
        
    }
}
