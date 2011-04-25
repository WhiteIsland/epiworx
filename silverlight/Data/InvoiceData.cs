using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class InvoiceData
    {
        public ProjectData Project { get; set; }
        public TaskData Task { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public DateTime PreparedDate { get; set; }
        public decimal Amount { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public InvoiceData()
        {

        }

        public InvoiceData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Project = new ProjectData(data.Element(ns + "Project"));
            this.Task = new TaskData(data.Element(ns + "Task"));
            this.Number = data.Element(ns + "Number").Value;
            this.Description = data.Element(ns + "Description").Value;
            this.PreparedDate = DateTime.Parse(data.Element(ns + "PreparedDate").Value);
            this.Amount = decimal.Parse(data.Element(ns + "Amount").Value);
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);
        }
    }
}