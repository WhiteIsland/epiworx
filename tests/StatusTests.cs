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
    public class StatusTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public StatusTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            StatusTests.UserName = DataHelper.RandomString(20);
            StatusTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                StatusTests.UserName,
                StatusTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                StatusTests.UserName,
                StatusTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Status_New()
        {
            var status = StatusService.StatusNew();

            Assert.IsTrue(status.IsNew, "IsNew should be true");
            Assert.IsTrue(status.IsDirty, "IsDirty should be true");
            Assert.IsFalse(status.IsValid, "IsValid should be false");
            Assert.IsTrue(status.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(status.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(status.IsActive, "IsActive should be true");
            Assert.IsFalse(status.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(status, DbType.String, "Name"),
                "Name should be required");
        }

        [TestMethod]
        public void Status_Add()
        {
            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            Assert.IsTrue(status.IsValid, "IsValid should be true");

            StatusService.StatusSave(status);
        }

        [TestMethod]
        public void Status_Add_With_Duplicate_Name()
        {
            var status = StatusService.StatusNew();
            var name = DataHelper.RandomString(20);

            status.Name = name;

            StatusService.StatusSave(status);

            status = StatusService.StatusNew();

            status.Name = name;

            Assert.IsTrue(ValidationHelper.ContainsRule(status, "rule://epiworx.business.statusduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Status_Edit()
        {
            var status = StatusService.StatusNew();
            var name = DataHelper.RandomString(20);

            status.Name = name;

            status = StatusService.StatusSave(status);

            status = StatusService.StatusFetch(status.StatusId);

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            status = StatusService.StatusFetch(status.StatusId);

            Assert.IsTrue(status.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Status_Delete()
        {
            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            status = StatusService.StatusFetch(status.StatusId);

            StatusService.StatusDelete(status.StatusId);

            try
            {
                StatusService.StatusFetch(status.StatusId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Status_Fetch()
        {
            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            status = StatusService.StatusFetch(status.StatusId);

            Assert.IsFalse(status == null, "Status should not be null");
        }

        [TestMethod]
        public void Status_Fetch_List()
        {
            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            status.Name = DataHelper.RandomString(20);

            StatusService.StatusSave(status);

            var statuses = StatusService.StatusFetchInfoList();

            Assert.IsTrue(statuses.Count > 1, "Categories should be greater than one");
        }
    }
}
