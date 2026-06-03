
using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayTracker.HabitAnalysis
{
    internal class AnalysisService : IAnalysisService
    {
        
        public AnalysisService()
        {
            
        }

        
        public async Task<DashboardData> AnalyzeHabitsAsync()
        {
            var dashboard = new DashboardData();

            /*if (!_calendarService.IsConnected)
                return dashboard;

            using (var db = _calendarService.CreateContext())
            {
                var calendarEvents = await db.GetType<CalendarEvent>();
                var sleepRecords = await db.GetType<Sleep>();
                var todoItems = await db.GetType<TodoItem>();*/


            DateTime dzisiaj = DateTime.Today;

            // --- 1. MOCK: ZADANIA TODO ---
            var todoItems = new List<TodoItem>
{
    new TodoItem(1, "Skończyć projekt WinForms", "Dodać wykresy"),
    new TodoItem(2, "Zrobić zakupy", "Mleko, chleb, jajka"),
    new TodoItem(3, "Trening siłowy", "Klatka i triceps"),
    new TodoItem(4, "Napisać raport", "Raport miesięczny")
};

            // --- 2. MOCK: SEN ---
            var sleepRecords = new List<Sleep>
{
    // Normalny sen (8h)
    new Sleep { Id = 1, StartTime = dzisiaj.AddDays(-3).AddHours(23), EndTime = dzisiaj.AddDays(-2).AddHours(7) },
    // Normalny sen (7h)
    new Sleep { Id = 2, StartTime = dzisiaj.AddDays(-2).AddHours(23), EndTime = dzisiaj.AddDays(-1).AddHours(6) },
    // Normalny sen (7h)
    new Sleep { Id = 3, StartTime = dzisiaj.AddDays(-1).AddHours(22), EndTime = dzisiaj.AddHours(5) },
    
    // ANOMALIA 1: Użytkownik spał tylko 3 godziny (Wykres pokaże mocny dołek)
    new Sleep { Id = 4, StartTime = dzisiaj.AddHours(1), EndTime = dzisiaj.AddHours(4) },
    
    // ANOMALIA 2: Użytkownik nie kliknął "Zakończ sen" i spał 26 godzin
    new Sleep { Id = 5, StartTime = dzisiaj.AddDays(-4).AddHours(20), EndTime = dzisiaj.AddDays(-3).AddHours(22) }
};

            // --- 3. MOCK: WYDARZENIA Z KALENDARZA ---
            var calendarEvents = new List<CalendarEvent>
{
    // Praca (część połączona z zadaniami Todo)
    new CalendarEvent { Id = 1, StartTime = dzisiaj.AddDays(-2).AddHours(9), Duration = TimeSpan.FromHours(8), IsWork = true, TodoId = 1 },
    new CalendarEvent { Id = 2, StartTime = dzisiaj.AddDays(-1).AddHours(10), Duration = TimeSpan.FromHours(6), IsWork = true },
    new CalendarEvent { Id = 3, StartTime = dzisiaj.AddHours(8), Duration = TimeSpan.FromHours(4), IsWork = true, TodoId = 4 },
    
    // Edukacja
    new CalendarEvent { Id = 4, StartTime = dzisiaj.AddDays(-2).AddHours(18), Duration = TimeSpan.FromHours(2), IsEducation = true },
    
    // Sport i czas na zewnątrz
    new CalendarEvent { Id = 5, StartTime = dzisiaj.AddDays(-1).AddHours(17), Duration = TimeSpan.FromHours(1.5), IsSport = true, IsOutdoor = true },
    new CalendarEvent { Id = 6, StartTime = dzisiaj.AddHours(16), Duration = TimeSpan.FromHours(1.5), IsSport = true, TodoId = 3 },
    
    // Relaks
    new CalendarEvent { Id = 7, StartTime = dzisiaj.AddDays(-1).AddHours(20), Duration = TimeSpan.FromHours(2), IsRelax = true },
    new CalendarEvent { Id = 8, StartTime = dzisiaj.AddHours(19), Duration = TimeSpan.FromHours(3), IsRelax = true },
    
    // ANOMALIA 3: Zagięcie czasoprzestrzeni (Ten dzień ma zarejestrowane 8h pracy + 26h snu z rekordu wyżej)
    new CalendarEvent { Id = 9, StartTime = dzisiaj.AddDays(-3).AddHours(10), Duration = TimeSpan.FromHours(8), IsWork = true }
};

            foreach (var s in sleepRecords)
                {
                    double hours = (s.EndTime - s.StartTime).TotalHours;

                    if (hours < 0 || hours > 24)
                    {
                        dashboard.Anomalies.Add($"Anomalia Snu (ID: {s.Id}): Nieprawidłowy czas trwania ({hours:F1}h).");
                        continue;
                    }

                    var date = s.EndTime.Date;
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

                foreach (var ev in calendarEvents)
                {
                    double duration = ev.Duration.TotalHours;
                    var eventDate = ev.StartTime.Date;

                    if (duration < 0)
                    {
                        dashboard.Anomalies.Add($"Anomalia Wydarzenia (ID: {ev.Id}): Ujemny czas trwania.");
                        continue;
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

                    if (totalLoggedHours > 24.1)
                    {
                        dashboard.Anomalies.Add($"Zagięcie czasoprzestrzeni ({date:dd.MM.yyyy}): Zarejestrowano {totalLoggedHours:F1} godzin w ciągu jednej doby!");
                    }
                }

                return dashboard;
            //}
        }
    }

    public class DashboardData
    {
        public Dictionary<DateTime, double> SleepHoursPerDay { get; set; } = new();

        public Dictionary<string, double> TotalTimePerCategory { get; set; } = new();

        public Dictionary<DateTime, int> TodosCompletedPerDay { get; set; } = new();

        public List<string> Anomalies { get; set; } = new();
    }
}