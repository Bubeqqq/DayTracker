using DayTracker.Forms;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DayTracker.Forms.Day
{
    internal interface IDayModel:IModel
    {
        INavigationService NavigationService { get; set; }
        List<List<TestTask>> CalculateColumns(List<TestTask> tasks);
        int CalculateY(DateTime date, int pixelPerHour);
        int CalculateHeight(TimeSpan duration, int pixelPerHour);
        int CalculateX(int leftMargin, int columnIndex, int taskWidth);
    }
}
