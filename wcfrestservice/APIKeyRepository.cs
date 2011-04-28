using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

namespace Epiworx.WcfRestService
{
    public class APIKeyRepository
    {
        public static bool IsValidAPIKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            if (key != ConfigurationManager.AppSettings["APIKey"])
            {
                return false;
            }

            return true;
        }
    }
}