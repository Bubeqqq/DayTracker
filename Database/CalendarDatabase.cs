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

        DbSet<Sleep> Sleeps { get; set; }

        public CalendarDatabase(DbContextOptions<CalendarDatabase> options) : base(options)
        {
            
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
            Sleep? sleep = record as Sleep;
            if (sleep != null)
            {
                await Sleeps.AddAsync(sleep);
                await SaveChangesAsync();
                return;
            }

        }

        public async Task EnsureCreated()
        {
            await Database.EnsureCreatedAsync();
        }

        public async Task<List<T>?> GetType<T>() where T : class
        {
            return typeof(T) switch
            {
                Type t when t == typeof(User) => await Users.ToListAsync() as List<T>,
                Type t when t == typeof(TodoItem) => await TodoItems.ToListAsync() as List<T>,
                Type t when t == typeof(CalendarEvent) => await CalendarEvents.ToListAsync() as List<T>,
                Type t when t == typeof(Sleep) => await Sleeps.ToListAsync() as List<T>,
                _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
            };
        }
    }
}
