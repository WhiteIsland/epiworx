using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class FeedCriteria : Csla.CriteriaBase<FeedCriteria>
    {
        public FeedCriteria()
        {
            this.FeedId = null;
            this.Type = null;
            this.Data = null;
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Type";
            this.SortOrder = ListSortDirection.Descending;
        }
    }
}
