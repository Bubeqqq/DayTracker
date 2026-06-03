using DayTracker.Database.Datatypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal class DatabaseService : DbContext, IDatabaseService
    {
        DbSet<User> Users { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<CalendarEvent> CalendarEvents { get; set; }

        DbSet<Sleep> Sleeps { get; set; }

        DbSet<Permission> Permissions { get; set; }

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {

        }

        public async Task AddAsync<T>(T record) where T : class, ICalendarRecord
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(TodoItem):
                    await TodoItems.AddAsync(record as TodoItem);
                    break;
                case Type t when t == typeof(CalendarEvent):
                    await CalendarEvents.AddAsync(record as CalendarEvent);
                    break;
                case Type t when t == typeof(Sleep):
                    await Sleeps.AddAsync(record as Sleep);
                    break;
                case Type t when t == typeof(Permission):
                    await Permissions.AddAsync(record as Permission);
                    break;
            }
            ;

            await SaveChangesAsync();
        }

        public async Task AddUserAsync(User record)
        {
            await Users.AddAsync(record);
            await SaveChangesAsync();
        }

        public async Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate)
        {
            return await Users.Where(predicate).ToListAsync();
        }

        public async Task EnsureCreated()
        {
            await Database.EnsureCreatedAsync();
        }

        public async Task<List<T>> GetType<T>() where T : class, ICalendarRecord
        {
            return typeof(T) switch
            {
                Type t when t == typeof(TodoItem) => await TodoItems.ToListAsync() as List<T>,
                Type t when t == typeof(CalendarEvent) => await CalendarEvents.ToListAsync() as List<T>,
                Type t when t == typeof(Sleep) => await Sleeps.ToListAsync() as List<T>,
                Type t when t == typeof(Permission) => await Permissions.ToListAsync() as List<T>,
                _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
            };
        }

        public async Task<List<T>> GetType<T>(Expression<Func<T, bool>> predicate) where T : class, ICalendarRecord
        {
            return typeof(T) switch
            {
                Type t when t == typeof(TodoItem) => await TodoItems.Where(predicate as Expression<Func<TodoItem, bool>>).ToListAsync() as List<T>,
                Type t when t == typeof(CalendarEvent) => await CalendarEvents.Where(predicate as Expression<Func<CalendarEvent, bool>>).ToListAsync() as List<T>,
                Type t when t == typeof(Sleep) => await Sleeps.Where(predicate as Expression<Func<Sleep, bool>>).ToListAsync() as List<T>,
                Type t when t == typeof(Permission) => await Permissions.Where(predicate as Expression<Func<Permission, bool>>).ToListAsync() as List<T>,
                _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
            };
        }
    }
}
