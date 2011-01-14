using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using Epiworx.Security;
using Epiworx.WebMvc.Helpers;

namespace Epiworx.WebMvc.Models
{
    public class ModelBase
    {
        public string Tab { get; set; }
    }

    public class ModelListBase : ModelBase
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public Dictionary<string, string> SortableColumns { get; set; }

        public ModelListBase()
        {
            this.SortableColumns = new Dictionary<string, string>();
        }
    }

    public class ModelBusinessBase : ModelBase
    {
        public bool IsNew { get; set; }
        public bool IsValid { get; set; }
    }

    public class DecimalRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            decimal checkValue;

            if (decimal.TryParse(value.ToString(), out checkValue))
            {
                if (checkValue > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class IntegerRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            int checkValue;

            if (int.TryParse(value.ToString(), out checkValue))
            {
                if (checkValue > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}