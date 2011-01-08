using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epiworx.Security;

namespace Epiworx.Tests
{
    [TestClass]
    public class CategoryTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public CategoryTests()
        {
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            CategoryTests.UserName = DataHelper.RandomString(20);
            CategoryTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                CategoryTests.UserName,
                CategoryTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                CategoryTests.UserName,
                CategoryTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Category_New()
        {
            var category = CategoryService.CategoryNew();

            Assert.IsTrue(category.IsNew, "IsNew should be true");
            Assert.IsTrue(category.IsDirty, "IsDirty should be true");
            Assert.IsFalse(category.IsValid, "IsValid should be false");
            Assert.IsTrue(category.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(category.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(category.IsActive, "IsActive should be true");
            Assert.IsFalse(category.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(category, DbType.String, "Name"),
                "Name should be required");
        }

        [TestMethod]
        public void Category_Add()
        {
            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            Assert.IsTrue(category.IsValid, "IsValid should be true");

            CategoryService.CategorySave(category);
        }

        [TestMethod]
        public void Category_Add_With_Duplicate_Name()
        {
            var category = CategoryService.CategoryNew();
            var name = DataHelper.RandomString(20);

            category.Name = name;

            CategoryService.CategorySave(category);

            category = CategoryService.CategoryNew();

            category.Name = name;

            Assert.IsTrue(ValidationHelper.ContainsRule(category, "rule://epiworx.business.categoryduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Category_Edit()
        {
            var category = CategoryService.CategoryNew();
            var name = DataHelper.RandomString(20);

            category.Name = name;

            category = CategoryService.CategorySave(category);

            category = CategoryService.CategoryFetch(category.CategoryId);

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            category = CategoryService.CategoryFetch(category.CategoryId);

            Assert.IsTrue(category.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Category_Delete()
        {
            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            category = CategoryService.CategoryFetch(category.CategoryId);

            CategoryService.CategoryDelete(category.CategoryId);

            try
            {
                CategoryService.CategoryFetch(category.CategoryId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Category_Fetch()
        {
            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            category = CategoryService.CategoryFetch(category.CategoryId);

            Assert.IsFalse(category == null, "Category should not be null");
        }

        [TestMethod]
        public void Category_Fetch_List()
        {
            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            category.Name = DataHelper.RandomString(20);

            CategoryService.CategorySave(category);

            var categories = CategoryService.CategoryFetchInfoList();

            Assert.IsTrue(categories.Count > 1, "Categories should be greater than one");
        }

    }
}
