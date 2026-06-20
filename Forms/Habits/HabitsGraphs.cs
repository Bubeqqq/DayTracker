using DayTracker.HabitAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace DayTracker.Forms.Habits
{
    public partial class HabitsGraphs : UserControl, IHabitView
    {
        private PieChart chartCategories;
        private CartesianChart chartSleep;
        private CartesianChart chartTodos;

        public HabitsGraphs()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;

            chartCategories = new PieChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right // Nowy sposób na legendę
            };

            chartSleep = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            chartTodos = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            this.Load += HabitsGraphs_Load;
        }

        private void HabitsGraphs_Load(object? sender, EventArgs e)
        {
            mainPanel.SuspendLayout();
            mainPanel.Controls.Clear();

            mainPanel.Controls.Add(chartCategories, 0, 0);
            mainPanel.Controls.Add(chartSleep, 1, 0);
            mainPanel.Controls.Add(chartTodos, 1, 1);

            mainPanel.ResumeLayout(true);
        }

        public void BuildDashboard(DashboardData data)
        {
            var pieSeriesList = new List<ISeries>();

            var labelPaint = new SolidColorPaint(SKColors.White) { SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright) };

            foreach (var category in data.TotalTimePerCategory)
            {
                if (category.Value > 0)
                {
                    pieSeriesList.Add(new PieSeries<double>
                    {
                        Name = category.Key,
                        Values = new double[] { category.Value },
                        DataLabelsPaint = labelPaint,
                        DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                        DataLabelsFormatter = point => $"{point.Model:F1}h"
                    });
                }
            }
            chartCategories.Series = pieSeriesList;

            var sleepData = data.SleepHoursPerDay.OrderBy(x => x.Key).ToList();

            chartSleep.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Sleep",
                    Values = sleepData.Select(x => x.Value).ToArray(),
                    GeometrySize = 10,
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsFormatter = point => $"{point.Model:F1}h"
                }
            };

            chartSleep.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Date",
                    Labels = sleepData.Select(x => x.Key.ToString("dd MMM")).ToList()
                }
            };

            chartSleep.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Time (Hours)",
                    MinLimit = 0
                }
            };


            var todoData = data.TodosCompletedPerDay.OrderBy(x => x.Key).ToList();

            chartTodos.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Completed Todos",
                    Values = todoData.Select(x => x.Value).ToArray(),
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black)
                }
            };

            chartTodos.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Date",
                    Labels = todoData.Select(x => x.Key.ToString("dd MMM")).ToList()
                }
            };

            chartTodos.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Task Count",
                    MinLimit = 0,
                    Labeler = value => value.ToString("N0")
                }
            };
        }
    }
}