using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class AttachmentSourceTypeRequired : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IAttachment)context.Target;
            if (target.SourceType == SourceType.None)
            {
                context.AddErrorResult("SourceType is required.");
            }
        }
    }
}
