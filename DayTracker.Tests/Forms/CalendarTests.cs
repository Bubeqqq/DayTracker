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
using DayTracker.Forms.Calendar;
namespace DayTracker.Tests.Forms
{
    public class CalendarModelTests
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<ILoadedDataService> _mockLoadedDataService;
        private readonly Mock<IDatabaseService> _mockDatabaseService;
        private readonly CalendarModel _calendarModel;

        public CalendarModelTests()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockLoadedDataService = new Mock<ILoadedDataService>();
            _mockDatabaseService = new Mock<IDatabaseService>();
            _calendarModel = new CalendarModel(
                _mockNavigationService.Object,
                _mockLoadedDataService.Object,
                _mockDatabaseService.Object
            );
        }

        [Fact]
        public void CalculateOffset_MonthStartingOnMonday_ReturnsZero()
        {
            // Arrange
            DateTime testDate = new DateTime(2023, 5, 15);

            // Act
            int offset = _calendarModel.CalculateOffset(testDate);

            // Assert
            Assert.Equal(0, offset);
        }

        [Fact]
        public void CalculateOffset_MonthStartingOnSunday_ReturnsSix()
        {
            // Arrange
            DateTime testDate = new DateTime(2023, 10, 10);

            // Act
            int offset = _calendarModel.CalculateOffset(testDate);

            // Assert
            Assert.Equal(6, offset);
        }

        [Theory]
        [InlineData("2024", false)] 
        [InlineData("2000", false)] 
        [InlineData("2100", false)] 
        [InlineData("1999", true)]  
        [InlineData("2101", true)]  
        [InlineData("abc", true)]   
        public void ValidateYear_TestsVariousInputs(string yearStr, bool expectedResult)
        {
            // Act
            bool result = _calendarModel.ValidateYear(yearStr);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetModifyPermission_ReadOnly_ReturnsFalse()
        {
            // Arrange
            _mockLoadedDataService.Setup(s => s.GetCurrentPermisions())
                .Returns(PermissionType.ReadOnly);

            // Act
            bool result = _calendarModel.GetModifyPermission();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetModifyPermission_Admin_ReturnsTrue()
        {
            // Arrange
            _mockLoadedDataService.Setup(s => s.GetCurrentPermisions())
                .Returns(PermissionType.Admin);

            // Act
            bool result = _calendarModel.GetModifyPermission();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SleepValid_ValidSleep_ReturnsTrue()
        {
            // Arrange
            DateTime start = DateTime.Now.AddHours(-8);
            DateTime end = DateTime.Now.AddHours(-1);
            var sleep = new Tuple<DateTime, DateTime>(start, end);

            // Act
            bool result = _calendarModel.SleepValid(sleep);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SleepValid_StartAfterEnd_ReturnsFalse()
        {
            // Arrange
            DateTime start = DateTime.Now.AddHours(-1);
            DateTime end = DateTime.Now.AddHours(-8);
            var sleep = new Tuple<DateTime, DateTime>(start, end);

            // Act
            bool result = _calendarModel.SleepValid(sleep);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SleepValid_FutureDates_ReturnsFalse()
        {
            // Arrange
            DateTime start = DateTime.Now.AddHours(1);
            DateTime end = DateTime.Now.AddHours(8);
            var sleep = new Tuple<DateTime, DateTime>(start, end);

            // Act
            bool result = _calendarModel.SleepValid(sleep);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetStringTaskList_FiltersAndFormatsCorrectly()
        {
            // Arrange
            DateTime targetDate = new DateTime(2023, 1, 1);

            var events = new List<CalendarEvent>
    {
        new CalendarEvent("Event 1", "Desc 1", 1, targetDate.ToUniversalTime(), TimeSpan.FromHours(1)),
        new CalendarEvent("Event 2", "Desc 2", 1, targetDate.AddHours(2).ToUniversalTime(), TimeSpan.FromHours(1)),
        new CalendarEvent("Event for different day", "Desc 3", 1, targetDate.AddDays(1).ToUniversalTime(), TimeSpan.FromHours(1))
    };

            // Act
            var result = _calendarModel.GetStringTaskList(targetDate, events);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("- Event 1", result);
            Assert.Contains("- Event 2", result);
            Assert.DoesNotContain("- Event for different day", result);
        }

        [Fact]
        public async Task DeleteCalendarEvent_DeletesEventAndTodo_WhenTodoIdIsNotNull()
        {
            // Arrange

            var calendarEvent = new CalendarEvent(
                title: "TestEvent",
                description: "TestDesc",
                calendarId: 1,
                startTime: DateTime.UtcNow,
                duration: TimeSpan.FromHours(1),
                todoId: 5, // Parametr powiązany z TodoItem
                id: 10     // Parametr ID zdarzenia
            );

            // Act
            await _calendarModel.DeleteCalendarEvent(calendarEvent);

            // Assert
 
            _mockDatabaseService.Verify(db => db.RemoveByType<CalendarEvent>(10), Times.Once);

 
            _mockDatabaseService.Verify(db => db.RemoveByType<TodoItem>(5), Times.Once);
        }

        [Fact]
        public async Task AddSleep_ValidUserAndDates_CallsDatabaseService()
        {
            // Arrange
            DateTime start = DateTime.Now.AddHours(-8);
            DateTime end = DateTime.Now.AddHours(-1);
            var sleepTuple = new Tuple<DateTime, DateTime>(start, end);

  
            var mockUser = new User("TestUser") { Id = 1};
            _mockLoadedDataService.Setup(s => s.GetCurrentUser()).Returns(mockUser);

            // Act
            await _calendarModel.AddSleep(sleepTuple);

            // Assert
            _mockDatabaseService.Verify(
                db => db.AddAsync(It.Is<Sleep>(s => s.UserId == mockUser.Id && s.StartTime == start.ToUniversalTime())),
                Times.Once
            );
        }

        
    }
}