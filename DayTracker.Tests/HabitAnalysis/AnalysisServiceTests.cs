using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using DayTracker.HabitAnalysis;
using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;

namespace DayTracker.Tests.HabitAnalysis
{
    public class AnalysisServiceTests
    {
        private readonly Mock<ILoadedDataService> _mockDataService;
        private readonly AnalysisService _analysisService;

        public AnalysisServiceTests()
        {
            _mockDataService = new Mock<ILoadedDataService>();
            _analysisService = new AnalysisService(_mockDataService.Object);
        }

        [Fact]
        public void AnalyzeHabits_ValidSleep_CalculatesSleepHours()
        {
            var sleep = new Sleep(1, new DateTime(2024, 1, 1, 22, 0, 0), new DateTime(2024, 1, 2, 6, 0, 0));
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep> { sleep });
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent>());

            var result = _analysisService.AnalyzeHabits();

            Assert.Equal(8.0, result.SleepHoursPerDay[new DateTime(2024, 1, 2)]);
        }

        [Fact]
        public void AnalyzeHabits_InvalidSleep_IgnoresOutliers()
        {
            var sleepTooLong = new Sleep(1, new DateTime(2024, 1, 1, 0, 0, 0), new DateTime(2024, 1, 3, 6, 0, 0));
            var sleepNegative = new Sleep(1, new DateTime(2024, 1, 2, 6, 0, 0), new DateTime(2024, 1, 1, 22, 0, 0));
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep> { sleepTooLong, sleepNegative });
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent>());

            var result = _analysisService.AnalyzeHabits();

            Assert.Empty(result.SleepHoursPerDay);
        }

        [Fact]
        public void AnalyzeHabits_ValidEvents_CalculatesCategoriesCorrectly()
        {
            var workEvent = new CalendarEvent("Work", "", 1, DateTime.Today, TimeSpan.FromHours(4), isWork: true, isHard: false);
            var relaxEvent = new CalendarEvent("Relax", "", 1, DateTime.Today, TimeSpan.FromHours(2), isRelax: true, isHard: false);
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep>());
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent> { workEvent, relaxEvent });

            var result = _analysisService.AnalyzeHabits();

            Assert.Equal(4.0, result.TotalTimePerCategory["Praca"]);
            Assert.Equal(2.0, result.TotalTimePerCategory["Relaks"]);
            Assert.Equal(0.0, result.TotalTimePerCategory["Edukacja"]);
        }

        [Fact]
        public void AnalyzeHabits_SportAndOutdoorEvents_CalculatesSportAndOutdoorHours()
        {
            var date = DateTime.Today;
            var sportEvent = new CalendarEvent("Gym", "", 1, date, TimeSpan.FromHours(1.5), isSport: true, isHard: false);
            var outdoorEvent = new CalendarEvent("Walk", "", 1, date, TimeSpan.FromHours(1.0), isOutdoor: true, isHard: false);
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep>());
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent> { sportEvent, outdoorEvent });

            var result = _analysisService.AnalyzeHabits();

            Assert.Equal(2.5, result.SportAndOutdoorHoursPerDay[date]);
        }

        [Fact]
        public void AnalyzeHabits_EventWithTodo_CountsCompletedTodos()
        {
            var date = DateTime.Today;
            var eventWithTodo = new CalendarEvent("Task", "", 1, date, TimeSpan.FromHours(1), todoId: 99, isHard: false);
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep>());
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent> { eventWithTodo });

            var result = _analysisService.AnalyzeHabits();

            Assert.Equal(1, result.TodosCompletedPerDay[date]);
        }

        [Fact]
        public void AnalyzeHabits_NegativeDurationEvent_IsIgnored()
        {
            var negativeEvent = new CalendarEvent("Error", "", 1, DateTime.Today, TimeSpan.FromHours(-2), isWork: true, isHard: false);
            _mockDataService.Setup(m => m.GetSleeps()).Returns(new List<Sleep>());
            _mockDataService.Setup(m => m.GetCalendarEvents()).Returns(new List<CalendarEvent> { negativeEvent });

            var result = _analysisService.AnalyzeHabits();

            Assert.Equal(0.0, result.TotalTimePerCategory["Praca"]);
        }
    }
}