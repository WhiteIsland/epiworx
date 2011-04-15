using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class InvoiceInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Number);
        }

        internal static InvoiceInfo FetchInvoiceInfo(Data.Invoice data)
        {
            var result = new InvoiceInfo();
            result.Fetch(data);
            return result;
        }
    }
}
