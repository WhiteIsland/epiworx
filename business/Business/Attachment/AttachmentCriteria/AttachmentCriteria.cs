using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Business
{
    [Serializable]
    public partial class AttachmentCriteria : Csla.CriteriaBase<AttachmentCriteria>
    {
        public AttachmentCriteria()
        {
            this.AttachmentId = null;
            this.SourceType = null;
            this.SourceId = null;
            this.Name = null;
            this.FileType = null;
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
