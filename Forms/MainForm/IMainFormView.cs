using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.MainForm
{
    internal interface IMainFormView : IView
    {
        void SetControl(UserControl form);

        event Action OnGoBack;
        event Action OnGoForward;

        event Action OnMouseEnterUserBar;
        event Action OnMouseLeaveUserBar;

        void SetBackButtonEnable(bool enable);
        void SetForwardButtonEnable(bool enable);

        void ShowBar();
        void HideBar(bool absolute);
    }
}
