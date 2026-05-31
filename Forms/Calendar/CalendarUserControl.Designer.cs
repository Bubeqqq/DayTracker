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
            tableLayoutPanelDaysOfWeek.SuspendLayout();
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
            tableLayoutPanelCalendar.Location = new Point(0, 56);
            tableLayoutPanelCalendar.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelCalendar.Name = "tableLayoutPanelCalendar";
            tableLayoutPanelCalendar.RowCount = 6;
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.Size = new Size(723, 811);
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
            tableLayoutPanelDaysOfWeek.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelDaysOfWeek.Name = "tableLayoutPanelDaysOfWeek";
            tableLayoutPanelDaysOfWeek.RowCount = 1;
            tableLayoutPanelDaysOfWeek.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDaysOfWeek.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanelDaysOfWeek.Size = new Size(723, 33);
            tableLayoutPanelDaysOfWeek.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(618, 3);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 6;
            label7.Text = "Sunday";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(516, 3);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 5;
            label6.Text = "Saturday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(414, 3);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Friday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 3);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 3;
            label4.Text = "Thursday";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(210, 3);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 2;
            label3.Text = "Wednesday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 3);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Tuesday";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Monday";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Dock = DockStyle.Top;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.MaximumSize = new Size(194, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(194, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // buttonNextMonth
            // 
            buttonNextMonth.Location = new Point(261, 3);
            buttonNextMonth.Margin = new Padding(3, 4, 3, 4);
            buttonNextMonth.Name = "buttonNextMonth";
            buttonNextMonth.Size = new Size(30, 31);
            buttonNextMonth.TabIndex = 3;
            buttonNextMonth.Text = ">";
            buttonNextMonth.UseVisualStyleBackColor = true;
            buttonNextMonth.Click += buttonNextMonth_Click;
            // 
            // buttonPreviousMonth
            // 
            buttonPreviousMonth.Location = new Point(224, 3);
            buttonPreviousMonth.Margin = new Padding(3, 4, 3, 4);
            buttonPreviousMonth.Name = "buttonPreviousMonth";
            buttonPreviousMonth.Size = new Size(30, 31);
            buttonPreviousMonth.TabIndex = 4;
            buttonPreviousMonth.Text = "<";
            buttonPreviousMonth.UseVisualStyleBackColor = true;
            buttonPreviousMonth.Click += buttonPreviousMonth_Click;
            // 
            // CalendarUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelCalendar);
            Controls.Add(tableLayoutPanelDaysOfWeek);
            Controls.Add(buttonNextMonth);
            Controls.Add(buttonPreviousMonth);
            Controls.Add(dateTimePicker1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CalendarUserControl";
            Size = new Size(723, 867);
            tableLayoutPanelDaysOfWeek.ResumeLayout(false);
            tableLayoutPanelDaysOfWeek.PerformLayout();
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
    }
}
