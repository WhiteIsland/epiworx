using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class CategoryListModel : ModelBase
    {
        public IQueryable<ICategory> Categories { get; set; }
    }

    public class CategoryFormModel : ModelBusinessBase
    {
        public int CategoryId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        [DisplayName("Display order:")]
        public int Ordinal { get; set; }

        [DisplayName("Fore color:")]
        public string ForeColor { get; set; }

        [DisplayName("Back color:")]
        public string BackColor { get; set; }

        [DisplayName("This category is active")]
        public bool IsActive { get; set; }

        [DisplayName("This category is archived")]
        public bool IsArchived { get; set; }
    }
}