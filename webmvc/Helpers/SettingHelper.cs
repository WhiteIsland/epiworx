using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Helpers
{
    public enum ConfigurationMode
    {
        Simple = 0,
        Advanced = 1
    }

    public class SettingHelper
    {
        public static string EncryptionKey
        {
            get { return ConfigurationManager.AppSettings["EncryptionKey"]; }
        }

        public static ConfigurationMode LabelMode
        {
            get
            {
                int result;

                if (int.TryParse(ConfigurationManager.AppSettings["LabelMode"], out result))
                {
                    return (ConfigurationMode)result;
                }

                return ConfigurationMode.Simple;
            }
        }

        public static IDictionary<decimal, string> EstimatedDurations
        {
            get
            {
                var result = new Dictionary<decimal, string>();
                var values = ConfigurationManager.AppSettings["EstimatedDurations"];

                if (string.IsNullOrEmpty(values))
                {
                    values = "1,2,3,4";
                }

                foreach (var value in values.Split(','))
                {
                    if (value.Contains("="))
                    {
                        result.Add(decimal.Parse(value.Split('=')[0].Trim()), value.Split('=')[1].Trim());
                    }
                    else
                    {
                        result.Add(decimal.Parse(value.Trim()), value.Trim());
                    }
                }

                return result;
            }
        }
    }
}