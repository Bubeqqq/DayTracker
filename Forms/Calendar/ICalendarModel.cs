using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Calendar
{
    internal interface ICalendarModel:IModel
    {
        ILoadedDataService LoadedDataService { get; }
        INavigationService NavigationService { get; set; }
        bool CanModify { get; }
        int CalculateOffset(DateTime date);
        List<string> GetStringTaskList(DateTime date, List<CalendarEvent> events);
            List<CalendarEvent> GetCalendarEvents();
        bool SleepSubmited();
        Task AddSleep(Tuple<DateTime, DateTime> sleep);
        Task EditSleep(Tuple<DateTime, DateTime> sleep);
        bool SleepValid(Tuple<DateTime, DateTime> sleep);
        Tuple<DateTime, DateTime> GetLatestSleep();
    }
}
