namespace DayTracker.Forms.Day { 
    partial class DayUserControl
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
            buttonAddEvent = new Button();
            buttonGoCalendar = new Button();
            panel1 = new Panel();
            labelDate = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAddEvent
            // 
            buttonAddEvent.Dock = DockStyle.Left;
            buttonAddEvent.Location = new Point(163, 0);
            buttonAddEvent.MaximumSize = new Size(0, 23);
            buttonAddEvent.Name = "buttonAddEvent";
            buttonAddEvent.Size = new Size(112, 23);
            buttonAddEvent.TabIndex = 0;
            buttonAddEvent.Text = "Add Event";
            buttonAddEvent.UseVisualStyleBackColor = true;
            buttonAddEvent.Click += buttonAddEvent_Click;
            // 
            // buttonGoCalendar
            // 
            buttonGoCalendar.Dock = DockStyle.Left;
            buttonGoCalendar.Location = new Point(53, 0);
            buttonGoCalendar.Name = "buttonGoCalendar";
            buttonGoCalendar.Size = new Size(110, 23);
            buttonGoCalendar.TabIndex = 1;
            buttonGoCalendar.Text = "Back to calendar";
            buttonGoCalendar.UseVisualStyleBackColor = true;
            buttonGoCalendar.Click += buttonGoCalendar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAddEvent);
            panel1.Controls.Add(buttonGoCalendar);
            panel1.Controls.Add(labelDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(0, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(1130, 23);
            panel1.TabIndex = 2;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Dock = DockStyle.Left;
            labelDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            labelDate.Location = new Point(0, 0);
            labelDate.MaximumSize = new Size(0, 23);
            labelDate.MinimumSize = new Size(0, 23);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(53, 23);
            labelDate.TabIndex = 2;
            labelDate.Text = "label1";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DayUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1490);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "DayUserControl";
            Size = new Size(1130, 657);
            ClientSizeChanged += DayUserControl_ClientSizeChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAddEvent;
        private Button buttonGoCalendar;
        private Panel panel1;
        private Label labelDate;
    }
}
