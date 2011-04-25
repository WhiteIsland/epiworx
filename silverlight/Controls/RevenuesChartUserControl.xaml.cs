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
using Epiworx.Silverlight.Core;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;
using Epiworx.Silverlight.Models;

namespace Epiworx.Silverlight.Controls
{
    public partial class RevenuesChartUserControl : UserControl
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private IEnumerable<InvoiceData> Invoices { get; set; }
        private IEnumerable<InvoiceData> FilteredInvoices { get; set; }

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

        public RevenuesChartUserControl()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            var proxy = new WebClient();
            var uri = string.Format(
                "{0}Invoices?apikey={1}&start={2:d}&end={3:d}",
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
            this.Invoices = xml.Elements(ns + "InvoiceData")
                .Select(hour => new InvoiceData(hour))
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
            var query = this.Invoices;

            if (this.Filters != null
                && this.Filters.Count() != 0)
            {
                query = query.Where(row => this.Filters["Users"].Filters.SelectedValues.Contains(row.Task.AssignedTo.Name));
                query = query.Where(row => this.Filters["Projects"].Filters.SelectedValues.Contains(row.Project.Name));
            }

            this.FilteredInvoices = query.ToList();
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

            var itemsSource = new List<InvoiceByGroupData>();

            var currentDate = startDate;

            while (currentDate.Date <= endDate)
            {
                var data = new InvoiceByGroupData();

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
                        data.End = currentDate.ToEndOfMonth();
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

                data.Amount = this.FilteredInvoices
                    .Where(row => row.PreparedDate >= data.Start
                                  && row.PreparedDate <= data.End)
                    .Sum(row => row.Amount);

                itemsSource.Add(data);
            }

            this.Chart.Series.Clear();

            ColumnSeries series;

            series = new ColumnSeries();

            series.Title = "Invoices";
            series.DependentValuePath = "Amount";
            series.IndependentValuePath = "Name";
            series.ItemsSource = itemsSource;

            this.Chart.Series.Add(series);
        }
    }
}
