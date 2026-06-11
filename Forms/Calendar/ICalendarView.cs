using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Calendar
{
    internal interface ICalendarView:IView
    {
        DateTime SelectedDate { get; }
        event EventHandler<DayClickedEventArgs> DayClicked;
        event EventHandler SelectedDateChanged;
        event EventHandler NextButtonClicked;
        event EventHandler PreviousButtonClicked;
        event EventHandler AddEventButtonClicked;
        void CreateAndAddDayCell(DateTime date, List<string> tasks, int column, int row);
        void SuspendAndClearCalendar();
        public void ResumeCalendarLayout();
        void ShowMessage(string message);
        void AddMonthToDate(int monthsToAdd);
    }
}
