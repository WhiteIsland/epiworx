using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Xml.Linq;
using Epiworx.Silverlight.Core;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;
using Epiworx.Silverlight.Models;

namespace Epiworx.Silverlight.Controls
{
    public partial class HoursChartUserControl : UserControl
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private IEnumerable<HourData> Hours { get; set; }
        private IEnumerable<HourData> FilteredHours { get; set; }

        private FilterCollection _filters = new FilterCollection();
        public FilterCollection Filters
        {
            get
            {
                return _filters;
            }
            set
            {
                _filters = value;
                this.OnFiltersChanged();
            }
        }

        private GroupBy _groupBy = GroupBy.Week;
        public GroupBy GroupBy
        {
            get
            {
                return _groupBy;
            }
            set
            {
                _groupBy = value;
                this.OnGroupByChanged();
            }
        }

        public HoursChartUserControl()
        {
            InitializeComponent();
        }

        public void LoadData()
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
            this.Hours = xml.Elements(ns + "HourData")
                .Select(hour => new HourData(hour))
                .ToList();

            this.DisplayData();
        }

        private void OnGroupByChanged()
        {
            this.DisplayData();
        }

        private void OnFiltersChanged()
        {
            this.DisplayData();
        }

        private void ApplyFilter()
        {
            var query = this.Hours;

            if (this.Filters != null
                && this.Filters.Count() != 0)
            {
                query = query.Where(row => this.Filters["Users"].Filters.SelectedValues.Contains(row.User.Name));
                query = query.Where(row => this.Filters["Projects"].Filters.SelectedValues.Contains(row.Project.Name));
            }

            this.FilteredHours = query.ToList();
        }

        private void DisplayData()
        {
            this.ApplyFilter();

            DateTime startDate;
            DateTime endDate;

            switch (this.GroupBy)
            {
                case GroupBy.Week:
                    startDate = this.Start.ToStartOfWeek();
                    endDate = this.End.ToEndOfWeek();
                    break;
                case GroupBy.Month:
                    startDate = this.Start.ToStartOfMonth();
                    endDate = this.End.ToEndOfMonth();
                    break;
                case GroupBy.Year:
                    startDate = this.Start.ToStartOfYear();
                    endDate = this.End.ToEndOfYear();
                    break;
                default:
                    throw new NotImplementedException();
            }

            var itemsSource = new List<HourByGroupData>();

            var currentDate = startDate;

            while (currentDate.Date <= endDate)
            {
                var data = new HourByGroupData();

                data.Start = currentDate;

                switch (this.GroupBy)
                {
                    case GroupBy.Week:
                        data.Name = currentDate.Date.ToString("M/d");
                        data.End = currentDate.ToEndOfWeek();
                        currentDate = currentDate.ToStartOfNextWeek();
                        break;
                    case GroupBy.Month:
                        data.Name = currentDate.Date.ToString("M/yyyy");
                        data.End = currentDate.ToEndOfWeek();
                        currentDate = currentDate.ToStartOfNextMonth();
                        break;
                    case GroupBy.Year:
                        data.Name = currentDate.Date.ToString("yyyy");
                        data.End = currentDate.ToEndOfYear();
                        currentDate = currentDate.ToStartOfNextYear();
                        break;
                    default:
                        break;
                }

                data.Quantity = this.FilteredHours
                    .Where(row => row.Date >= data.Start && row.Date <= data.End)
                    .Sum(row => row.Duration);

                itemsSource.Add(data);
            }

            this.Chart.Palette.Clear();
            this.Chart.Series.Clear();

            ColumnSeries series;

            series = new ColumnSeries();

            series.Title = "Hours";
            series.DependentValuePath = "Quantity";
            series.IndependentValuePath = "Name";
            series.ItemsSource = itemsSource;

            this.Chart.Series.Add(series);
        }
    }
}
