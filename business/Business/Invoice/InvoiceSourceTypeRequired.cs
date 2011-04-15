using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class InvoiceSourceTypeRequired : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IInvoice)context.Target;
            if (target.SourceType == SourceType.None)
            {
                context.AddErrorResult("SourceType is required.");
            }
        }
    }
}
