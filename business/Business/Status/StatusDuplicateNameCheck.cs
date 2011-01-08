using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class StatusDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IStatus)context.Target;
            var users = StatusInfoList.FetchStatusInfoList(new StatusCriteria { Name = target.Name });
            if (users.Count(row => row.StatusId != target.StatusId) != 0)
            {
                context.AddErrorResult("That status name is already in use.");
            }
        }
    }
}
