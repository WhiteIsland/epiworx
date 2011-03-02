using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Business
{
    [Serializable]
    public partial class NoteCriteria : Csla.CriteriaBase<NoteCriteria>
    {
        public NoteCriteria()
        {
            this.NoteId = null;
            this.SourceType = null;
            this.SourceId = null;
            this.Body = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "CreatedDate";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
