using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class SprintDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (ISprint)context.Target;
            var projects = SprintInfoList.FetchSprintInfoList(new SprintCriteria
                {
                    ProjectId = target.ProjectId,
                    Name = target.Name
                });

            if (projects.Count(row => row.SprintId != target.SprintId) != 0)
            {
                context.AddErrorResult("That sprint name is already in use.");
            }
        }
    }
}
