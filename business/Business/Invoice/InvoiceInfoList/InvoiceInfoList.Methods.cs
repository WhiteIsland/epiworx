using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class InvoiceInfoList
    {
        internal static InvoiceInfoList FetchInvoiceInfoList(InvoiceCriteria criteria)
        {
            return Csla.DataPortal.Fetch<InvoiceInfoList>(criteria);
        }
    }
}
