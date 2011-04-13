using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class TaskData
    {
        public int TaskId { get; set; }
        public CategoryData Category { get; set; }
        public StatusData Status { get; set; }
        public string Description { get; set; }

        public TaskData()
        {
        }

        public TaskData(Task task)
            : this()
        {
            this.TaskId = task.TaskId;
            this.Category = new CategoryData(task.Category);
            this.Status = new StatusData(task.Status);
            this.Description = task.Description;
        }
    }
}