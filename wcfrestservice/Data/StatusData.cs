using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class StatusData
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }

        public StatusData()
        {
        }

        public StatusData(Status status)
            : this()
        {
            this.StatusId = status.StatusId;
            this.Name = status.Name;
            this.BackColor = status.BackColor;
            this.ForeColor = status.ForeColor;
        }
    }
}