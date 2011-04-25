using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class NoteData
    {
        public string Body { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public NoteData()
        {
            this.CreatedBy = new UserData();
        }

        public NoteData(XElement data)
            : this()
        {
            if (data == null)
            {
                return;
            }

            var ns = data.GetDefaultNamespace();

            this.Body = data.Element(ns + "Body").Value;
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);
        }
    }
}