using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.Business
{
    [Serializable]
    public partial class SprintCriteria : Csla.CriteriaBase<SprintCriteria>
    {
        public SprintCriteria()
        {
            this.SprintId = null;
            this.Name = null;
            this.ProjectId = null;
            this.IsCompleted = null;
            this.CompletedDate = new DateRangeCriteria();
            this.EstimatedCompletedDate = new DateRangeCriteria();
            this.IsActive = null;
            this.IsArchived = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Descending;
        }
    }
}
