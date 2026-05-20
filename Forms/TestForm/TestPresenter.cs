using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal class TestPresenter : IPresenter
    {
        private readonly ITestView _view;
        private readonly ITestModel _model;
        public TestPresenter(ITestView view, ITestModel model)
        {
            _view = view;
            _model = model;

            _view.OnTestButtonClicked += () =>
                {
                    _model.Print();
                };
        }

        public IModel Model => _model;
        public IView View => _view;
    }
}
