using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    internal class Sleep : ICalendarRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        private Sleep() { }
        public Sleep(int userId, DateTime startTime, DateTime endTime,User user)
        {
            UserId = userId;
            StartTime = startTime;
            EndTime = endTime;
            User = user;
        }
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
