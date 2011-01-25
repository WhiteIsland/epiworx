using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class SprintInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static SprintInfo FetchSprintInfo(Data.Sprint data)
        {
            var result = new SprintInfo();
            result.Fetch(data);
            return result;
        }
    }
}
