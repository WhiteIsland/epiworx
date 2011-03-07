using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Business
{
    [Serializable]
    public partial class LabelCriteria : Csla.CriteriaBase<LabelCriteria>
    {
        public LabelCriteria()
        {
            this.SourceId = null;
            this.SourceType = null;
            this.Name = null;
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Descending;
        }
    }
}
