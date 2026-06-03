using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    internal class Permission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PermissionType PermissionName { get; set; }
    }

    enum PermissionType
    {
        ReadOnly,
        Edit,
        Admin
    }
}
