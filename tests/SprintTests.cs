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
    public class SprintTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public SprintTests()
        {
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            SprintTests.UserName = DataHelper.RandomString(20);
            SprintTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                SprintTests.UserName,
                SprintTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                SprintTests.UserName,
                SprintTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Sprint_New()
        {
            var sprint = SprintService.SprintNew();

            Assert.IsTrue(sprint.IsNew, "IsNew should be true");
            Assert.IsTrue(sprint.IsDirty, "IsDirty should be true");
            Assert.IsFalse(sprint.IsValid, "IsValid should be false");
            Assert.IsTrue(sprint.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(sprint.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(sprint.IsActive, "IsActive should be true");
            Assert.IsFalse(sprint.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(sprint, DbType.String, "Name"),
                "Name should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(sprint, DbType.Int32, "ProjectId"),
                "ProjectId should be required");
        }

        [TestMethod]
        public void Sprint_Add()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            Assert.IsTrue(sprint.IsValid, "IsValid should be true");

            SprintService.SprintSave(sprint);
        }

        [TestMethod]
        public void Sprint_Add_With_Duplicate_Name()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();
            var name = DataHelper.RandomString(20);

            sprint.ProjectId = project.ProjectId;
            sprint.Name = name;

            SprintService.SprintSave(sprint);

            sprint = SprintService.SprintNew();

            sprint.ProjectId = project.ProjectId;
            sprint.Name = name;

            Assert.IsTrue(ValidationHelper.ContainsRule(sprint, "rule://epiworx.business.sprintduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Sprint_Edit()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();
            var name = DataHelper.RandomString(20);

            sprint.ProjectId = project.ProjectId;
            sprint.Name = name;

            sprint = SprintService.SprintSave(sprint);

            sprint = SprintService.SprintFetch(sprint.SprintId);

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            sprint = SprintService.SprintSave(sprint);

            sprint = SprintService.SprintFetch(sprint.SprintId);

            Assert.IsTrue(sprint.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Sprint_Delete()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            sprint = SprintService.SprintSave(sprint);

            sprint = SprintService.SprintFetch(sprint.SprintId);

            SprintService.SprintDelete(sprint.SprintId);

            try
            {
                SprintService.SprintFetch(sprint.SprintId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Sprint_Fetch()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            sprint = SprintService.SprintSave(sprint);

            sprint = SprintService.SprintFetch(sprint.SprintId);

            Assert.IsFalse(sprint == null, "Sprint should not be null");
        }

        [TestMethod]
        public void Sprint_Fetch_List()
        {
            var sprint = SprintService.SprintNew();
            var project = BusinessHelper.CreateProject();

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            sprint = SprintService.SprintSave(sprint);

            sprint.ProjectId = project.ProjectId;
            sprint.Name = DataHelper.RandomString(20);

            SprintService.SprintSave(sprint);

            var categories = SprintService.SprintFetchInfoList();

            Assert.IsTrue(categories.Count > 1, "Categories should be greater than one");
        }

    }
}
