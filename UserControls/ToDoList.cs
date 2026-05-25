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
        }

        public void SetTODOList(string todoList)
        {
            var tasks = todoList.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            MainPanel.Controls.Clear();
            MainPanel.SuspendLayout();

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

        private void EditTask(object sender, EventArgs args)
        {
            CheckBox? checkBox = sender as CheckBox;

            if (checkBox == null)
            {
                return;
            }

            Panel? panel = null;
            foreach (var c in MainPanel.Controls)
            {
                Panel? control = c as Panel;

                if (control == null)
                    continue;

                if (control.Controls[0] == sender)
                {
                    panel = control;
                    break;
                }
            }

            if (panel == null)
            {
                return;
            }

            TextBox textBox = new TextBox()
            {
                Text = checkBox.Text,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand,
                AutoSize = false
            };

            textBox.LostFocus += ConfirmTask;
            textBox.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) ConfirmTask(o, e); };

            panel.Controls.Clear();
            panel.Controls.Add(textBox);

            textBox.Focus();
        }

        private void ConfirmTask(object sender, EventArgs args)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            Panel? panel = null;
            foreach (var c in MainPanel.Controls)
            {
                Panel? control = c as Panel;

                if (control == null)
                    continue;

                if (control.Controls[0] == sender)
                {
                    panel = control;
                    break;
                }
            }

            if (panel == null)
            {
                return;
            }

            CheckBox checkBox = CreateTaskPanel(textBox.Text, false).Controls[0] as CheckBox;

            panel.Controls.Clear();
            panel.Controls.Add(checkBox);
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
                AutoSize = false
            };

            cb.CheckedChanged += (s, e) =>
            {
                cb.Font = new Font("Segoe UI", 10F, cb.Checked ? FontStyle.Strikeout : FontStyle.Regular);
                cb.ForeColor = cb.Checked ? Color.DimGray : Color.Black;
            };

            cb.MouseUp += (o, e) => { if(e.Button == MouseButtons.Right) EditTask(o, e); };

            panel.Controls.Add(cb);
            return panel;
        }

        private Label CreateHeaderLabel(string text)
        {
            string headerText = text.StartsWith("---") ? text : $"--- {text} ---";

            return new Label
            {
                Text = headerText,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(10, 15, 10, 5)
            };
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