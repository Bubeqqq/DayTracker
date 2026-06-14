using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    internal class Permission : ICalendarRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
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
