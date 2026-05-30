using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Calendar
{
    public class DayClickedEventArgs : EventArgs
    {
        public DateTime Date { get; }

        public DayClickedEventArgs(DateTime date)
        {
            Date = date;
        }
    }
}
