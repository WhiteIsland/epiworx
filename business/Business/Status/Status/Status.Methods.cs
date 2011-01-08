using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Status
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

        internal static Status NewStatus()
        {
            return Csla.DataPortal.Create<Status>();
        }

        internal static Status FetchStatus(StatusCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Status>(criteria);
        }

        internal static void DeleteStatus(StatusCriteria criteria)
        {
            Csla.DataPortal.Delete<Status>(criteria);
        }
    }
}
