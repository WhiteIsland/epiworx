using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Validation
{
    public class IntegerRequired : Csla.Rules.CommonRules.CommonBusinessRule
    {
        public int EmptyValue { get; internal set; }

        public IntegerRequired(Csla.Core.IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            this.EmptyValue = 0;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        public IntegerRequired(Csla.Core.IPropertyInfo primaryProperty, int emptyValue)
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
