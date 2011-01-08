using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Validation
{
    public class GuidRequired : Csla.Rules.CommonRules.CommonBusinessRule
    {
        public Guid EmptyValue { get; internal set; }

        public GuidRequired(Csla.Core.IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            this.EmptyValue = Guid.Empty;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        protected override void Execute(Csla.Rules.RuleContext context)
        {
            var value = context.InputPropertyValues[PrimaryProperty];
            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || value.ToString() == this.EmptyValue.ToString())
            {
                var message = string.Format(Csla.Properties.Resources.StringRequiredRule, PrimaryProperty.FriendlyName);
                context.Results.Add(new Csla.Rules.RuleResult(RuleName, PrimaryProperty, message) { Severity = Severity });
            }
        }
    }
}
