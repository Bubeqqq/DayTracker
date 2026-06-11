using DayTracker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TaskControl
{
    internal interface ITaskView:IView
    {
        event Action? ConfirmClicked;
        event EventHandler<FieldValidationEventArgs> FieldValidation;
        string Title { get ; }
        string Descritpion { get; }
        string StartMinute { get; }
        string StartHour { get; }
        string StartDay { get; set; }
        string StartMonth { get; }
        string StartYear { get; }
        string DurationMinutes { get; }
        string DurationHours { get; }
         string DurationDays { get; }
        public string EndMinute { get; }
        public string EndHour { get; }
        string EndDay { get; set; }
        string EndMonth { get; } 
        string EndYear { get; }
        void SetTaskInfoFields(string title, string description);
        void SetStartDate(string hour, string minute, string day, string month, string year);
        void SetEndDate(string hour, string minute, string day, string month, string year);
        void SetDuration(string days, string hours, string minutes);
        void SetCheckedListBoxItems(Dictionary<string, bool> categories);
        List<string> GetCheckedItems();
    }
}
