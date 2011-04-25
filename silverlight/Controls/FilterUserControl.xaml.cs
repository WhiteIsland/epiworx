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

        public FilterUserControl()
        {
            InitializeComponent();
        }

        private void OnModelChanged()
        {
            this.FilterTreeView.ItemsSource = this.Model.Filters;
        }

        public event RoutedEventHandler ItemCheckBoxClick;

        protected virtual void OnItemCheckBoxClicked(object sender, RoutedEventArgs e)
        {
            this.Model.ApplyFilters();

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
