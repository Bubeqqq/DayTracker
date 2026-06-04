using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    internal class Permission : ICalendarRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int CalendarId { get; set; }

        public PermissionType PermissionName { get; set; }
    }

    enum PermissionType
    {
        Blocked,
        ReadOnly,
        Edit,
        Admin
    }
}
