using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using DayTracker.Navigation;
namespace DayTracker.Forms.Day
{
    internal class DayModel : IDayModel
    {
        public ILoadedDataService LoadedDataService { get; }
        private readonly IDatabaseService _databaseService;

        public INavigationService NavigationService { get; set; }
        private Color blue1;
        private Color blue2;
        private Color blue3;
        private Color blue4;

        private Color green1;
        private Color green2;
        private Color green3;
        private Color green4;
        public DayModel(INavigationService navigationService, ILoadedDataService loadedDataService, IDatabaseService databaseService)
        {
            LoadedDataService = loadedDataService;
            NavigationService = navigationService;
            _databaseService = databaseService;

            blue1 = Color.FromArgb(41, 128, 185);
            blue2 = Color.FromArgb(52, 152, 219);
            blue3 = Color.FromArgb(93, 173, 226);
            blue4 = Color.FromArgb(133, 193, 233);

            green1 = Color.FromArgb(39, 174, 96);
            green2 = Color.FromArgb(46, 204, 113);
            green3 = Color.FromArgb(88, 214, 141);
            green4 = Color.FromArgb(130, 224, 170);
        }
        public List<CalendarEvent> GetEventsForDay(DateTime date)
        {
            date = date.Date;
            List<CalendarEvent> events = LoadedDataService.GetCalendarEvents();


            return events.Where(e => e.StartTime < date.AddDays(1) && e.StartTime.Add(e.Duration) > date).ToList();
        }
        public List<List<CalendarEvent>> CalculateColumns(List<CalendarEvent> events)
        {
            var sortedEvents = events.OrderBy(e => e.StartTime).ThenBy(e => e.StartTime.Add(e.Duration)).ToList();


            List<List<CalendarEvent>> columns = new List<List<CalendarEvent>>();

            foreach (var calendarEvent in sortedEvents)
            {
                bool placed = false;

                foreach (var column in columns)
                {
                    if (column.Last().StartTime.Add(column.Last().Duration) <= calendarEvent.StartTime)
                    {
                        column.Add(calendarEvent);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    columns.Add(new List<CalendarEvent> { calendarEvent });
                }
            }
            return columns;
        }
        public int CalculateY(DateTime startTime, int pixelPerHour, DateTime date)
        {

            if (date.Date > startTime)
            {
                return 0;
            }

            return Convert.ToInt32(startTime.Hour * pixelPerHour + startTime.Minute * pixelPerHour / 60.0);

        }
        public int CalculateHeight(DateTime startTime, TimeSpan duration, int pixelPerHour, DateTime date)
        {

            DateTime taskEnd = startTime.Add(duration);

            // 2. Definiujemy ramy czasowe widoku dnia
            DateTime dayStart = date.Date; // Wyzerowana godzina (00:00:00)
            DateTime dayEnd = dayStart.AddDays(1); // Początek następnego dnia

            // 3. Obliczamy punkt początkowy i końcowy w obrębie tego konkretnego dnia
            // (Wybieramy późniejszy start i wcześniejszy koniec)
            DateTime overlapStart = startTime > dayStart ? startTime : dayStart;
            DateTime overlapEnd = taskEnd < dayEnd ? taskEnd : dayEnd;

            // 4. Obliczamy faktyczny czas trwania zadania w tym dniu
            TimeSpan effectiveDuration = overlapEnd - overlapStart;

            // 5. Jeśli przedział jest ujemny lub zerowy, zadanie nie wyświetla się w tym dniu
            if (effectiveDuration <= TimeSpan.Zero)
            {
                return 0;
            }

            // 6. Przeliczamy czas na piksele
            return Convert.ToInt32(effectiveDuration.TotalMinutes * pixelPerHour / 60.0);
          
        }
        public int CalculateX(int leftMargin, int columnIndex, int taskWidth)
        {
            return leftMargin + columnIndex * taskWidth;
        }
        public CalendarEvent CreateDefualutCalendarEvent(DateTime date)
        {
            CalendarEvent calendarEvent = new CalendarEvent("Title", "Description", _databaseService.CurrentCalendarID, date.Date, new TimeSpan(1, 1, 1, 0));

            return calendarEvent;
        }
        public Color GetEventColor(CalendarEvent calendarEvent)
        {
            if (calendarEvent.IsHard)
            {
                if (IsFun(calendarEvent) && (calendarEvent.IsWork || calendarEvent.IsEducation))
                {
                    return blue3;
                }
                else if (IsFun(calendarEvent))
                {
                    return blue4;
                }
                else if (calendarEvent.IsWork || calendarEvent.IsEducation)
                {
                    return blue1;
                }
                else
                {
                    return blue2;
                }
            }
            else
            {
                if (IsFun(calendarEvent) && (calendarEvent.IsWork || calendarEvent.IsEducation))
                {
                    return green3;
                }
                else if (IsFun(calendarEvent))
                {
                    return green4;
                }
                else if (calendarEvent.IsWork || calendarEvent.IsEducation)
                {
                    return green1;
                }
                else
                {
                    return green2;
                }
            }
        }
        private bool IsFun(CalendarEvent calendarEvent)
        {
            if (calendarEvent.IsOutdoor || calendarEvent.IsSport || calendarEvent.IsRelax)
            {
                return true;
            }
            return false;
        }
        public async Task DeleteCalendarEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent.Todo != null)
            {
                await DeleteToDoItem(calendarEvent.Todo);
            }
            await _databaseService.RemoveByType<CalendarEvent>(calendarEvent.Id);
        }
        private async Task DeleteToDoItem(TodoItem todoItem)
        {
            await _databaseService.RemoveByType<TodoItem>(todoItem.Id);
        }
        public bool CanModify()
        {
            return true;
            //return _loadedDataService.CanModify();
        }
    }
}
