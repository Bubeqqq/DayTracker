namespace DayTracker.Forms.SelectCalendarForm
{
    partial class SelectCalendarForm
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
            btnYourCalendar = new Button();
            splitter1 = new Splitter();
            comboBoxSelectCalendar = new ComboBox();
            labelGreeting = new Label();
            textBoxInviteCode = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnSubmitCode = new Button();
            btnSubmitSelectedCalendar = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnYourCalendar
            // 
            btnYourCalendar.Anchor = AnchorStyles.None;
            btnYourCalendar.FlatAppearance.BorderSize = 2;
            btnYourCalendar.FlatStyle = FlatStyle.Flat;
            btnYourCalendar.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnYourCalendar.Location = new Point(160, 149);
            btnYourCalendar.Margin = new Padding(20, 50, 20, 50);
            btnYourCalendar.Name = "btnYourCalendar";
            btnYourCalendar.Size = new Size(300, 50);
            btnYourCalendar.TabIndex = 28;
            btnYourCalendar.Text = "Your own calendar";
            btnYourCalendar.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 500);
            splitter1.TabIndex = 29;
            splitter1.TabStop = false;
            // 
            // comboBoxSelectCalendar
            // 
            comboBoxSelectCalendar.Anchor = AnchorStyles.None;
            comboBoxSelectCalendar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBoxSelectCalendar.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBoxSelectCalendar, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(comboBoxSelectCalendar, 4);
            comboBoxSelectCalendar.Location = new Point(160, 292);
            comboBoxSelectCalendar.Margin = new Padding(3, 3, 3, 40);
            comboBoxSelectCalendar.Name = "comboBoxSelectCalendar";
            comboBoxSelectCalendar.Size = new Size(217, 28);
            comboBoxSelectCalendar.TabIndex = 30;
            // 
            // labelGreeting
            // 
            labelGreeting.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelGreeting.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGreeting.Location = new Point(10, 30);
            labelGreeting.Margin = new Padding(3, 30, 3, 0);
            labelGreeting.Name = "labelGreeting";
            labelGreeting.Size = new Size(607, 31);
            labelGreeting.TabIndex = 31;
            labelGreeting.Text = "Hello [firstName]!";
            labelGreeting.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxInviteCode
            // 
            textBoxInviteCode.Anchor = AnchorStyles.None;
            textBoxInviteCode.BackColor = SystemColors.Window;
            textBoxInviteCode.BorderStyle = BorderStyle.FixedSingle;
            textBoxInviteCode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            errorProvider.SetIconAlignment(textBoxInviteCode, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetIconPadding(textBoxInviteCode, 4);
            textBoxInviteCode.Location = new Point(160, 400);
            textBoxInviteCode.Margin = new Padding(0, 0, 0, 10);
            textBoxInviteCode.Name = "textBoxInviteCode";
            textBoxInviteCode.Size = new Size(217, 27);
            textBoxInviteCode.TabIndex = 33;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(160, 269);
            label3.Margin = new Padding(0, 20, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(185, 20);
            label3.TabIndex = 34;
            label3.Text = "Calendars shared with you:";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(160, 380);
            label1.Margin = new Padding(0, 20, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(180, 20);
            label1.TabIndex = 35;
            label1.Text = "Join using invitation code:";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(10, 71);
            label2.Margin = new Padding(0, 10, 0, 50);
            label2.Name = "label2";
            label2.Size = new Size(432, 28);
            label2.TabIndex = 36;
            label2.Text = "Select the calendar which you would like to use:";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // btnSubmitCode
            // 
            btnSubmitCode.Anchor = AnchorStyles.None;
            btnSubmitCode.FlatAppearance.BorderSize = 2;
            btnSubmitCode.FlatStyle = FlatStyle.Flat;
            btnSubmitCode.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnSubmitCode.Location = new Point(387, 393);
            btnSubmitCode.Margin = new Padding(10, 50, 20, 50);
            btnSubmitCode.Name = "btnSubmitCode";
            btnSubmitCode.Size = new Size(73, 38);
            btnSubmitCode.TabIndex = 37;
            btnSubmitCode.Text = "Submit";
            btnSubmitCode.UseVisualStyleBackColor = true;
            // 
            // btnSubmitSelectedCalendar
            // 
            btnSubmitSelectedCalendar.Anchor = AnchorStyles.None;
            btnSubmitSelectedCalendar.FlatAppearance.BorderSize = 2;
            btnSubmitSelectedCalendar.FlatStyle = FlatStyle.Flat;
            btnSubmitSelectedCalendar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSubmitSelectedCalendar.Location = new Point(387, 286);
            btnSubmitSelectedCalendar.Margin = new Padding(10, 50, 20, 50);
            btnSubmitSelectedCalendar.Name = "btnSubmitSelectedCalendar";
            btnSubmitSelectedCalendar.Size = new Size(73, 38);
            btnSubmitSelectedCalendar.TabIndex = 38;
            btnSubmitSelectedCalendar.Text = "Select";
            btnSubmitSelectedCalendar.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // SelectCalendarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnSubmitSelectedCalendar);
            Controls.Add(btnSubmitCode);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(textBoxInviteCode);
            Controls.Add(labelGreeting);
            Controls.Add(comboBoxSelectCalendar);
            Controls.Add(splitter1);
            Controls.Add(btnYourCalendar);
            MinimumSize = new Size(620, 500);
            Name = "SelectCalendarForm";
            Size = new Size(620, 500);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnYourCalendar;
        private Splitter splitter1;
        private ComboBox comboBoxSelectCalendar;
        private Label labelGreeting;
        private TextBox textBoxInviteCode;
        private Label label3;
        private Label label1;
        private Label label2;
        private Button btnSubmitCode;
        private Button btnSubmitSelectedCalendar;
        private ErrorProvider errorProvider;
    }
}
