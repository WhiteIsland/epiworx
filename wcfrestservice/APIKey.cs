using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService
{
    public class APIKey
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public APIKey(DataRow row)
        {
            this.Key = row["Key"].ToString();
            this.Value = row["Value"].ToString();
        }
    }
}