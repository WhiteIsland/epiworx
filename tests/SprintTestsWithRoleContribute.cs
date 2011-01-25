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
    public class SprintTestsWithRoleContribute
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public SprintTestsWithRoleContribute()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            SprintTestsWithRoleContribute.UserName = DataHelper.RandomString(20);
            SprintTestsWithRoleContribute.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithContribute(
                SprintTestsWithRoleContribute.UserName,
                SprintTestsWithRoleContribute.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                SprintTestsWithRoleContribute.UserName,
                SprintTestsWithRoleContribute.UserPassword);
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

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Sprint_Edit()
        {
            var sprint = BusinessHelper.CreateSprintAndLogon(
                SprintTestsWithRoleContribute.UserName,
                SprintTestsWithRoleContribute.UserPassword);

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

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Sprint_Delete()
        {
            var sprint = BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleContribute.UserName,
                 SprintTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                SprintService.SprintDelete(sprint.SprintId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Sprint_Fetch()
        {
            var sprint = BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleContribute.UserName,
                 SprintTestsWithRoleContribute.UserPassword);

            Exception exception = null;

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
            BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleContribute.UserName,
                 SprintTestsWithRoleContribute.UserPassword);

            BusinessHelper.CreateSprintAndLogon(
                 SprintTestsWithRoleContribute.UserName,
                 SprintTestsWithRoleContribute.UserPassword);

            Exception exception = null;

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
