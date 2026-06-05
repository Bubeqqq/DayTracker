using DayTracker.Navigation;

namespace DayTracker.Forms.LoginForm
{
    internal class LoginPresenter: IPresenter
    {
        private readonly ILoginView _view;
        private readonly ILoginModel _model;
        private readonly INavigationService _navigationService;

        public IModel Model => _model;
        public IView View => _view;

        public LoginPresenter(ILoginView view, ILoginModel model, INavigationService navigationService)
        {
            _view = view;
            _model = model;
            _navigationService = navigationService;
            _navigationService.HideBar();

            _view.LoginRequested += OnLoginRequested;
            _view.BtnRegisterClicked += OnBtnRegisterClicked;

            _view.BtnShowPassMouseDown += () => _view.IsPasswordHidden = false;
            _view.BtnShowPassMouseUp += () => _view.IsPasswordHidden = true;
            _view.BtnShowPassMouseLeave += () => _view.IsPasswordHidden = true;
        }

        private void OnBtnRegisterClicked()
        {
            _navigationService.NavigateTo<RegisterForm.RegisterPresenter>();
        }

        private async void OnLoginRequested()
        {
            string email = _view.Email.Trim();
            string password = _view.Password;

            _view.ClearAllValidationErrors();
            var errors = new Dictionary<string, string>();

            // TODO: Dodaj bardziej zaawansowaną walidację (np. regex dla emaila, sprawdzanie siły hasła itp.)

            if (string.IsNullOrEmpty(email))
            {
                errors[nameof(_view.Email)] = "Email is required.";
            }
            if (string.IsNullOrEmpty(password))
            {
                errors[nameof(_view.Password)] = "Password is required.";
            }

            if (errors.Count > 0)
            {
                _view.ShowValidationErrors(errors);
                return;
            }

            var result = await _model.Login(email, password);
            
            if (result.IsSuccess)
            {
                _navigationService.NavigateTo<DayTracker.Forms.SelectCalendarForm.SelectCalendarPresenter>();
            }
            else
            {
                // TODO: Wyświetl błąd logowania w message boxie
                MessageBox.Show(result.ErrorMsg); // placeholder
                return;
            }
        }

        public void LoadArgs(int args) {}
    }
}
