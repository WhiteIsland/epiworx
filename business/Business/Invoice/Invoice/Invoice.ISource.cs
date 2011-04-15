using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Invoice : ISource
    {
        public SourceType SourceType
        {
            get { return Business.SourceType.Invoice; }
        }

        public int SourceId
        {
            get { return this.InvoiceId; }
        }
    }
}
