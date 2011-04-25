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
using Epiworx.Silverlight.Models;

namespace Epiworx.Silverlight
{
    public partial class MainPage : UserControl
    {
        private HomeViewModel Model;

        public MainPage()
        {
            InitializeComponent();

            this.Model = new HomeViewModel();

            this.Model.FiltersChanged += FiltersChanged;
            this.Model.AppliedFiltersChanged += AppliedFiltersChanged;

            this.Model.RefreshData();

            //this.HoursChartUserControl.Model = this.Model;
            //this.RevenuesChartUserControl.Model = this.Model;

            this.DataContext = this.Model;
        }

        private void FiltersChanged(object sender, EventArgs e)
        {
            this.FilterUserControl.Model = this.Model;

            this.StartDate.SelectedDateChanged += StartDate_SelectedDateChanged;
            this.EndDate.SelectedDateChanged += EndDate_SelectedDateChanged;
        }

        private void AppliedFiltersChanged(object sender, EventArgs e)
        {
            this.HoursChartUserControl.Model = this.Model;
            this.RevenuesChartUserControl.Model = this.Model;
        }

        private void WeekHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.Grouping = Grouping.Week;
            this.HoursChartUserControl.Model = this.Model;
            this.RevenuesChartUserControl.Model = this.Model;
        }

        private void MonthHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.Grouping = Grouping.Month;
            this.HoursChartUserControl.Model = this.Model;
            this.RevenuesChartUserControl.Model = this.Model;
        }

        private void YearHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.Grouping = Grouping.Year;
            this.HoursChartUserControl.Model = this.Model;
            this.RevenuesChartUserControl.Model = this.Model;
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Model.StartDate = (DateTime)this.StartDate.SelectedDate;

            this.Model.RefreshData();
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Model.EndDate = (DateTime)this.EndDate.SelectedDate;

            this.Model.RefreshData();
        }
    }
}
