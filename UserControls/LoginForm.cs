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

        public event Action? BtnLoginClicked;
        public event Action? BtnRegisterClicked;
        public LoginForm()
        {
            InitializeComponent();
            btnLogIn.Click += (s, e) => BtnLoginClicked?.Invoke();
            btnRegister.Click += (s, e) => BtnRegisterClicked?.Invoke();
        }
    }
}
