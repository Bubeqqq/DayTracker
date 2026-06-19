namespace DayTracker.UserControls.UserBar
{
    partial class UserBarControl
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
            tableLayoutPanel = new TableLayoutPanel();
            AnalasisButton = new Button();
            backButton = new Button();
            forwardButton = new Button();
            SettingButton = new Button();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.Controls.Add(AnalasisButton, 2, 0);
            tableLayoutPanel.Controls.Add(backButton, 0, 0);
            tableLayoutPanel.Controls.Add(forwardButton, 1, 0);
            tableLayoutPanel.Controls.Add(SettingButton, 4, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1104, 422);
            tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.MouseEnter += UserBarControl_MouseEnter;
            tableLayoutPanel.MouseLeave += UserBarControl_MouseLeave;
            // 
            // AnalasisButton
            // 
            AnalasisButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            AnalasisButton.Location = new Point(215, 193);
            AnalasisButton.Name = "AnalasisButton";
            AnalasisButton.Size = new Size(47, 35);
            AnalasisButton.TabIndex = 3;
            AnalasisButton.Text = "📊";
            AnalasisButton.UseVisualStyleBackColor = true;
            AnalasisButton.Click += AnalasisButton_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            backButton.Location = new Point(3, 193);
            backButton.Name = "backButton";
            backButton.Size = new Size(100, 35);
            backButton.TabIndex = 0;
            backButton.Text = "BACK";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // forwardButton
            // 
            forwardButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            forwardButton.Location = new Point(109, 193);
            forwardButton.Name = "forwardButton";
            forwardButton.Size = new Size(100, 35);
            forwardButton.TabIndex = 1;
            forwardButton.Text = "FORWARD";
            forwardButton.UseVisualStyleBackColor = true;
            forwardButton.Click += forwardButton_Click;
            // 
            // SettingButton
            // 
            SettingButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SettingButton.Font = new Font("Segoe UI", 10.6F, FontStyle.Bold);
            SettingButton.Location = new Point(1069, 193);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(32, 35);
            SettingButton.TabIndex = 2;
            SettingButton.Text = "⚙️";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // UserBarControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "UserBarControl";
            Size = new Size(1104, 422);
            MouseEnter += UserBarControl_MouseEnter;
            MouseLeave += UserBarControl_MouseLeave;
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button backButton;
        private Button forwardButton;
        private Button SettingButton;
        private Button AnalasisButton;
    }
}
