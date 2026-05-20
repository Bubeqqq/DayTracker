using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DayTracker.Forms.MainForm
{
    internal class MainFormModel : IMainFormModel, ISceneLoader
    {
        private readonly IServiceProvider _serviceProvider;

        public MainFormModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public event Action<UserControl> OnSceneChanged;

        public void LoadScene<TPresenter>() where TPresenter : IPresenter
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            var view = presenter.View as UserControl;

            if (view == null)
                return;

            var model = presenter.Model;
            model.SceneLoader = this;

            OnSceneChanged?.Invoke(view);
        }
    }
}
