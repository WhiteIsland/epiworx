using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class HourData
    {
        public int HourId { get; set; }
        public DateTime Date { get; set; }
        public UserData User { get; set; }
        public string Notes { get; set; }
        public Decimal Duration { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }

        public HourData()
        {
        }

        public HourData(Hour hour)
            : this()
        {
            this.HourId = hour.HourId;
            this.Date = hour.Date;
            this.User = new UserData(hour.User);
            this.Notes = hour.Notes;
            this.CreatedBy = new UserData(hour.CreatedByUser);
            this.CreateDate = hour.CreatedDate;
        }
    }
}