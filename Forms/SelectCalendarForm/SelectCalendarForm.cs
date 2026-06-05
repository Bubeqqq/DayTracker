namespace DayTracker.Forms.SelectCalendarForm
{
    public partial class SelectCalendarForm : UserControl, ISelectCalendarView
    {
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
    }
}
