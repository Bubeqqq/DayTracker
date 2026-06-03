using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class TodoItem : ICalendarRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TodoItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
