using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.Business
{
    public partial class SprintCriteria
    {
        public int? SprintId { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }
        public bool? IsCompleted { get; set; }
        public DateRangeCriteria CompletedDate { get; set; }
        public DateRangeCriteria EstimatedCompletedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }
        public int? ModifiedBy { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }
    }
}