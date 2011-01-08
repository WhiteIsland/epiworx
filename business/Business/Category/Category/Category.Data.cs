using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Category
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(CategoryCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Category> query = ctx.ObjectContext.Categories;

                if (criteria.CategoryId != null)
                {
                    query = query.Where(row => row.CategoryId == criteria.CategoryId);
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

        protected void Fetch(Data.Category data)
        {
            this.LoadProperty(CategoryIdProperty, data.CategoryId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(OrdinalProperty, data.Ordinal);
            this.LoadProperty(ForeColorProperty, data.ForeColor);
            this.LoadProperty(BackColorProperty, data.BackColor);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
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
                var data = new Data.Category();

                this.Insert(data);

                ctx.ObjectContext.AddToCategories(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(CategoryIdProperty, data.CategoryId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Category data)
        {
            data.CategoryId = this.ReadProperty(CategoryIdProperty);
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
                var data = new Data.Category
                {
                    CategoryId = this.ReadProperty(CategoryIdProperty)
                };

                ctx.ObjectContext.Categories.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Category data)
        {
            if (this.IsSelfDirty)
            {
                data.Name = this.ReadProperty(NameProperty);
                data.Description = this.ReadProperty(DescriptionProperty);
                data.Ordinal = this.ReadProperty(OrdinalProperty);
                data.ForeColor = this.ReadProperty(ForeColorProperty);
                data.BackColor = this.ReadProperty(BackColorProperty);
                data.IsActive = this.ReadProperty(IsActiveProperty);
                data.IsArchived = this.ReadProperty(IsArchivedProperty);
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
                var data = new Data.Category
                {
                    CategoryId = this.ReadProperty(CategoryIdProperty)
                };

                ctx.ObjectContext.Categories.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(CategoryCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Categories
                    .Single(row => row.CategoryId == criteria.CategoryId);

                ctx.ObjectContext.Categories.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}