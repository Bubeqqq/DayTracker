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
            Login = new Button();
            toDoList = new DayTracker.UserControls.ToDoList();
            Register = new Button();
            ImieI = new TextBox();
            emailI = new TextBox();
            nazwiskoI = new TextBox();
            hasloI = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // Login
            // 
            Login.Location = new Point(0, 0);
            Login.Margin = new Padding(3, 2, 3, 2);
            Login.Name = "Login";
            Login.Size = new Size(193, 68);
            Login.TabIndex = 0;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += button1_Click;
            // 
            // toDoList
            // 
            toDoList.Location = new Point(12, 297);
            toDoList.Margin = new Padding(3, 2, 3, 2);
            toDoList.Name = "toDoList";
            toDoList.Size = new Size(531, 121);
            toDoList.TabIndex = 1;
            // 
            // Register
            // 
            Register.Location = new Point(3, 73);
            Register.Name = "Register";
            Register.Size = new Size(190, 80);
            Register.TabIndex = 2;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = true;
            Register.Click += button2_Click;
            // 
            // ImieI
            // 
            ImieI.Location = new Point(260, 29);
            ImieI.Name = "ImieI";
            ImieI.Size = new Size(100, 23);
            ImieI.TabIndex = 3;
            // 
            // emailI
            // 
            emailI.Location = new Point(260, 112);
            emailI.Name = "emailI";
            emailI.Size = new Size(100, 23);
            emailI.TabIndex = 4;
            // 
            // nazwiskoI
            // 
            nazwiskoI.Location = new Point(260, 73);
            nazwiskoI.Name = "nazwiskoI";
            nazwiskoI.Size = new Size(100, 23);
            nazwiskoI.TabIndex = 5;
            // 
            // hasloI
            // 
            hasloI.Location = new Point(260, 154);
            hasloI.Name = "hasloI";
            hasloI.Size = new Size(100, 23);
            hasloI.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(404, 31);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 7;
            label1.Text = "Imie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 73);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 8;
            label2.Text = "Nazwisko";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(404, 120);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 9;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(404, 162);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 10;
            label4.Text = "Hasło";
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hasloI);
            Controls.Add(nazwiskoI);
            Controls.Add(emailI);
            Controls.Add(ImieI);
            Controls.Add(Register);
            Controls.Add(toDoList);
            Controls.Add(Login);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TestForm";
            Size = new Size(701, 476);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Login;
        private UserControls.ToDoList toDoList;
        private Button Register;
        private TextBox ImieI;
        private TextBox emailI;
        private TextBox nazwiskoI;
        private TextBox hasloI;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
