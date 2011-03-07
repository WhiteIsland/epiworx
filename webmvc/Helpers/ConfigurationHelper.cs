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

    public class ConfigurationHelper
    {
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
    }
}