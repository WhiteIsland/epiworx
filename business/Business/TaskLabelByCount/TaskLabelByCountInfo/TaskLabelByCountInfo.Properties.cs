using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabelByCountInfo
    {
        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.LoadProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<int> QuantityProperty =
            RegisterProperty<int>(row => row.Quantity, "Quantity");
        public int Quantity
        {
            get { return this.GetProperty(QuantityProperty); }
            set { this.LoadProperty(QuantityProperty, value); }
        }
    }
}
