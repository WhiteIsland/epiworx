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
    public class FilterTestsWithRoleContribute
    {
        public static User User { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public FilterTestsWithRoleContribute()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            FilterTestsWithRoleContribute.UserName = DataHelper.RandomString(20);
            FilterTestsWithRoleContribute.UserPassword = DataHelper.RandomString(20);

            FilterTestsWithRoleContribute.User = BusinessHelper.CreateUserWithContribute(
                FilterTestsWithRoleContribute.UserName,
                FilterTestsWithRoleContribute.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                FilterTestsWithRoleContribute.UserName,
                FilterTestsWithRoleContribute.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Filter_New()
        {
            Exception exception = null;

            try
            {
                FilterService.FilterNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Filter_Cannot_Delete_Record_For_Different_User()
        {
            var hour = BusinessHelper.CreateFilterAndLogon(
                FilterTestsWithRoleContribute.UserName,
                FilterTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                FilterService.FilterDelete(hour.FilterId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Filter_Cannot_Edit_Record_For_Different_User()
        {
            var hour = BusinessHelper.CreateFilterAndLogon(
                FilterTestsWithRoleContribute.UserName,
                FilterTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                hour = FilterService.FilterFetch(hour.FilterId);

                hour.Name = DataHelper.RandomString(20);

                FilterService.FilterSave(hour);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
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
            var hour = BusinessHelper.CreateFilterAndLogon(
                 FilterTestsWithRoleContribute.UserName,
                 FilterTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                FilterService.FilterFetch(hour.FilterId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Filter_Fetch_List()
        {
            BusinessHelper.CreateFilterAndLogon(
                 FilterTestsWithRoleContribute.UserName,
                 FilterTestsWithRoleContribute.UserPassword);

            BusinessHelper.CreateFilterAndLogon(
                 FilterTestsWithRoleContribute.UserName,
                 FilterTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                FilterService.FilterFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
