using DayTracker.Database.Datatypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Day.TaskPreview
{
    public class CalendarEventClickedEventArgs
    {
        public CalendarEvent CalendarEvent { get; }
        public CalendarEventClickedEventArgs(CalendarEvent calendarEvent) 
        {
            CalendarEvent = calendarEvent;
        }
    }
}
