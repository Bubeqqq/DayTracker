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
            Login.Name = "Login";
            Login.Size = new Size(221, 91);
            Login.TabIndex = 0;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += button1_Click;
            // 
            // toDoList
            // 
            toDoList.Location = new Point(14, 255);
            toDoList.Name = "toDoList";
            toDoList.Size = new Size(607, 361);
            toDoList.TabIndex = 1;
            // 
            // Register
            // 
            Register.Location = new Point(3, 97);
            Register.Margin = new Padding(3, 4, 3, 4);
            Register.Name = "Register";
            Register.Size = new Size(217, 107);
            Register.TabIndex = 2;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = true;
            Register.Click += button2_Click;
            // 
            // ImieI
            // 
            ImieI.Location = new Point(297, 39);
            ImieI.Margin = new Padding(3, 4, 3, 4);
            ImieI.Name = "ImieI";
            ImieI.Size = new Size(114, 27);
            ImieI.TabIndex = 3;
            // 
            // emailI
            // 
            emailI.Location = new Point(297, 149);
            emailI.Margin = new Padding(3, 4, 3, 4);
            emailI.Name = "emailI";
            emailI.Size = new Size(114, 27);
            emailI.TabIndex = 4;
            // 
            // nazwiskoI
            // 
            nazwiskoI.Location = new Point(297, 97);
            nazwiskoI.Margin = new Padding(3, 4, 3, 4);
            nazwiskoI.Name = "nazwiskoI";
            nazwiskoI.Size = new Size(114, 27);
            nazwiskoI.TabIndex = 5;
            // 
            // hasloI
            // 
            hasloI.Location = new Point(297, 205);
            hasloI.Margin = new Padding(3, 4, 3, 4);
            hasloI.Name = "hasloI";
            hasloI.Size = new Size(114, 27);
            hasloI.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(462, 41);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 7;
            label1.Text = "Imie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(462, 97);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 8;
            label2.Text = "Nazwisko";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(462, 160);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 9;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(462, 216);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 10;
            label4.Text = "Hasło";
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Name = "TestForm";
            Size = new Size(801, 635);
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
