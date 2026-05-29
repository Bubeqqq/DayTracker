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

        public event Action? BtnRegisterClicked;
        public event Action? BtnLoginClicked;

        public RegisterForm()
        {
            InitializeComponent();
            btnRegister.Click += (s, e) => BtnRegisterClicked?.Invoke();
            btnLogIn.Click += (s, e) => BtnLoginClicked?.Invoke();
        }
    }
}