using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService
{
    public class APIKey
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public APIKey(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.Value = row["Value"].ToString();
        }
    }
}