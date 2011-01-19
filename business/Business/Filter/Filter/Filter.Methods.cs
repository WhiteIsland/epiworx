using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Epiworx.Business
{
    public partial class Filter
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

        internal static Filter NewFilter()
        {
            return Csla.DataPortal.Create<Filter>();
        }

        internal static Filter FetchFilter(FilterCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Filter>(criteria);
        }

        internal static void DeleteFilter(FilterCriteria criteria)
        {
            var filter = Filter.FetchFilter(criteria);

            if (!Filter.CanDeleteObject(filter))
            {
                throw new SecurityException("Only the creator of the filter or users with full control can delete this filter");
            }

            Csla.DataPortal.Delete<Filter>(criteria);
        }

        public override Filter Save()
        {
            if (this.IsDirty
                && !this.IsNew
                && !Filter.CanSaveObject(this))
            {
                throw new SecurityException("Only the creator of the filter or users with full control can edit this filter");
            }

            return base.Save();
        }
    }
}
