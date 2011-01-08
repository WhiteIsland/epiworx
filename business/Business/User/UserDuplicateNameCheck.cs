using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class UserDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IUser)context.Target;
            var users = UserInfoList.FetchUserInfoList(new UserCriteria { Name = target.Name });
            if (users.Count(row => row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult("That user name is already in use.");
            }
        }
    }
}
