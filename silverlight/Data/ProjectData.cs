using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class ProjectData
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public NoteData LastNote { get; set; }

        public ProjectData()
        {
            this.LastNote = new NoteData();
        }

        public ProjectData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Name = data.Element(ns + "Name").Value;
            this.LastNote = new NoteData(data.Element(ns + "Notes").Elements(ns + "NoteData").FirstOrDefault());
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
        }
    }
}