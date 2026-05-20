// Plik: MainFormPresenter.cs
using DayTracker.Forms.TestForm;
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

        public MainFormPresenter(IMainFormView view, IMainFormModel model, INavigationService navigationService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            _model.NavigationService = _navigationService;

            _navigationService.OnSceneChanged += scene =>
            {
                _view.SetControl(scene);
            };
        }

        public IModel Model => _model;
        public IView View => _view;

        public void Initialize()
        {
            _navigationService.NavigateTo<TestPresenter, int>(5);
        }
    }
}