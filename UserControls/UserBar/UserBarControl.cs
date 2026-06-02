using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.UserControls.UserBar
{
    public partial class UserBarControl : UserControl
    {
        public event Action BackButtonClicked;
        public event Action ForwardButtonClicked;

        public event Action MouseEnterUserBar;
        public event Action MouseLeaveUserBar;

        public UserBarControl()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            ForwardButtonClicked?.Invoke();
        }

        public void SetForwardButtonEnable(bool enable)
        {
            forwardButton.Enabled = enable;
        }

        public void SetBackButtonEnable(bool enable)
        {
            backButton.Enabled = enable;
        }

        private void UserBarControl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterUserBar?.Invoke();
        }

        private void UserBarControl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveUserBar?.Invoke();
        }
    }
}
