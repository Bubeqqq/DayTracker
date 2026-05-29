using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class TestTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

        public TestTask(int id, string title, DateTime date, string description, TimeSpan duration)
        {
            Id = id;
            Title = title;
            Date = date;
            Description = description;
            Duration = duration;
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
