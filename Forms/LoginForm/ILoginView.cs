using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.LoginForm
{
    internal interface ILoginView
    {
        string Email { get; }
        string Password { get; }
        bool IsPasswordHidden { get; set; }

        event Action BtnLoginClicked;
        event Action BtnRegisterClicked;
    }
}
