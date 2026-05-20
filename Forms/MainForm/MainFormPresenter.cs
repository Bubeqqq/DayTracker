using DayTracker.Forms.TestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.MainForm
{
    internal class MainFormPresenter : IPresenter
    {
        private readonly IMainFormView _view;
        private readonly IMainFormModel _model;
        public MainFormPresenter(IMainFormView view, IMainFormModel model)
        {
            _view = view;
            _model = model;

            _model.OnSceneChanged += scene =>
            {
                _view.SetControl(scene);
            };
        }

        public Form View => (Form)_view;

        public void Initialize() //Load first form
        {
            var sceneLoader = _model as ISceneLoader;
            if (sceneLoader != null)
            {
                sceneLoader.LoadScene<TestPresenter>();
            }
        }


        //To fix
        public IModel Model => throw new NotImplementedException();
        IView IPresenter.View => throw new NotImplementedException();
    }
}
