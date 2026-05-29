using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Calendar
{
    internal interface ICalendarModel:IModel
    {
        int CalculateOffset(DateTime date);
        List<string> GetStringTaskList(List<TestTask> tasks, DateTime date);
    }
}
