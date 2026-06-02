using DayTracker.Forms.Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DayTracker.Forms.Calendar
{
    public partial class DayCellUserControl : UserControl
    {
        public DateTime Date { get; set; }
        public event EventHandler<DayClickedEventArgs> DayCellClicked;
        public DayCellUserControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

        }
        public void Setup(DateTime date,List<string> tasks)
        {
            this.Date = date;
            labelDayNumber.Text = date.Day.ToString();
            listBoxTasks.DataSource = tasks;
        }
        private void DayCell_Click(object sender, EventArgs e)
        {
            DayCellClicked?.Invoke(this, new DayClickedEventArgs(Date));
        }
    }
}
