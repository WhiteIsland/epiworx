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
    public class HourIndexModel : HourListModel
    {
        public int[] ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDisplayName { get; set; }
        public int[] UserId { get; set; }
        public string UserName { get; set; }
        public string UserDisplayName { get; set; }
        public string Date { get; set; }
        public int IsArchived { get; set; }
    }

    public class HourListModel : ModelListBase
    {
        public bool HideUserColumn { get; set; }
        public IEnumerable<IHour> Hours { get; set; }
        public IEnumerable<IUser> Users { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
    }

    public class HourFormModel : ModelBusinessBase
    {
        public int HourId { get; set; }

        [DisplayName("Project:")]
        [IntegerRequired(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }

        [DisplayName("Task:")]
        public int TaskId { get; set; }

        [DisplayName("User:")]
        [IntegerRequired(ErrorMessage = "User is required")]
        public int UserId { get; set; }

        [DisplayName("User:")]
        public string UserName { get; set; }

        [DisplayName("Date:")]
        public DateTime Date { get; set; }

        [DisplayName("Duration:")]
        [DecimalRequired(ErrorMessage = "Duration is required")]
        public decimal Duration { get; set; }

        [DisplayName("Enter some notes that provide more detail about the task:")]
        public string Notes { get; set; }

        [DisplayName("This hour is archived")]
        public bool IsArchived { get; set; }

        public ITask Task { get; set; }

        public IEnumerable<IUser> Users { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
    }
}