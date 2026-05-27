using DayTracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.CalendarServices
{
    internal interface ICalendarService
    {
        Task Connect(string connectionString);
        void Disconnect();
        bool IsConnected { get; }
        ICalendarDatabase CreateContext();
    }
}
