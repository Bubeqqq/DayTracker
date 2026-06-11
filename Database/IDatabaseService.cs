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
    internal interface IDatabaseService
    {
        public int CurrentCalendarID { get; set; }

        event Action<string, EntityState> OnEntityChanged;

        Task<List<T>> GetType<T>() where T : class, ICalendarRecord;

        Task<List<T>> GetType<T>(Expression<Func<T, bool>> predicate) where T : class, ICalendarRecord;

        Task RemoveByType<T>(int index) where T : class, ICalendarRecord;

        Task RemoveByType<T>(T record) where T : class, ICalendarRecord;

        Task UpdateByType<T>(int index, Action<T> update) where T : class, ICalendarRecord;

        Task UpdateByType<T>(T record, Action<T> update) where T : class, ICalendarRecord;

        Task EnsureCreated();

        Task AddAsync<T>(T record) where T : class, ICalendarRecord;

        Task AddUserAsync(User record);

        Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate);

        Task<PermissionType> LoadUserPermissions(int UserID, int CalendarID);
    }
}
