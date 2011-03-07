using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Data.Validation;

namespace Epiworx.Business
{
    public partial class TaskLabel
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(TaskLabel),
                  new IsInRole(AuthorizationActions.CreateObject,
                      Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(TaskLabel),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(TaskLabel),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }
    }
}
