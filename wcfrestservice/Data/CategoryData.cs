using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class CategoryData
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }

        public CategoryData()
        {
        }

        public CategoryData(Category category)
            : this()
        {
            this.CategoryId = category.CategoryId;
            this.Name = category.Name;
            this.BackColor = category.BackColor;
            this.ForeColor = category.ForeColor;
        }
    }
}