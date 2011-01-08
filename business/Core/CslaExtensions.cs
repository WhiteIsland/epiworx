using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Core
{
    public static class CslaExtensions
    {
        public static bool Contains(this BrokenRulesCollection brokenRules, string ruleName)
        {
            return brokenRules.Any(brokenRule => brokenRule.RuleName == ruleName);
        }
    }
}
