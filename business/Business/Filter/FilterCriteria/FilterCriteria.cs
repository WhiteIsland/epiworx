using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class FilterCriteria : Csla.CriteriaBase<FilterCriteria>
    {
        public FilterCriteria()
        {
            this.FilterId = null;
            this.Name = null;
            this.Target = null;
            this.Query = null;
            this.IsActive = null;
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
