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
            SuspendLayout();
            // 
            // buttonAddEvent
            // 
            buttonAddEvent.Dock = DockStyle.Top;
            buttonAddEvent.Location = new Point(0, 0);
            buttonAddEvent.MaximumSize = new Size(0, 23);
            buttonAddEvent.Name = "buttonAddEvent";
            buttonAddEvent.Size = new Size(1198, 23);
            buttonAddEvent.TabIndex = 0;
            buttonAddEvent.Text = "Add Event";
            buttonAddEvent.UseVisualStyleBackColor = true;
            buttonAddEvent.Click += buttonAddEvent_Click;
            // 
            // DayUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1490);
            Controls.Add(buttonAddEvent);
            DoubleBuffered = true;
            Name = "DayUserControl";
            Size = new Size(1198, 657);
            ClientSizeChanged += DayUserControl_ClientSizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAddEvent;
    }
}
