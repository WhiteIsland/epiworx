using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class TaskData
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public UserData AssignedTo { get; set; }
        public StatusData Status { get; set; }
        public CategoryData Category { get; set; }

        public TaskData()
        {
            this.Status = new StatusData();
            this.Category = new CategoryData();
        }

        public TaskData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.TaskId = int.Parse(data.Element(ns + "TaskId").Value);
            this.Description = data.Element(ns + "Description").Value;
            this.AssignedTo = new UserData(data.Element(ns + "AssignedTo"));
            this.Status = new StatusData(data.Element(ns + "Status"));
            this.Category = new CategoryData(data.Element(ns + "Category"));
        }
    }
}