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
    public class TaskTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public TaskTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TaskTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            TaskTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(
                TaskTestsWithRoleReview.UserName,
                TaskTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                TaskTestsWithRoleReview.UserName,
                TaskTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Task_New()
        {
            Exception exception = null;

            try
            {
                TaskService.TaskNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Task_Edit()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                TaskTestsWithRoleReview.UserName, TaskTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                task = TaskService.TaskFetch(task.TaskId);

                task.Description = DataHelper.RandomString(100);

                TaskService.TaskSave(task);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Task_Delete()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleReview.UserName, TaskTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                TaskService.TaskDelete(task.TaskId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Task_Fetch()
        {
            Exception exception = null;

            var task = BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleReview.UserName, TaskTestsWithRoleReview.UserPassword);

            try
            {
                TaskService.TaskFetch(task.TaskId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Task_Fetch_List()
        {
            Exception exception = null;

            BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleReview.UserName, TaskTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleReview.UserName, TaskTestsWithRoleReview.UserPassword);

            try
            {
                TaskService.TaskFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
