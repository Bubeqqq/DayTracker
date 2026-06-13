using DayTracker.Database.Datatypes;
using DayTracker.Forms.MainForm;

namespace DayTracker
{
    public partial class Form1 : Form, IMainFormView
    {
        private bool isBarEnlarged = false;

        public Form1()
        {
            InitializeComponent();

            userBar.BackButtonClicked += () => OnGoBack?.Invoke();
            userBar.ForwardButtonClicked += () => OnGoForward?.Invoke();

            userBar.MouseEnterUserBar += () => OnMouseEnterUserBar?.Invoke();
            userBar.MouseLeaveUserBar += () => OnMouseLeaveUserBar?.Invoke();
            userBar.SettingButtonClicked += () =>
            {
                if (isBarEnlarged)
                {
                    ShrinkBar();
                }
                else
                {
                    EnlargeBar();
                    OnSettingsOpened?.Invoke();
                }
            };

            userBar.OnClearListRequested += () => OnClearListRequested?.Invoke();
            userBar.OnCalendarResetRequested += () => OnCalendarResetRequested?.Invoke();
            userBar.OnBarVisibilityChanged += (visible) => OnBarVisibilityChanged?.Invoke(visible);
            userBar.OnExitRequested += () => OnExitRequested?.Invoke();
            userBar.OnLogoutRequested += () => OnLogoutRequested?.Invoke();
            userBar.OnPermissionChanged += (email, role, old) => OnPermissionChanged?.Invoke(email, role, old);
            userBar.OnUserAdded += (email, role) => OnUserAdded?.Invoke(email, role);
            userBar.OnUserRemoved += (email) => OnUserRemoved?.Invoke(email);
        }

        public event Action OnGoBack;
        public event Action OnGoForward;
        public event Action OnMouseEnterUserBar;
        public event Action OnMouseLeaveUserBar;
        //Settings
        public event Action OnLogoutRequested;
        public event Action OnExitRequested;
        public event Action OnClearListRequested;
        public event Action OnCalendarResetRequested;
        public event Action<bool> OnBarVisibilityChanged;
        public event Action<string, string, string> OnPermissionChanged;
        public event Action<string, string> OnUserAdded;
        public event Action<string> OnUserRemoved;
        public event Action OnSettingsOpened;

        public void SetBackButtonEnable(bool enable)
        {
            userBar.SetBackButtonEnable(enable);
        }

        public void SetControl(UserControl form)
        {
            if (mainPanel.Controls.Count > 1)
            {
                mainPanel.Controls.RemoveAt(1);
            }

            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
        }

        public void SetForwardButtonEnable(bool enable)
        {
            userBar.SetForwardButtonEnable(enable);
        }

        public void HideBar(bool absolute)
        {
            mainPanel.SuspendLayout();

            if (absolute)
                userBar.Enabled = false;

            mainPanel.RowStyles.Clear();
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, absolute ? 0F : 10F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            mainPanel.ResumeLayout(true);
        }

        public void ShowBar()
        {
            mainPanel.SuspendLayout();

            userBar.Enabled = true;

            mainPanel.RowStyles.Clear();
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            mainPanel.ResumeLayout(true);
        }

        private void EnlargeBar()
        {
            mainPanel.SuspendLayout();

            isBarEnlarged = true;

            mainPanel.RowStyles.Clear();
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            userBar.ShowUserSettingsMenu();

            mainPanel.ResumeLayout(true);
        }

        private void ShrinkBar()
        {
            mainPanel.SuspendLayout();

            isBarEnlarged = false;

            mainPanel.RowStyles.Clear();
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            userBar.HideUserSettingsMenu();

            mainPanel.ResumeLayout(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ExitApp()
        {
            Application.Exit();
        }

        void IMainFormView.LoadPermissions(List<SimplePermission> permissions)
        {
            userBar.PopulateSettingsData(permissions);
        }
    }
}
