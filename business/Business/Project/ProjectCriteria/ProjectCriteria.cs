using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class ProjectCriteria : Csla.CriteriaBase<ProjectCriteria>
    {
        public ProjectCriteria()
        {
            this.ProjectId = null;
            this.Name = null;
            this.Description = null;
            this.IsActive = null;
            this.IsArchived = null;
            this.Notes = null;
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
