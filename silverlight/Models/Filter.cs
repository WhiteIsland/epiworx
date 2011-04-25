using System;
using System.ComponentModel;
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

namespace Epiworx.Silverlight.Models
{
    public class Filter : INotifyPropertyChanged, IComparable<Filter>
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public string Caption { get; set; }
        public string Value { get; set; }
        public FilterCollection Filters { get; set; }

        public bool HasFilters
        {
            get { return this.Filters.Count > 0; }
        }

        private bool? _isChecked = true;
        public bool? IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                if (_isChecked == value)
                {
                    return;
                }

                _isChecked = value;
                this.NotifyPropertyChanged("IsChecked");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Filter()
        {
            this.Filters = new FilterCollection();
        }

        public int CompareTo(Filter other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
