using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class HourInfo
    {
        public override string ToString()
        {
            return string.Format("{0:d} for {1}", this.Date, this.UserName);
        }

        internal static HourInfo FetchHourInfo(Data.Hour data)
        {
            var result = new HourInfo();
            result.Fetch(data);
            return result;
        }
    }
}
