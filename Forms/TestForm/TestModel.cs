using DayTracker.Database;
using DayTracker.LoginServices;
using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DayTracker.Forms.TestForm
{
    internal class TestModel : ITestModel
    {
        private readonly ILoginService _loginService;

        public TestModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public INavigationService NavigationService { get; set; }

        public void Login(string email, string password)
        {
            Console.WriteLine($"Login with email: {email} and password: {password}");
            Console.WriteLine($"Login result: {_loginService.ConvertLoginResultToMessage(_loginService.Login(email, password))}");
        }

        public void Register(string email, string password, string name, string surname)
        {
            Console.WriteLine($"Register with email: {email}, password: {password}, name: {name} and surname: {surname}");
            Console.WriteLine($"Register result: {_loginService.ConvertLoginResultToMessage(_loginService.Register(email, password, name, surname))}");
        }
    }
}
