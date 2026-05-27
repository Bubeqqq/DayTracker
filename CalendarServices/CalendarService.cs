using DayTracker.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.CalendarServices
{
    internal class CalendarService : ICalendarService
    {
        private string? _currentConnectionString = null;

        public bool IsConnected => !string.IsNullOrEmpty(_currentConnectionString);

        public async Task Connect(string password)
        {
            _currentConnectionString = password;

            ICalendarDatabase context = CreateContext();
            await context.EnsureCreated();
        }

        public void Disconnect()
        {
            _currentConnectionString = null;
        }

        public ICalendarDatabase CreateContext()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Brak połączenia. Najpierw podaj klucz i użyj metody Connect().");
            }

            var optionsBuilder = new DbContextOptionsBuilder<CalendarDatabase>();

            optionsBuilder.UseNpgsql(_currentConnectionString);

            return new CalendarDatabase(optionsBuilder.Options);
        }
    }
}
