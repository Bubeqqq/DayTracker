using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Windows.Forms;

namespace CompactAppSettings
{
    public partial class OptionsControl : UserControl
    {

        public event Action OnLogoutRequested;
        public event Action OnExitRequested;

        public event Action OnClearListRequested;
        public event Action OnCalendarResetRequested;

        public event Action<bool> OnBarVisibilityChanged;

        public event Action<string, string, string> OnPermissionChanged;
        public event Action<string, string> OnUserAdded;
        public event Action<string> OnUserRemoved;

        private string _oldEmailValue = null;

        public OptionsControl()
        {
            InitializeComponent();
        }

        public void HidePermissions()
        {
            dgvUsers.Enabled = false;
            addPersonButton.Enabled = false;
            clearPeopleListButton.Enabled = false;
            clearCalendarButton.Enabled = false;
            InvitationCodeLabel.Enabled = false;

            dgvUsers.Visible = false;
            addPersonButton.Visible = false;
            clearPeopleListButton.Visible = false;
            clearCalendarButton.Visible = false;
            InvitationCodeLabel.Visible = false;
        }

        public void ClearRows()
        {
            dgvUsers.Rows.Clear();
        }
        public void AddRow(string email, string permission)
        {
            dgvUsers.Rows.Add(email, permission);
        }

        public void SetInvitationCode(string code)
        {
            InvitationCodeLabel.Text = "Invite Code: " + code;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            OnLogoutRequested?.Invoke();
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            OnExitRequested?.Invoke();
        }

        private void clearPeopleListButton_Click(object sender, EventArgs e)
        {
            for (int i = dgvUsers.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvUsers.Rows[i].Cells[1].Value?.ToString() != "Admin")
                {
                    dgvUsers.Rows.RemoveAt(i);
                }
            }

            OnClearListRequested?.Invoke();
        }

        private void clearCalendarButton_Click(object sender, EventArgs e)
        {
            OnCalendarResetRequested?.Invoke();
        }

        private void navBarVisibleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            OnBarVisibilityChanged?.Invoke(navBarVisibleCheckbox.Checked);
        }

        private bool isValidEmail(string email)
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.Cells[0].Value?.ToString() == email)
                {
                    return false;
                }
            }

            return true;
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            int i = 1;

            while (!isValidEmail("Email" + i))
            {
                i++;
            }

            dgvUsers.Rows.Add("Email" + i, "Blocked");
            OnUserAdded?.Invoke("Email" + i, "Blocked");
        }

        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;

            if (y < 0 || x < 0)
            {
                return;
            }

            string? email = dgvUsers.Rows[y].Cells[0].Value?.ToString();
            string? role = dgvUsers.Rows[y].Cells[1].Value?.ToString();

            if (email == null || role == null)
            {
                return;
            }

            OnPermissionChanged?.Invoke(email, role, _oldEmailValue);
        }

        private void dgvUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvUsers.IsCurrentCellDirty && dgvUsers.CurrentCell is DataGridViewComboBoxCell)
            {
                dgvUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvUsers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _oldEmailValue = dgvUsers.Rows[e.RowIndex].Cells[0].Value?.ToString();
            }

                string currentValue = dgvUsers.Rows[e.RowIndex].Cells[1].Value?.ToString();

                if (currentValue == "Admin")
                {
                    e.Cancel = true;
                }
        }

        private void dgvUsers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvUsers.CurrentCell.OwningColumn.Name == "colRole" && e.Control is ComboBox comboBox)
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(new object[] { "Blocked", "Read Only", "Edit" });
            }
        }

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string? email = dgvUsers.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    string? role = dgvUsers.Rows[e.RowIndex].Cells[1].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
                        return;

                    if (role == "Admin")
                        return;

                    OnUserRemoved(email);
                    dgvUsers.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}