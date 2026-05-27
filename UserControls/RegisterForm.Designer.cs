namespace DayTracker.UserControls.ToDoControl
{
    partial class RegisterForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label6 = new Label();
            btnShowPass2 = new Button();
            btnShowPass1 = new Button();
            textBoxPass2 = new TextBox();
            label5 = new Label();
            textBoxPass = new TextBox();
            label4 = new Label();
            textBoxEmail = new TextBox();
            label3 = new Label();
            textBoxLastName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBoxName = new TextBox();
            btnRegister = new Button();
            btnLogIn = new Button();
            errorProvider = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnShowPass2);
            panel1.Controls.Add(btnShowPass1);
            panel1.Controls.Add(textBoxPass2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBoxPass);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxLastName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnLogIn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 560);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(0, 30);
            label6.Margin = new Padding(3, 30, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(400, 31);
            label6.TabIndex = 21;
            label6.Text = "Create your own account";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnShowPass2
            // 
            btnShowPass2.Anchor = AnchorStyles.Top;
            btnShowPass2.Cursor = Cursors.Hand;
            btnShowPass2.FlatAppearance.BorderSize = 0;
            btnShowPass2.FlatStyle = FlatStyle.Flat;
            btnShowPass2.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowPass2.Location = new Point(333, 341);
            btnShowPass2.Name = "btnShowPass2";
            btnShowPass2.Size = new Size(30, 30);
            btnShowPass2.TabIndex = 20;
            btnShowPass2.Text = "";
            btnShowPass2.UseVisualStyleBackColor = true;
            // 
            // btnShowPass1
            // 
            btnShowPass1.Anchor = AnchorStyles.Top;
            btnShowPass1.Cursor = Cursors.Hand;
            btnShowPass1.FlatAppearance.BorderSize = 0;
            btnShowPass1.FlatStyle = FlatStyle.Flat;
            btnShowPass1.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowPass1.Location = new Point(333, 281);
            btnShowPass1.Name = "btnShowPass1";
            btnShowPass1.Size = new Size(30, 30);
            btnShowPass1.TabIndex = 19;
            btnShowPass1.Text = "";
            btnShowPass1.UseVisualStyleBackColor = true;
            // 
            // textBoxPass2
            // 
            textBoxPass2.Anchor = AnchorStyles.Top;
            textBoxPass2.BackColor = SystemColors.Window;
            textBoxPass2.BorderStyle = BorderStyle.FixedSingle;
            textBoxPass2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxPass2, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxPass2, 4);
            textBoxPass2.Location = new Point(70, 341);
            textBoxPass2.Margin = new Padding(0, 0, 0, 30);
            textBoxPass2.Name = "textBoxPass2";
            textBoxPass2.Size = new Size(260, 30);
            textBoxPass2.TabIndex = 18;
            textBoxPass2.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(70, 321);
            label5.Margin = new Padding(10, 0, 0, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 17;
            label5.Text = "Repeat password";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxPass
            // 
            textBoxPass.Anchor = AnchorStyles.Top;
            textBoxPass.BackColor = SystemColors.Window;
            textBoxPass.BorderStyle = BorderStyle.FixedSingle;
            textBoxPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxPass, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxPass, 4);
            textBoxPass.Location = new Point(70, 281);
            textBoxPass.Margin = new Padding(0, 0, 0, 10);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(260, 30);
            textBoxPass.TabIndex = 16;
            textBoxPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(70, 261);
            label4.Margin = new Padding(10, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 15;
            label4.Text = "Password";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top;
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxEmail, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxEmail, 4);
            textBoxEmail.Location = new Point(70, 221);
            textBoxEmail.Margin = new Padding(0, 0, 0, 10);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(260, 30);
            textBoxEmail.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(70, 201);
            label3.Margin = new Padding(10, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 13;
            label3.Text = "Email";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Anchor = AnchorStyles.Top;
            textBoxLastName.BackColor = SystemColors.Window;
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxLastName, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxLastName, 4);
            textBoxLastName.Location = new Point(70, 161);
            textBoxLastName.Margin = new Padding(0, 0, 0, 10);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(260, 30);
            textBoxLastName.TabIndex = 12;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(70, 141);
            label2.Margin = new Padding(10, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 11;
            label2.Text = "Last name";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(70, 81);
            label1.Margin = new Padding(0, 20, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 10;
            label1.Text = "Name";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top;
            textBoxName.BackColor = SystemColors.Window;
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxName, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxName, 4);
            textBoxName.Location = new Point(70, 101);
            textBoxName.Margin = new Padding(0, 0, 0, 10);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(260, 30);
            textBoxName.TabIndex = 8;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top;
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnRegister.Location = new Point(70, 424);
            btnRegister.Margin = new Padding(0, 0, 0, 6);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(260, 50);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            btnLogIn.Anchor = AnchorStyles.Top;
            btnLogIn.FlatAppearance.BorderSize = 2;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnLogIn.Location = new Point(70, 480);
            btnLogIn.Margin = new Padding(0, 0, 0, 30);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(260, 50);
            btnLogIn.TabIndex = 6;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(panel1);
            Name = "RegisterForm";
            Size = new Size(400, 560);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxName;
        private Button btnRegister;
        private Button btnLogIn;
        private Label label1;
        private TextBox textBoxPass;
        private Label label4;
        private TextBox textBoxEmail;
        private Label label3;
        private TextBox textBoxLastName;
        private Label label2;
        private TextBox textBoxPass2;
        private Label label5;
        private Button btnShowPass2;
        private Button btnShowPass1;
        private Label label6;
        private ErrorProvider errorProvider;
        private Button button2;
    }
}
