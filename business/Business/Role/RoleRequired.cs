using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class RoleRequired : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IUser)context.Target;
            if (target.Role == Role.None)
            {
                context.AddErrorResult("Role is required.");
            }
        }
    }
}
