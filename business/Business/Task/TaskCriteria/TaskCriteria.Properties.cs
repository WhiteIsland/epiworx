using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class TaskCriteria
    {
        public int? TaskId { get; set; }
        public int[] ProjectId { get; set; }
        public int? SprintId { get; set; }
        public int[] CategoryId { get; set; }
        public int[] StatusId { get; set; }
        public string Description { get; set; }
        public int[] AssignedTo { get; set; }
        public DateRangeCriteria AssignedDate { get; set; }
        public DateRangeCriteria StartDate { get; set; }
        public DateRangeCriteria CompletedDate { get; set; }
        public DateRangeCriteria EstimatedCompletedDate { get; set; }
        public decimal? Duration { get; set; }
        public decimal? EstimatedDuration { get; set; }
        public string Label { get; set; }
        public bool? IsArchived { get; set; }
        public string Notes { get; set; }
        public int? ModifiedBy { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }
        public string[] TaskLabels { get; set; }
    }
}