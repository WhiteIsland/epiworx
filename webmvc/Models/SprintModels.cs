using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class SprintListModel : ModelBase
    {
        public int ProjectId { get; set; }
        public IQueryable<ISprint> Sprints { get; set; }
    }

    public class SprintFormModel : ModelBusinessBase
    {
        public int SprintId { get; set; }

        [DisplayName("Project:")]
        [IntegerRequired(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Estimated Completed Date:")]
        public DateTime EstimatedCompletedDate { get; set; }

        [DisplayName("Completed Date:")]
        public DateTime CompletedDate { get; set; }

        [DisplayName("This sprint is completed")]
        public bool IsCompleted { get; set; }

        [DisplayName("This sprint is active")]
        public bool IsActive { get; set; }

        [DisplayName("This sprint is archived")]
        public bool IsArchived { get; set; }

        public IEnumerable<IProject> Projects { get; set; }
    }
}