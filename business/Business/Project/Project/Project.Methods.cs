using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Project
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static Project NewProject()
        {
            return Csla.DataPortal.Create<Project>();
        }

        internal static Project FetchProject(ProjectCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Project>(criteria);
        }

        internal static void DeleteProject(ProjectCriteria criteria)
        {
            Csla.DataPortal.Delete<Project>(criteria);
        }
    }
}
