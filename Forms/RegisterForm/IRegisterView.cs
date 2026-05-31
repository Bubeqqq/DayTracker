using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.RegisterForm
{
    internal interface IRegisterView : IView
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        bool IsPasswordHidden { get; set; }
        bool IsConfirmPasswordHidden { get; set; }

        event Action BtnRegisterClicked;
        event Action BtnLoginClicked;

        event Action BtnShowPassMouseDown;
        event Action BtnShowPassMouseUp;
        event Action BtnShowPassMouseLeave;

        event Action BtnShowConfirmPassMouseDown;
        event Action BtnShowConfirmPassMouseUp;
        event Action BtnShowConfirmPassMouseLeave;

        void ShowValidationErrors(Dictionary<string, string> errors);
        void ClearAllValidationErrors();
    }
}
