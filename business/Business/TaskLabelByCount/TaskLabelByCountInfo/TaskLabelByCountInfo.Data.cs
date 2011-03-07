using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabelByCountInfo
    {
        private void Fetch(string name, int quantity)
        {
            this.LoadProperty(NameProperty, name);
            this.LoadProperty(QuantityProperty, quantity);
        }
    }
}
