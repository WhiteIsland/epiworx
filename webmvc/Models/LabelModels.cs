using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Models
{
    public class LabelListModel : ModelBase
    {
        public string Action { get; set; }
        public string Label { get; set; }
        public IEnumerable<string> Labels { get; set; }
    }

    public class LabelByCountListModel : ModelBase
    {
        public string Action { get; set; }
        public string Label { get; set; }
        public IEnumerable<ILabelByCount> Labels { get; set; }
    }
}