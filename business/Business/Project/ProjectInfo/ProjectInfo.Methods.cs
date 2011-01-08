using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class ProjectInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static ProjectInfo FetchProjectInfo(Data.Project data)
        {
            var result = new ProjectInfo();
            result.Fetch(data);
            return result;
        }
    }
}
