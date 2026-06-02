using DayTracker.Forms.MainForm;

namespace DayTracker
{
    public partial class Form1 : Form, IMainFormView
    {
        public Form1()
        {
            InitializeComponent();

            userBar.BackButtonClicked += () => OnGoBack?.Invoke();
            userBar.ForwardButtonClicked += () => OnGoForward?.Invoke();

            userBar.MouseEnterUserBar += () => OnMouseEnterUserBar?.Invoke();
            userBar.MouseLeaveUserBar += () => OnMouseLeaveUserBar?.Invoke();
        }

        public event Action OnGoBack;
        public event Action OnGoForward;
        public event Action OnMouseEnterUserBar;
        public event Action OnMouseLeaveUserBar;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
