using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayTracker.Database.Datatypes
{
    public class CalendarEvent : ICalendarRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("Calendar")]
        public int CalendarId { get; set; }
        public Calendar? Calendar { get; set; }

        [ForeignKey("Todo")]
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
        public bool IsRepetitive { get; set; } // Indicates if the event is repetitive
        //To musi być konstruktor prywatny, aby Entity Framework mógł tworzyć instancje klasy CalendarEvent podczas odczytu danych z bazy danych.
        private CalendarEvent() { }
        public CalendarEvent(string title, string description, int calendarId, DateTime startTime, TimeSpan duration, int? todoId = null,
            bool isHard=true, bool isOutdoor = false, bool isSport = false, bool isWork = false, bool isRelax = false, bool isEducation = false ,bool isRepetitive = false, int id=-1)
        {
            if(!IsFieldsValid())
            {
                throw new InvalidOperationException("Repetitive events must be hard events.");
            }
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
            IsRepetitive=isRepetitive;
            TodoId = todoId;
            Id = id;
        }
        private bool IsFieldsValid()
        {
            if (IsRepetitive && !IsHard)
            {
                return false;
            }
            return true;
        }
        public DateTime GetLocalStartTime()
        {
            return StartTime.ToLocalTime();
        }
    }
}
