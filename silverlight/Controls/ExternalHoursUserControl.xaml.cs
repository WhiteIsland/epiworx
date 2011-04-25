using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;

namespace Epiworx.Silverlight.Controls
{
    public partial class ExternalHoursUserControl : UserControl
    {
        private DateTime Start { get; set; }
        private DateTime End { get; set; }

        public ExternalHoursUserControl()
        {
            InitializeComponent();

            this.Start = DateTime.Parse("1/1/2011");
            this.End = DateTime.Now.Date.ToEndOfMonth();

            this.LoadData();
        }

        private void LoadData()
        {
            var proxy = new WebClient();
            var uri = string.Format(
                "{0}Hours?apikey={1}&start={2}&end={3}",
                DataHelper.ServiceUri,
                DataHelper.ServiceApiKey,
                this.Start,
                this.End);

            proxy.OpenReadCompleted += OnReadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        void OnReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            var xml = XElement.Load(e.Result);
            var ns = xml.GetDefaultNamespace();
            var hours = xml.Elements(ns + "HourData")
                .Select(hour => new HourData(hour))
                .ToList();

            var externalHours = new List<HourByPeriodData>();

            var startDate = this.Start;
            var endDate = startDate.AddMonths(1).AddDays(-1);

            while (startDate.Date <= this.End.Date)
            {
                externalHours.Add(
                    new HourByPeriodData()
                    {
                        Name = startDate.ToString("MMM"),
                        Start = startDate.Date,
                        End = endDate.Date,
                        Hours = hours
                            .Where(row => row.Date >= startDate
                                && row.Date <= endDate
                                && !row.Project.Name.StartsWith("Epitec"))
                            .Sum(row => row.Duration)
                    });

                startDate = endDate.AddDays(1);
                endDate = startDate.ToEndOfMonth();
            }

            this.HourChart.Series.Clear();

            var palette = new ResourceDictionaryCollection();
            ColumnSeries series;

            series = new ColumnSeries();

            series.Title = "Hours";
            series.DependentValuePath = "Hours";
            series.IndependentValuePath = "Name";
            series.ItemsSource = externalHours;

            this.HourChart.Series.Add(series);
            ChartHelper.AddColor(palette, ChartHelper.ColorForExternalHours);

            this.HourChart.Palette = palette;
        }
    }
}
