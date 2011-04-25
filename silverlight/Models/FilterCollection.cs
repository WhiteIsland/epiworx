using System;
using System.Collections.Generic;
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
using Epiworx.Silverlight.Core;

namespace Epiworx.Silverlight.Models
{
    public class FilterCollection : SortableObservableCollection<Filter>
    {
        public string[] Values
        {
            get
            {
                return this
                    .Select(child => child.Value)
                    .ToArray();
            }
        }

        public string[] SelectedValues
        {
            get
            {
                return this
                    .Where(row => row.IsChecked.Value)
                    .Select(child => child.Value)
                    .ToArray();
            }
        }

        public Filter this[string name]
        {
            get
            {
                return this.FirstOrDefault(child => child.Name == name);
            }
        }

        public bool Contains(string name)
        {
            return this.Any(row => row.Name == name);
        }
    }
}
