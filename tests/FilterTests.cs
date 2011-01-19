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
    public class FilterTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public FilterTests()
        {
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            FilterTests.UserName = DataHelper.RandomString(20);
            FilterTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                FilterTests.UserName,
                FilterTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                FilterTests.UserName,
                FilterTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Filter_New()
        {
            var filter = FilterService.FilterNew();

            Assert.IsTrue(filter.IsNew, "IsNew should be true");
            Assert.IsTrue(filter.IsDirty, "IsDirty should be true");
            Assert.IsFalse(filter.IsValid, "IsValid should be false");
            Assert.IsTrue(filter.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(filter.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(filter.IsActive, "IsActive should be true");

            Assert.IsTrue(ValidationHelper.ContainsRule(filter, DbType.String, "Name"),
                "Name should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(filter, DbType.String, "Target"),
                "Target should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(filter, DbType.String, "Query"),
                "Query should be required");
        }

        [TestMethod]
        public void Filter_Add()
        {
            var filter = FilterService.FilterNew();

            filter.Name = DataHelper.RandomString(20);
            filter.Target = DataHelper.RandomString(20);
            filter.Query = DataHelper.RandomString(20);

            Assert.IsTrue(filter.IsValid, "IsValid should be true");

            FilterService.FilterSave(filter);
        }

        [TestMethod]
        public void Filter_Edit()
        {
            var filter = FilterService.FilterNew();
            var name = DataHelper.RandomString(20);

            filter.Name = name;
            filter.Target = DataHelper.RandomString(20);
            filter.Query = DataHelper.RandomString(20);

            filter = FilterService.FilterSave(filter);

            filter = FilterService.FilterFetch(filter.FilterId);

            filter.Name = DataHelper.RandomString(20);

            filter = FilterService.FilterSave(filter);

            filter = FilterService.FilterFetch(filter.FilterId);

            Assert.IsTrue(filter.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Filter_Delete()
        {
            var filter = FilterService.FilterNew();

            filter.Name = DataHelper.RandomString(20);
            filter.Target = DataHelper.RandomString(20);
            filter.Query = DataHelper.RandomString(20);

            filter = FilterService.FilterSave(filter);

            filter = FilterService.FilterFetch(filter.FilterId);

            FilterService.FilterDelete(filter.FilterId);

            try
            {
                FilterService.FilterFetch(filter.FilterId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Filter_Fetch()
        {
            var filter = FilterService.FilterNew();

            filter.Name = DataHelper.RandomString(20);
            filter.Target = DataHelper.RandomString(20);
            filter.Query = DataHelper.RandomString(20);

            filter = FilterService.FilterSave(filter);

            filter = FilterService.FilterFetch(filter.FilterId);

            Assert.IsFalse(filter == null, "Filter should not be null");
        }

        [TestMethod]
        public void Filter_Fetch_List()
        {
            var filter = FilterService.FilterNew();

            filter.Name = DataHelper.RandomString(20);
            filter.Target = DataHelper.RandomString(20);
            filter.Query = DataHelper.RandomString(20);

            filter = FilterService.FilterSave(filter);

            filter.Name = DataHelper.RandomString(20);

            FilterService.FilterSave(filter);

            var categories = FilterService.FilterFetchInfoList();

            Assert.IsTrue(categories.Count > 1, "Filters should be greater than one");
        }

    }
}
