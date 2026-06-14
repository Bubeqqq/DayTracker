using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class TodoItem : ICalendarRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
