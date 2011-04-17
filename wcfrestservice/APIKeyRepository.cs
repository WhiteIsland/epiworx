using System;
using System.Collections.Generic;
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
        private static string APIKeyFile
        {
            get { return HttpContext.Current.Server.MapPath("~/App_Data/APIKeys.xml"); }
        }

        public static bool IsValidAPIKey(string key)
        {
            // TODO: Implement IsValidAPI Key using your repository
            //APIKeyRepository.CreateFile();
            //APIKeyRepository.AddKey();

            // Convert the string into a Guid and validate it
            if (!string.IsNullOrEmpty(key)
                && APIKeyRepository.APIKeys.Any(row => row.Value == key))
            {
                return true;
            }

            return false;
        }

        private static IEnumerable<APIKey> APIKeys
        {
            get
            {
                // Get from the cache
                // Could also use AppFabric cache for scalability
                var keys = HttpContext.Current.Cache[APIKeyRepository.APIKeyList] as IEnumerable<APIKey>;

                if (keys == null)
                {
                    keys = APIKeyRepository.PopulateAPIKeys();
                }

                return keys;
            }
        }

        private static IEnumerable<APIKey> PopulateAPIKeys()
        {
            //if (!File.Exists(APIKeyRepository.APIKeyFile))
            //{
            //    APIKeyRepository.CreateFile();
            //}

            var ds = new DataSet();

            ds.ReadXml(APIKeyRepository.APIKeyFile, XmlReadMode.ReadSchema);

            var keyList = new List<APIKey>();

            foreach (DataRow row in ds.Tables["APIKey"].Rows)
            {
                keyList.Add(new APIKey(row));
            }

            HttpContext.Current.Cache[APIKeyRepository.APIKeyList] = keyList;

            return keyList;
        }

        //private static void CreateFile()
        //{
        //    var ds = new DataSet();

        //    ds.DataSetName = "APIKeys";

        //    var dt = new DataTable();

        //    dt.TableName = "APIKey";

        //    DataColumn col;

        //    col = dt.Columns.Add("Key", typeof(string));
        //    col.AllowDBNull = false;
        //    col.Unique = true;

        //    col = dt.Columns.Add("Value", typeof(string));
        //    col.AllowDBNull = false;
        //    col.Unique = true;

        //    ds.Tables.Add(dt);

        //    ds.WriteXml(APIKeyRepository.APIKeyFile, XmlWriteMode.WriteSchema);
        //}

        const string APIKeyList = "APIKeyList";
    }
}