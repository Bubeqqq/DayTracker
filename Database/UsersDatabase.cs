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
    internal class UsersDatabase : DbContext, IUsersDatabase
    {
        public DbSet<User> Users { get; set; }

        public UsersDatabase(DbContextOptions<UsersDatabase> options) : base(options)
        {

        }

        public async Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate)
        {
            return await Users.Where(predicate).ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
        }
    }
}
