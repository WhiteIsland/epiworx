using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Business
{
    [Serializable]
    public partial class InvoiceCriteria : Csla.CriteriaBase<InvoiceCriteria>
    {
        public InvoiceCriteria()
        {
            this.InvoiceId = null;
            this.Number = null;
            this.ProjectId = null;
            this.Description = null;
            this.SourceType = null;
            this.SourceId = null;
            this.Amount = null;
            this.IsArchived = null;
            this.Notes = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Number";
            this.SortOrder = ListSortDirection.Descending;
        }
    }
}
