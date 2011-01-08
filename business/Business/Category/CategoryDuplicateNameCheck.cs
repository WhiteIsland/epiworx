using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;

namespace Epiworx.Business
{
    public class CategoryDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (ICategory)context.Target;
            var users = CategoryInfoList.FetchCategoryInfoList(new CategoryCriteria { Name = target.Name });
            if (users.Count(row => row.CategoryId != target.CategoryId) != 0)
            {
                context.AddErrorResult("That category name is already in use.");
            }
        }
    }
}
