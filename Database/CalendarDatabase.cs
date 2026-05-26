using DayTracker.Database.Datatypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal class CalendarDatabase : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<CalendarEvent> CalendarEvents { get; set; }

        public CalendarDatabase(DbContextOptions<CalendarDatabase> options) : base(options)
        {
            
        }

        public async Task<List<T>> ExecuteRawSqlSelectAsync<T>(string sqlQuery) where T : class
        {
            return await Set<T>().FromSqlRaw(sqlQuery).ToListAsync();
        }

        public async Task<int> ExecuteRawSqlCommandAsync(string sqlCommand)
        {
            return await Database.ExecuteSqlRawAsync(sqlCommand);
        }
    }
}
