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
    public class StatusTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public StatusTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            StatusTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            StatusTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(
                StatusTestsWithRoleReview.UserName,
                StatusTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                StatusTestsWithRoleReview.UserName,
                StatusTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Status_New()
        {
            Exception exception = null;

            try
            {
                StatusService.StatusNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Status_Edit()
        {
            var status = BusinessHelper.CreateStatusAndLogon(
                StatusTestsWithRoleReview.UserName, StatusTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                status = StatusService.StatusFetch(status.StatusId);

                status.Name = DataHelper.RandomString(20);

                StatusService.StatusSave(status);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Status_Delete()
        {
            var status = BusinessHelper.CreateStatusAndLogon(
                 StatusTestsWithRoleReview.UserName, StatusTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                StatusService.StatusDelete(status.StatusId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Status_Fetch()
        {
            Exception exception = null;

            var status = BusinessHelper.CreateStatusAndLogon(
                 StatusTestsWithRoleReview.UserName, StatusTestsWithRoleReview.UserPassword);

            try
            {
                StatusService.StatusFetch(status.StatusId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Status_Fetch_List()
        {
            Exception exception = null;

            BusinessHelper.CreateStatusAndLogon(
                 StatusTestsWithRoleReview.UserName, StatusTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateStatusAndLogon(
                 StatusTestsWithRoleReview.UserName, StatusTestsWithRoleReview.UserPassword);

            try
            {
                StatusService.StatusFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
