namespace DayTracker.UserControls
{
    partial class LoginForm
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
            label6 = new Label();
            textBoxPass = new TextBox();
            label4 = new Label();
            textBoxEmail = new TextBox();
            label3 = new Label();
            btnRegister = new Button();
            btnLogIn = new Button();
            btnShowPass1 = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(0, 40);
            label6.Margin = new Padding(3, 30, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(400, 31);
            label6.TabIndex = 26;
            label6.Text = "Log in to your account";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPass
            // 
            textBoxPass.Anchor = AnchorStyles.Top;
            textBoxPass.BackColor = SystemColors.Window;
            textBoxPass.BorderStyle = BorderStyle.FixedSingle;
            textBoxPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxPass.Location = new Point(70, 171);
            textBoxPass.Margin = new Padding(0, 0, 0, 50);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(260, 30);
            textBoxPass.TabIndex = 25;
            textBoxPass.UseSystemPasswordChar = true;
            textBoxPass.TextChanged += textBoxPass_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(70, 151);
            label4.Margin = new Padding(10, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 24;
            label4.Text = "Password";
            label4.TextAlign = ContentAlignment.BottomLeft;
            label4.Click += this.label4_Click;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top;
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxEmail.Location = new Point(70, 111);
            textBoxEmail.Margin = new Padding(0, 0, 0, 10);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(260, 30);
            textBoxEmail.TabIndex = 23;
            textBoxEmail.TextChanged += this.textBoxEmail_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(70, 91);
            label3.Margin = new Padding(0, 20, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 22;
            label3.Text = "Email";
            label3.TextAlign = ContentAlignment.BottomLeft;
            label3.Click += this.label3_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top;
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnRegister.Location = new Point(70, 311);
            btnRegister.Margin = new Padding(0, 0, 0, 30);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(260, 50);
            btnRegister.TabIndex = 28;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            btnLogIn.Anchor = AnchorStyles.Top;
            btnLogIn.FlatAppearance.BorderSize = 2;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnLogIn.Location = new Point(70, 251);
            btnLogIn.Margin = new Padding(0, 0, 0, 6);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(260, 50);
            btnLogIn.TabIndex = 27;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = true;
            // 
            // btnShowPass1
            // 
            btnShowPass1.Anchor = AnchorStyles.Top;
            btnShowPass1.Cursor = Cursors.Hand;
            btnShowPass1.FlatAppearance.BorderSize = 0;
            btnShowPass1.FlatStyle = FlatStyle.Flat;
            btnShowPass1.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowPass1.Location = new Point(333, 171);
            btnShowPass1.Name = "btnShowPass1";
            btnShowPass1.Size = new Size(30, 30);
            btnShowPass1.TabIndex = 29;
            btnShowPass1.Text = "";
            btnShowPass1.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnShowPass1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogIn);
            Controls.Add(label6);
            Controls.Add(textBoxPass);
            Controls.Add(label4);
            Controls.Add(textBoxEmail);
            Controls.Add(label3);
            Name = "LoginForm";
            Size = new Size(400, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private TextBox textBoxPass;
        private Label label4;
        private TextBox textBoxEmail;
        private Label label3;
        private Button btnRegister;
        private Button btnLogIn;
        private Button btnShowPass1;
    }
}
