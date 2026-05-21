using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal interface IDatabaseService
    {
        Task<List<T>> ExecuteRawSqlSelectAsync<T>(string sqlQuery) where T : class;

        Task<int> ExecuteRawSqlCommandAsync(string sqlCommand);
    }
}
