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
    public class TaskTestsWithRoleContribute
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public TaskTestsWithRoleContribute()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TaskTestsWithRoleContribute.UserName = DataHelper.RandomString(20);
            TaskTestsWithRoleContribute.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithContribute(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);
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

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Task_Edit()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);

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

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Task_Cannot_Edit_Where_Is_Archived_Property_Is_True()
        {
            var task = BusinessHelper.CreateTaskThatIsArchivedAndLogon(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);

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
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Task_Cannot_Write_To_Is_Archived_Property()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                task = TaskService.TaskFetch(task.TaskId);

                task.IsArchived = !task.IsArchived;

                TaskService.TaskSave(task);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Task_Cannot_Delete_Where_Is_Archived_Property_Is_True()
        {
            var task = BusinessHelper.CreateTaskThatIsArchivedAndLogon(
                TaskTestsWithRoleContribute.UserName,
                TaskTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                TaskService.TaskDelete(task);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException, "Exception should be of type SecurityException");
        }

        [TestMethod]
        public void Task_Delete()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleContribute.UserName,
                 TaskTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                TaskService.TaskDelete(task.TaskId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Task_Fetch()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleContribute.UserName,
                 TaskTestsWithRoleContribute.UserPassword);

            Exception exception = null;

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
            BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleContribute.UserName,
                 TaskTestsWithRoleContribute.UserPassword);

            BusinessHelper.CreateTaskAndLogon(
                 TaskTestsWithRoleContribute.UserName,
                 TaskTestsWithRoleContribute.UserPassword);

            Exception exception = null;

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
