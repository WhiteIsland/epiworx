using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public UserData()
        {

        }

        public UserData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Name = data.Element(ns + "Name").Value;
            this.Email = data.Element(ns + "Email").Value;
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
        }
    }
}