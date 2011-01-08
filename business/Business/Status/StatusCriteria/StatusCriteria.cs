using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class StatusCriteria : Csla.CriteriaBase<StatusCriteria>
    {
        public StatusCriteria()
        {
            this.StatusId = null;
            this.Name = null;
            this.Description = null;
            this.Ordinal = null;
            this.ForeColor = null;
            this.BackColor = null;
            this.IsStarted = null;
            this.IsCompleted = null;
            this.IsActive = null;
            this.IsArchived = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
