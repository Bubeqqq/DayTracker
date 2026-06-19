using DayTracker.Database.Datatypes;
using DayTracker.Forms.Calendar;
using DayTracker.Forms.TaskControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.Forms.Calendar
{
    public partial class CalendarUserControl : UserControl, ICalendarView
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public DateTime SelectedDate { get { return dateTimePicker1.Value; } set { dateTimePicker1.Value = value; } }
        public event EventHandler<DayClickedEventArgs> DayClicked;
        public event EventHandler SelectedDateChanged;
        public event EventHandler NextButtonClicked;
        public event EventHandler PreviousButtonClicked;
        public event EventHandler AddEventButtonClicked;
        public event Action EditSleepButtonClicked;
        public event Action CalendarLoad;
        public CalendarUserControl()
        {
            InitializeComponent();

            typeof(TableLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(tableLayoutPanelCalendar, true, null);

        }
        public Tuple<DateTime, DateTime> GetUserSleep(string title, DateTime start, DateTime end)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 240,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label labelStart = new Label() { Left = 20, Top = 20, Text = "Sleep start:", Width = 340 };
            DateTimePicker sleepStart = new DateTimePicker()
            {
                Left = 20,
                Top = 45,
                Width = 340,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm dd-MM" 
            };

            // Kontrolki dla Zakończenia
            Label labelEnd = new Label() { Left = 20, Top = 85, Text = "Sleep end:", Width = 340 };
            DateTimePicker sleepEnd = new DateTimePicker()
            {
                Left = 20,
                Top = 110,
                Width = 340,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm dd-MM"
            };
            sleepStart.Value = DateTime.Now.Date.AddDays(-1).AddHours(22);
            
            if (start != DateTime.MinValue && end != DateTime.MinValue)
            {
                sleepStart.Value = start;
                sleepEnd.Value = end;
            }
 
            Button buttonOk = new Button() { Text = "OK", Left = 190, Width = 80, Top = 160, DialogResult = DialogResult.OK };
            Button buttonCancel = new Button() { Text = "Anuluj", Left = 280, Width = 80, Top = 160, DialogResult = DialogResult.Cancel };

         
            prompt.AcceptButton = buttonOk;
            prompt.CancelButton = buttonCancel;

            prompt.Controls.Add(labelStart);
            prompt.Controls.Add(sleepStart);
            prompt.Controls.Add(labelEnd);
            prompt.Controls.Add(sleepEnd);
            prompt.Controls.Add(buttonOk);
            prompt.Controls.Add(buttonCancel);

            if (prompt.ShowDialog() == DialogResult.OK)
            {
        
                return new Tuple<DateTime, DateTime>(sleepStart.Value, sleepEnd.Value);
            }
            else
            {
                return null; 
            }
        }
        public void CreateAndAddDayCell(DateTime date, List<string> tasks, int column, int row)
        {
            DayCellUserControl dayCell = new DayCellUserControl();

            dayCell.Setup(date, tasks);// tylko to robic w view

            dayCell.Dock = DockStyle.Fill;
            dayCell.DayCellClicked += DayCellClicked;
            tableLayoutPanelCalendar.Controls.Add(dayCell, column, row);

        }
        public void ClearCalendarControls()
        {
            tableLayoutPanelCalendar.Controls.Clear();
        }

        public void AddMonthToDate(int monthsToAdd)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(monthsToAdd);
        }
        public bool YesNoMessage(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "Choose an option", MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes ? true : false;
        }
        public void SuspendAndClearCalendar()
        {
            tableLayoutPanelCalendar.SuspendLayout();

            foreach (DayCellUserControl control in tableLayoutPanelCalendar.Controls)
            {
                control.DayCellClicked -= DayCellClicked;
                control.Dispose();
            }

            tableLayoutPanelCalendar.Controls.Clear();
        }
        public void ResumeCalendarLayout()
        {
            tableLayoutPanelCalendar.ResumeLayout(true);

            Refresh();
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void DayCellClicked(object sender, DayClickedEventArgs e)
        {
            DayClicked?.Invoke(this, e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SelectedDateChanged?.Invoke(this, e);
        }

        private void buttonNextMonth_Click(object sender, EventArgs e)
        {
            NextButtonClicked?.Invoke(this, e);
        }

        private void buttonPreviousMonth_Click(object sender, EventArgs e)
        {

            PreviousButtonClicked?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            AddEventButtonClicked?.Invoke(this, e);
        }

        private void buttonEditSleep_Click(object sender, EventArgs e)
        {
            EditSleepButtonClicked?.Invoke();
        }

        private void CalendarUserControl_Load(object sender, EventArgs e)
        {
            CalendarLoad?.Invoke();
        }
    }


}
