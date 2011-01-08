using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class ProjectInfoList
    {
        internal static ProjectInfoList FetchProjectInfoList(ProjectCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectInfoList>(criteria);
        }
    }
}
