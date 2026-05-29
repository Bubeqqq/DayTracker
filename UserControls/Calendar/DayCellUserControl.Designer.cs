namespace WinFormsApp1
{
    partial class DayCellUserControl
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
            labelDayNumber = new Label();
            listBoxTasks = new ListBox();
            SuspendLayout();
            // 
            // labelDayNumber
            // 
            labelDayNumber.AutoSize = true;
            labelDayNumber.BackColor = Color.Transparent;
            labelDayNumber.Dock = DockStyle.Top;
            labelDayNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDayNumber.ImageAlign = ContentAlignment.TopRight;
            labelDayNumber.Location = new Point(0, 0);
            labelDayNumber.Name = "labelDayNumber";
            labelDayNumber.Size = new Size(22, 17);
            labelDayNumber.TabIndex = 0;
            labelDayNumber.Text = "00";
            labelDayNumber.Click += DayCell_Click;
            // 
            // listBoxTasks
            // 
            listBoxTasks.BackColor = SystemColors.Control;
            listBoxTasks.Dock = DockStyle.Fill;
            listBoxTasks.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.ItemHeight = 20;
            listBoxTasks.Location = new Point(0, 17);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.SelectionMode = SelectionMode.None;
            listBoxTasks.Size = new Size(143, 105);
            listBoxTasks.TabIndex = 1;
            listBoxTasks.Click += DayCell_Click;
            // 
            // DayCellUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(listBoxTasks);
            Controls.Add(labelDayNumber);
            Name = "DayCellUserControl";
            Size = new Size(143, 122);
            Click += DayCell_Click;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label labelDayNumber;
        private ListBox listBoxTasks;
    }
}
