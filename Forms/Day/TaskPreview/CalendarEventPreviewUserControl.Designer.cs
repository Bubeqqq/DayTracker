namespace DayTracker.Forms.Day
{
    partial class CalendarEventPreviewUserControl
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
            labelTitle = new Label();
            labelDescription = new Label();
            labelDelete = new Label();
            labelDidntStartToday = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(48, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Title";
            labelTitle.Click += CalendarEvent_Click;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(0, 25);
            labelDescription.MaximumSize = new Size(190, 90);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(187, 45);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            labelDescription.Click += CalendarEvent_Click;
            // 
            // labelDelete
            // 
            labelDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDelete.AutoSize = true;
            labelDelete.BackColor = Color.White;
            labelDelete.Cursor = Cursors.Hand;
            labelDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelDelete.ForeColor = Color.Red;
            labelDelete.Location = new Point(172, 6);
            labelDelete.Name = "labelDelete";
            labelDelete.Size = new Size(15, 15);
            labelDelete.TabIndex = 4;
            labelDelete.Text = "X";
            labelDelete.Click += labelDelete_Click;
            // 
            // labelDidntStartToday
            // 
            labelDidntStartToday.AutoSize = true;
            labelDidntStartToday.Location = new Point(47, 25);
            labelDidntStartToday.Name = "labelDidntStartToday";
            labelDidntStartToday.Size = new Size(120, 15);
            labelDidntStartToday.TabIndex = 6;
            labelDidntStartToday.Text = "This Event started on:";
            labelDidntStartToday.Visible = false;
            labelDidntStartToday.Click += CalendarEvent_Click;
            // 
            // TaskPreviewUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Lime;
            Controls.Add(labelDidntStartToday);
            Controls.Add(labelDelete);
            Controls.Add(labelDescription);
            Controls.Add(labelTitle);
            Name = "TaskPreviewUserControl";
            Size = new Size(190, 115);
            BackColorChanged += TaskUserControl_BackColorChanged;
            Click += CalendarEvent_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelDescription;
        private Label labelDelete;
        private Label labelDidntStartToday;
    }
}
