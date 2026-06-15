namespace CompactAppSettings
{
    partial class OptionsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanelMain = new TableLayoutPanel();
            gbOptions = new GroupBox();
            navBarVisibleCheckbox = new CheckBox();
            btnAppControl = new Button();
            lblNavBar = new Label();
            clearCalendarButton = new Button();
            clearPeopleListButton = new Button();
            gbUsers = new GroupBox();
            dgvUsers = new DataGridView();
            colEmail = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewComboBoxColumn();
            addPersonButton = new Button();
            InvitationCodeLabel = new Label();
            gbSession = new GroupBox();
            exitAppButton = new Button();
            logoutButton = new Button();
            tableLayoutPanelMain.SuspendLayout();
            gbOptions.SuspendLayout();
            gbUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            gbSession.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 3;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelMain.Controls.Add(gbOptions, 0, 0);
            tableLayoutPanelMain.Controls.Add(gbUsers, 1, 0);
            tableLayoutPanelMain.Controls.Add(gbSession, 2, 0);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.Padding = new Padding(13, 15, 13, 15);
            tableLayoutPanelMain.RowCount = 1;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(1015, 288);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // gbOptions
            // 
            gbOptions.Controls.Add(navBarVisibleCheckbox);
            gbOptions.Controls.Add(btnAppControl);
            gbOptions.Controls.Add(lblNavBar);
            gbOptions.Controls.Add(clearCalendarButton);
            gbOptions.Controls.Add(clearPeopleListButton);
            gbOptions.Dock = DockStyle.Fill;
            gbOptions.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbOptions.Location = new Point(17, 20);
            gbOptions.Margin = new Padding(4, 5, 4, 5);
            gbOptions.Name = "gbOptions";
            gbOptions.Padding = new Padding(13, 15, 13, 15);
            gbOptions.Size = new Size(239, 248);
            gbOptions.TabIndex = 0;
            gbOptions.TabStop = false;
            gbOptions.Text = "SYSTEM OPTIONS";
            // 
            // navBarVisibleCheckbox
            // 
            navBarVisibleCheckbox.AutoSize = true;
            navBarVisibleCheckbox.Location = new Point(22, 211);
            navBarVisibleCheckbox.Margin = new Padding(4, 5, 4, 5);
            navBarVisibleCheckbox.Name = "navBarVisibleCheckbox";
            navBarVisibleCheckbox.Size = new Size(67, 24);
            navBarVisibleCheckbox.TabIndex = 6;
            navBarVisibleCheckbox.Text = "Fluid";
            navBarVisibleCheckbox.UseVisualStyleBackColor = true;
            navBarVisibleCheckbox.CheckedChanged += navBarVisibleCheckbox_CheckedChanged;
            // 
            // btnAppControl
            // 
            btnAppControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAppControl.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppControl.Location = new Point(17, 446);
            btnAppControl.Margin = new Padding(4, 5, 4, 5);
            btnAppControl.Name = "btnAppControl";
            btnAppControl.Size = new Size(204, 54);
            btnAppControl.TabIndex = 5;
            btnAppControl.Text = "⚙️ Sterowanie Aplikacji";
            btnAppControl.UseVisualStyleBackColor = true;
            // 
            // lblNavBar
            // 
            lblNavBar.AutoSize = true;
            lblNavBar.Location = new Point(17, 182);
            lblNavBar.Margin = new Padding(4, 0, 4, 0);
            lblNavBar.Name = "lblNavBar";
            lblNavBar.Size = new Size(121, 20);
            lblNavBar.TabIndex = 2;
            lblNavBar.Text = "Navigation bar:";
            // 
            // clearCalendarButton
            // 
            clearCalendarButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clearCalendarButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearCalendarButton.Location = new Point(17, 112);
            clearCalendarButton.Margin = new Padding(4, 5, 4, 5);
            clearCalendarButton.Name = "clearCalendarButton";
            clearCalendarButton.Size = new Size(204, 54);
            clearCalendarButton.TabIndex = 1;
            clearCalendarButton.Text = "📅 Clear Calendar";
            clearCalendarButton.UseVisualStyleBackColor = true;
            clearCalendarButton.Click += clearCalendarButton_Click;
            // 
            // clearPeopleListButton
            // 
            clearPeopleListButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clearPeopleListButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearPeopleListButton.Location = new Point(17, 39);
            clearPeopleListButton.Margin = new Padding(4, 5, 4, 5);
            clearPeopleListButton.Name = "clearPeopleListButton";
            clearPeopleListButton.Size = new Size(204, 54);
            clearPeopleListButton.TabIndex = 0;
            clearPeopleListButton.Text = "🗑️ Clear users list";
            clearPeopleListButton.UseVisualStyleBackColor = true;
            clearPeopleListButton.Click += clearPeopleListButton_Click;
            // 
            // gbUsers
            // 
            gbUsers.Controls.Add(dgvUsers);
            gbUsers.Controls.Add(addPersonButton);
            gbUsers.Controls.Add(InvitationCodeLabel);
            gbUsers.Dock = DockStyle.Fill;
            gbUsers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbUsers.Location = new Point(264, 20);
            gbUsers.Margin = new Padding(4, 5, 4, 5);
            gbUsers.Name = "gbUsers";
            gbUsers.Padding = new Padding(13, 15, 13, 15);
            gbUsers.Size = new Size(486, 248);
            gbUsers.TabIndex = 1;
            gbUsers.TabStop = false;
            gbUsers.Text = "MANAGE USERS";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colEmail, colRole });
            dgvUsers.GridColor = Color.LightGray;
            dgvUsers.Location = new Point(17, 93);
            dgvUsers.Margin = new Padding(4, 5, 4, 5);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(452, 135);
            dgvUsers.TabIndex = 2;
            dgvUsers.CellBeginEdit += dgvUsers_CellBeginEdit;
            dgvUsers.CellMouseClick += dgvUsers_CellMouseClick;
            dgvUsers.CellValueChanged += dgvUsers_CellValueChanged;
            dgvUsers.CurrentCellDirtyStateChanged += dgvUsers_CurrentCellDirtyStateChanged;
            dgvUsers.EditingControlShowing += dgvUsers_EditingControlShowing;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.HeaderText = "E-mail";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            // 
            // colRole
            // 
            colRole.HeaderText = "Permission";
            colRole.Items.AddRange(new object[] { "Blocked", "Read Only", "Edit", "Admin" });
            colRole.MinimumWidth = 6;
            colRole.Name = "colRole";
            colRole.Resizable = DataGridViewTriState.True;
            colRole.SortMode = DataGridViewColumnSortMode.Automatic;
            colRole.Width = 150;
            // 
            // addPersonButton
            // 
            addPersonButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addPersonButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addPersonButton.Location = new Point(331, 29);
            addPersonButton.Margin = new Padding(4, 5, 4, 5);
            addPersonButton.Name = "addPersonButton";
            addPersonButton.Size = new Size(128, 54);
            addPersonButton.TabIndex = 1;
            addPersonButton.Text = "+ Invite";
            addPersonButton.UseVisualStyleBackColor = true;
            addPersonButton.Click += addPersonButton_Click;
            // 
            // InvitationCodeLabel
            // 
            InvitationCodeLabel.AutoSize = true;
            InvitationCodeLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InvitationCodeLabel.ForeColor = Color.DimGray;
            InvitationCodeLabel.Location = new Point(13, 44);
            InvitationCodeLabel.Margin = new Padding(4, 0, 4, 0);
            InvitationCodeLabel.Name = "InvitationCodeLabel";
            InvitationCodeLabel.Size = new Size(233, 24);
            InvitationCodeLabel.TabIndex = 0;
            InvitationCodeLabel.Text = "Invite Code: ABCD-1234";
            // 
            // gbSession
            // 
            gbSession.Controls.Add(exitAppButton);
            gbSession.Controls.Add(logoutButton);
            gbSession.Dock = DockStyle.Fill;
            gbSession.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbSession.Location = new Point(758, 20);
            gbSession.Margin = new Padding(4, 5, 4, 5);
            gbSession.Name = "gbSession";
            gbSession.Padding = new Padding(13, 15, 13, 15);
            gbSession.Size = new Size(240, 248);
            gbSession.TabIndex = 2;
            gbSession.TabStop = false;
            gbSession.Text = "SESSION";
            // 
            // exitAppButton
            // 
            exitAppButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            exitAppButton.FlatAppearance.BorderColor = Color.Firebrick;
            exitAppButton.FlatAppearance.BorderSize = 2;
            exitAppButton.FlatStyle = FlatStyle.Flat;
            exitAppButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitAppButton.Location = new Point(18, 151);
            exitAppButton.Margin = new Padding(4, 5, 4, 5);
            exitAppButton.Name = "exitAppButton";
            exitAppButton.Size = new Size(205, 77);
            exitAppButton.TabIndex = 1;
            exitAppButton.Text = "❌ Exit the App";
            exitAppButton.UseVisualStyleBackColor = true;
            exitAppButton.Click += exitAppButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logoutButton.FlatAppearance.BorderColor = Color.Firebrick;
            logoutButton.FlatAppearance.BorderSize = 2;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutButton.Location = new Point(17, 39);
            logoutButton.Margin = new Padding(4, 5, 4, 5);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(205, 77);
            logoutButton.TabIndex = 0;
            logoutButton.Text = "🔒 Log Out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // OptionsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanelMain);
            Margin = new Padding(4, 5, 4, 5);
            Name = "OptionsControl";
            Size = new Size(1015, 288);
            tableLayoutPanelMain.ResumeLayout(false);
            gbOptions.ResumeLayout(false);
            gbOptions.PerformLayout();
            gbUsers.ResumeLayout(false);
            gbUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            gbSession.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button clearPeopleListButton;
        private System.Windows.Forms.Button clearCalendarButton;
        private System.Windows.Forms.Label lblNavBar;
        private System.Windows.Forms.Button btnAppControl;
        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.Label InvitationCodeLabel;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox gbSession;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button exitAppButton;
        private System.Windows.Forms.CheckBox navBarVisibleCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRole;
    }
}