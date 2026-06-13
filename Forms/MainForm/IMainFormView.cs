using DayTracker.Database.Datatypes;
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

        void ExitApp();

        //settings

        public event Action OnLogoutRequested;
        public event Action OnExitRequested;

        public event Action OnClearListRequested;
        public event Action OnCalendarResetRequested;

        public event Action<bool> OnBarVisibilityChanged;

        public event Action<string, string, string> OnPermissionChanged;
        public event Action<string, string> OnUserAdded;
        public event Action<string> OnUserRemoved;


        event Action OnSettingsOpened;
        void LoadPermissions(List<SimplePermission> permissions);

    }
}
