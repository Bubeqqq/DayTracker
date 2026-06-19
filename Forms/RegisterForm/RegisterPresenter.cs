using DayTracker.Navigation;
using System.Text.RegularExpressions;

namespace DayTracker.Forms.RegisterForm
{
    internal class RegisterPresenter : IPresenter
    {
        private readonly IRegisterView _view;
        private readonly IRegisterModel _model;
        private readonly INavigationService _navigationService;

        public IModel Model => _model;
        public IView View => _view;

        public RegisterPresenter(IRegisterView view, IRegisterModel model, INavigationService navigationService)
        {
            _view = view;
            _model = model;
            _navigationService = navigationService;

            _view.RegistrationRequested += OnRegistrationRequested;
            _view.BtnLoginClicked += OnBtnLoginClicked;

            _view.BtnShowPassMouseDown += () => _view.IsPasswordHidden = false;
            _view.BtnShowPassMouseUp += () => _view.IsPasswordHidden = true;
            _view.BtnShowPassMouseLeave += () => _view.IsPasswordHidden = true;

            _view.BtnShowConfirmPassMouseDown += () => _view.IsConfirmPasswordHidden = false;
            _view.BtnShowConfirmPassMouseUp += () => _view.IsConfirmPasswordHidden = true;
            _view.BtnShowConfirmPassMouseLeave += () => _view.IsConfirmPasswordHidden = true;
        }
        private async void OnRegistrationRequested()
        {
            string firstName = _view.FirstName.Trim();
            string lastName = _view.LastName.Trim();
            string email = _view.Email.Trim();
            string password = _view.Password;
            string confirmPassword = _view.ConfirmPassword;

            List<string> passwordErrors = new List<string>();

            _view.ClearAllValidationErrors();
            var errors = new Dictionary<string, string>();



            if (string.IsNullOrEmpty(firstName))
            {
                errors[nameof(_view.FirstName)] = "Name is required.";
            }
            if (string.IsNullOrEmpty(lastName))
            {
                errors[nameof(_view.LastName)] = "Last name is required.";
            }

            if (string.IsNullOrEmpty(email))
            {
                errors[nameof(_view.Email)] = "Email is required.";
            }
            /* -------------------------// to się potem odkomentuje
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errors[nameof(_view.Email)] = "Invalid email format.";
            }
            */

            if (string.IsNullOrEmpty(password))
            {
                passwordErrors.Add("Password is required.");
            }
            else
            {
                /* -------------------------// to się potem odkomentuje
                if (password.Length < 8)
                {
                    passwordErrors.Add("Password must be at least 8 characters long.");
                }
                if (!password.Any(char.IsUpper))
                {
                    passwordErrors.Add("Password must contain at least one uppercase letter.");
                }
                if (!password.Any(char.IsDigit))
                {
                    passwordErrors.Add("Password must contain at least one number.");
                }
                if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    passwordErrors.Add("Password must contain at least one special character.");
                }
                */
            if (string.IsNullOrEmpty(confirmPassword))
                {
                    errors[nameof(_view.ConfirmPassword)] = "Please confirm your password.";
                }
                else
                {
                    if (password != confirmPassword)
                    {
                        passwordErrors.Add("Passwords do not match.");
                        errors[nameof(_view.ConfirmPassword)] = "Passwords do not match.";
                    }
                }
            }
            
            if (passwordErrors.Count != 0)
            {
                errors[nameof(_view.Password)] = string.Join('\n', passwordErrors);
            }

            if (errors.Count > 0)
            {
                _view.ShowValidationErrors(errors);
                return;
            }

            var registrationResult = await _model.Register(firstName, lastName, email, password);

            if (registrationResult.IsSuccess)
            {
                _view.ShowInfo("Registration successful!");
                var loginResult = await _model.Login(email, password);
                if (loginResult.IsSuccess)
                {
                    _navigationService.NavigateTo<SelectCalendarForm.SelectCalendarPresenter>();
                }
                else
                {
                    _view.ShowError(loginResult.ErrorMsg!);
                    return;
                }
            }
            else
            {
                _view.ShowError(registrationResult.ErrorMsg!);
                return;
            }
        }

        private void OnBtnLoginClicked()
        {
            _navigationService.NavigateTo<LoginForm.LoginPresenter>();
        }
    }
}
