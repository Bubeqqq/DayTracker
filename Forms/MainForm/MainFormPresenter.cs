// Plik: MainFormPresenter.cs
using DayTracker.Database;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.Day;
using DayTracker.Forms.Habits;
using DayTracker.Forms.LoginForm;
using DayTracker.Forms.TaskControl;
using DayTracker.Forms.TestForm;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Windows.Forms;

namespace DayTracker.Forms.MainForm
{
    internal class MainFormPresenter : IPresenter
    {
        private readonly IMainFormView _view;
        private readonly IMainFormModel _model;
        private readonly INavigationService _navigationService;

        public MainFormPresenter(IMainFormView view, IMainFormModel model, INavigationService navigationService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

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
        }

        public IModel Model => _model;
        public IView View => _view;

        public void Initialize()
        {
            _navigationService.NavigateTo<LoginPresenter>();
        }
    }
}