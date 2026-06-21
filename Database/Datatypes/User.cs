using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database.Datatypes
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Calendar")]
        public int CalendarId { get; set; }
        public Calendar? Calendar { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public string invitationCode {  get; set; } = string.Empty;
        private User() { }
        public User( string firstName = "", string lastName = "", string email= "", string password= "", string invitationCode= "")
        {
            FirstName = firstName;
            LastName = lastName;
            this.email = email;
            this.password = password;
            this.invitationCode = invitationCode;
        }
    }
}
