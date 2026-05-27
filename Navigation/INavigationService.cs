using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Navigation
{
    internal interface INavigationService
    {
        event Action<IView> OnSceneChanged;
        void NavigateTo<TPresenter>() where TPresenter : class, IPresenter;
        void NavigateTo<TPresenter, TArgs>(TArgs args) where TPresenter : class, IPresenter<TArgs>;

        IView LoadUserControl<TPresenter>() where TPresenter : class, IPresenter;

        IView LoadUserControl<TPresenter, TArgs>(TArgs args) where TPresenter : class, IPresenter<TArgs>;
    }
}
