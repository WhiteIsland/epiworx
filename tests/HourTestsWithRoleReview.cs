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
    public class HourTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public HourTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            HourTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            HourTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(HourTestsWithRoleReview.UserName, HourTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(HourTestsWithRoleReview.UserName, HourTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Hour_New()
        {
            Exception exception = null;

            try
            {
                HourService.HourNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Hour_Edit()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                HourTestsWithRoleReview.UserName,
                HourTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.Notes = DataHelper.RandomString(20);

                hour = HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Hour_Delete()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleReview.UserName,
                 HourTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                HourService.HourDelete(hour.HourId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Hour_Fetch()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleReview.UserName,
                 HourTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                HourService.HourFetch(hour.HourId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Hour_Fetch_List()
        {
            BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleReview.UserName,
                 HourTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleReview.UserName,
                 HourTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                HourService.HourFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
