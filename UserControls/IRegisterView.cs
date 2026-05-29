using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.UserControls
{
    internal interface IRegisterView
    {
        string Name { get; }
        string LastName { get; }
        string Email { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        bool IsPasswordHidden { get; set; }
        bool IsConfirmPasswordHidden { get; set; }

        event Action BtnRegisterClicked;
        event Action BtnLoginClicked;
    }
}
