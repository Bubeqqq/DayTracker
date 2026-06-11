using DayTracker.Forms;
using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTracker.Database.Datatypes;

namespace DayTracker.Forms.Calendar
{
    internal interface ICalendarModel:IModel
    {
        INavigationService NavigationService { get; set; }
        int CalculateOffset(DateTime date);
        List<string> GetStringTaskList(DateTime date, List<CalendarEvent> events);
            List<CalendarEvent> GetCalendarEvents();
    }
}
