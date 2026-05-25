using DayTracker.Database;
using DayTracker.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TestForm
{
    internal class TestModel : ITestModel
    {
        public INavigationService NavigationService { get; set; }

        private readonly IDatabaseService _databaseService;

        public TestModel(IDatabaseService databaseService) 
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        }
        public async Task PrintAsync()
        {
            Console.WriteLine("TestModel Print method called.");

            /*string sql = "INSERT INTO \"CalendarEvents\" (\"StartTime\", \"Duration\", \"UserId\", \"ActionId\", \"IsHard\", \"IsOutdoor\", \"IsSport\") " +
                 "VALUES ('2026-05-21 16:55:08', '10:00:00', null, null, false, false, false);";

            try
            {
                await _databaseService.ExecuteRawSqlCommandAsync(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL command: {ex.Message}");
            }*/
        }
    }
}
