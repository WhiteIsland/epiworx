using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Data.Validation;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Invoice
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(ProjectIdProperty, 0));
            this.BusinessRules.AddRule(new IntegerRequired(TaskIdProperty, 0));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Invoice),
                new IsInRole(AuthorizationActions.DeleteObject,
                    Role.FullControl.ToString()));
        }
    }
}
