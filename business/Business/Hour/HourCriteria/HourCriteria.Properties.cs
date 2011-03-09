using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class HourCriteria
    {
        public int? HourId { get; set; }
        public int[] TaskId { get; set; }
        public int[] ProjectId { get; set; }
        public int[] UserId { get; set; }
        public DateRangeCriteria Date { get; set; }
        public decimal? Duration { get; set; }
        public string Labels { get; set; }
        public bool? IsArchived { get; set; }
        public string Notes { get; set; }
        public int? ModifiedBy { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string[] TaskLabels { get; set; }
        public string Text { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }
    }
}