using CompactAppSettings;
using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.UserControls.UserBar
{
    public partial class UserBarControl : UserControl
    {
        public event Action BackButtonClicked;
        public event Action ForwardButtonClicked;

        public event Action MouseEnterUserBar;
        public event Action MouseLeaveUserBar;

        public event Action SettingButtonClicked;



        //settings

        public event Action OnAnalasisRequest;

        public event Action OnLogoutRequested;
        public event Action OnExitRequested;

        public event Action OnClearListRequested;
        public event Action OnCalendarResetRequested;

        public event Action<bool> OnBarVisibilityChanged;

        public event Action<string, string, string> OnPermissionChanged;
        public event Action<string, string> OnUserAdded;
        public event Action<string> OnUserRemoved;

        public UserBarControl()
        {
            InitializeComponent();
        }

        public void ShowUserSettingsMenu()
        {
            OptionsControl optionsControl = new OptionsControl();

            optionsControl.OnLogoutRequested += () => OnLogoutRequested?.Invoke();
            optionsControl.OnExitRequested += () => OnExitRequested?.Invoke();
            optionsControl.OnClearListRequested += () => OnClearListRequested?.Invoke();
            optionsControl.OnCalendarResetRequested += () => OnCalendarResetRequested?.Invoke();
            optionsControl.OnBarVisibilityChanged += (visible) => OnBarVisibilityChanged?.Invoke(visible);
            optionsControl.OnPermissionChanged += (email, role, old) => OnPermissionChanged?.Invoke(email, role, old);
            optionsControl.OnUserAdded += (email, role) => OnUserAdded?.Invoke(email, role);
            optionsControl.OnUserRemoved += (email) => OnUserRemoved?.Invoke(email);

            optionsControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.Controls.Add(optionsControl);
        }

        public void PopulateSettingsData(List<SimplePermission> simplePermissions, string code, bool isAdmin)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is OptionsControl c)
                {
                    if (!isAdmin)
                        c.HidePermissions();

                    c.SetInvitationCode(code);
                    c.ClearRows();
                    foreach (var perm in simplePermissions)
                        c.AddRow(perm.Email, perm.Permission);

                    return;
                }
            }
        }

        public void HideUserSettingsMenu()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is OptionsControl)
                {
                    tableLayoutPanel.Controls.Remove(control);
                    control.Dispose();
                    break;
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            ForwardButtonClicked?.Invoke();
        }

        public void SetForwardButtonEnable(bool enable)
        {
            forwardButton.Enabled = enable;
        }

        public void SetBackButtonEnable(bool enable)
        {
            backButton.Enabled = enable;
        }

        private void UserBarControl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterUserBar?.Invoke();
        }

        private void UserBarControl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveUserBar?.Invoke();
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingButtonClicked?.Invoke();
        }

        private void AnalasisButton_Click(object sender, EventArgs e)
        {
            OnAnalasisRequest?.Invoke();
        }
    }
}
