using DayTracker.Navigation;

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

            _view.ClearAllValidationErrors();
            var errors = new Dictionary<string, string>();

            // TODO: Dodaj bardziej zaawansowaną walidację (np. regex dla emaila, sprawdzanie siły hasła itp.)

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
            if (string.IsNullOrEmpty(password))
            {
                errors[nameof(_view.Password)] = "Password is required.";
            }
            else
            {
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    errors[nameof(_view.ConfirmPassword)] = "Please confirm your password.";
                }
                else
                {
                    if (password != confirmPassword)
                    {
                        errors[nameof(_view.Password)] = "Passwords do not match.";
                        errors[nameof(_view.ConfirmPassword)] = "Passwords do not match.";
                    }
                }
            }
            
            if (errors.Count > 0)
            {
                _view.ShowValidationErrors(errors);
                return;
            }

            var result = await _model.Register(firstName, lastName, email, password);

            if (result.IsSuccess)
            {
                _navigationService.NavigateTo<SelectCalendarForm.SelectCalendarPresenter>();
            }
            else
            {
                // TODO: Wyświetl błąd rejestracji w message boxie
                MessageBox.Show(result.ErrorMsg); // placeholder
                return;
            }
        }

        private async void OnBtnLoginClicked()
        {
            _navigationService.NavigateTo<LoginForm.LoginPresenter>();
        }
    }
}
