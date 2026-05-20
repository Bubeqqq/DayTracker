using DayTracker.Forms.MainForm;

namespace DayTracker
{
    public partial class Form1 : Form, IMainFormView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SetControl(UserControl form)
        {
            mainPanel.Controls.Clear();

            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
