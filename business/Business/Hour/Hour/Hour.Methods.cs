using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Epiworx.Business
{
    public partial class Hour
    {
        public override string ToString()
        {
            return string.Format("{0:d} for {1}", this.Date, this.UserName);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                case "ProjectId":
                    this.OnProjectIdChanged();
                    break;
                case "UserId":
                    this.OnUserIdChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnUserIdChanged()
        {
            this.LoadProperty(UserNameProperty, ForeignKeyMapper.FetchUserName(this.UserId));
        }

        private void OnProjectIdChanged()
        {
            this.LoadProperty(ProjectNameProperty, ForeignKeyMapper.FetchProjectName(this.ProjectId));
        }

        internal static Hour NewHour()
        {
            return Csla.DataPortal.Create<Hour>();
        }

        internal static Hour FetchHour(HourCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Hour>(criteria);
        }

        internal static void DeleteHour(HourCriteria criteria)
        {
            var hour = Hour.FetchHour(criteria);

            if (!Hour.CanDeleteObject(hour))
            {
                throw new SecurityException("Only users with full control can delete and archived hour");
            }

            Csla.DataPortal.Delete<Hour>(criteria);
        }

        public override Hour Save()
        {
            if (this.IsDirty
                && !this.IsNew
                && !Hour.CanSaveObject(this))
            {
                throw new SecurityException("Only users with full control can edit or delete and archived hour");
            }

            return base.Save();
        }
    }
}
