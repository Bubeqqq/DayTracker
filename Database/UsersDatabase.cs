using DayTracker.Database.Datatypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal class UsersDatabase : DbContext, IUsersDatabase
    {
        DbSet<User> Users { get; set; }

        public UsersDatabase(DbContextOptions<UsersDatabase> options) : base(options)
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
