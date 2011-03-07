using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskLabel
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static TaskLabel NewTaskLabel(string name)
        {
            return Csla.DataPortal.CreateChild<TaskLabel>(name);
        }

        internal static TaskLabel FetchTaskLabel(Data.Label data)
        {
            return Csla.DataPortal.FetchChild<TaskLabel>(data);
        }
    }
}
