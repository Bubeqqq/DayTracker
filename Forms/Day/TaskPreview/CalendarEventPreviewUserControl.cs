using DayTracker.Database.Datatypes;
using DayTracker.Forms.Day.TaskPreview;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.Forms.Day
{
    public partial class CalendarEventPreviewUserControl : UserControl//TODO dodać funkcję pokazującą labelDidntStartToday i ustawiającą odpowiedni tekst
    {
        public CalendarEvent CalendarEvent { get; }
        public string LabelDidntStartToday { get { return labelDidntStartToday.Text; } set { labelDidntStartToday.Text = value; } }
        public Size MaxLabelSize { get { return labelDescription.MaximumSize; } set { labelDescription.MaximumSize = value; } }
        public event EventHandler<CalendarEventClickedEventArgs> CalendarEventClicked;
        public event EventHandler<CalendarEventClickedEventArgs> DeleteClicked;
        public CalendarEventPreviewUserControl(CalendarEvent calendarEvent)
        {
            InitializeComponent();
            CalendarEvent = calendarEvent;
            labelTitle.Text = CalendarEvent.Title;
            labelDescription.Text = CalendarEvent.Description;

        }
        public void UpdateLocation(int x, int y, int taskWidth, int height)
        {
            this.Location = new Point(x, y);
            this.Width = taskWidth;
            this.Height= height;
        }
        public void LabelDidntStartTodayVisible(bool visible)
        {
            labelDidntStartToday.Visible = visible;
        }
        private void CalendarEvent_Click(object sender, EventArgs e)
        {
            CalendarEventClicked?.Invoke(this,new CalendarEventClickedEventArgs(CalendarEvent));
        }                                    // Prawdopodobnie będzie trzeba utworzyc zdarzenie i przy tworzeniu tej kontrolki podpiac je w Day Presenter

        private void TaskUserControl_BackColorChanged(object sender, EventArgs e)
        {
            labelDelete.BackColor = this.BackColor;
        }


        private void labelDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, new CalendarEventClickedEventArgs(CalendarEvent));
        }
    }
}
