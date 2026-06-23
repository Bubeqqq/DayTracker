using DayTracker.HabitAnalysis;
using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DayTracker.Forms.Habits
{
    public partial class HabitsGraphs : UserControl, IHabitView
    {
        private PieChart chartCategories;
        private CartesianChart chartSleep;
        private CartesianChart chartTodos;
        private CartesianChart chartSportVsSleep;

        public HabitsGraphs()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;

            chartCategories = new PieChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                Title = new DrawnLabelVisual(new LabelGeometry
                {
                    Text = "Daily Activity Breakdown",
                    TextSize = 18,
                    Paint = new SolidColorPaint(SKColors.Black)
                })
            };

            chartSleep = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                Title = new DrawnLabelVisual(new LabelGeometry
                {
                    Text = "Daily Sleep Tracking",
                    TextSize = 18,
                    Paint = new SolidColorPaint(SKColors.Black)
                })
            };

            chartTodos = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                Title = new DrawnLabelVisual(new LabelGeometry
                {
                    Text = "Completed Tasks per Day",
                    TextSize = 18,
                    Paint = new SolidColorPaint(SKColors.Black)
                })
            };

            chartSportVsSleep = new CartesianChart 
            { 
                Dock = DockStyle.Fill, 
                Margin = new Padding(10),
                Title = new DrawnLabelVisual(new LabelGeometry
                {
                    Text = "Activity vs. Sleep Correlation",
                    TextSize = 18,
                    Paint = new SolidColorPaint(SKColors.Black)
                })
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
            mainPanel.Controls.Add(chartSportVsSleep, 0, 1);

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

            var allDates = data.SleepHoursPerDay.Keys
            .Union(data.SportAndOutdoorHoursPerDay.Keys)
            .OrderBy(d => d)
            .ToList();

            var sleepValues = new List<double>();
            var activeValues = new List<double>();

            foreach (var d in allDates)
            {
                sleepValues.Add(data.SleepHoursPerDay.ContainsKey(d) ? data.SleepHoursPerDay[d] : 0);
                activeValues.Add(data.SportAndOutdoorHoursPerDay.ContainsKey(d) ? data.SportAndOutdoorHoursPerDay[d] : 0);
            }

            chartSportVsSleep.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Sleep Time",
                    Values = sleepValues.ToArray(),
                    GeometrySize = 10,
                    Stroke = new SolidColorPaint(SKColors.DarkBlue) { StrokeThickness = 3 },
                    GeometryStroke = new SolidColorPaint(SKColors.DarkBlue) { StrokeThickness = 3 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Name = "Sport and Outdoor",
                    Values = activeValues.ToArray(),
                    GeometrySize = 10,
                    Stroke = new SolidColorPaint(SKColors.MediumSeaGreen) { StrokeThickness = 3 },
                    GeometryStroke = new SolidColorPaint(SKColors.MediumSeaGreen) { StrokeThickness = 3 },
                    Fill = null
                }
             };

            chartSportVsSleep.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Date",
                    Labels = allDates.Select(x => x.ToString("dd MMM")).ToList()
                }
                        };

                        chartSportVsSleep.YAxes = new Axis[]
                        {
                new Axis
                {
                    Name = "Time (hours)",
                    MinLimit = 0
                }
            };
        }
    }
}