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
using System.Xml.Linq;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;
using Epiworx.Silverlight.Models;

namespace Epiworx.Silverlight.Controls
{
    public partial class FilterUserControl : UserControl
    {
        public FilterCollection Filters { get; set; }

        public FilterUserControl()
        {
            InitializeComponent();

            this.LoadData();
        }

        private void LoadData()
        {
            this.Filters = new FilterCollection();

            this.Filters.Add(new Filter { Name = "Users", Caption = "Users" });
            this.Filters.Add(new Filter { Name = "Projects", Caption = "Projects" });

            this.LoadUsers();
        }

        private void LoadUsers()
        {
            var proxy = new WebClient();
            var uri = string.Format("{0}Users?apikey={1}", DataHelper.ServiceUri, DataHelper.ServiceApiKey);

            proxy.OpenReadCompleted += OnLoadUsersCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        void OnLoadUsersCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            var xml = XElement.Load(e.Result);
            var ns = xml.GetDefaultNamespace();
            var users = xml.Elements(ns + "UserData")
                .Select(user => new UserData(user))
                .ToList();

            foreach (var user in users)
            {
                this.Filters["Users"].Filters.Add(new Filter { Name = "Users-" + user.Name, Caption = user.Name, IsChecked = user.IsActive, Value = user.Name });
            }

            this.LoadProjects();
        }

        private void LoadProjects()
        {
            var proxy = new WebClient();
            var uri = string.Format("{0}Projects?apikey={1}", DataHelper.ServiceUri, DataHelper.ServiceApiKey);

            proxy.OpenReadCompleted += OnLoadProjectsCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        void OnLoadProjectsCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            var xml = XElement.Load(e.Result);
            var ns = xml.GetDefaultNamespace();
            var projects = xml.Elements(ns + "ProjectData")
                .Select(project => new ProjectData(project))
                .ToList();

            foreach (var project in projects)
            {
                this.Filters["Projects"].Filters.Add(new Filter { Name = "Projects-" + project.Name, Caption = project.Name, IsChecked = project.IsActive, Value = project.Name });
            }

            this.OnLoadDataCompleted();
        }

        //private void LoadStatuses()
        //{
        //    var proxy = new WebClient();
        //    var uri = string.Format("{0}Statuses?apikey={1}", DataHelper.ServiceUri, DataHelper.ServiceApiKey);

        //    proxy.OpenReadCompleted += OnLoadStatusesCompleted;

        //    proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        //}

        //void OnLoadStatusesCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        return;
        //    }

        //    var xml = XElement.Load(e.Result);
        //    var ns = xml.GetDefaultNamespace();
        //    var statuses = xml.Elements(ns + "StatusData")
        //        .Select(status => new StatusData(status))
        //        .ToList();

        //    foreach (var status in statuses)
        //    {
        //        this.Filters["Statuses"].Filters.Add(new Filter { Name = "Statuses-" + status.Name, Caption = status.Name, IsChecked = status.IsActive, Value = status.Name });
        //    }

        //    this.LoadCategories();
        //}

        //private void LoadCategories()
        //{
        //    var proxy = new WebClient();
        //    var uri = string.Format("{0}Categories?apikey={1}", DataHelper.ServiceUri, DataHelper.ServiceApiKey);

        //    proxy.OpenReadCompleted += OnLoadCategoriesCompleted;

        //    proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        //}

        //void OnLoadCategoriesCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        return;
        //    }

        //    var xml = XElement.Load(e.Result);
        //    var ns = xml.GetDefaultNamespace();
        //    var categories = xml.Elements(ns + "CategoryData")
        //        .Select(category => new CategoryData(category))
        //        .ToList();

        //    foreach (var category in categories)
        //    {
        //        this.Filters["Categories"].Filters.Add(new Filter { Name = "Categories-" + category.Name, Caption = category.Name, IsChecked = category.IsActive, Value = category.Name });
        //    }

        //    this.OnLoadDataCompleted();
        //}

        void OnLoadDataCompleted()
        {
            this.FilterTreeView.ItemsSource = this.Filters;
        }

        public event RoutedEventHandler ItemCheckBoxClick;

        protected virtual void OnItemCheckBoxClicked(object sender, RoutedEventArgs e)
        {
            if (ItemCheckBoxClick != null)
            {
                ItemCheckBoxClick(this, e);
            }
        }

        private void ItemCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var item = GetParentTreeViewItem((DependencyObject)sender);

            if (item == null)
            {
                return;
            }

            var filter = item.DataContext as Filter;

            if (filter != null)
            {
                UpdateChildrenCheckedState(filter);
                UpdateParentCheckedState(item);
            }

            this.OnItemCheckBoxClicked(sender, e);
        }

        private static TreeViewItem GetParentTreeViewItem(DependencyObject item)
        {
            if (item != null)
            {
                var parent = VisualTreeHelper.GetParent(item);
                var parentTreeViewItem = parent as TreeViewItem;
                return parentTreeViewItem ?? GetParentTreeViewItem(parent);
            }
            return null;
        }

        private static void UpdateParentCheckedState(TreeViewItem item)
        {
            var parent = GetParentTreeViewItem(item);

            if (parent == null)
            {
                return;
            }

            var filter = (Filter)parent.DataContext;

            if (filter == null)
            {
                return;
            }

            // Get the combined checked state of all the children,
            // determing if they're all checked, all unchecked or a
            // combination.
            var childrenCheckedState = filter.Filters.First().IsChecked;

            for (var i = 1; i < filter.Filters.Count(); i++)
            {
                if (childrenCheckedState == filter.Filters[i].IsChecked)
                {
                    continue;
                }

                childrenCheckedState = null;
                break;
            }

            // Set the parent to the combined state of the children.
            filter.IsChecked = childrenCheckedState;

            // Continue up the tree updating each parent with the
            // correct combined state.
            UpdateParentCheckedState(parent);
        }

        private static void UpdateChildrenCheckedState(Filter filter)
        {
            if (!filter.IsChecked.HasValue)
            {
                return;
            }

            foreach (var childFilter in filter.Filters)
            {
                childFilter.IsChecked = filter.IsChecked;
                if (childFilter.Filters.Count() > 0)
                {
                    UpdateChildrenCheckedState(childFilter);
                }
            }
        }
    }
}
