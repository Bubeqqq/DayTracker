using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace DayTracker.Forms.Calendar
{
    internal class CalendarModel:ICalendarModel
    {
        public INavigationService NavigationService { get; set; }
        public CalendarModel() { }
        public int CalculateOffset(DateTime date)
        {
            if(date == null)
            {
                throw new ArgumentNullException("Date can't be null");
            }
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek;
            if (offset == 0)
            {
                offset = 7;
            }
            offset -= 1;
            return offset; 
        }
        public List<string> GetStringTaskList(List<TestTask> tasks, DateTime date) 
        {
            if (date == null)
            {
                throw new ArgumentNullException("Date can't be null");
            }
            List<TestTask> dailyTasks = tasks
                        .Where(t => t.Date.Date == date.Date)
                        .Take(3)
                        .ToList();
            List<string> tasksStr = dailyTasks.ConvertAll(t => $"- {t.ToString()}");
            return tasksStr;
        }
    }
}
