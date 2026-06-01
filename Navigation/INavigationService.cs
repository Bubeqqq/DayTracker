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
        //form main panel

        event Action<IView> OnSceneChanged;

        event Action<bool> OnGoBackButtonEnableChange;
        event Action<bool> OnGoForwardButtonEnableChange;

        event Action OnBarShow;
        event Action<bool> OnBarHide;

        void MouseEnterUserBar();
        void MouseLeaveUserBar();

        //usable

        void NavigateTo<TPresenter>() where TPresenter : class, IPresenter;
        void NavigateTo<TPresenter, TArgs>(TArgs args) where TPresenter : class, IPresenter<TArgs>;

        void GoBack();

        void GoForward();

        void UpdateCurrentArgs<TArgs>(TArgs args);

        void ShowBar();
        void HideBar();

        void ShowOnMouseEnterUserBar(bool enabled);

        IView LoadUserControl<TPresenter>() where TPresenter : class, IPresenter;

        IView LoadUserControl<TPresenter, TArgs>(TArgs args) where TPresenter : class, IPresenter<TArgs>;
    
        
    }
}
