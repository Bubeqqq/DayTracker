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
        private ListBox listAnomalies;

        public HabitsGraphs()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            mainPanel.Controls.Clear();

            chartCategories = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            mainPanel.Controls.Add(chartCategories, 0, 0);

            chartSleep = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };
            mainPanel.Controls.Add(chartSleep, 1, 0);

            chartTodos = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };
            mainPanel.Controls.Add(chartTodos, 1, 1);

            listAnomalies = new ListBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = System.Drawing.Color.LightSalmon,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            };
            mainPanel.Controls.Add(listAnomalies, 0, 1);
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

            listAnomalies.Items.Clear();
            if (data.Anomalies.Any())
            {
                listAnomalies.Items.Add("⚠️ DATA ERRORS DETECTED:");
                foreach (var anomaly in data.Anomalies)
                {
                    listAnomalies.Items.Add($"- {anomaly}");
                }
            }
            else
            {
                listAnomalies.Items.Add("✅ Data is consistent. No anomalies.");
            }
        }
    }
}
