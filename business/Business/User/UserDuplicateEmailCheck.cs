using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class UserDuplicateEmailCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IUser)context.Target;
            var users = UserInfoList.FetchUserInfoList(new UserCriteria { Email = target.Email });
            if (users.Count(row => row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult("That email address is already in use.");
            }
        }
    }
}
