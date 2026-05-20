using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal class TestModel : ITestModel
    {
        public INavigationService NavigationService { get; set; }

        public void Print()
        {
            Console.WriteLine("TestModel Print method called.");
        }
    }
}
