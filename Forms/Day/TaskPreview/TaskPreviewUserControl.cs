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
        public string Title { get { return labelTitle.Text; } set { labelTitle.Text = value; } }
        public string Description { get { return labelDescription.Text; } set { labelDescription.Text = value; } }
        public Size MaxLabelSize { get { return labelDescription.MaximumSize; } set { labelDescription.MaximumSize = value; } }
        public TaskPreviewUserControl()
        {
            InitializeComponent();
        }
        public void UpdateLocation(int x, int y, int taskWidth, int height)
        {
            this.Location = new Point(x, y);
            this.Width = taskWidth;
            this.Height= height;
        }

        private void Task_Click(object sender, EventArgs e)
        {
            MessageBox.Show(labelTitle.Text);//TODO musi pokazywać widok Taska
        }                                    // Prawdopodobnie będzie trzeba utworzyc zdarzenie i przy tworzeniu tej kontrolki podpiac je w Day Presenter

        private void TaskUserControl_BackColorChanged(object sender, EventArgs e)
        {
            labelDelete.BackColor = this.BackColor;
            labelEdit.BackColor = this.BackColor;
        }

        private void labelEdit_Click(object sender, EventArgs e)
        {
            //TODO to musi pokazywać ekran edycji Taska
        }

        private void labelDelete_Click(object sender, EventArgs e)
        {
            //TODO to musi pytać czy na pewno usunąć i jeśli tak to usunąć (Chyba będzie trzeba jebnąć model do tego)
        }
    }
}
