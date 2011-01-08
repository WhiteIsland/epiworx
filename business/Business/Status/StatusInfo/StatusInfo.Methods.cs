using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class StatusInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static StatusInfo FetchStatusInfo(Data.Status data)
        {
            var result = new StatusInfo();
            result.Fetch(data);
            return result;
        }
    }
}
