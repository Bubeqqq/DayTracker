using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.UserControls
{
    partial class ToDoList
    {
        //UTILS

        private Panel? GetPanelWithControl(object sender)
        {
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

            return panel;
        }

        //REMOVE TASK

        private void RemoveTask(object sender, EventArgs args)
        {
            Panel? panel = GetPanelWithControl(sender);
            if (panel == null)
            {
                return;
            }

            Label? label = panel.Controls[0] as Label;

            if (label != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the \"{label.Text}\" section along with all tasks?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                int index = MainPanel.Controls.IndexOf(panel) + 1;

                while (index < MainPanel.Controls.Count)
                {
                    Panel? nextPanel = MainPanel.Controls[index] as Panel;
                    if (nextPanel == null)
                    {
                        break;
                    }
                    Label? nextLabel = nextPanel.Controls[0] as Label;
                    if (nextLabel != null)
                    {
                        break;
                    }
                    MainPanel.Controls.Remove(nextPanel);
                }
            }

            MainPanel.Controls.Remove(panel);
        }

        //ADD TASK

        private void AddTask(object sender, EventArgs args)
        {
            Panel? panel = GetPanelWithControl(sender);

            if (panel == null)
            {
                return;
            }

            int index = MainPanel.Controls.IndexOf(panel);

            Panel taskPanel = CreateTaskPanel("Task", false);
            MainPanel.Controls.Add(taskPanel);
            MainPanel.Controls.SetChildIndex(taskPanel, index + 1);

            AdjustControlsWidth();
        }

        //SECTION EDITS

        private void EditSection(object sender, EventArgs args)
        {
            Label? label = sender as Label;

            if (label == null)
            {
                return;
            }

            Panel? panel = GetPanelWithControl(sender);

            if (panel == null)
            {
                return;
            }

            TextBox textBox = new TextBox()
            {
                Text = label.Text.Substring(4, label.Text.Length - 8),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand,
                AutoSize = false
            };

            textBox.Leave += ConfirmSection;
            textBox.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) ConfirmSection(o, e); };

            panel.Controls.Clear();
            panel.Controls.Add(textBox);

            textBox.Focus();
        }

        private void ConfirmSection(object sender, EventArgs args)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            Panel? panel = GetPanelWithControl(sender);

            if (panel == null)
            {
                return;
            }

            Label label = CreateHeaderLabel(textBox.Text).Controls[0] as Label;

            panel.Controls.Clear();
            panel.Controls.Add(label);
        }

        //TASK EDITS

        private void EditTask(object sender, EventArgs args)
        {
            CheckBox? checkBox = sender as CheckBox;

            if (checkBox == null)
            {
                return;
            }

            Panel? panel = GetPanelWithControl(sender);

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

            textBox.Leave += ConfirmTask;
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
    }
}
