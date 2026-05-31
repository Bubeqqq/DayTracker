using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTracker.UserControls.TestTask_usunac;
namespace DayTracker.Forms.Day
{
    internal class DayModel:IDayModel
    {
        public INavigationService NavigationService { get; set; }
        public DayModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public List<List<TestTask>> CalculateColumns(List<TestTask> tasks)
        {
            var sortedTasks = tasks.OrderBy(t => t.Date).ThenBy(t => t.Date.Add(t.Duration)).ToList();


            List<List<TestTask>> columns = new List<List<TestTask>>();

            foreach (var task in sortedTasks)
            {
                bool placed = false;

                foreach (var column in columns)
                {
                    if (column.Last().Date.Add(column.Last().Duration) <= task.Date)
                    {
                        column.Add(task);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    columns.Add(new List<TestTask> { task });
                }
            }
            return columns;
        }
        public int CalculateY(DateTime date,int pixelPerHour)
        {
            if (date == null)
            {
                throw new ArgumentNullException("Date can't be null");
            }
            return Convert.ToInt32(date.Hour * pixelPerHour + date.Minute * pixelPerHour / 60.0);
            
        }
        public int CalculateHeight(TimeSpan duration, int pixelPerHour)
        {
            if (duration == null)
            {
                throw new ArgumentNullException("duration can't be null");
            }
            return Convert.ToInt32(duration.TotalMinutes * pixelPerHour / 60.0);
        }
        public int CalculateX(int leftMargin ,int columnIndex,int taskWidth)
        {
            return leftMargin + columnIndex * taskWidth;
        }
    }
}
