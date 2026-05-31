using DayTracker.Forms.TaskControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DayTracker.Forms.TaskControl
{
    public partial class TaskUserControl : UserControl, ITaskView//TODO trzeba dodać coś wyświetlającego kategorie taska
    {
        public string Title { get { return textBoxTitle.Text; } private set { textBoxTitle.Text = value; } }
        public string Descritpion { get { return textBoxDescription.Text; } private set { textBoxDescription.Text = value; } }
        public string StartMinute { get { return textBoxStartMinute.Text; } }
        public string StartHour { get { return textBoxStartHour.Text; } }
        public string StartDay { get { return textBoxStartDay.Text; } set { textBoxEndDay.Text = value; } }
        public string StartMonth { get { return textBoxStartMonth.Text; } }
        public string StartYear { get { return textBoxStartYear.Text; } }
        public string DurationMinutes { get {  return textBoxDurationMinutes.Text; } }
        public string DurationHours { get { return textBoxDurationHours.Text; } }
        public string DurationDays { get { return textBoxDurationDays.Text; } }
        public string EndMinute { get { return textBoxEndMinute.Text; } } 
        public string EndHour { get { return textBoxEndHour.Text; } }
        public string EndDay { get { return textBoxEndDay.Text; } set{ textBoxEndDay.Text = value; } }
        public string EndMonth { get { return textBoxEndMonth.Text; } }
        public string EndYear { get { return textBoxEndYear.Text; } }
        public event EventHandler<FieldValidationEventArgs> FieldValidation;
        private string _originalValue;
        public TaskUserControl()
        {
            InitializeComponent();
            AssignTagsToTextBoxes();
            ChangeAllTextBoxCursorsToArrow();
        }
        public void SetTaskInfoFields(string title, string description, DateTime startDate, TimeSpan duration, DateTime endDate)
        {
            Title = title;
            Descritpion = description;

            
        }
        public void SetStartDate(string hour, string minute, string day, string month, string year)
        {
            textBoxStartHour.Text = hour;
            textBoxStartMinute.Text = minute;
            textBoxStartDay.Text = day;
            textBoxStartMonth.Text = month;
            textBoxStartYear.Text = year;
        }
        public void SetEndDate(string hour, string minute, string day, string month, string year)
        {
            textBoxEndHour.Text = hour;
            textBoxEndMinute.Text = minute;
            textBoxEndDay.Text = day;
            textBoxEndMonth.Text = month;
            textBoxEndYear.Text = year;
        }
        public void SetDuration(string days,string hours, string minutes )
        {
            textBoxDurationDays.Text = days;
            textBoxDurationHours .Text = hours;
            textBoxDurationMinutes.Text = minutes;

        }
        private void AssignTagsToTextBoxes()
        {
            textBoxTitle.Tag = TaskField.Text;

            textBoxDescription.Tag = TaskField.Text;

            textBoxStartHour.Tag = TaskField.StartHour;
            textBoxStartMinute.Tag = TaskField.StartMinute;
            textBoxStartDay.Tag = TaskField.StartDay;
            textBoxStartMonth.Tag = TaskField.StartMonth;
            textBoxStartYear.Tag = TaskField.StartYear;

            textBoxEndHour.Tag = TaskField.EndHour;
            textBoxEndMinute.Tag = TaskField.EndMinute;
            textBoxEndDay.Tag = TaskField.EndDay;
            textBoxEndMonth.Tag = TaskField.EndMonth;
            textBoxEndYear.Tag = TaskField.EndYear;

            textBoxDurationDays.Tag = TaskField.DurationDays;
            textBoxDurationHours.Tag = TaskField.DurationHours;
            textBoxDurationMinutes.Tag = TaskField.DurationMinutes;
        }
        
        private void ChangeAllTextBoxCursorsToArrow()
        {
            textBoxTitle.Cursor = Cursors.Arrow;

            textBoxDescription.Cursor = Cursors.Arrow;

            textBoxStartHour.Cursor = Cursors.Arrow;
            textBoxStartMinute.Cursor = Cursors.Arrow;
            textBoxStartDay.Cursor = Cursors.Arrow;
            textBoxStartMonth.Cursor = Cursors.Arrow;
            textBoxStartYear.Cursor = Cursors.Arrow;

            textBoxEndHour.Cursor = Cursors.Arrow;
            textBoxEndMinute.Cursor = Cursors.Arrow;
            textBoxEndDay.Cursor = Cursors.Arrow;
            textBoxEndMonth.Cursor = Cursors.Arrow;
            textBoxEndYear.Cursor = Cursors.Arrow;

            textBoxDurationDays.Cursor = Cursors.Arrow;
            textBoxDurationHours.Cursor = Cursors.Arrow;
            textBoxDurationMinutes.Cursor = Cursors.Arrow;

        }
        private void ChangeTextBoxToTypeMode(TextBox textBox)
        {
            if (textBox != null)
            {
                _originalValue = textBox.Text;

                textBox.ReadOnly = false;
                textBox.BackColor = Color.Wheat;
                textBox.Focus();
                textBox.SelectAll();
                textBox.Cursor = Cursors.IBeam;
            }

        }
        private void ChangeTextBoxToViewMode(TextBox textBox, Color color)
        {
            if (textBox != null)
            {
                textBox.ReadOnly = true;
                textBox.BackColor = color;
                textBox.Cursor = Cursors.Arrow;
                LoseFocus();
            }
            
        }
        
        private void ValidateEdit(TextBox textBox)
        {
            if (textBox != null && textBox.Tag is TaskField fieldType)
            {
                if (textBox.Text != _originalValue)
                {
                    var args = new FieldValidationEventArgs(fieldType, textBox.Text);
                    FieldValidation?.Invoke(this, args);
                    if (!args.IsValid)
                    {
                        textBox.Text = _originalValue;
                        MessageBox.Show(args.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox_DoubleClick(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            ChangeTextBoxToTypeMode((TextBox)sender);
        }

        private void textBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeTextBoxToViewMode((TextBox)sender, Color.PowderBlue);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            ChangeTextBoxToViewMode((TextBox)sender, Color.PowderBlue);
        }

        private void textBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeTextBoxToViewMode((TextBox)sender, Color.PowderBlue);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            ChangeTextBoxToViewMode((TextBox)sender, Color.SkyBlue);
        }
        private void LoseFocus()
        {
            label5.Focus();
        }
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            LoseFocus();
        }

        private void textBoxStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                ValidateEdit(textBox);
                ChangeTextBoxToViewMode(textBox, Color.PaleGreen);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxStart_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ValidateEdit(textBox);
            ChangeTextBoxToViewMode(textBox, Color.PaleGreen);
        }

        private void textBoxDuration_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ValidateEdit(textBox);
            ChangeTextBoxToViewMode(textBox, Color.Plum);
        }

        private void textBoxDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                ValidateEdit(textBox);
                ChangeTextBoxToViewMode(textBox, Color.Plum);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                ValidateEdit(textBox);
                ChangeTextBoxToViewMode(textBox, Color.Salmon);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxEnd_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ValidateEdit(textBox);
            ChangeTextBoxToViewMode(textBox, Color.Salmon);
        }

        private void textBoxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int newWidth = textBox.MinimumSize.Width* textBox.Text.Length;
                textBox.Width = newWidth;
            }
        }
    }
}
