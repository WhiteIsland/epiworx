using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class HourData
    {
        public DateTime Date { get; set; }
        public TaskData Task { get; set; }
        public ProjectData Project { get; set; }
        public decimal Duration { get; set; }
        public UserData User { get; set; }
        public string Notes { get; set; }

        public HourData()
        {

        }

        public HourData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Date = DateTime.Parse(data.Element(ns + "Date").Value);
            this.Project = new ProjectData(data.Element(ns + "Project"));
            this.Duration = decimal.Parse(data.Element(ns + "Duration").Value);
            this.User = new UserData(data.Element(ns + "User"));
            this.Notes = data.Element(ns + "Notes").Value;
        }
    }
}