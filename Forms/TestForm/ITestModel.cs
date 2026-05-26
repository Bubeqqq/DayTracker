using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal interface ITestModel : IModel
    {
        void Login(string email, string password);

        void Register(string email, string password, string name, string surname);
    }
}
