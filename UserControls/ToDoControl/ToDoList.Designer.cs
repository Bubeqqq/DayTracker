namespace DayTracker.UserControls
{
    partial class ToDoList
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
            MainPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.FlowDirection = FlowDirection.TopDown;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(630, 333);
            MainPanel.TabIndex = 0;
            MainPanel.WrapContents = false;
            // 
            // ToDoList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainPanel);
            Name = "ToDoList";
            Size = new Size(630, 333);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel MainPanel;
    }
}
