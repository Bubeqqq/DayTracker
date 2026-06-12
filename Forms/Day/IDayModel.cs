using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DayTracker.Forms.Day
{
    internal interface IDayModel:IModel
    {
        INavigationService NavigationService { get; set; }
        List<List<CalendarEvent>> CalculateColumns(List<CalendarEvent> tasks);
        List<CalendarEvent> GetEventsForDay(DateTime date);
        Task DeleteCalendarEvent(CalendarEvent calendarEvent);
        int CalculateY(DateTime startTime, int pixelPerHour,DateTime date);
        int CalculateHeight(DateTime startTime, TimeSpan duration, int pixelPerHour, DateTime date);
        int CalculateX(int leftMargin, int columnIndex, int taskWidth);
        CalendarEvent CreateDefualutCalendarEvent(DateTime date);
        Color GetEventColor(CalendarEvent calendarEvent);
    }
}
