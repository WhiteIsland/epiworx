using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Business
{
    public partial class AttachmentCriteria
    {
        public int? AttachmentId { get; set; }
        public SourceType? SourceType { get; set; }
        public int? SourceId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
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