using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Invoice
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Number);
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

        internal static Invoice NewInvoice()
        {
            return Csla.DataPortal.Create<Invoice>();
        }

        internal static Invoice FetchInvoice(InvoiceCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Invoice>(criteria);
        }

        internal static void DeleteInvoice(InvoiceCriteria criteria)
        {
            Csla.DataPortal.Delete<Invoice>(criteria);
        }
    }
}
