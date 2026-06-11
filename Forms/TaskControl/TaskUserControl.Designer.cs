

using System.Windows.Forms;
//using DayTracker.UserControls.ToDoControl;
namespace DayTracker.Forms.TaskControl
{
    partial class TaskUserControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxTitle = new TextBox();
            textBoxDescription = new TextBox();
            labelStartDate = new Label();
            panelStart = new Panel();
            label1 = new Label();
            textBoxStartYear = new TextBox();
            labelStartSpace3 = new Label();
            textBoxStartMonth = new TextBox();
            labelStartSpace2 = new Label();
            textBoxStartDay = new TextBox();
            labelStartSpace = new Label();
            textBoxStartMinute = new TextBox();
            labelStartDots = new Label();
            textBoxStartHour = new TextBox();
            panelEnd = new Panel();
            label2 = new Label();
            textBoxEndYear = new TextBox();
            labelEndSpace3 = new Label();
            textBoxEndMonth = new TextBox();
            labelEndSpace2 = new Label();
            textBoxEndDay = new TextBox();
            labelEndSpace = new Label();
            textBoxEndMinute = new TextBox();
            labelEndDots = new Label();
            textBoxEndHour = new TextBox();
            labelEndDate = new Label();
            panelDuration = new Panel();
            labelDurationMinutes = new Label();
            textBoxDurationMinutes = new TextBox();
            labelDurationHours = new Label();
            textBoxDurationHours = new TextBox();
            labelDurationDays = new Label();
            textBoxDurationDays = new TextBox();
            label5 = new Label();
            checkedListBoxCategories = new CheckedListBox();
            buttonConfirm = new Button();
            panelStart.SuspendLayout();
            panelEnd.SuspendLayout();
            panelDuration.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxTitle
            // 
            textBoxTitle.BackColor = Color.PowderBlue;
            textBoxTitle.BorderStyle = BorderStyle.None;
            textBoxTitle.Dock = DockStyle.Top;
            textBoxTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxTitle.Location = new Point(0, 0);
            textBoxTitle.Multiline = true;
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.ReadOnly = true;
            textBoxTitle.Size = new Size(738, 60);
            textBoxTitle.TabIndex = 7;
            textBoxTitle.TabStop = false;
            textBoxTitle.Text = "Title";
            textBoxTitle.DoubleClick += textBox_DoubleClick;
            textBoxTitle.KeyDown += textBoxTitle_KeyDown;
            textBoxTitle.Leave += textBoxTitle_Leave;
            textBoxTitle.MouseDown += textBox_MouseDown;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.SkyBlue;
            textBoxDescription.BorderStyle = BorderStyle.None;
            textBoxDescription.Dock = DockStyle.Top;
            textBoxDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxDescription.Location = new Point(0, 60);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new Size(738, 85);
            textBoxDescription.TabIndex = 8;
            textBoxDescription.TabStop = false;
            textBoxDescription.Text = "Description";
            textBoxDescription.DoubleClick += textBox_DoubleClick;
            textBoxDescription.KeyDown += textBoxDescription_KeyDown;
            textBoxDescription.Leave += textBoxDescription_Leave;
            textBoxDescription.MouseDown += textBox_MouseDown;
            // 
            // labelStartDate
            // 
            labelStartDate.BackColor = Color.PaleGreen;
            labelStartDate.Dock = DockStyle.Left;
            labelStartDate.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartDate.Location = new Point(0, 0);
            labelStartDate.MinimumSize = new Size(126, 44);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(126, 44);
            labelStartDate.TabIndex = 15;
            labelStartDate.Text = "Start Date: ";
            // 
            // panelStart
            // 
            panelStart.AutoSize = true;
            panelStart.Controls.Add(label1);
            panelStart.Controls.Add(textBoxStartYear);
            panelStart.Controls.Add(labelStartSpace3);
            panelStart.Controls.Add(textBoxStartMonth);
            panelStart.Controls.Add(labelStartSpace2);
            panelStart.Controls.Add(textBoxStartDay);
            panelStart.Controls.Add(labelStartSpace);
            panelStart.Controls.Add(textBoxStartMinute);
            panelStart.Controls.Add(labelStartDots);
            panelStart.Controls.Add(textBoxStartHour);
            panelStart.Controls.Add(labelStartDate);
            panelStart.Dock = DockStyle.Top;
            panelStart.Location = new Point(0, 145);
            panelStart.MinimumSize = new Size(450, 44);
            panelStart.Name = "panelStart";
            panelStart.Size = new Size(738, 44);
            panelStart.TabIndex = 18;
            // 
            // label1
            // 
            label1.BackColor = Color.PaleGreen;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Dubai", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(399, 0);
            label1.MinimumSize = new Size(18, 0);
            label1.Name = "label1";
            label1.Size = new Size(339, 44);
            label1.TabIndex = 25;
            label1.Text = "📅";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxStartYear
            // 
            textBoxStartYear.BackColor = Color.PaleGreen;
            textBoxStartYear.BorderStyle = BorderStyle.None;
            textBoxStartYear.Dock = DockStyle.Left;
            textBoxStartYear.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStartYear.Location = new Point(343, 0);
            textBoxStartYear.MaxLength = 4;
            textBoxStartYear.MinimumSize = new Size(34, 44);
            textBoxStartYear.Name = "textBoxStartYear";
            textBoxStartYear.Size = new Size(56, 44);
            textBoxStartYear.TabIndex = 24;
            textBoxStartYear.TabStop = false;
            textBoxStartYear.Text = "2000";
            textBoxStartYear.DoubleClick += textBox_DoubleClick;
            textBoxStartYear.KeyDown += textBoxStart_KeyDown;
            textBoxStartYear.KeyPress += textBoxNumeric_KeyPress;
            textBoxStartYear.Leave += textBoxStart_Leave;
            textBoxStartYear.MouseDown += textBox_MouseDown;
            // 
            // labelStartSpace3
            // 
            labelStartSpace3.BackColor = Color.PaleGreen;
            labelStartSpace3.Dock = DockStyle.Left;
            labelStartSpace3.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartSpace3.Location = new Point(325, 0);
            labelStartSpace3.MinimumSize = new Size(18, 0);
            labelStartSpace3.Name = "labelStartSpace3";
            labelStartSpace3.Size = new Size(18, 44);
            labelStartSpace3.TabIndex = 23;
            labelStartSpace3.Text = "/";
            labelStartSpace3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxStartMonth
            // 
            textBoxStartMonth.BackColor = Color.PaleGreen;
            textBoxStartMonth.BorderStyle = BorderStyle.None;
            textBoxStartMonth.Dock = DockStyle.Left;
            textBoxStartMonth.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStartMonth.Location = new Point(291, 0);
            textBoxStartMonth.MaxLength = 2;
            textBoxStartMonth.MinimumSize = new Size(15, 44);
            textBoxStartMonth.Name = "textBoxStartMonth";
            textBoxStartMonth.Size = new Size(34, 44);
            textBoxStartMonth.TabIndex = 22;
            textBoxStartMonth.TabStop = false;
            textBoxStartMonth.Text = "12";
            textBoxStartMonth.TextAlign = HorizontalAlignment.Right;
            textBoxStartMonth.TextChanged += textBox_TextChanged;
            textBoxStartMonth.DoubleClick += textBox_DoubleClick;
            textBoxStartMonth.KeyDown += textBoxStart_KeyDown;
            textBoxStartMonth.KeyPress += textBoxNumeric_KeyPress;
            textBoxStartMonth.Leave += textBoxStart_Leave;
            textBoxStartMonth.MouseDown += textBox_MouseDown;
            // 
            // labelStartSpace2
            // 
            labelStartSpace2.BackColor = Color.PaleGreen;
            labelStartSpace2.Dock = DockStyle.Left;
            labelStartSpace2.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartSpace2.Location = new Point(273, 0);
            labelStartSpace2.MinimumSize = new Size(18, 0);
            labelStartSpace2.Name = "labelStartSpace2";
            labelStartSpace2.Size = new Size(18, 44);
            labelStartSpace2.TabIndex = 21;
            labelStartSpace2.Text = "/";
            labelStartSpace2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxStartDay
            // 
            textBoxStartDay.BackColor = Color.PaleGreen;
            textBoxStartDay.BorderStyle = BorderStyle.None;
            textBoxStartDay.Dock = DockStyle.Left;
            textBoxStartDay.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStartDay.Location = new Point(258, 0);
            textBoxStartDay.MaxLength = 2;
            textBoxStartDay.MinimumSize = new Size(15, 44);
            textBoxStartDay.Name = "textBoxStartDay";
            textBoxStartDay.Size = new Size(15, 44);
            textBoxStartDay.TabIndex = 19;
            textBoxStartDay.TabStop = false;
            textBoxStartDay.Text = "5";
            textBoxStartDay.TextAlign = HorizontalAlignment.Right;
            textBoxStartDay.TextChanged += textBox_TextChanged;
            textBoxStartDay.DoubleClick += textBox_DoubleClick;
            textBoxStartDay.KeyDown += textBoxStart_KeyDown;
            textBoxStartDay.KeyPress += textBoxNumeric_KeyPress;
            textBoxStartDay.Leave += textBoxStart_Leave;
            textBoxStartDay.MouseDown += textBox_MouseDown;
            // 
            // labelStartSpace
            // 
            labelStartSpace.BackColor = Color.PaleGreen;
            labelStartSpace.Dock = DockStyle.Left;
            labelStartSpace.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartSpace.Location = new Point(208, 0);
            labelStartSpace.MinimumSize = new Size(18, 0);
            labelStartSpace.Name = "labelStartSpace";
            labelStartSpace.Size = new Size(50, 44);
            labelStartSpace.TabIndex = 20;
            labelStartSpace.Text = "🕐";
            labelStartSpace.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxStartMinute
            // 
            textBoxStartMinute.BackColor = Color.PaleGreen;
            textBoxStartMinute.BorderStyle = BorderStyle.None;
            textBoxStartMinute.Dock = DockStyle.Left;
            textBoxStartMinute.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStartMinute.Location = new Point(178, 0);
            textBoxStartMinute.MaxLength = 2;
            textBoxStartMinute.MinimumSize = new Size(15, 44);
            textBoxStartMinute.Name = "textBoxStartMinute";
            textBoxStartMinute.Size = new Size(30, 44);
            textBoxStartMinute.TabIndex = 17;
            textBoxStartMinute.TabStop = false;
            textBoxStartMinute.Text = "16";
            textBoxStartMinute.TextAlign = HorizontalAlignment.Right;
            textBoxStartMinute.TextChanged += textBox_TextChanged;
            textBoxStartMinute.DoubleClick += textBox_DoubleClick;
            textBoxStartMinute.KeyDown += textBoxStart_KeyDown;
            textBoxStartMinute.KeyPress += textBoxNumeric_KeyPress;
            textBoxStartMinute.Leave += textBoxStart_Leave;
            textBoxStartMinute.MouseDown += textBox_MouseDown;
            // 
            // labelStartDots
            // 
            labelStartDots.BackColor = Color.PaleGreen;
            labelStartDots.Dock = DockStyle.Left;
            labelStartDots.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStartDots.Location = new Point(160, 0);
            labelStartDots.MinimumSize = new Size(18, 0);
            labelStartDots.Name = "labelStartDots";
            labelStartDots.Size = new Size(18, 44);
            labelStartDots.TabIndex = 18;
            labelStartDots.Text = ": ";
            // 
            // textBoxStartHour
            // 
            textBoxStartHour.BackColor = Color.PaleGreen;
            textBoxStartHour.BorderStyle = BorderStyle.None;
            textBoxStartHour.Dock = DockStyle.Left;
            textBoxStartHour.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStartHour.Location = new Point(126, 0);
            textBoxStartHour.MaxLength = 2;
            textBoxStartHour.MinimumSize = new Size(15, 44);
            textBoxStartHour.Name = "textBoxStartHour";
            textBoxStartHour.Size = new Size(34, 44);
            textBoxStartHour.TabIndex = 16;
            textBoxStartHour.TabStop = false;
            textBoxStartHour.Text = "16";
            textBoxStartHour.TextAlign = HorizontalAlignment.Right;
            textBoxStartHour.TextChanged += textBox_TextChanged;
            textBoxStartHour.DoubleClick += textBox_DoubleClick;
            textBoxStartHour.KeyDown += textBoxStart_KeyDown;
            textBoxStartHour.KeyPress += textBoxNumeric_KeyPress;
            textBoxStartHour.Leave += textBoxStart_Leave;
            textBoxStartHour.MouseDown += textBox_MouseDown;
            // 
            // panelEnd
            // 
            panelEnd.AutoSize = true;
            panelEnd.Controls.Add(label2);
            panelEnd.Controls.Add(textBoxEndYear);
            panelEnd.Controls.Add(labelEndSpace3);
            panelEnd.Controls.Add(textBoxEndMonth);
            panelEnd.Controls.Add(labelEndSpace2);
            panelEnd.Controls.Add(textBoxEndDay);
            panelEnd.Controls.Add(labelEndSpace);
            panelEnd.Controls.Add(textBoxEndMinute);
            panelEnd.Controls.Add(labelEndDots);
            panelEnd.Controls.Add(textBoxEndHour);
            panelEnd.Controls.Add(labelEndDate);
            panelEnd.Dock = DockStyle.Top;
            panelEnd.Location = new Point(0, 233);
            panelEnd.MinimumSize = new Size(450, 44);
            panelEnd.Name = "panelEnd";
            panelEnd.Size = new Size(738, 44);
            panelEnd.TabIndex = 25;
            // 
            // label2
            // 
            label2.BackColor = Color.Salmon;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(389, 0);
            label2.MinimumSize = new Size(18, 0);
            label2.Name = "label2";
            label2.Size = new Size(349, 44);
            label2.TabIndex = 25;
            label2.Text = "📅";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxEndYear
            // 
            textBoxEndYear.BackColor = Color.Salmon;
            textBoxEndYear.BorderStyle = BorderStyle.None;
            textBoxEndYear.Dock = DockStyle.Left;
            textBoxEndYear.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEndYear.Location = new Point(333, 0);
            textBoxEndYear.MaxLength = 4;
            textBoxEndYear.MinimumSize = new Size(34, 44);
            textBoxEndYear.Name = "textBoxEndYear";
            textBoxEndYear.Size = new Size(56, 44);
            textBoxEndYear.TabIndex = 24;
            textBoxEndYear.TabStop = false;
            textBoxEndYear.Text = "2000";
            textBoxEndYear.DoubleClick += textBox_DoubleClick;
            textBoxEndYear.KeyDown += textBoxEnd_KeyDown;
            textBoxEndYear.KeyPress += textBoxNumeric_KeyPress;
            textBoxEndYear.Leave += textBoxEnd_Leave;
            textBoxEndYear.MouseDown += textBox_MouseDown;
            // 
            // labelEndSpace3
            // 
            labelEndSpace3.BackColor = Color.Salmon;
            labelEndSpace3.Dock = DockStyle.Left;
            labelEndSpace3.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEndSpace3.ImageAlign = ContentAlignment.MiddleLeft;
            labelEndSpace3.Location = new Point(309, 0);
            labelEndSpace3.MinimumSize = new Size(18, 0);
            labelEndSpace3.Name = "labelEndSpace3";
            labelEndSpace3.Size = new Size(24, 44);
            labelEndSpace3.TabIndex = 23;
            labelEndSpace3.Text = "/";
            labelEndSpace3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxEndMonth
            // 
            textBoxEndMonth.BackColor = Color.Salmon;
            textBoxEndMonth.BorderStyle = BorderStyle.None;
            textBoxEndMonth.Dock = DockStyle.Left;
            textBoxEndMonth.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEndMonth.Location = new Point(275, 0);
            textBoxEndMonth.MaxLength = 2;
            textBoxEndMonth.MinimumSize = new Size(15, 44);
            textBoxEndMonth.Name = "textBoxEndMonth";
            textBoxEndMonth.Size = new Size(34, 44);
            textBoxEndMonth.TabIndex = 22;
            textBoxEndMonth.TabStop = false;
            textBoxEndMonth.Text = "12";
            textBoxEndMonth.TextAlign = HorizontalAlignment.Right;
            textBoxEndMonth.TextChanged += textBox_TextChanged;
            textBoxEndMonth.DoubleClick += textBox_DoubleClick;
            textBoxEndMonth.KeyDown += textBoxEnd_KeyDown;
            textBoxEndMonth.KeyPress += textBoxNumeric_KeyPress;
            textBoxEndMonth.Leave += textBoxEnd_Leave;
            textBoxEndMonth.MouseDown += textBox_MouseDown;
            // 
            // labelEndSpace2
            // 
            labelEndSpace2.BackColor = Color.Salmon;
            labelEndSpace2.Dock = DockStyle.Left;
            labelEndSpace2.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEndSpace2.Location = new Point(257, 0);
            labelEndSpace2.MinimumSize = new Size(18, 0);
            labelEndSpace2.Name = "labelEndSpace2";
            labelEndSpace2.Size = new Size(18, 44);
            labelEndSpace2.TabIndex = 21;
            labelEndSpace2.Text = "/";
            labelEndSpace2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxEndDay
            // 
            textBoxEndDay.BackColor = Color.Salmon;
            textBoxEndDay.BorderStyle = BorderStyle.None;
            textBoxEndDay.Dock = DockStyle.Left;
            textBoxEndDay.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEndDay.Location = new Point(242, 0);
            textBoxEndDay.MaxLength = 2;
            textBoxEndDay.MinimumSize = new Size(15, 44);
            textBoxEndDay.Name = "textBoxEndDay";
            textBoxEndDay.Size = new Size(15, 44);
            textBoxEndDay.TabIndex = 19;
            textBoxEndDay.TabStop = false;
            textBoxEndDay.Text = "5";
            textBoxEndDay.TextAlign = HorizontalAlignment.Right;
            textBoxEndDay.TextChanged += textBox_TextChanged;
            textBoxEndDay.DoubleClick += textBox_DoubleClick;
            textBoxEndDay.KeyDown += textBoxEnd_KeyDown;
            textBoxEndDay.KeyPress += textBoxNumeric_KeyPress;
            textBoxEndDay.Leave += textBoxEnd_Leave;
            textBoxEndDay.MouseDown += textBox_MouseDown;
            // 
            // labelEndSpace
            // 
            labelEndSpace.BackColor = Color.Salmon;
            labelEndSpace.Dock = DockStyle.Left;
            labelEndSpace.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEndSpace.Location = new Point(192, 0);
            labelEndSpace.MinimumSize = new Size(18, 0);
            labelEndSpace.Name = "labelEndSpace";
            labelEndSpace.Size = new Size(50, 44);
            labelEndSpace.TabIndex = 20;
            labelEndSpace.Text = "🕐";
            labelEndSpace.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxEndMinute
            // 
            textBoxEndMinute.BackColor = Color.Salmon;
            textBoxEndMinute.BorderStyle = BorderStyle.None;
            textBoxEndMinute.Dock = DockStyle.Left;
            textBoxEndMinute.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEndMinute.Location = new Point(164, 0);
            textBoxEndMinute.MaxLength = 2;
            textBoxEndMinute.MinimumSize = new Size(15, 44);
            textBoxEndMinute.Name = "textBoxEndMinute";
            textBoxEndMinute.Size = new Size(28, 44);
            textBoxEndMinute.TabIndex = 17;
            textBoxEndMinute.TabStop = false;
            textBoxEndMinute.Text = "16";
            textBoxEndMinute.TextAlign = HorizontalAlignment.Right;
            textBoxEndMinute.TextChanged += textBox_TextChanged;
            textBoxEndMinute.DoubleClick += textBox_DoubleClick;
            textBoxEndMinute.KeyDown += textBoxEnd_KeyDown;
            textBoxEndMinute.KeyPress += textBoxNumeric_KeyPress;
            textBoxEndMinute.Leave += textBoxEnd_Leave;
            textBoxEndMinute.MouseDown += textBox_MouseDown;
            // 
            // labelEndDots
            // 
            labelEndDots.BackColor = Color.Salmon;
            labelEndDots.Dock = DockStyle.Left;
            labelEndDots.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEndDots.Location = new Point(146, 0);
            labelEndDots.MinimumSize = new Size(18, 0);
            labelEndDots.Name = "labelEndDots";
            labelEndDots.Size = new Size(18, 44);
            labelEndDots.TabIndex = 18;
            labelEndDots.Text = ": ";
            // 
            // textBoxEndHour
            // 
            textBoxEndHour.BackColor = Color.Salmon;
            textBoxEndHour.BorderStyle = BorderStyle.None;
            textBoxEndHour.Dock = DockStyle.Left;
            textBoxEndHour.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEndHour.Location = new Point(112, 0);
            textBoxEndHour.MaxLength = 2;
            textBoxEndHour.MinimumSize = new Size(15, 44);
            textBoxEndHour.Name = "textBoxEndHour";
            textBoxEndHour.Size = new Size(34, 44);
            textBoxEndHour.TabIndex = 16;
            textBoxEndHour.TabStop = false;
            textBoxEndHour.Text = "16";
            textBoxEndHour.TextAlign = HorizontalAlignment.Right;
            textBoxEndHour.TextChanged += textBox_TextChanged;
            textBoxEndHour.DoubleClick += textBox_DoubleClick;
            textBoxEndHour.KeyDown += textBoxEnd_KeyDown;
            textBoxEndHour.KeyPress += textBoxNumeric_KeyPress;
            textBoxEndHour.Leave += textBoxEnd_Leave;
            textBoxEndHour.MouseDown += textBox_MouseDown;
            // 
            // labelEndDate
            // 
            labelEndDate.BackColor = Color.Salmon;
            labelEndDate.Dock = DockStyle.Left;
            labelEndDate.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEndDate.Location = new Point(0, 0);
            labelEndDate.MinimumSize = new Size(112, 44);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(112, 44);
            labelEndDate.TabIndex = 15;
            labelEndDate.Text = "End Date:";
            labelEndDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelDuration
            // 
            panelDuration.AutoSize = true;
            panelDuration.Controls.Add(labelDurationMinutes);
            panelDuration.Controls.Add(textBoxDurationMinutes);
            panelDuration.Controls.Add(labelDurationHours);
            panelDuration.Controls.Add(textBoxDurationHours);
            panelDuration.Controls.Add(labelDurationDays);
            panelDuration.Controls.Add(textBoxDurationDays);
            panelDuration.Controls.Add(label5);
            panelDuration.Dock = DockStyle.Top;
            panelDuration.Location = new Point(0, 189);
            panelDuration.MinimumSize = new Size(450, 44);
            panelDuration.Name = "panelDuration";
            panelDuration.Size = new Size(738, 44);
            panelDuration.TabIndex = 26;
            // 
            // labelDurationMinutes
            // 
            labelDurationMinutes.BackColor = Color.Plum;
            labelDurationMinutes.Dock = DockStyle.Fill;
            labelDurationMinutes.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDurationMinutes.Location = new Point(334, 0);
            labelDurationMinutes.Margin = new Padding(0);
            labelDurationMinutes.MinimumSize = new Size(95, 44);
            labelDurationMinutes.Name = "labelDurationMinutes";
            labelDurationMinutes.Size = new Size(404, 44);
            labelDurationMinutes.TabIndex = 21;
            labelDurationMinutes.Text = "minutes⏰";
            // 
            // textBoxDurationMinutes
            // 
            textBoxDurationMinutes.BackColor = Color.Plum;
            textBoxDurationMinutes.BorderStyle = BorderStyle.None;
            textBoxDurationMinutes.Dock = DockStyle.Left;
            textBoxDurationMinutes.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDurationMinutes.Location = new Point(319, 0);
            textBoxDurationMinutes.MaxLength = 2;
            textBoxDurationMinutes.MinimumSize = new Size(15, 44);
            textBoxDurationMinutes.Name = "textBoxDurationMinutes";
            textBoxDurationMinutes.Size = new Size(15, 44);
            textBoxDurationMinutes.TabIndex = 19;
            textBoxDurationMinutes.Text = "5";
            textBoxDurationMinutes.TextAlign = HorizontalAlignment.Right;
            textBoxDurationMinutes.TextChanged += textBox_TextChanged;
            textBoxDurationMinutes.DoubleClick += textBox_DoubleClick;
            textBoxDurationMinutes.KeyDown += textBoxDuration_KeyDown;
            textBoxDurationMinutes.KeyPress += textBoxNumeric_KeyPress;
            textBoxDurationMinutes.Leave += textBoxDuration_Leave;
            textBoxDurationMinutes.MouseDown += textBox_MouseDown;
            // 
            // labelDurationHours
            // 
            labelDurationHours.BackColor = Color.Plum;
            labelDurationHours.Dock = DockStyle.Left;
            labelDurationHours.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDurationHours.Location = new Point(242, 0);
            labelDurationHours.Margin = new Padding(0);
            labelDurationHours.MinimumSize = new Size(77, 44);
            labelDurationHours.Name = "labelDurationHours";
            labelDurationHours.Size = new Size(77, 44);
            labelDurationHours.TabIndex = 20;
            labelDurationHours.Text = "hours";
            // 
            // textBoxDurationHours
            // 
            textBoxDurationHours.BackColor = Color.Plum;
            textBoxDurationHours.BorderStyle = BorderStyle.None;
            textBoxDurationHours.Dock = DockStyle.Left;
            textBoxDurationHours.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDurationHours.Location = new Point(208, 0);
            textBoxDurationHours.MaxLength = 2;
            textBoxDurationHours.MinimumSize = new Size(15, 44);
            textBoxDurationHours.Name = "textBoxDurationHours";
            textBoxDurationHours.Size = new Size(34, 44);
            textBoxDurationHours.TabIndex = 17;
            textBoxDurationHours.Text = "16";
            textBoxDurationHours.TextAlign = HorizontalAlignment.Right;
            textBoxDurationHours.TextChanged += textBox_TextChanged;
            textBoxDurationHours.DoubleClick += textBox_DoubleClick;
            textBoxDurationHours.KeyDown += textBoxDuration_KeyDown;
            textBoxDurationHours.KeyPress += textBoxNumeric_KeyPress;
            textBoxDurationHours.Leave += textBoxDuration_Leave;
            textBoxDurationHours.MouseDown += textBox_MouseDown;
            // 
            // labelDurationDays
            // 
            labelDurationDays.BackColor = Color.Plum;
            labelDurationDays.Dock = DockStyle.Left;
            labelDurationDays.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDurationDays.Location = new Point(123, 0);
            labelDurationDays.Margin = new Padding(0);
            labelDurationDays.MinimumSize = new Size(18, 44);
            labelDurationDays.Name = "labelDurationDays";
            labelDurationDays.Size = new Size(85, 44);
            labelDurationDays.TabIndex = 18;
            labelDurationDays.Text = " day(s)";
            // 
            // textBoxDurationDays
            // 
            textBoxDurationDays.BackColor = Color.Plum;
            textBoxDurationDays.BorderStyle = BorderStyle.None;
            textBoxDurationDays.Dock = DockStyle.Left;
            textBoxDurationDays.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDurationDays.Location = new Point(108, 0);
            textBoxDurationDays.MaxLength = 4;
            textBoxDurationDays.MinimumSize = new Size(15, 44);
            textBoxDurationDays.Name = "textBoxDurationDays";
            textBoxDurationDays.Size = new Size(15, 44);
            textBoxDurationDays.TabIndex = 16;
            textBoxDurationDays.Text = "0";
            textBoxDurationDays.TextAlign = HorizontalAlignment.Center;
            textBoxDurationDays.TextChanged += textBox_TextChanged;
            textBoxDurationDays.DoubleClick += textBox_DoubleClick;
            textBoxDurationDays.KeyDown += textBoxDuration_KeyDown;
            textBoxDurationDays.KeyPress += textBoxNumeric_KeyPress;
            textBoxDurationDays.Leave += textBoxDuration_Leave;
            textBoxDurationDays.MouseDown += textBox_MouseDown;
            // 
            // label5
            // 
            label5.BackColor = Color.Plum;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.MinimumSize = new Size(108, 44);
            label5.Name = "label5";
            label5.Size = new Size(108, 44);
            label5.TabIndex = 15;
            label5.Text = "Duration:";
            // 
            // checkedListBoxCategories
            // 
            checkedListBoxCategories.CheckOnClick = true;
            checkedListBoxCategories.Dock = DockStyle.Top;
            checkedListBoxCategories.FormattingEnabled = true;
            checkedListBoxCategories.Location = new Point(0, 277);
            checkedListBoxCategories.MinimumSize = new Size(0, 132);
            checkedListBoxCategories.Name = "checkedListBoxCategories";
            checkedListBoxCategories.Size = new Size(738, 130);
            checkedListBoxCategories.TabIndex = 27;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.Aquamarine;
            buttonConfirm.Dock = DockStyle.Fill;
            buttonConfirm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            buttonConfirm.Location = new Point(0, 407);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(738, 257);
            buttonConfirm.TabIndex = 29;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // TaskUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonConfirm);
            Controls.Add(checkedListBoxCategories);
            Controls.Add(panelEnd);
            Controls.Add(panelDuration);
            Controls.Add(panelStart);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxTitle);
            Name = "TaskUserControl";
            Size = new Size(738, 664);
            panelStart.ResumeLayout(false);
            panelStart.PerformLayout();
            panelEnd.ResumeLayout(false);
            panelEnd.PerformLayout();
            panelDuration.ResumeLayout(false);
            panelDuration.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxTitle;
        private TextBox textBoxDescription;
        private Label labelStartDate;
        private Label labelEndDate;
        private Panel panelDuration;
        private TextBox textBoxDurationMinutes;
        private Label labelDurationHours;
        private TextBox textBoxDurationHours;
        private Label labelDurationDays;
        private TextBox textBoxDurationDays;
        private Label label5;
        private Label labelDurationMinutes;
        private Panel panelStart;
        private Label labelStartDots;
        private TextBox textBoxStartMinute;
        private TextBox textBoxStartHour;
        private TextBox textBoxStartMonth;
        private Label labelStartSpace2;
        private TextBox textBoxStartDay;
        private Label labelStartSpace;
        private TextBox textBoxStartYear;
        private Label labelStartSpace3;
        private Panel panelEnd;
        private TextBox textBoxEndYear;
        private Label labelEndSpace3;
        private TextBox textBoxEndMonth;
        private Label labelEndSpace2;
        private TextBox textBoxEndDay;
        private Label labelEndSpace;
        private TextBox textBoxEndMinute;
        private Label labelEndDots;
        private TextBox textBoxEndHour;
        private Label label1;
        private Label label2;
        private UserControls.ToDoList toDoList1;
        private CheckedListBox checkedListBoxCategories;
        private Button buttonConfirm;
    }
}
