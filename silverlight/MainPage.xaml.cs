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

            this.DataContext = this.Model;
        }

        private void FiltersChanged(object sender, EventArgs e)
        {
            this.FilterUserControl.Model = this.Model;

            this.StartDate.SelectedDateChanged += StartDate_SelectedDateChanged;
            this.EndDate.SelectedDateChanged += EndDate_SelectedDateChanged;
            this.GroupingComboBox.SelectionChanged += GroupingComboBox_SelectionChanged;
        }

        private void AppliedFiltersChanged(object sender, EventArgs e)
        {
            this.HoursChartUserControl.Model = this.Model;
            this.HoursGridUserControl.Model = this.Model;
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

        private void GroupingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ComboBoxItem addedItem in e.AddedItems)
            {
                if ((string)addedItem.Content == "Week")
                {
                    this.Model.Grouping = Grouping.Week;
                }
                else if ((string)addedItem.Content == "Month")
                {
                    this.Model.Grouping = Grouping.Month;
                }
                else
                {
                    this.Model.Grouping = Grouping.Year;
                }
            }

            this.HoursChartUserControl.Model = this.Model;
            this.RevenuesChartUserControl.Model = this.Model;
        }
    }
}
