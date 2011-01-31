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
    public class ProjectTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public ProjectTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            ProjectTests.UserName = DataHelper.RandomString(20);
            ProjectTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                ProjectTests.UserName,
                ProjectTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                ProjectTests.UserName,
                ProjectTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Project_New()
        {
            var project = ProjectService.ProjectNew();

            Assert.IsTrue(project.IsNew, "IsNew should be true");
            Assert.IsTrue(project.IsDirty, "IsDirty should be true");
            Assert.IsFalse(project.IsValid, "IsValid should be false");
            Assert.IsTrue(project.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(project.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(project.IsActive, "IsActive should be true");
            Assert.IsFalse(project.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(project, DbType.String, "Name"),
                "Name should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(project, DbType.String, "Description"),
                "Description should be required");
        }

        [TestMethod]
        public void Project_Add()
        {
            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);
            project.Description = DataHelper.RandomString(300);

            Assert.IsTrue(project.IsValid, "IsValid should be true");

            ProjectService.ProjectSave(project);
        }

        [TestMethod]
        public void Project_Add_With_Duplicate_Name()
        {
            var project = ProjectService.ProjectNew();

            var name = DataHelper.RandomString(20);

            project.Name = name;
            project.Description = DataHelper.RandomString(300);

            ProjectService.ProjectSave(project);

            project = ProjectService.ProjectNew();

            project.Name = name;

            Assert.IsTrue(ValidationHelper.ContainsRule(project, "rule://epiworx.business.projectduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Project_Edit()
        {
            var project = ProjectService.ProjectNew();
            var name = DataHelper.RandomString(20);

            project.Name = name;
            project.Description = DataHelper.RandomString(300);

            project = ProjectService.ProjectSave(project);

            project = ProjectService.ProjectFetch(project.ProjectId);

            project.Name = DataHelper.RandomString(20);

            project = ProjectService.ProjectSave(project);

            project = ProjectService.ProjectFetch(project.ProjectId);

            Assert.IsTrue(project.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Project_Delete()
        {
            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);
            project.Description = DataHelper.RandomString(300);

            project = ProjectService.ProjectSave(project);

            project = ProjectService.ProjectFetch(project.ProjectId);

            ProjectService.ProjectDelete(project.ProjectId);

            try
            {
                ProjectService.ProjectFetch(project.ProjectId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Project_Fetch()
        {
            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);
            project.Description = DataHelper.RandomString(300);

            project = ProjectService.ProjectSave(project);

            project = ProjectService.ProjectFetch(project.ProjectId);

            Assert.IsFalse(project == null, "Project should not be null");
        }

        [TestMethod]
        public void Project_Fetch_List()
        {
            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);
            project.Description = DataHelper.RandomString(300);

            project = ProjectService.ProjectSave(project);

            project.Name = DataHelper.RandomString(20);

            ProjectService.ProjectSave(project);

            var projects = ProjectService.ProjectFetchInfoList();

            Assert.IsTrue(projects.Count > 1, "Projects should be greater than one");
        }
    }
}
