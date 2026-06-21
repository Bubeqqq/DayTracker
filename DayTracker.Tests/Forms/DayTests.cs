using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using DayTracker.Database;
using DayTracker.Database.Datatypes;
using DayTracker.LoadedData;
using DayTracker.Navigation;
using DayTracker.Forms.Day;

namespace DayTracker.Tests
{
    public class DayModelTests
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<ILoadedDataService> _mockLoadedDataService;
        private readonly Mock<IDatabaseService> _mockDatabaseService;
        private readonly DayModel _dayModel;

        public DayModelTests()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockLoadedDataService = new Mock<ILoadedDataService>();
            _mockDatabaseService = new Mock<IDatabaseService>();

            _dayModel = new DayModel(
                _mockNavigationService.Object,
                _mockLoadedDataService.Object,
                _mockDatabaseService.Object
            );
        }

        [Fact]
        public void CalculateY_EventStartsToday_ReturnsCorrectYCoordinate()
        {
            // Arrange
            DateTime date = new DateTime(2023, 10, 10);
            DateTime startTime = new DateTime(2023, 10, 10, 8, 30, 0); // 08:30
            int pixelsPerHour = 60;

            // Act
            int y = _dayModel.CalculateY(startTime, pixelsPerHour, date);

            // Assert
            // 8 hours * 60px + 30 minutes * (60px / 60) = 480 + 30 = 510
            Assert.Equal(510, y);
        }

        [Fact]
        public void CalculateY_EventStartedPreviousDay_ReturnsZero()
        {
            // Arrange
            DateTime date = new DateTime(2023, 10, 10);
            DateTime startTime = new DateTime(2023, 10, 9, 22, 0, 0); // started yesterday
            int pixelsPerHour = 60;

            // Act
            int y = _dayModel.CalculateY(startTime, pixelsPerHour, date);

            // Assert
            // 
            Assert.Equal(0, y);
        }

        [Fact]
        public void CalculateHeight_EventFullyWithinDay_ReturnsCorrectHeight()
        {
            // Arrange
            DateTime date = new DateTime(2023, 10, 10);
            DateTime startTime = new DateTime(2023, 10, 10, 10, 0, 0);
            TimeSpan duration = TimeSpan.FromHours(2); // 
            int pixelsPerHour = 60;

            // Act
            int height = _dayModel.CalculateHeight(startTime, duration, pixelsPerHour, date);

            // Assert
            // 2 hours ==120 minutes. 120 minutes * (60px / 60) = 120px
            Assert.Equal(120, height);
        }

        [Fact]
        public void CalculateHeight_EventCrossesToNextDay_ClampsHeightToMidnight()
        {
            // Arrange
            DateTime date = new DateTime(2023, 10, 10);
            DateTime startTime = new DateTime(2023, 10, 10, 23, 0, 0); // 23:00
            TimeSpan duration = TimeSpan.FromHours(3); // Lasts till 02:00 the next day
            int pixelsPerHour = 60;

            // Act
            int height = _dayModel.CalculateHeight(startTime, duration, pixelsPerHour, date);

            // Assert
            // Only 1 hour-> 60px
            Assert.Equal(60, height);
        }

        [Fact]
        public void CalculateX_CalculatesCorrectly()
        {
            // Act
            int x = _dayModel.CalculateX(leftMargin: 50, columnIndex: 2, taskWidth: 100);

            // Assert
            // 50 + 2 * 100 = 250
            Assert.Equal(250, x);
        }

        [Fact]
        public void CalculateColumns_OverlappingEvents_PlacesInSeparateColumns()
        {
            // Arrange
            var events = new List<CalendarEvent>
            {
                new CalendarEvent("Event 1", "", 1, DateTime.UtcNow, TimeSpan.FromHours(2)),
                // Event 2 overlaps with Event 1
                new CalendarEvent("Event 2", "", 1, DateTime.UtcNow.AddHours(1), TimeSpan.FromHours(2)),
                // Event 3 overlaps with Event 2, but not with Event 1
                new CalendarEvent("Event 3", "", 1, DateTime.UtcNow.AddHours(2.5), TimeSpan.FromHours(1))
            };

            // Act
            var columns = _dayModel.CalculateColumns(events);

            // Assert
            Assert.Equal(2, columns.Count); 
            Assert.Equal(2, columns[0].Count); 
            Assert.Single(columns[1]);        
        }

        [Fact]
        public void GetModifyPermission_ReturnsCorrectValues()
        {
            // Arrange - ReadOnly
            _mockLoadedDataService.Setup(s => s.GetCurrentPermisions()).Returns(PermissionType.ReadOnly);
            Assert.False(_dayModel.GetModifyPermission());

            // Arrange - Modify 
            _mockLoadedDataService.Setup(s => s.GetCurrentPermisions()).Returns(PermissionType.Edit); 
            Assert.True(_dayModel.GetModifyPermission());
        }

        [Fact]
        public async Task DeleteCalendarEvent_CallsDatabaseServiceCorrectly()
        {
            // Arrange
            var calendarEvent = new CalendarEvent(
                title: "Test",
                description: "Test",
                calendarId: 1,
                startTime: DateTime.UtcNow,
                duration: TimeSpan.FromHours(1),
                todoId: 99,
                id: 42
            );

            // Act
            await _dayModel.DeleteCalendarEvent(calendarEvent);

            // Assert
            _mockDatabaseService.Verify(db => db.RemoveByType<CalendarEvent>(42), Times.Once);
            _mockDatabaseService.Verify(db => db.RemoveByType<TodoItem>(99), Times.Once);
        }

        [Theory]
        [InlineData(true, false, false, false, false, false, 52, 152, 219)]   // IsHard only -> blue2
        [InlineData(true, false, false, true, false, false, 41, 128, 185)]    // IsHard, IsWork -> blue1
        [InlineData(true, true, false, false, false, false, 133, 193, 233)]   // IsHard, IsOutdoor IsFun -> blue4
        [InlineData(true, true, false, true, false, false, 93, 173, 226)]     // IsHard, IsOutdoor, IsWork -> blue3
        [InlineData(false, false, false, false, false, false, 46, 204, 113)]  // !IsHard -> green2
        [InlineData(false, true, false, false, false, false, 130, 224, 170)]  // !IsHard, IsOutdoor -> green4
        [InlineData(false, false, false, true, false, false, 39, 174, 96)]    // !IsHard, IsWork -> green1
        public void GetEventColor_ReturnsCorrectColorBasedOnFlags(
            bool isHard, bool isOutdoor, bool isSport, bool isWork, bool isRelax, bool isEducation,
            int expectedR, int expectedG, int expectedB)
        {
            // Arrange
            var calendarEvent = new CalendarEvent(
                title: "Test",
                description: "",
                calendarId: 1,
                startTime: DateTime.Now,
                duration: TimeSpan.FromHours(1),
                isHard: isHard,
                isOutdoor: isOutdoor,
                isSport: isSport,
                isWork: isWork,
                isRelax: isRelax,
                isEducation: isEducation
            );

            // Act
            var color = _dayModel.GetEventColor(calendarEvent);

            // Assert

            Assert.Equal(expectedR, color.R);
            Assert.Equal(expectedG, color.G);
            Assert.Equal(expectedB, color.B);
        }
    }
}