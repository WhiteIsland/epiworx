using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FilterCriteria
    {
        public int? FilterId { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public string Query { get; set; }
        public bool? IsActive { get; set; }
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