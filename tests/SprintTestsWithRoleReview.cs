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
    public class SprintTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public SprintTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            SprintTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            SprintTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(
                SprintTestsWithRoleReview.UserName,
                SprintTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                SprintTestsWithRoleReview.UserName,
                SprintTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Sprint_New()
        {
            Exception exception = null;

            try
            {
                SprintService.SprintNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Sprint_Edit()
        {
            var sprint = BusinessHelper.CreateSprintAndLogon(
                SprintTestsWithRoleReview.UserName, SprintTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                sprint = SprintService.SprintFetch(sprint.SprintId);

                sprint.Name = DataHelper.RandomString(20);

                SprintService.SprintSave(sprint);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Sprint_Delete()
        {
            var sprint = BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleReview.UserName, SprintTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                SprintService.SprintDelete(sprint.SprintId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Sprint_Fetch()
        {
            Exception exception = null;

            var sprint = BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleReview.UserName, SprintTestsWithRoleReview.UserPassword);

            try
            {
                SprintService.SprintFetch(sprint.SprintId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Sprint_Fetch_List()
        {
            Exception exception = null;

            BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleReview.UserName, SprintTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleReview.UserName, SprintTestsWithRoleReview.UserPassword);

            try
            {
                SprintService.SprintFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
