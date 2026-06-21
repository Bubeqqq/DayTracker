using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class SimplePermission
    {
        public string Email { get; set; }
        public string Permission { get; set; }
        private SimplePermission() { }
        public SimplePermission(string email, string permission)
        {
            Email = email;
            Permission = permission;
        }
    }
}
