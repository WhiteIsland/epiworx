using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;

namespace Epiworx.Silverlight.Helpers
{
    public class DataHelper
    {
        public static string ServiceUri
        {
            get { return "http://epiworx.epitecgroup.com/api/"; }
        }

        public static string ServiceApiKey
        {
            get { return "8852324A-1062-42AB-88A9-B97958F66483-B2562557-0857-4023-B291-CF9AB6C29688"; }
        }

        public static IEnumerable<HourData> GetHours(DateTime start, DateTime end)
        {
            var uri = string.Format("{0}Hours?apikey={1}", ServiceUri, ServiceApiKey);

            uri += "&start=";
            uri += start.ToShortDateString();
            uri += "&end=";
            uri += end.ToShortDateString();

            var xml = XElement.Load(uri);
            var ns = xml.GetDefaultNamespace();
            var hours = xml.Elements(ns + "HourData");

            return hours
                .Select(hour => new HourData(hour))
                .ToList();
        }

        public static IEnumerable<ProjectData> GetProjects()
        {
            var uri = string.Format("{0}Projects?apikey={1}", ServiceUri, ServiceApiKey);

            var xml = XElement.Load(uri);
            var ns = xml.GetDefaultNamespace();
            var projects = xml.Elements(ns + "ProjectData");

            return projects
                .Select(project => new ProjectData(project))
                .ToList();
        }
    }
}