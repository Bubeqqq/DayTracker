using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal interface ITestView : IView
    {
        event Action OnTestButtonClicked;
        event Action OnTestButton2Clicked;

        string email { get; }
        string password { get; }
        string name { get; }
        string surname { get; }
    }
}
