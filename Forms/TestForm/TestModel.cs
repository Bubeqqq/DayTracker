
using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.LoginServices;
using DayTracker.Navigation;
using Npgsql.TypeMapping;
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

        public async void Login(string email, string password)
        {
            Console.WriteLine($"Login with email: {email} and password: {password}");
            Console.WriteLine($"Login result: {_loginService.ConvertLoginResultToMessage(await _loginService.Login(email, password))}");

            /*await _calendarService.Connect("Host=ep-late-moon-alrdgxm2-pooler.c-3.eu-central-1.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_2pclYXG1KhVE; SSL Mode=VerifyFull; Channel Binding=Require;");

            using (var db = _calendarService.CreateContext())
            {
                User s = new User
                {
                    FirstName = "Test",
                    LastName = "User",
                    email = "asda",
                    password = "asda"
                };

                await db.AddAsync(s);
            }

            _calendarService.Disconnect();*/
        }

        public async void Register(string email, string password, string name, string surname)
        {
            Console.WriteLine($"Register with email: {email}, password: {password}, name: {name} and surname: {surname}");
            Console.WriteLine($"Register result: {_loginService.ConvertLoginResultToMessage(await _loginService.Register(name, surname, email, password))}");
        }
    }
}
