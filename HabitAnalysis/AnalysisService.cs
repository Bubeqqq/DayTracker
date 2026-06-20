
using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayTracker.HabitAnalysis
{
    internal class AnalysisService : IAnalysisService
    {
        
        private readonly ILoadedDataService _loadedDataService;

        public AnalysisService(ILoadedDataService loadedDataService)
        {
            _loadedDataService = loadedDataService;
        }

        
        public DashboardData AnalyzeHabits()
        {
            var dashboard = new DashboardData();


            foreach (var s in _loadedDataService.GetSleeps())
            {
                Console.WriteLine(s.StartTime);

                double hours = (s.GetLocalEndTime() - s.GetLocalStartTime()).TotalHours;

                if (hours < 0 || hours > 24)
                {
                    Console.WriteLine($"{hours} <==== {s.GetLocalEndTime()} -- {s.GetLocalStartTime()}");
                    continue;
                }

                var date = s.GetLocalEndTime().Date;
                if (!dashboard.SleepHoursPerDay.ContainsKey(date))
                    dashboard.SleepHoursPerDay[date] = 0;

                dashboard.SleepHoursPerDay[date] += hours;
            }

            dashboard.TotalTimePerCategory.Add("Praca", 0);
            dashboard.TotalTimePerCategory.Add("Edukacja", 0);
            dashboard.TotalTimePerCategory.Add("Sport", 0);
            dashboard.TotalTimePerCategory.Add("Relaks", 0);
            dashboard.TotalTimePerCategory.Add("Na zewnątrz", 0);

            var dailyActivityTime = new Dictionary<DateTime, double>();

            foreach (var ev in _loadedDataService.GetCalendarEvents())
            {
                double duration = ev.Duration.TotalHours;
                var eventDate = ev.GetLocalStartTime().Date;

                if (duration < 0)
                {
                    continue;
                }

                if (ev.IsSport || ev.IsOutdoor)
                {
                    if (!dashboard.SportAndOutdoorHoursPerDay.ContainsKey(eventDate))
                        dashboard.SportAndOutdoorHoursPerDay[eventDate] = 0;

                    dashboard.SportAndOutdoorHoursPerDay[eventDate] += duration;
                }

                if (!dailyActivityTime.ContainsKey(eventDate)) dailyActivityTime[eventDate] = 0;
                dailyActivityTime[eventDate] += duration;

                if (ev.IsWork) dashboard.TotalTimePerCategory["Praca"] += duration;
                if (ev.IsEducation) dashboard.TotalTimePerCategory["Edukacja"] += duration;
                if (ev.IsSport) dashboard.TotalTimePerCategory["Sport"] += duration;
                if (ev.IsRelax) dashboard.TotalTimePerCategory["Relaks"] += duration;
                if (ev.IsOutdoor) dashboard.TotalTimePerCategory["Na zewnątrz"] += duration;

                if (ev.TodoId.HasValue)
                {
                    if (!dashboard.TodosCompletedPerDay.ContainsKey(eventDate))
                        dashboard.TodosCompletedPerDay[eventDate] = 0;

                    dashboard.TodosCompletedPerDay[eventDate]++;
                }
            }

            foreach (var date in dailyActivityTime.Keys)
            {
                double sleepHours = dashboard.SleepHoursPerDay.ContainsKey(date) ? dashboard.SleepHoursPerDay[date] : 0;
                double totalLoggedHours = dailyActivityTime[date] + sleepHours;
            }

            return dashboard;
        }
    }

    public class DashboardData
    {
        public Dictionary<DateTime, double> SleepHoursPerDay { get; set; } = new();

        public Dictionary<string, double> TotalTimePerCategory { get; set; } = new();

        public Dictionary<DateTime, int> TodosCompletedPerDay { get; set; } = new();

        public Dictionary<DateTime, double> SportAndOutdoorHoursPerDay { get; set; } = new();
    }
}