using DayTracker.Forms.RegisterForm;

namespace DayTracker.UserControls.ToDoControl
{
    public partial class RegisterForm : UserControl, IRegisterView
    {
        public string FirstName => textBoxName.Text;
        public string LastName => textBoxLastName.Text;
        public string Email => textBoxEmail.Text;
        public string Password => textBoxPass.Text;
        public string ConfirmPassword => textBoxConfirmPass.Text;

        public bool IsPasswordHidden
        {
            get => textBoxPass.UseSystemPasswordChar;
            set => textBoxPass.UseSystemPasswordChar = value;
        }
        public bool IsConfirmPasswordHidden
        {
            get => textBoxConfirmPass.UseSystemPasswordChar;
            set => textBoxConfirmPass.UseSystemPasswordChar = value;
        }

        public event Action? RegistrationRequested;
        public event Action? BtnLoginClicked;

        public event Action? BtnShowPassMouseDown;
        public event Action? BtnShowPassMouseUp;
        public event Action? BtnShowPassMouseLeave;

        public event Action? BtnShowConfirmPassMouseDown;
        public event Action? BtnShowConfirmPassMouseUp;
        public event Action? BtnShowConfirmPassMouseLeave;

        public RegisterForm()
        {
            InitializeComponent();

            btnRegister.Click += (s, e) => RegistrationRequested?.Invoke();
            btnLogIn.Click += (s, e) => BtnLoginClicked?.Invoke();

            btnShowPass.MouseDown += (s, e) => BtnShowPassMouseDown?.Invoke();
            btnShowPass.MouseUp += (s, e) => BtnShowPassMouseUp?.Invoke();
            btnShowPass.MouseLeave += (s, e) => BtnShowPassMouseLeave?.Invoke();

            btnShowConfirmPass.MouseDown += (s, e) => BtnShowConfirmPassMouseDown?.Invoke();
            btnShowConfirmPass.MouseUp += (s, e) => BtnShowConfirmPassMouseUp?.Invoke();
            btnShowConfirmPass.MouseLeave += (s, e) => BtnShowConfirmPassMouseLeave?.Invoke();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                RegistrationRequested?.Invoke();
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
                    case nameof(FirstName):
                        errorProvider.SetError(textBoxName, e.Value); break;
                    case nameof(LastName):
                        errorProvider.SetError(textBoxLastName, e.Value); break;
                    case nameof(Email):
                        errorProvider.SetError(textBoxEmail, e.Value); break;
                    case nameof(Password):
                        errorProvider.SetError(textBoxPass, e.Value); break;
                    case nameof(ConfirmPassword):
                        errorProvider.SetError(textBoxConfirmPass, e.Value); break;
                }
            }
        }
        public void ClearAllValidationErrors()
        {
            errorProvider.SetError(textBoxName, string.Empty);
            errorProvider.SetError(textBoxLastName, string.Empty);
            errorProvider.SetError(textBoxEmail, string.Empty);
            errorProvider.SetError(textBoxPass, string.Empty);
            errorProvider.SetError(textBoxConfirmPass, string.Empty);
        }
    }
}