using DayTracker.Navigation;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal class TestPresenter : IPresenter<int>
    {
        private readonly ITestView _view;
        private readonly ITestModel _model;
        public TestPresenter(ITestView view, ITestModel model, INavigationService navigationService)
        {
            _view = view;
            _model = model;

            navigationService.ShowOnMouseEnterUserBar(true);

            _view.OnTestButtonClicked += () =>
                {
                    //_model.Login(_view.email, _view.password);
                    navigationService.HideBar();
                };

            _view.OnTestButton2Clicked += () =>
                {
                    //_model.Register(_view.email, _view.password, _view.name, _view.surname);
                    navigationService.ShowBar();
                };
        }

        public IModel Model => _model;
        public IView View => _view;

        public void LoadArgs(int args)
        {
            Console.WriteLine(args);
        }
    }
}
