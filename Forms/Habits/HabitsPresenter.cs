using DayTracker.HabitAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.Habits
{
    internal class HabitsPresenter : IPresenter
    {
        private readonly IHabitModel _model;
        private readonly IHabitView _view;

        IModel IPresenter.Model => _model;

        IView IPresenter.View => _view;

        public HabitsPresenter(IHabitModel model, IHabitView view, IAnalysisService analysisService) 
        { 
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));

            DashboardData data = analysisService.AnalyzeHabitsAsync().Result;
            _view.BuildDashboard(data);
        }
    }
}
