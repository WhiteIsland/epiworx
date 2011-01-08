using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public static class Database
    {
        public static string SecurityConnection
        {
            get { return ConfigurationManager.ConnectionStrings["SecurityConnection"].ConnectionString; }
        }

        public static string ApplicationConnection
        {
            get { return ConfigurationManager.ConnectionStrings["ApplicationConnection"].ConnectionString; }
        }
    }
}
