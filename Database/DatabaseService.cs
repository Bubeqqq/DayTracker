using DayTracker.Database.Datatypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public int CurrentCalendarID { get; set; } = -1;

        private readonly SemaphoreSlim _dbLock = new SemaphoreSlim(1, 1);

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {

        }

        public event Action<string, EntityState> OnEntityChanged;

        public async Task<T> AddAsync<T>(T record) where T : class, ICalendarRecord
        {
            if (record == null)
            {
                return null;
            }

            await _dbLock.WaitAsync();
            try
            {

                if (record is CalendarEvent calendarRecord)
                {
                    calendarRecord.CalendarId = CurrentCalendarID;
                    calendarRecord.Id = 0;
                }
                else if (record is Sleep sleepRecord)
                {
                    sleepRecord.CalendarId = CurrentCalendarID;
                    sleepRecord.Id = 0;
                }
                else if (record is Permission permissionRecord)
                {
                    permissionRecord.CalendarId = CurrentCalendarID;
                    permissionRecord.Id = 0;
                }
                else if (record is TodoItem todoRecord)
                {
                    todoRecord.Id = 0;
                }

                await Set<T>().AddAsync(record);

                await SaveChangesAsync();

                return record;
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task AddUserAsync(User record)
        {
            await _dbLock.WaitAsync();

            record.Id = 0;

            await Users.AddAsync(record);
            await SaveChangesAsync();

            _dbLock.Release();
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
                Type t when t == typeof(CalendarEvent) => await CalendarEvents.Where(e => e.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                Type t when t == typeof(Sleep) => await Sleeps.Where(s => s.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                Type t when t == typeof(Permission) => await Permissions.Where(p => p.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
            };
        }

        public async Task<List<T>> GetType<T>(Expression<Func<T, bool>> predicate) where T : class, ICalendarRecord
        {
            return typeof(T) switch
            {
                Type t when t == typeof(TodoItem) => await TodoItems.Where(predicate as Expression<Func<TodoItem, bool>>).ToListAsync() as List<T>,
                Type t when t == typeof(CalendarEvent) => await CalendarEvents.Where(predicate as Expression<Func<CalendarEvent, bool>>).Where(e => e.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                Type t when t == typeof(Sleep) => await Sleeps.Where(predicate as Expression<Func<Sleep, bool>>).Where(s => s.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                Type t when t == typeof(Permission) => await Permissions.Where(predicate as Expression<Func<Permission, bool>>).Where(p => p.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
            };
        }

        public async Task<PermissionType> LoadUserPermissions(int UserID, int CalendarID)
        {
            List<Permission> permissions = await Permissions.Where(p => p.UserId == UserID && p.CalendarId == CalendarID).ToListAsync();

            if(permissions.Count == 0)
            {
                return PermissionType.Blocked;
            }

            if(permissions.Count > 1)
            {
                throw new InvalidOperationException($"User with ID {UserID} has multiple permissions for calendar with ID {CalendarID}.");
            }
            
            return permissions[0].PermissionName;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbLock.WaitAsync();

            try
            {

                var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added ||
                                e.State == EntityState.Modified ||
                                e.State == EntityState.Deleted)
                    .ToList();

                var result = await base.SaveChangesAsync(cancellationToken);

                foreach (var entry in modifiedEntries)
                {

                    if (entry.Entity is CalendarEvent calendarEvent)
                    {
                        if (calendarEvent.CalendarId == CurrentCalendarID)
                        {
                            OnEntityChanged?.Invoke(nameof(CalendarEvent), entry.State);
                        }
                    }
                    else if (entry.Entity is Sleep sleep)
                    {
                        if (sleep.CalendarId == CurrentCalendarID)
                        {
                            OnEntityChanged?.Invoke(nameof(Sleep), entry.State);
                        }
                    }
                    else
                    {
                        string tableName = entry.Entity.GetType().Name;
                        OnEntityChanged?.Invoke(tableName, entry.State);
                    }
                }

                return result;
            }
            finally
            {
                _dbLock.Release();
            }
        }

        async Task IDatabaseService.RemoveByType<T>(int index)
        {
            await _dbLock.WaitAsync();

            var record = await Set<T>().FindAsync(index);

            if (record != null)
            {
                Remove(record);

                await SaveChangesAsync();
            }

            _dbLock.Release();
        }

        async Task IDatabaseService.RemoveByType<T>(T record)
        {
            if (record == null)
            {
                return;
            }

            Remove(record);

            await SaveChangesAsync();
        }

        async Task<T> IDatabaseService.UpdateByType<T>(int index, Action<T> update)
        {
            try
            {

                object? foundRecord = null;

                switch (typeof(T))
                {
                    case Type t when t == typeof(TodoItem):
                        foundRecord = await TodoItems.FindAsync(index);
                        break;
                    case Type t when t == typeof(CalendarEvent):
                        foundRecord = await CalendarEvents.FindAsync(index);
                        break;
                    case Type t when t == typeof(Sleep):
                        foundRecord = await Sleeps.FindAsync(index);
                        break;
                    case Type t when t == typeof(Permission):
                        foundRecord = await Permissions.FindAsync(index);
                        break;
                }

                if (foundRecord != null)
                {
                    update((T)foundRecord);
                    await SaveChangesAsync();
                    return (T)foundRecord;
                }
            }finally
            {
                _dbLock.Release();
            }

            throw new ArgumentNullException($"{index} not found.");
        }

        async Task<T> IDatabaseService.UpdateByType<T>(T record, Action<T> update)
        {
            if (record == null)
            {
                throw new ArgumentNullException($"{nameof(record)} cannot be null.");
            }

            update(record);

            Update(record);

            await SaveChangesAsync();
            return record;
        }
    }
}
