using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class CategoryData
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public CategoryData()
        {

        }

        public CategoryData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Name = data.Element(ns + "Name").Value;
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
        }
    }
}