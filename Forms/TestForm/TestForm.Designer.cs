namespace DayTracker.Forms.TestForm
{
    partial class TestForm
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
            button1 = new Button();
            toDoList = new DayTracker.UserControls.ToDoList();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(318, 68);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // toDoList
            // 
            toDoList.Location = new Point(12, 107);
            toDoList.Margin = new Padding(3, 2, 3, 2);
            toDoList.Name = "toDoList";
            toDoList.Size = new Size(531, 311);
            toDoList.TabIndex = 1;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(toDoList);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TestForm";
            Size = new Size(701, 476);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private UserControls.ToDoList toDoList;
    }
}
