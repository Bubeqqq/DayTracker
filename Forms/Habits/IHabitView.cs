using DayTracker.HabitAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Habits
{
    internal interface IHabitView : IView
    {
        void BuildDashboard(DashboardData data);
    }
}
