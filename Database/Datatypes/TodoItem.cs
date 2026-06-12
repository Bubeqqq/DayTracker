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
        
        public string Description { get; set; }
        private TodoItem() { } 

        public TodoItem(string description)
        {
        
            Description = description;
        }
        public override string ToString()
        {
            return Description;
        }
    }
}
