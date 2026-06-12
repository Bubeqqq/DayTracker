using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class CalendarEvent : ICalendarRecord
    {
        public int? Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int CalendarId { get; set; }

        public int? TodoId { get; set; }
        public TodoItem? Todo { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public bool IsHard { get; set; } // Task should be completed in this time, otherwise it is failed
        public bool IsOutdoor { get; set; }
        public bool IsSport { get; set; }
        public bool IsWork { get; set; }
        public bool IsRelax { get; set; }
        public bool IsEducation { get; set; }
        //To musi być konstruktor prywatny, aby Entity Framework mógł tworzyć instancje klasy CalendarEvent podczas odczytu danych z bazy danych.
        private CalendarEvent() { }
        public CalendarEvent(string title, string description, int calendarId, DateTime startTime, TimeSpan duration, int? todoId = null, TodoItem? todo = null,
            bool isHard=false, bool isOutdoor = false, bool isSport = false, bool isWork = false, bool isRelax = false, bool isEducation = false, int? id=null)
        {
            
            Title = title;
            Description = description;
            CalendarId = calendarId;            
            StartTime = startTime;
            Duration = duration;
            IsHard = isHard;
            IsOutdoor = isOutdoor;
            IsSport = isSport;
            IsWork = isWork;
            IsRelax = isRelax;
            IsEducation = isEducation;
            TodoId = todoId;
            Todo = todo;
            Id = id;
        }
    }
}
