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
        }

        public event Action OnGoBack;
        public event Action OnGoForward;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
