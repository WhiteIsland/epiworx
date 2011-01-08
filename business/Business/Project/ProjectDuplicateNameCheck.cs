using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class ProjectDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IProject)context.Target;
            var projects = ProjectInfoList.FetchProjectInfoList(new ProjectCriteria
                {
                    Name = target.Name
                });

            if (projects.Count(row => row.ProjectId != target.ProjectId) != 0)
            {
                context.AddErrorResult("That project name is already in use.");
            }
        }
    }
}
