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
using WinFormsApp1.Calendar;

namespace WinFormsApp1
{
    public partial class CalendarUserControl : UserControl, ICalendarView
    {
        public DateTime SelectedDate { get { return dateTimePicker1.Value; } }
        public event EventHandler<DayClickedEventArgs> DayClicked;
        public event EventHandler SelectedDateChanged;
        public event EventHandler NextButtonClicked;
        public event EventHandler PreviousButtonClicked;
        public CalendarUserControl()
        {
            InitializeComponent();
        }
        public void CreateAndAddDayCell(DateTime date, List<string> tasks, int column, int row)
        {
            DayCellUserControl dayCell = new DayCellUserControl();

            dayCell.Setup(date, tasks);// tylko to robic w view

            dayCell.Dock = DockStyle.Fill;
            dayCell.DayCellClicked += DayCellClicked;
            tableLayoutPanelCalendar.Controls.Add(dayCell, column, row);

        }
        public void AddMonthToDate(int monthsToAdd)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(monthsToAdd);
        }
        public void SuspendAndClearCalendar()
        {
            tableLayoutPanelCalendar.SuspendLayout();
            tableLayoutPanelCalendar.Controls.Clear();
        }
        public void ResumeCalendarLayout()
        {
            tableLayoutPanelCalendar.ResumeLayout();
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
    }


}
