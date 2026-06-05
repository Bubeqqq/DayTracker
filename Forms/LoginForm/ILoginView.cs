using DayTracker.Navigation;

namespace DayTracker.Forms.LoginForm
{
    internal interface ILoginView : IView
    {
        string Email { get; }
        string Password { get; }
        bool IsPasswordHidden { get; set; }

        event Action LoginRequested;
        event Action BtnRegisterClicked;

        event Action? BtnShowPassMouseDown;
        event Action? BtnShowPassMouseUp;
        event Action? BtnShowPassMouseLeave;

        void ShowValidationErrors(Dictionary<string, string> errors);
        void ClearAllValidationErrors();
    }
}
