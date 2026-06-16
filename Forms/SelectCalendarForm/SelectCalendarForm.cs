using System.Windows.Controls.Primitives;

namespace DayTracker.Forms.SelectCalendarForm
{
    public partial class SelectCalendarForm : UserControl, ISelectCalendarView
    {
        public string InviteCode => textBoxInviteCode.Text;

        public event Action BtnYourCalendarClicked;
        public event Action<int?> BtnSubmitSelectedCalendarClicked;
        public event Action<string> BtnSubmitCodeClicked;
        public event Action FormLoading;

        public string Greeting
        {
            set => labelGreeting.Text = value;
        }

        public SelectCalendarForm()
        {
            InitializeComponent();

            btnYourCalendar.Click += (s, e) => BtnYourCalendarClicked?.Invoke();
            btnSubmitSelectedCalendar.Click += (s, e) => BtnSubmitSelectedCalendarClicked?.Invoke((int?)comboBoxSelectCalendar.SelectedValue);
            btnSubmitCode.Click += (s, e) => BtnSubmitCodeClicked?.Invoke(textBoxInviteCode.Text);
            this.Load += (s, e) => FormLoading?.Invoke();
        }

        public void LoadSharedCalendars(List<KeyValuePair<int, string>> calendars)
        {
            comboBoxSelectCalendar.DisplayMember = "Value";
            comboBoxSelectCalendar.ValueMember = "Key";
            comboBoxSelectCalendar.DataSource = calendars;
        }
        public void ShowValidationErrors(Dictionary<string, string> errors)
        {
            foreach (var e in errors)
            {
                switch (e.Key)
                {
                    case nameof(InviteCode):
                        errorProvider.SetError(textBoxInviteCode, e.Value); break;
                }
            }
        }
        public void ClearAllValidationErrors()
        {
            errorProvider.SetError(textBoxInviteCode, string.Empty);
        }

        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
