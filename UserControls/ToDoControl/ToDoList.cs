using System;
using System.Drawing;
using System.Windows.Forms;

namespace DayTracker.UserControls
{
    public partial class ToDoList : UserControl
    {
        public ToDoList()
        {
            InitializeComponent();

            MainPanel.BackColor = Color.FromArgb(226, 239, 252);

            MainPanel.Resize += MainPanel_Resize;
            MainPanel.Click += (s, e) => Focus();
        }

        public void SetTODOList(string todoList)
        {
            var tasks = todoList.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            MainPanel.Controls.Clear();
            MainPanel.SuspendLayout();

            MainPanel.Controls.Add(CreateAddButton());

            foreach (var task in tasks)
            {
                string trimmedTask = task.Trim();

                if (trimmedTask.StartsWith("[]"))
                {
                    MainPanel.Controls.Add(CreateTaskPanel(trimmedTask.Substring(2).Trim(), false));
                }
                else if (trimmedTask.StartsWith("[x]"))
                {
                    MainPanel.Controls.Add(CreateTaskPanel(trimmedTask.Substring(3).Trim(), true));
                }
                else
                {
                    MainPanel.Controls.Add(CreateHeaderLabel(trimmedTask));
                }
            }

            MainPanel.ResumeLayout();
            AdjustControlsWidth();
        }

        public string GetTODOList()
        {
            string result = "";
            foreach (Control control in MainPanel.Controls)
            {
                if (control is Panel panel && panel.Controls.Count > 0)
                {
                    Control innerControl = panel.Controls[0];
                    if (innerControl is CheckBox cb)
                    {
                        result += (cb.Checked ? "[x] " : "[] ") + cb.Text + Environment.NewLine;
                    }
                    else if (innerControl is Label lbl)
                    {
                        result += lbl.Text.Replace("--- ", "").Replace(" ---", "") + Environment.NewLine;
                    }
                }
            }
            return result.TrimEnd();
        }

        private Panel? CreateAddButton()
        {
            Panel panel = new Panel
            {
                Height = 48,
                Padding = new Padding(10, 5, 10, 5),
                BackColor = Color.Transparent
            };

            Button btn = new Button
            {
                Text = "+ Add Task Section",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);

            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 250, 255);
            


            btn.Click += (e, o) => {
                MainPanel.Controls.Add(CreateHeaderLabel("New Section"));
                MainPanel.Controls.SetChildIndex(MainPanel.Controls[MainPanel.Controls.Count - 1], 1);
                AdjustControlsWidth();
                Focus();
            };

            panel.Controls.Add(btn);

            return panel;
        }

        private Panel CreateTaskPanel(string text, bool isChecked)
        {
            Panel panel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 5, 10, 5),
                Height = 38
            };

            CheckBox cb = new CheckBox
            {
                Text = text,
                Checked = isChecked,
                Font = new Font("Segoe UI", 10F, isChecked ? FontStyle.Strikeout : FontStyle.Regular),
                ForeColor = isChecked ? Color.DimGray : Color.Black,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand,
                AutoSize = false,
                AutoEllipsis = true
            };

            cb.CheckedChanged += (s, e) =>
            {
                cb.Font = new Font("Segoe UI", 10F, cb.Checked ? FontStyle.Strikeout : FontStyle.Regular);
                cb.ForeColor = cb.Checked ? Color.DimGray : Color.Black;
            };

            cb.MouseUp += (o, e) => {
                Focus();
                if(e.Button == MouseButtons.Right) EditTask(o, e);
                else if (e.Button == MouseButtons.Middle) RemoveTask(o, e);
            };

            panel.Controls.Add(cb);
            return panel;
        }

        private Panel CreateHeaderLabel(string text)
        {
            string headerText = text.StartsWith("---") ? text : $"--- {text} ---";

            Panel panel = new Panel
            {
                Height = 38
            };

            Label l = new Label
            {
                Text = headerText,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 15, 10, 5),
                AutoEllipsis = true
            };

            l.MouseDoubleClick += AddTask;
            l.MouseUp += (o, e) => {
                MainPanel.Focus();
                if (e.Button == MouseButtons.Right) EditSection(o, e); 
                else if(e.Button == MouseButtons.Middle) RemoveTask(o, e); 
            };

            panel.Controls.Add(l);

            return panel;
        }

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            AdjustControlsWidth();
        }

        private void AdjustControlsWidth()
        {
            if (MainPanel.Controls.Count == 0) return;

            int newWidth = MainPanel.ClientSize.Width - 30;

            MainPanel.SuspendLayout();
            foreach (Control control in MainPanel.Controls)
            {
                if (control is Panel)
                {
                    control.Width = newWidth;
                }
            }
            MainPanel.ResumeLayout();
        }
    }
}