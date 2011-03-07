using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Data.Validation;

namespace Epiworx.Business
{
    public partial class Label
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(SourceIdProperty, 0));
            this.BusinessRules.AddRule(new LabelSourceTypeRequired { PrimaryProperty = SourceTypeProperty });
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Label),
                  new IsInRole(AuthorizationActions.CreateObject,
                      Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Label),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Label),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }
    }
}
