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
    public class HourTestsWithRoleContribute
    {
        public static User User { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public HourTestsWithRoleContribute()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            HourTestsWithRoleContribute.UserName = DataHelper.RandomString(20);
            HourTestsWithRoleContribute.UserPassword = DataHelper.RandomString(20);

            HourTestsWithRoleContribute.User = BusinessHelper.CreateUserWithContribute(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);
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

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Hour_Cannot_Delete_Record_For_Different_User()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

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
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Cannot_Edit_Record_For_Different_User()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.Notes = DataHelper.RandomString(20);

                HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Cannot_Edit_Where_Is_Archived_Property_Is_True()
        {
            var hour = BusinessHelper.CreateHourThatIsArchivedAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.Notes = DataHelper.RandomString(100);

                HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Cannot_Write_To_Is_Archived_Property()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.IsArchived = !hour.IsArchived;

                HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Cannot_Write_To_User_Id_Property()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.UserId = DataHelper.RandomNumber(1000);

                HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Cannot_Delete_Where_Is_Archived_Property_Is_True()
        {
            var hour = BusinessHelper.CreateHourThatIsArchivedAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                HourService.HourDelete(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Hour_Edit()
        {
            var hour = BusinessHelper.CreateHourForUserAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword,
                HourTestsWithRoleContribute.User.UserId);

            Exception exception = null;

            try
            {
                hour = HourService.HourFetch(hour.HourId);

                hour.Notes = DataHelper.RandomString(20);

                HourService.HourSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Hour_Delete()
        {
            var hour = BusinessHelper.CreateHourForUserAndLogon(
                HourTestsWithRoleContribute.UserName,
                HourTestsWithRoleContribute.UserPassword,
                HourTestsWithRoleContribute.User.UserId);

            Exception exception = null;

            try
            {
                HourService.HourDelete(hour.HourId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Hour_Fetch()
        {
            var hour = BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleContribute.UserName,
                 HourTestsWithRoleContribute.UserPassword);

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
                 HourTestsWithRoleContribute.UserName,
                 HourTestsWithRoleContribute.UserPassword);

            BusinessHelper.CreateHourAndLogon(
                 HourTestsWithRoleContribute.UserName,
                 HourTestsWithRoleContribute.UserPassword);

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
