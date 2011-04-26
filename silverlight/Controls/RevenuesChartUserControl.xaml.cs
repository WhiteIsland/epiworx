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
        private HomeViewModel _model;
        public HomeViewModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                this.OnModelChanged();
            }
        }

        public RevenuesChartUserControl()
        {
            InitializeComponent();
        }

        private void OnModelChanged()
        {
            DateTime startDate;
            DateTime endDate;

            switch (this.Model.Grouping)
            {
                case Grouping.Week:
                    startDate = this.Model.StartDate.ToStartOfWeek();
                    endDate = this.Model.EndDate.ToEndOfWeek();
                    break;
                case Grouping.Month:
                    startDate = this.Model.StartDate.ToStartOfMonth();
                    endDate = this.Model.EndDate.ToEndOfMonth();
                    break;
                case Grouping.Year:
                    startDate = this.Model.StartDate.ToStartOfYear();
                    endDate = this.Model.EndDate.ToEndOfYear();
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

                switch (this.Model.Grouping)
                {
                    case Grouping.Week:
                        data.Name = currentDate.Date.ToString("M/d");
                        data.End = currentDate.ToEndOfWeek();
                        currentDate = currentDate.ToStartOfNextWeek();
                        break;
                    case Grouping.Month:
                        data.Name = currentDate.Date.ToString("M/yyyy");
                        data.End = currentDate.ToEndOfMonth();
                        currentDate = currentDate.ToStartOfNextMonth();
                        break;
                    case Grouping.Year:
                        data.Name = currentDate.Date.ToString("yyyy");
                        data.End = currentDate.ToEndOfYear();
                        currentDate = currentDate.ToStartOfNextYear();
                        break;
                    default:
                        break;
                }

                data.Amount = this.Model.FilteredInvoices
                    .Where(row => row.PreparedDate >= data.Start
                                  && row.PreparedDate <= data.End)
                    .Sum(row => row.Amount);

                itemsSource.Add(data);
            }

            this.Chart.Series.Clear();

            LineSeries series;

            series = new LineSeries();

            series.Title = "Invoices";
            series.DependentValuePath = "Amount";
            series.IndependentValuePath = "Name";
            series.ItemsSource = itemsSource;
            series.DataPointStyle = (Style)Application.Current.Resources["LineDataPointStyle"];

            this.Chart.Title = string.Format("Revenues ({0:N0})", itemsSource.Sum(row => row.Amount));

            this.Chart.Series.Add(series);
        }
    }
}
