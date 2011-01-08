using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public class DateRangeCriteria
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public bool HasValue
        {
            get { return this.DateFrom != DateTime.MinValue || this.DateTo != DateTime.MaxValue; }
        }

        public List<DateTime> Dates
        {
            get
            {
                var result = new List<DateTime>();

                for (var i = 0; i < this.DateTo.Subtract(this.DateFrom).Days + 1; i++)
                {
                    result.Add(this.DateFrom.AddDays(i).Date);
                }

                return result;
            }
        }

        public DateRangeCriteria()
        {
            this.DateFrom = DateTime.MinValue;
            this.DateTo = DateTime.MaxValue;
        }

        public DateRangeCriteria(DateTime startDate, DateTime endDate)
        {
            this.DateFrom = startDate;
            this.DateTo = endDate;
        }

        public DateRangeCriteria(int year)
        {
            this.DateFrom = DateTime.Parse(String.Format("1/1/{0}", year));
            this.DateTo = DateTime.Parse(String.Format("12/31/{0}", year));
        }
    }
}
