using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.LoginServices
{
    internal interface ILoginService
    {
        int Login(string email, string password);

        int Register(string name, string surname, string email, string password);

        string ConvertLoginResultToMessage(int result);
    }
}
