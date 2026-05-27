using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal interface IUsersDatabase
    {
        Task AddUserAsync(User user);

        Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate);
    }
}
