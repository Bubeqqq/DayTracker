using DayTracker.Database.Datatypes;
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
        Task<List<T>> GetType<T>() where T : class, ICalendarRecord;

        Task<List<T>> GetType<T>(Expression<Func<T, bool>> predicate) where T : class, ICalendarRecord;

        Task EnsureCreated();

        Task AddAsync<T>(T record) where T : class, ICalendarRecord;

        Task AddUserAsync(User record);

        Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate);
    }
}
