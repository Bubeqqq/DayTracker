using DayTracker.UserControls.TestTask_usunac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Day.TaskPreview
{
    public class TaskClickedEventArgs
    {
        public TestTask Task { get; }
        public TaskClickedEventArgs(TestTask task) 
        {
            Task=task;
        }
    }
}
