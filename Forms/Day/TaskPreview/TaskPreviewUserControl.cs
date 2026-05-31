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
    public partial class TaskPreviewUserControl : UserControl//TODO dodać funkcję pokazującą labelDidntStartToday i ustawiającą odpowiedni tekst
    {
        public TestTask Task { get; }
        public Size MaxLabelSize { get { return labelDescription.MaximumSize; } set { labelDescription.MaximumSize = value; } }
        public event EventHandler<TaskClickedEventArgs> TaskClicked;
        public event EventHandler<TaskClickedEventArgs> DeleteClicked;
        public TaskPreviewUserControl(TestTask task)
        {
            InitializeComponent();
            Task=task;
            labelTitle.Text = task.Title;
            labelDescription.Text = task.Description;

        }
        public void UpdateLocation(int x, int y, int taskWidth, int height)
        {
            this.Location = new Point(x, y);
            this.Width = taskWidth;
            this.Height= height;
        }
        
        private void Task_Click(object sender, EventArgs e)
        {
            TaskClicked?.Invoke(this,new TaskClickedEventArgs(Task));
        }                                    // Prawdopodobnie będzie trzeba utworzyc zdarzenie i przy tworzeniu tej kontrolki podpiac je w Day Presenter

        private void TaskUserControl_BackColorChanged(object sender, EventArgs e)
        {
            labelDelete.BackColor = this.BackColor;
        }


        private void labelDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, new TaskClickedEventArgs(Task));
        }
    }
}
