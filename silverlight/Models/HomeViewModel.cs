using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;

namespace Epiworx.Silverlight.Models
{
    public enum Grouping
    {
        Day,
        Week,
        Month,
        Year
    }

    public class HomeViewModel
    {
        private const int NumberOfRefreshSteps = 3;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Grouping Grouping { get; set; }
        public FilterCollection Filters { get; set; }
        public List<InvoiceData> Invoices { get; set; }
        public List<InvoiceData> FilteredInvoices { get; set; }
        public List<HourData> Hours { get; set; }
        public List<HourData> FilteredHours { get; set; }

        private int _currentRefreshStep = 0;
        public int CurrentRefreshStep
        {
            get
            {
                return _currentRefreshStep;
            }
            set
            {
                _currentRefreshStep = value;
                this.OnCurrentRefreshStepChanged();
            }
        }

        public bool IsBusy
        {
            get { return this.CurrentRefreshStep != NumberOfRefreshSteps; }
        }

        public HomeViewModel()
        {
            this.StartDate = DateTime.Now.ToStartOfYear();
            this.EndDate = DateTime.Now;
        }

        public HomeViewModel(DateTime startDate, DateTime endDate)
            : this()
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public void RefreshData()
        {
            this.CurrentRefreshStep = 0;

            this.RefreshDataForHours();
            this.RefreshDataForInvoices();
        }

        public void RefreshDataForHours()
        {
            var proxy = new WebClient();
            var uri = string.Format(
                "{0}Hours?apikey={1}&start={2}&end={3}",
                DataHelper.ServiceUri,
                DataHelper.ServiceApiKey,
                this.StartDate.ToShortDateString(),
                this.EndDate.ToShortDateString());

            proxy.OpenReadCompleted += OnRefreshDataForHoursCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        public event OpenReadCompletedEventHandler RefreshDataForHoursCompleted;

        public void OnRefreshDataForHoursCompleted(object sender, OpenReadCompletedEventArgs e)
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

            if (this.RefreshDataForHoursCompleted != null)
            {
                this.RefreshDataForHoursCompleted(this, e);
            }

            this.CurrentRefreshStep++;
        }

        public void RefreshDataForInvoices()
        {
            var proxy = new WebClient();
            var uri = string.Format(
                "{0}Invoices?apikey={1}&start={2:d}&end={3:d}",
                DataHelper.ServiceUri,
                DataHelper.ServiceApiKey,
                this.StartDate.ToShortDateString(),
                this.EndDate.ToShortDateString());

            proxy.OpenReadCompleted += OnRefreshDataForInvoicesCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        public event OpenReadCompletedEventHandler RefreshDataForInvoicesCompleted;

        public void OnRefreshDataForInvoicesCompleted(object sender, OpenReadCompletedEventArgs e)
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

            if (this.RefreshDataForInvoicesCompleted != null)
            {
                this.RefreshDataForInvoicesCompleted(this, e);
            }

            this.CurrentRefreshStep++;
        }

        private void OnCurrentRefreshStepChanged()
        {
            if (this.CurrentRefreshStep == 2)
            {
                this.LoadFilters();
            }
        }

        public event EventHandler FiltersChanged;
        public event EventHandler AppliedFiltersChanged;

        private void LoadFilters()
        {
            this.Filters = new FilterCollection();

            this.Filters.Add(new Filter { Name = "Users", Caption = "Users" });
            this.Filters.Add(new Filter { Name = "Projects", Caption = "Projects" });

            List<string> names;

            names = new List<string>();

            // load users
            foreach (var userName in
                this.Hours.Select(row => row.User.Name).Distinct().Where(userName => !names.Contains(userName)))
            {
                names.Add(userName);
            }

            foreach (var userName in
                this.Invoices.Select(row => row.Task.AssignedTo.Name).Distinct().Where(userName => !names.Contains(userName)))
            {
                names.Add(userName);
            }

            foreach (var name in names.OrderBy(row => row))
            {
                this.LoadFilter("Users", name);
            }

            names = new List<string>();

            // load projects
            foreach (var projectName in
                this.Hours.Select(row => row.Project.Name).Distinct().Where(projectName => !names.Contains(projectName)))
            {
                names.Add(projectName);
            }

            foreach (var projectName in
                this.Invoices.Select(row => row.Project.Name).Distinct().Where(projectName => !names.Contains(projectName)))
            {
                names.Add(projectName);
            }

            foreach (var name in names.OrderBy(row => row))
            {
                this.LoadFilter("Projects", name);
            }

            if (this.FiltersChanged != null)
            {
                this.FiltersChanged(this, new EventArgs());
            }

            this.ApplyFilters();
        }

        private void LoadFilter(string parentName, string childName)
        {
            var name = string.Format("{0}-{1}", parentName, childName);

            if (!this.Filters[parentName].Filters.Contains(name))
            {
                this.Filters[parentName].Filters.Add(
                    new Filter { Name = name, Caption = childName, IsChecked = true, Value = childName });
            }
        }

        public void ApplyFilters()
        {
            this.ApplyFilterForHours();
            this.ApplyFilterForInvoices();

            if (this.AppliedFiltersChanged != null)
            {
                this.AppliedFiltersChanged(this, new EventArgs());
            }
        }

        private void ApplyFilterForHours()
        {
            var query = this.Hours.AsQueryable();

            if (this.Filters != null
                && this.Filters.Count() != 0)
            {
                query = query.Where(row =>
                    this.Filters["Users"].Filters.SelectedValues.Contains(row.User.Name));
                query = query.Where(row =>
                    this.Filters["Projects"].Filters.SelectedValues.Contains(row.Project.Name));
            }

            this.FilteredHours = query.ToList();
        }

        private void ApplyFilterForInvoices()
        {
            var query = this.Invoices.AsQueryable();

            if (this.Filters != null
                && this.Filters.Count() != 0)
            {
                query = query.Where(row =>
                    this.Filters["Users"].Filters.SelectedValues.Contains(row.Task.AssignedTo.Name));
                query = query.Where(row =>
                    this.Filters["Projects"].Filters.SelectedValues.Contains(row.Project.Name));
            }

            this.FilteredInvoices = query.ToList();
        }
    }
}
