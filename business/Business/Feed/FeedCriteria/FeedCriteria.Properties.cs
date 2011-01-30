using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FeedCriteria
    {
        public int? FeedId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }
    }
}