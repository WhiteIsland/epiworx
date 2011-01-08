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
    public partial class Status
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StatusDuplicateNameCheck { PrimaryProperty = NameProperty });
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Status),
                 new IsInRole(AuthorizationActions.CreateObject,
                     Role.FullControl.ToString()));

            BusinessRules.AddRule(typeof(Status),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString()));

            BusinessRules.AddRule(typeof(Status),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString()));
        }
    }
}
