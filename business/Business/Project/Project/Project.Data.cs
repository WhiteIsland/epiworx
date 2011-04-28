using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Project
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(ProjectCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Project> query = ctx.ObjectContext.Projects;

                if (criteria.ProjectId != null)
                {
                    query = query.Where(row => row.ProjectId == criteria.ProjectId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                var data = query.Single();
                
                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Project data)
        {
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
            this.LoadProperty(NotesProperty, data.Notes);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Project();

                this.Insert(data);

                ctx.ObjectContext.AddToProjects(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ProjectIdProperty, data.ProjectId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Project data)
        {
            data.ProjectId = this.ReadProperty(ProjectIdProperty);
            data.CreatedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
            data.CreatedDate = DateTime.Now;

            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Project
                {
                    ProjectId = this.ReadProperty(ProjectIdProperty)
                };

                ctx.ObjectContext.Projects.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Project data)
        {
            if (this.IsSelfDirty)
            {
                data.Name = this.ReadProperty(NameProperty);
                data.Description = this.ReadProperty(DescriptionProperty);
                data.IsActive = this.ReadProperty(IsActiveProperty);
                data.IsArchived = this.ReadProperty(IsArchivedProperty);
                data.Notes = this.ReadProperty(NotesProperty);
                data.ModifiedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                data.ModifiedDate = DateTime.Now;
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Project
                {
                    ProjectId = this.ReadProperty(ProjectIdProperty)
                };

                ctx.ObjectContext.Projects.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(ProjectCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Projects
                    .Single(row => row.ProjectId == criteria.ProjectId);

                ctx.ObjectContext.Projects.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}