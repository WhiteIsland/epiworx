using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Epitec.Epiworx.Data
{
    public class DataMapper
    {
        public static void Map(object source, object destination)
        {
            var properties = destination.GetType().GetProperties();

            for (var index = 0; index <= properties.Length - 1; index++)
            {
                if (!properties[index].CanWrite)
                {
                    continue;
                }

                var p = source.GetType().GetProperty(properties[index].Name);

                if (p == null)
                {
                    continue;
                }

                var value = p.GetValue(source, null);

                DataMapper.SetValue(destination, properties[index].Name, value);
            }
        }

        private static void SetValue(object obj, string name, object value)
        {
            try
            {
                var p = obj.GetType().GetProperty(name);

                p.SetValue(obj, value, null);
            }
            catch
            {

            }
        }
    }
}
