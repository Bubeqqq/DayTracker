using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTracker.UserControls.TestTask_usunac;
namespace DayTracker.Forms.Day
{
    internal interface IDayModel:IModel
    {
        List<List<TestTask>> CalculateColumns(List<TestTask> tasks);
        int CalculateY(DateTime date, int pixelPerHour);
        int CalculateHeight(TimeSpan duration, int pixelPerHour);
        int CalculateX(int leftMargin, int columnIndex, int taskWidth);
    }
}
