using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Epiworx.Silverlight.Core;
using Epiworx.Silverlight.Helpers;

namespace Epiworx.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.StartDate.SelectedDate = DateTime.Now.ToStartOfYear();
            this.EndDate.SelectedDate = DateTime.Now.Date;

            this.LoadData();

            this.ChartFilters.ItemCheckBoxClick += this.ItemCheckBoxClick;
        }

        private void LoadData()
        {
            this.HoursChart.Start = (DateTime)this.StartDate.SelectedDate;
            this.HoursChart.End = (DateTime)this.EndDate.SelectedDate;
            this.HoursChart.LoadData();

            this.RevenuesChart.Start = (DateTime)this.StartDate.SelectedDate;
            this.RevenuesChart.End = (DateTime)this.EndDate.SelectedDate;
            this.RevenuesChart.LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadData();
        }

        private void ItemCheckBoxClick(object sender, RoutedEventArgs e)
        {
            this.HoursChart.Filters = this.ChartFilters.Filters;
            this.RevenuesChart.Filters = this.ChartFilters.Filters;
        }

        private void WeekHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.HoursChart.GroupBy = GroupBy.Week;
            this.HoursChart.Filters = this.ChartFilters.Filters;
            this.RevenuesChart.GroupBy = GroupBy.Week;
            this.RevenuesChart.Filters = this.ChartFilters.Filters;
        }

        private void MonthHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.HoursChart.GroupBy = GroupBy.Month;
            this.HoursChart.Filters = this.ChartFilters.Filters;
            this.RevenuesChart.GroupBy = GroupBy.Month;
            this.RevenuesChart.Filters = this.ChartFilters.Filters;
        }

        private void YearHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.HoursChart.GroupBy = GroupBy.Year;
            this.HoursChart.Filters = this.ChartFilters.Filters;
            this.RevenuesChart.GroupBy = GroupBy.Year;
            this.RevenuesChart.Filters = this.ChartFilters.Filters;
        }
    }
}
