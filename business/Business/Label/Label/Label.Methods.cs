using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Label
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

        internal static Label NewLabel(LabelCriteria criteria)
        {
            return Csla.DataPortal.Create<Label>(criteria);
        }

        internal static Label FetchLabel(LabelCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Label>(criteria);
        }

        internal static void DeleteLabel(LabelCriteria criteria)
        {
            Csla.DataPortal.Delete<Label>(criteria);
        }
    }
}
