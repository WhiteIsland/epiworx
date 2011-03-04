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
    public partial class Attachment
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new AttachmentSourceTypeRequired { PrimaryProperty = SourceTypeProperty });
            this.BusinessRules.AddRule(new IntegerRequired(SourceIdProperty, 0));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Attachment),
                 new IsInRole(AuthorizationActions.CreateObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Attachment),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Attachment),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }
    }
}
