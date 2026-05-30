using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.TaskControl
{
    public enum TaskField
    {
        StartMinute,EndMinute,DurationMinutes,StartHour,EndHour,DurationHours,StartDay,EndDay,DurationDays,StartMonth,EndMonth,StartYear,EndYear,Text
    }
    public class FieldValidationEventArgs:EventArgs
    {
        public TaskField Field { get; }
        public string NewValue { get; }
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; }
        public FieldValidationEventArgs(TaskField taskField,string newValue) 
        {
            Field = taskField;
            NewValue = newValue;
        }
    }
}
