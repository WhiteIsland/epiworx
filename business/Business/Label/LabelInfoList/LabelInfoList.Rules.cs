using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Epiworx.Business
{
    public partial class LabelInfoList
    {
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(LabelInfoList),
                new IsInRole(AuthorizationActions.GetObject,
                    Role.FullControl.ToString(), Role.Contribute.ToString(), Role.Review.ToString()));
        }
    }
}
