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
using DayTracker.Forms.TaskControl;
using DayTracker.Forms.Day; 

namespace DayTracker.Tests
{
    public class TaskModelTests
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<ILoadedDataService> _mockLoadedDataService;
        private readonly Mock<IDatabaseService> _mockDatabaseService;
        private readonly TaskModel _taskModel;

        public TaskModelTests()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockLoadedDataService = new Mock<ILoadedDataService>();
            _mockDatabaseService = new Mock<IDatabaseService>();

            _mockDatabaseService.Setup(db => db.CurrentCalendarID).Returns(1);

            _taskModel = new TaskModel(
                _mockNavigationService.Object,
                _mockLoadedDataService.Object,
                _mockDatabaseService.Object
            );
        }



        [Theory]
        [InlineData("0", false)]   
        [InlineData("59", false)]  
        [InlineData("60", true)]  
        [InlineData("-1", true)]   
        [InlineData("abc", true)]  
        public void ValidateMinute_TestsVariousInputs(string minuteStr, bool expectedIsInvalid)
        {
            Assert.Equal(expectedIsInvalid, _taskModel.ValidateMinute(minuteStr));
        }

        [Theory]
        [InlineData("1", "2024", 31)] 
        [InlineData("2", "2024", 29)] 
        [InlineData("2", "2023", 28)] 
        public void TryCalculateDaysInMonth_ValidDates_ReturnsTrueAndCorrectDays(string month, string year, int expectedDays)
        {
            bool success = _taskModel.TryCalculateDaysInMonth(month, year, out int daysInMonth);

            Assert.True(success);
            Assert.Equal(expectedDays, daysInMonth);
        }

   
        [Fact]
        public void TryGetDate_ValidStrings_ReturnsTrueAndCreatesDateTime()
        {
            // Arrange
            string minute = "30", hour = "14", day = "15", month = "5", year = "2024";

            // Act
            bool success = _taskModel.TryGetDate(minute, hour, day, month, year, out DateTime resultDate);

            // Assert
            Assert.True(success);
            Assert.Equal(new DateTime(2024, 5, 15, 14, 30, 0), resultDate);
        }

        [Fact]
        public void TryGetDate_InvalidStrings_ReturnsFalse()
        {
            // Act
            bool success = _taskModel.TryGetDate("abc", "14", "15", "5", "2024", out DateTime resultDate);

            // Assert
            Assert.False(success);
            Assert.Equal(default, resultDate);
        }


        [Fact]
        public void SetEventCategories_UpdatesFlagsCorrectly()
        {
            // Arrange
            var calendarEvent = new CalendarEvent("Test", "Test", 1, DateTime.UtcNow, TimeSpan.FromHours(1));
            var checkedCategories = new List<string> { "IsSport", "IsRelax" };

            // Act
            _taskModel.SetEventCategories(checkedCategories, calendarEvent);

            // Assert
            Assert.True(calendarEvent.IsSport);
            Assert.True(calendarEvent.IsRelax);

            Assert.False(calendarEvent.IsHard);
            Assert.False(calendarEvent.IsWork);
        }



        [Fact]
        public async Task AddCalendarEvent_StartTimeNotUtc_ThrowsException()
        {
            // Arrange
            DateTime localStartTime = DateTime.Now;
            var calendarEvent = new CalendarEvent("Test", "Test", 1, localStartTime, TimeSpan.FromHours(1));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _taskModel.AddCalendarEvent(calendarEvent));
            Assert.Equal("StartTime must be in UTC", exception.Message);
        }

      

        [Fact]
        public async Task ProcessSavedChanges_AddNewEventWithoutTodo_CallsAddAndNavigates()
        {
            // Arrange
            DateTime utcStartTime = DateTime.UtcNow;
            var calendarEvent = new CalendarEvent("New Event", "Desc", 1, utcStartTime, TimeSpan.FromHours(1));

            // Act
        
            await _taskModel.ProcessSavedChanges(calendarEvent, false, "", null);

            // Assert
   
            _mockDatabaseService.Verify(db => db.AddAsync(calendarEvent), Times.Once);

            _mockDatabaseService.Verify(db => db.AddAsync(It.IsAny<TodoItem>()), Times.Never);

            _mockNavigationService.Verify(nav => nav.NavigateTo<DayPresenter, DateTime>(calendarEvent.GetLocalStartTime().Date), Times.Once);
        }

        [Fact]
        public void GetToDoDescription_ValidId_ReturnsDescription()
        {
            // Arrange
            var todoItems = new List<TodoItem>
            {
                new TodoItem("Homework", 1) { Id = 10 },
                new TodoItem("Task from work", 1) { Id = 20 }
            };
            _mockLoadedDataService.Setup(s => s.GetTodoItems()).Returns(todoItems);

            // Act
            string description = _taskModel.GetToDoDescription(20);

            // Assert
            Assert.Equal("Task from work", description);
        }
    }
}