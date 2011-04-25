using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class StatusData
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public StatusData()
        {

        }

        public StatusData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Name = data.Element(ns + "Name").Value;
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
        }
    }
}