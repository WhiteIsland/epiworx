using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;
using Epiworx.Silverlight.Helpers;

namespace Epiworx.Silverlight.Controls
{
    public partial class ProjectListUserControl : UserControl
    {
        public ProjectListUserControl()
        {
            InitializeComponent();

            this.LoadData();
        }

        private void LoadData()
        {
            var proxy = new WebClient();
            var uri = string.Format("{0}Projects?apikey={1}", DataHelper.ServiceUri, DataHelper.ServiceApiKey);

            proxy.OpenReadCompleted += OnReadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        void OnReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            var xml = XElement.Load(e.Result);
            var ns = xml.GetDefaultNamespace();
            var projects = xml.Elements(ns + "ProjectData")
                .Select(project => new ProjectData(project))
                .ToList();

            this.ProjectList.ItemsSource = projects;
        }
    }
}
