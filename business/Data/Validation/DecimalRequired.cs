using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Validation
{
    public class DecimalRequired : Csla.Rules.CommonRules.CommonBusinessRule
    {
        public decimal EmptyValue { get; internal set; }

        public DecimalRequired(Csla.Core.IPropertyInfo primaryProperty, decimal emptyValue)
            : base(primaryProperty)
        {
            this.EmptyValue = emptyValue;
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
