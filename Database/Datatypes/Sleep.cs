using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    internal class Sleep : ICalendarRecord
    {
        public int Id { get; set; }

        public int CalendarId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime GetLocalStartTime()
        {
            return StartTime.ToLocalTime();
        }
        public DateTime GetLocalEndTime()
        {
            return EndTime.ToLocalTime();
        }
    }
}
