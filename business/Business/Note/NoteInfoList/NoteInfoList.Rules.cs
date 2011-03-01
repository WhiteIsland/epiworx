using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class NoteInfoList
    {
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(NoteInfoList),
                  new IsInRole(AuthorizationActions.GetObject,
                      Role.FullControl.ToString(), Role.Contribute.ToString(), Role.Review.ToString()));
        }
    }
}
