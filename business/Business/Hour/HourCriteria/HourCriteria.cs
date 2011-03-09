using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class HourCriteria : Csla.CriteriaBase<HourCriteria>
    {
        public HourCriteria()
        {
            this.HourId = null;
            this.TaskId = null;
            this.ProjectId = null;
            this.UserId = null;
            this.Date = new DateRangeCriteria();
            this.Duration = null;
            this.Labels = null;
            this.TaskLabels = null;
            this.IsArchived = null;
            this.Notes = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Date";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
