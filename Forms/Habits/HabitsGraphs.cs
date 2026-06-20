using DayTracker.HabitAnalysis;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayTracker.Forms.Habits
{
    public partial class HabitsGraphs : UserControl, IHabitView
    {
        private LiveCharts.WinForms.PieChart chartCategories;
        private LiveCharts.WinForms.CartesianChart chartSleep;
        private LiveCharts.WinForms.CartesianChart chartTodos;

        public HabitsGraphs()
        {
            using (var dummyHost = new System.Windows.Forms.Integration.ElementHost())
            {
                var dummyChart = new LiveCharts.Wpf.PieChart();
                dummyHost.Child = dummyChart;
            }

            InitializeComponent();

            chartCategories = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            chartSleep = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            chartTodos = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            this.Load += Initialize;
        }

        private void Initialize(object? sender, EventArgs e)
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
            chartCategories.Series.Clear();
            var seriesCollectionPie = new SeriesCollection();

            foreach (var category in data.TotalTimePerCategory)
            {
                if (category.Value > 0)
                {
                    seriesCollectionPie.Add(new PieSeries
                    {
                        Title = category.Key,
                        Values = new ChartValues<double> { category.Value },
                        DataLabels = true,
                        LabelPoint = point => $"{point.Y:F1}h ({point.Participation:P0})"
                    });
                }
            }
            chartCategories.Series = seriesCollectionPie;
            chartCategories.LegendLocation = LegendLocation.Right;

            chartSleep.Series.Clear();
            chartSleep.AxisX.Clear();
            chartSleep.AxisY.Clear();

            var sleepData = data.SleepHoursPerDay.OrderBy(x => x.Key).ToList();

            Console.WriteLine("===============");
            Console.WriteLine(sleepData.Count);
            foreach (var s in sleepData)
            {
                Console.WriteLine(s.Value);
            }
            Console.WriteLine("===============");

            chartSleep.Series.Add(new LineSeries
            {
                Title = "Sleep",
                Values = new ChartValues<double>(sleepData.Select(x => x.Value)),
                PointGeometrySize = 10,
                DataLabels = true,
                LabelPoint = point => $"{point.Y:F1}h"
            });

            chartSleep.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = sleepData.Select(x => x.Key.ToString("dd MMM")).ToList()
            });

            chartSleep.AxisY.Add(new Axis
            {
                Title = "Time (Hours)",
                MinValue = 0
            });

            chartTodos.Series.Clear();
            chartTodos.AxisX.Clear();
            chartTodos.AxisY.Clear();

            var todoData = data.TodosCompletedPerDay.OrderBy(x => x.Key).ToList();

            chartTodos.Series.Add(new ColumnSeries
            {
                Title = "Completed Todos",
                Values = new ChartValues<int>(todoData.Select(x => x.Value)),
                DataLabels = true
            });

            chartTodos.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = todoData.Select(x => x.Key.ToString("dd MMM")).ToList()
            });

            chartTodos.AxisY.Add(new Axis
            {
                Title = "Task Count",
                MinValue = 0,
                LabelFormatter = value => value.ToString("N0")
            });
        }
    }
}
