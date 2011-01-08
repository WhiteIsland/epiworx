using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class StatusListModel : ModelBase
    {
        public IQueryable<IStatus> Statuses { get; set; }
    }

    public class StatusFormModel : ModelBusinessBase
    {
        public int StatusId { get; set; }

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

        [DisplayName("This status marks the task as started")]
        public bool IsStarted { get; set; }

        [DisplayName("This status marks the task as completed")]
        public bool IsCompleted { get; set; }

        [DisplayName("This status is active")]
        public bool IsActive { get; set; }

        [DisplayName("This status is archived")]
        public bool IsArchived { get; set; }
    }
}