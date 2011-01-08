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
    public class ProjectTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public ProjectTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            ProjectTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            ProjectTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(ProjectTestsWithRoleReview.UserName, ProjectTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(ProjectTestsWithRoleReview.UserName, ProjectTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Project_New()
        {
            Exception exception = null;

            try
            {
                ProjectService.ProjectNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Project_Edit()
        {
            var project = BusinessHelper.CreateProjectAndLogon(
                ProjectTestsWithRoleReview.UserName,
                ProjectTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                project = ProjectService.ProjectFetch(project.ProjectId);

                project.Name = DataHelper.RandomString(20);

                ProjectService.ProjectSave(project);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Project_Delete()
        {
            var project = BusinessHelper.CreateProjectAndLogon(
                 ProjectTestsWithRoleReview.UserName,
                 ProjectTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                ProjectService.ProjectDelete(project.ProjectId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Project_Fetch()
        {
            var project = BusinessHelper.CreateProjectAndLogon(
                 ProjectTestsWithRoleReview.UserName,
                 ProjectTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                ProjectService.ProjectFetch(project.ProjectId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Project_Fetch_List()
        {
            BusinessHelper.CreateProjectAndLogon(
                 ProjectTestsWithRoleReview.UserName,
                 ProjectTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateProjectAndLogon(
                 ProjectTestsWithRoleReview.UserName,
                 ProjectTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                ProjectService.ProjectFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
