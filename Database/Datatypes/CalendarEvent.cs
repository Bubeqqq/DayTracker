using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class CalendarEvent : ICalendarRecord
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CalendarId { get; set; }

        public int? TodoId { get; set; }
        public TodoItem? Todo { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public string Description { get; set; }

        public bool IsHard { get; set; } // Task should be completed in this time, otherwise it is failed
        public bool IsOutdoor { get; set; }
        public bool IsSport { get; set; }
        public bool IsWork { get; set; }
        public bool IsRelax { get; set; }
        public bool IsEducation { get; set; }

    }
}
