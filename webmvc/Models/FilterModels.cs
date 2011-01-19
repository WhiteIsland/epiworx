using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class FilterListModel : ModelBase
    {
        public string Target { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
    }

    public class FilterFormModel : ModelBusinessBase
    {
        public int FilterId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Target:")]
        [Required(ErrorMessage = "Target is required")]
        public string Target { get; set; }

        [DisplayName("Query:")]
        [Required(ErrorMessage = "Query is required")]
        public string Query { get; set; }

        [DisplayName("This filter is active")]
        public bool IsActive { get; set; }
    }
}