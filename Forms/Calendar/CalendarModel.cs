using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Calendar
{
    internal class CalendarModel : ICalendarModel
    {
        public INavigationService NavigationService { get; set; }

        public ILoadedDataService LoadedDataService { get; }
        private readonly IDatabaseService _databaseService;
        public bool CanModify { get; private set; }
        public CalendarModel(INavigationService navigationService, ILoadedDataService loadedDataService, IDatabaseService databaseService)
        {

            LoadedDataService = loadedDataService;
            NavigationService = navigationService;
            _databaseService = databaseService;
            CanModify = GetModifyPermission();
            LoadedDataService.OnPermissionsChanged += () =>
            {
                CanModify = GetModifyPermission();
            };


        }
        public int CalculateOffset(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek;
            if (offset == 0)
            {
                offset = 7;
            }
            offset -= 1;
            return offset;
        }
        public List<CalendarEvent> GetCalendarEvents()
        {
            return LoadedDataService.GetCalendarEvents();
        }
        public List<string> GetStringTaskList(DateTime date, List<CalendarEvent> events)
        {

            List<CalendarEvent> dailyEvents = events
                        .Where(e => e.GetLocalStartTime().Date == date.Date)
                        .ToList();
            return dailyEvents.ConvertAll(t => $"- {t.Title}");

        }
        private bool GetModifyPermission()
        {
            PermissionType currentPermission = LoadedDataService.GetCurrentPermisions();
            if (currentPermission == PermissionType.ReadOnly)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SleepSubmited()
        {
            User? user = LoadedDataService.GetCurrentUser();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            List<Sleep> sleeps = LoadedDataService.GetSleeps();
            if (sleeps.Count == 0)
            {
                return false;
            }
            Sleep latestSleep = sleeps.Where((s) => s.UserId == user.Id).ToList().MaxBy(s => s.EndTime);

            if (latestSleep.GetLocalEndTime().Date == DateTime.Now.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SleepValid(Tuple<DateTime, DateTime> sleep)
        {
            DateTime start = sleep.Item1;
            DateTime end = sleep.Item2;
            if (start > end || start == DateTime.MinValue || end == DateTime.MinValue || start >= DateTime.Now || end > DateTime.Now)
            {
                return false;
            }
            return true;
        }
        public async Task AddSleep(Tuple<DateTime, DateTime> sleep)
        {
            if (sleep != null)
            {
                DateTime start = sleep.Item1;
                DateTime end = sleep.Item2;
                User? user = LoadedDataService.GetCurrentUser();
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                Sleep newSleep = new Sleep(user.Id, start.ToUniversalTime(), end.ToUniversalTime(), user);
                await _databaseService.AddAsync(newSleep);
            }
            await Task.CompletedTask;
        }

        public async Task EditSleep(Tuple<DateTime, DateTime> sleep)
        {
            if (sleep != null)
            {
                DateTime start = sleep.Item1;
                DateTime end = sleep.Item2;
                User? user = LoadedDataService.GetCurrentUser();
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                List<Sleep> sleeps = LoadedDataService.GetSleeps();
                if (sleeps.Count == 0)
                {
                    await Task.CompletedTask;
                }
                Sleep latestSleep = sleeps.Where((s) => s.UserId == user.Id).ToList().MaxBy(s => s.EndTime);
                await _databaseService.UpdateByType<Sleep>(latestSleep.Id, (s) =>
                {
                    s.StartTime = start.ToUniversalTime();
                    s.EndTime = end.ToUniversalTime();
                    s.UserId = user.Id;
                    s.User = user;
                    s.Id = latestSleep.Id;


                });
            }
            await Task.CompletedTask;
        }
        public Tuple<DateTime, DateTime> GetLatestSleep()
        {
            User? user = LoadedDataService.GetCurrentUser();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            List<Sleep> sleeps = LoadedDataService.GetSleeps();
            if (sleeps.Count == 0)
            {
                return new Tuple<DateTime, DateTime>(DateTime.MinValue, DateTime.MinValue);
            }
            Sleep latestSleep = sleeps.Where((s) => s.UserId == user.Id).ToList().MaxBy(s => s.EndTime);
            return new Tuple<DateTime, DateTime>(latestSleep.GetLocalStartTime(), latestSleep.GetLocalEndTime());

        }
    }
    }
    
