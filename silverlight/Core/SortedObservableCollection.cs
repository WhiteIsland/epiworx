using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Silverlight.Core
{
    public class SortableObservableCollection<T> : ObservableCollection<T>
    {
        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }

        public void Sort(IComparer<T> comparer)
        {
            int i, j;

            T index;

            for (i = 1; i < Count; i++)
            {

                index = this[i]; // If you can't read it, it should be index = this[x], where x is i :-)

                j = i;

                while ((j > 0) && (comparer.Compare(this[j - 1], index) == 1))
                {
                    this[j] = this[j - 1];
                    j = j - 1;
                }

                this[j] = index;
            }

        }
    }
}
