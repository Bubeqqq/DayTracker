using DayTracker.Database.Datatypes;
using DayTracker.Forms;
using DayTracker.Forms.Day.TaskPreview;
using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Day
{
    internal interface IDayView: IView
    {
        int TopMargin { get; }
        int PixelsPerHour { get; }
        int LeftMargin { get; }
        int TotalWidth { get;}
        event EventHandler AddClicked;
        event EventHandler SizeChanged;
        event EventHandler BackToCalendarClicked;
        event EventHandler<CalendarEventClickedEventArgs> CalendarEventClicked;
        event EventHandler<CalendarEventClickedEventArgs> DeleteClicked;
        void CreateAndPlaceTaskControl(CalendarEvent calendarEvent, int x, int y, int taskWidth, int height, Color color, string? startedOn = null);
        public bool YesNoMessage(string message);
        void ModifyControl(int index, int x, int y, int taskWidth, int height, Color color, string? startedOn = null);
        void ClearControls();
        void SetDateLabel(DateTime date);
        void ShowMessage(string message);
    }
}
