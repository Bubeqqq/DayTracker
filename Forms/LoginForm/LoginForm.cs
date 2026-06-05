using DayTracker.Forms.LoginForm;

namespace DayTracker.UserControls
{
    public partial class LoginForm : UserControl, ILoginView
    {
        public string Email => textBoxEmail.Text;

        public string Password => textBoxPass.Text;

        public bool IsPasswordHidden
        {
            get => textBoxPass.UseSystemPasswordChar;
            set => textBoxPass.UseSystemPasswordChar = value;
        }

        public event Action? LoginRequested;
        public event Action? BtnRegisterClicked;
        public event Action? BtnShowPassMouseDown;
        public event Action? BtnShowPassMouseUp;
        public event Action? BtnShowPassMouseLeave;

        public LoginForm()
        {
            InitializeComponent();
            
            btnLogIn.Click += (s, e) => LoginRequested?.Invoke();
            btnRegister.Click += (s, e) => BtnRegisterClicked?.Invoke();
            btnShowPass.MouseLeave += (s, e) => BtnShowPassMouseLeave?.Invoke();
            btnShowPass.MouseDown += (s, e) => BtnShowPassMouseDown?.Invoke();
            btnShowPass.MouseUp += (s, e) => BtnShowPassMouseUp?.Invoke();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                LoginRequested?.Invoke();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ShowValidationErrors(Dictionary<string, string> errors)
        {
            foreach (var e in errors)
            {
                switch (e.Key)
                {
                    case nameof(Email):
                        errorProvider.SetError(textBoxEmail, e.Value); break;
                    case nameof(Password):
                        errorProvider.SetError(textBoxPass, e.Value); break;
                }
            }
        }
        public void ClearAllValidationErrors()
        {
            errorProvider.SetError(textBoxEmail, string.Empty);
            errorProvider.SetError(textBoxPass, string.Empty);
        }
    }
}
