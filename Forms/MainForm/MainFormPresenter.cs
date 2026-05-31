// Plik: MainFormPresenter.cs
using DayTracker.Database;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.Day;
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
        }

        public IModel Model => _model;
        public IView View => _view;

        public void Initialize()
        {
            _navigationService.NavigateTo<TaskPresenter, TestTask>(new TestTask(0, "chuj", new DateTime(), "paweł sołtysik", new TimeSpan()));
        }
    }
}