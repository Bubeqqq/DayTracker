using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DayTracker.Database;
using DayTracker.Database.Datatypes;

namespace DayTracker.Tests.Database
{
    public class DatabaseServiceTests : IDisposable
    {
        private readonly DatabaseService _dbContext;

        public DatabaseServiceTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseService>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new DatabaseService(options);
            _dbContext.CurrentCalendarID = 1;
        }

        [Fact]
        public async Task AddAsync_AddsRecordSuccessfully()
        {
            var record = new TodoItem("Test Todo", 1);
            
            var result = await _dbContext.AddAsync(record);

            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal(1, await _dbContext.Set<TodoItem>().CountAsync());
        }

        [Fact]
        public async Task AddUserAsync_AddsUserCreatesCalendarAndInvitationCode()
        {
            var user = new User("John", "Doe") ;

            await _dbContext.AddUserAsync(user);

            Assert.True(user.Id > 0);
            Assert.True(user.CalendarId > 0);
            Assert.NotEmpty(user.invitationCode);
        }

        [Fact]
        public async Task GetUsersAsync_ReturnsFilteredUsers()
        {
            await _dbContext.AddUserAsync(new User("Alice") );
            await _dbContext.AddUserAsync(new User("Bob") );

            var result = await _dbContext.GetUsersAsync(u => u.FirstName == "Alice");

            Assert.Single(result);
            Assert.Equal("Alice", result.First().FirstName);
        }

        [Fact]
        public async Task GetType_ReturnsRecords()
        {
            var todo = new TodoItem("Task 1", 1);
            await _dbContext.AddAsync(todo);

            var result = await _dbContext.GetType<TodoItem>();

            Assert.Single(result);
            Assert.Equal("Task 1", result.First().Description);
        }

        [Fact]
        public async Task RemoveByType_ByIndex_RemovesRecord()
        {
            var todo = new TodoItem("Task to remove", 1);
            await _dbContext.AddAsync(todo);

            await ((IDatabaseService)_dbContext).RemoveByType<TodoItem>(todo.Id);

            Assert.Empty(await _dbContext.Set<TodoItem>().ToListAsync());
        }

        [Fact]
        public async Task UpdateByType_ByIndex_UpdatesRecordSuccessfully()
        {
            var todo = new TodoItem("Old Description", 1);
            await _dbContext.AddAsync(todo);

            await ((IDatabaseService)_dbContext).UpdateByType<TodoItem>(todo.Id, t => t.Description = "New Description");

            var updated = await _dbContext.Set<TodoItem>().FindAsync(todo.Id);
            Assert.Equal("New Description", updated.Description);
        }

        [Fact]
        public async Task LoadUserPermissions_ReturnsCorrectPermission()
        {
            var permission = new Permission(2,1, PermissionType.Edit);
            await _dbContext.AddAsync(permission);

            var result = await _dbContext.LoadUserPermissions(2, 1);

            Assert.Equal(PermissionType.Edit, result);
        }

        [Fact]
        public async Task LoadUserPermissions_NoPermissions_ReturnsBlocked()
        {
            var result = await _dbContext.LoadUserPermissions(99, 99);

            Assert.Equal(PermissionType.Blocked, result);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}