using DayTracker.Forms.Day;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DayTracker.Forms.Day.TaskPreview;
using DayTracker.UserControls.TestTask_usunac;
namespace DayTracker.Forms.Day
{
    public partial class DayUserControl : UserControl,IDayView
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
        public int PixelsPerHour { get; }
        public int LeftMargin { get; }
        public int TotalWidth { get { return this.ClientSize.Width; } }
        public event EventHandler SizeChanged;
        public event EventHandler<TaskClickedEventArgs> TaskClicked;
        public event EventHandler<TaskClickedEventArgs> DeleteClicked;
        public DayUserControl()
        {
            InitializeComponent();
            LeftMargin = 50;
            PixelsPerHour = 60;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

        }
        // Algorytm grupujący zadania w kolumny, by uniknąć nachodzenia

        public void CreateAndPlaceTaskControl(TestTask task, int x, int y, int taskWidth, int height)
        {
            TaskPreviewUserControl control = new TaskPreviewUserControl(task);
            control.Location = new Point(x, y);
            control.Width = taskWidth;
            control.Height = height;
            control.BackColor = Color.Yellow;
            control.MaxLabelSize = new Size(taskWidth - 20, 0);
            control.DeleteClicked += DeleteClicked;
            control.TaskClicked += TaskClicked;
            this.Controls.Add(control);


        }
        public void ModifyControl(int index,int x,int y, int taskWidth, int height)
        {
            TaskPreviewUserControl control = (TaskPreviewUserControl)this.Controls[index];
            control.UpdateLocation(x,y,taskWidth,height);
        }
        public bool YesNoMessage(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "Choose an option", MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes ? true : false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Graphics g = e.Graphics;


            g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

            Pen linePen = new Pen(Color.LightGray);
            Font timeFont = new Font("Segoe UI", 8);
            Brush textBrush = Brushes.DimGray;

            for (int i = 0; i <= 24; i++)
            {
                int y = i * PixelsPerHour;

                string timeText = $"{i:00}:00";
                g.DrawString(timeText, timeFont, textBrush, 5, y);

                g.DrawLine(linePen, LeftMargin, y, this.Width - this.AutoScrollPosition.X, y);
            }
        }


        private void DayUserControl_ClientSizeChanged(object sender, EventArgs e)
        {
          SizeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
