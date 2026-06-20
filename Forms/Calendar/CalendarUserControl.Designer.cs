namespace DayTracker.Forms.Calendar
{
    partial class CalendarUserControl
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
            tableLayoutPanelCalendar = new TableLayoutPanel();
            tableLayoutPanelDaysOfWeek = new TableLayoutPanel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            buttonNextMonth = new Button();
            buttonPreviousMonth = new Button();
            buttonAddEvent = new Button();
            buttonEditSleep = new Button();
            panel1 = new Panel();
            tableLayoutPanelDaysOfWeek.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelCalendar
            // 
            tableLayoutPanelCalendar.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            tableLayoutPanelCalendar.ColumnCount = 7;
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanelCalendar.Dock = DockStyle.Fill;
            tableLayoutPanelCalendar.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelCalendar.Location = new Point(0, 48);
            tableLayoutPanelCalendar.Name = "tableLayoutPanelCalendar";
            tableLayoutPanelCalendar.RowCount = 6;
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.Size = new Size(633, 602);
            tableLayoutPanelCalendar.TabIndex = 0;
            // 
            // tableLayoutPanelDaysOfWeek
            // 
            tableLayoutPanelDaysOfWeek.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            tableLayoutPanelDaysOfWeek.ColumnCount = 7;
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanelDaysOfWeek.Controls.Add(label7, 6, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label6, 5, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label5, 4, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label4, 3, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label3, 2, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label2, 1, 0);
            tableLayoutPanelDaysOfWeek.Controls.Add(label1, 0, 0);
            tableLayoutPanelDaysOfWeek.Dock = DockStyle.Top;
            tableLayoutPanelDaysOfWeek.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelDaysOfWeek.Location = new Point(0, 23);
            tableLayoutPanelDaysOfWeek.Name = "tableLayoutPanelDaysOfWeek";
            tableLayoutPanelDaysOfWeek.RowCount = 1;
            tableLayoutPanelDaysOfWeek.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDaysOfWeek.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanelDaysOfWeek.Size = new Size(633, 25);
            tableLayoutPanelDaysOfWeek.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(546, 3);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 6;
            label7.Text = "Sunday";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(456, 3);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 5;
            label6.Text = "Saturday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(366, 3);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 4;
            label5.Text = "Friday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(276, 3);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 3;
            label4.Text = "Thursday";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(186, 3);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 2;
            label3.Text = "Wednesday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 3);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Tuesday";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Monday";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Dock = DockStyle.Left;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.MaximumSize = new Size(170, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // buttonNextMonth
            // 
            buttonNextMonth.Dock = DockStyle.Left;
            buttonNextMonth.Location = new Point(196, 0);
            buttonNextMonth.Name = "buttonNextMonth";
            buttonNextMonth.Size = new Size(26, 23);
            buttonNextMonth.TabIndex = 3;
            buttonNextMonth.Text = ">";
            buttonNextMonth.UseVisualStyleBackColor = true;
            buttonNextMonth.Click += buttonNextMonth_Click;
            // 
            // buttonPreviousMonth
            // 
            buttonPreviousMonth.Dock = DockStyle.Left;
            buttonPreviousMonth.Location = new Point(170, 0);
            buttonPreviousMonth.Name = "buttonPreviousMonth";
            buttonPreviousMonth.Size = new Size(26, 23);
            buttonPreviousMonth.TabIndex = 4;
            buttonPreviousMonth.Text = "<";
            buttonPreviousMonth.UseVisualStyleBackColor = true;
            buttonPreviousMonth.Click += buttonPreviousMonth_Click;
            // 
            // buttonAddEvent
            // 
            buttonAddEvent.Dock = DockStyle.Right;
            buttonAddEvent.Location = new Point(558, 0);
            buttonAddEvent.Name = "buttonAddEvent";
            buttonAddEvent.Size = new Size(75, 23);
            buttonAddEvent.TabIndex = 5;
            buttonAddEvent.Text = "Add Event";
            buttonAddEvent.UseVisualStyleBackColor = true;
            buttonAddEvent.Click += buttonAddEvent_Click;
            // 
            // buttonEditSleep
            // 
            buttonEditSleep.Dock = DockStyle.Right;
            buttonEditSleep.Location = new Point(483, 0);
            buttonEditSleep.Name = "buttonEditSleep";
            buttonEditSleep.Size = new Size(75, 23);
            buttonEditSleep.TabIndex = 6;
            buttonEditSleep.Text = "Edit Sleep";
            buttonEditSleep.UseVisualStyleBackColor = true;
            buttonEditSleep.Click += buttonEditSleep_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonEditSleep);
            panel1.Controls.Add(buttonAddEvent);
            panel1.Controls.Add(buttonNextMonth);
            panel1.Controls.Add(buttonPreviousMonth);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(0, 23);
            panel1.MinimumSize = new Size(0, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 23);
            panel1.TabIndex = 7;
            // 
            // CalendarUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelCalendar);
            Controls.Add(tableLayoutPanelDaysOfWeek);
            Controls.Add(panel1);
            Name = "CalendarUserControl";
            Size = new Size(633, 650);
            Load += CalendarUserControl_Load;
            tableLayoutPanelDaysOfWeek.ResumeLayout(false);
            tableLayoutPanelDaysOfWeek.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelCalendar;
        private TableLayoutPanel tableLayoutPanelDaysOfWeek;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Button buttonNextMonth;
        private Button buttonPreviousMonth;
        private Button buttonAddEvent;
        private Button buttonEditSleep;
        private Panel panel1;
    }
}
