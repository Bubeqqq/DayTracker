// Plik: MainFormPresenter.cs
using DayTracker.Database;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.Day;
using DayTracker.Forms.Habits;
using DayTracker.Forms.LoginForm;
using DayTracker.Forms.TaskControl;
using DayTracker.Forms.TestForm;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using System;
using System.Windows.Forms;

namespace DayTracker.Forms.MainForm
{
    internal class MainFormPresenter : IPresenter
    {
        private readonly IMainFormView _view;
        private readonly IMainFormModel _model;
        private readonly INavigationService _navigationService;
        private readonly ILoadedDataService _loadedDataService;

        public MainFormPresenter(IMainFormView view, IMainFormModel model, INavigationService navigationService, ILoadedDataService loadedDataService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _loadedDataService = loadedDataService ?? throw new ArgumentNullException(nameof(loadedDataService));

            _navigationService.OnSceneChanged += scene =>
            {
                _view.SetControl(scene as UserControl);
            };

            _view.OnGoBack += () => _navigationService.GoBack();
            _view.OnGoForward += () => _navigationService.GoForward();

            _navigationService.OnGoForwardButtonEnableChange += (e) => _view.SetForwardButtonEnable(e);
            _navigationService.OnGoBackButtonEnableChange += (e) => _view.SetBackButtonEnable(e);

            _navigationService.OnBarShow += () => _view.ShowBar();
            _navigationService.OnBarHide += (absolute) => _view.HideBar(absolute);

            _view.OnMouseEnterUserBar += () => _navigationService.MouseEnterUserBar();
            _view.OnMouseLeaveUserBar += () => _navigationService.MouseLeaveUserBar();

            _model.OnAppExitRequest += () => _view.ExitApp();

            _view.OnAnalasisRequest += () => _navigationService.NavigateTo<HabitsPresenter>();
        
            //settings

            _view.OnLogoutRequested += () => _model.Logout();
            _view.OnExitRequested += () => _model.Exit();
            _view.OnClearListRequested += async () => await _model.ClearList();
            _view.OnCalendarResetRequested += async () => await _model.ResetCalendar();
            _view.OnBarVisibilityChanged += (visible) => _model.ChangeBarVisibility(visible);
            _view.OnPermissionChanged += async (email, role, old) => await _model.ChangePermission(email, role, old);
            _view.OnUserAdded += async (email, role) => await _model.AddUser(email, role);
            _view.OnUserRemoved += async (email) => await _model.RemoveUser(email);

            _loadedDataService.OnPermissionsChanged += async () => 
            {
                var permissions = await _model.GetPermissionsList();
                string code = _model.GetInvitationCode();
                bool isAdmin = _model.IsCurrentUserAdmin();
                _view.LoadPermissions(permissions, code, isAdmin);
            };

            _view.OnSettingsOpened += async () =>
            {
                var permissions = await _model.GetPermissionsList();
                string code = _model.GetInvitationCode();
                bool isAdmin = _model.IsCurrentUserAdmin();
                _view.LoadPermissions(permissions, code, isAdmin);
            };
        }

        public IModel Model => _model;
        public IView View => _view;

        public void Initialize()
        {
            _navigationService.NavigateTo<LoginPresenter>();
        }
    }
}