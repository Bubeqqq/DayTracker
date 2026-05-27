using DayTracker.Database.Datatypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal class CalendarDatabase : DbContext, ICalendarDatabase
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

        public async Task AddAsync<T>(T record)
        {
            User? user = record as User;
            if (user != null)
            {
                await Users.AddAsync(user);
                await SaveChangesAsync();
                return;
            }
            TodoItem? todoItem = record as TodoItem;
            if (todoItem != null)
            {
                await TodoItems.AddAsync(todoItem);
                await SaveChangesAsync();
                return;
            }
            CalendarEvent? calendarEvent = record as CalendarEvent;
            if (calendarEvent != null)
            {
                await CalendarEvents.AddAsync(calendarEvent);
                await SaveChangesAsync();
                return;
            }
        }

        public async Task EnsureCreated()
        {
            await Database.EnsureCreatedAsync();
        }
    }
}
