using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Validation
{
    public class DateRequired : Csla.Rules.CommonRules.CommonBusinessRule
    {
        public DateTime MinValue { get; internal set; }
        public DateTime MaxValue { get; internal set; }

        public DateRequired(Csla.Core.IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            this.MinValue = DateTime.MinValue.Date;
            this.MaxValue = DateTime.MaxValue.Date;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        public DateRequired(Csla.Core.IPropertyInfo primaryProperty, DateTime minValue, DateTime maxValue)
            : base(primaryProperty)
        {
            this.MinValue = minValue.Date;
            this.MaxValue = maxValue.Date;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        protected override void Execute(Csla.Rules.RuleContext context)
        {
            var value = context.InputPropertyValues[PrimaryProperty];

            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || value.ToString() == this.MinValue.ToString()
                || value.ToString() == this.MaxValue.ToString())
            {
                var message = string.Format(Csla.Properties.Resources.StringRequiredRule, PrimaryProperty.FriendlyName);
                context.Results.Add(new Csla.Rules.RuleResult(RuleName, PrimaryProperty, message) { Severity = Severity });
            }
        }
    }
}
