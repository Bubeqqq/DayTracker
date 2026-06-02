using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal interface ICalendarDatabase : IDisposable
    {

        Task<List<T>?> GetType<T>() where T : class;

        Task AddAsync<T>(T user);

        Task EnsureCreated();
    }
}
