using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
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

        public HoursChartUserControl()
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

            var itemsSource = new List<HourByGroupData>();

            var currentDate = startDate;

            while (currentDate.Date <= endDate)
            {
                var data = new HourByGroupData();

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
                        data.End = currentDate.ToEndOfWeek();
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

                data.Quantity = this.Model.FilteredHours
                    .Where(row => row.Date >= data.Start && row.Date <= data.End)
                    .Sum(row => row.Duration);

                itemsSource.Add(data);
            }

            this.Chart.Series.Clear();

            LineSeries series;

            series = new LineSeries();

            series.Title = "Hours";
            series.DependentValuePath = "Quantity";
            series.IndependentValuePath = "Name";
            series.ItemsSource = itemsSource;
            series.DataPointStyle = (Style)Application.Current.Resources["LineDataPointStyle"];

            this.Chart.Series.Add(series);
        }
    }
}
