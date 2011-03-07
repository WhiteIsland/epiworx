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
    public class TaskTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public TaskTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TaskTests.UserName = DataHelper.RandomString(20);
            TaskTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                TaskTests.UserName,
                TaskTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                TaskTests.UserName,
                TaskTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Task_New()
        {
            var task = TaskService.TaskNew();

            Assert.IsTrue(task.IsNew, "IsNew should be true");
            Assert.IsTrue(task.IsDirty, "IsDirty should be true");
            Assert.IsFalse(task.IsValid, "IsValid should be false");
            Assert.IsTrue(task.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(task.IsSelfValid, "IsSelfValid should be false");
            Assert.IsFalse(task.IsArchived, "IsArchived should be false");
            Assert.IsTrue(task.AssignedDate == DateTime.MaxValue.Date, string.Format("AssignedDate should be '{0:d}'", DateTime.MaxValue.Date));
            Assert.IsTrue(task.StartDate == DateTime.MaxValue.Date, string.Format("StartDate should be '{0:d}'", DateTime.MaxValue.Date));
            Assert.IsTrue(task.CompletedDate == DateTime.MaxValue.Date, string.Format("CompletedDate should be '{0:d}'", DateTime.MaxValue.Date));
            Assert.IsTrue(task.EstimatedCompletedDate == DateTime.MaxValue.Date, string.Format("EstimatedCompletedDate should be '{0:d}'", DateTime.MaxValue.Date));
            Assert.IsTrue(task.TaskLabels != null, "TaskLabels should not be null");
            Assert.IsTrue(task.TaskLabels.Count == 0, "TaskLabels should be empty");

            Assert.IsTrue(ValidationHelper.ContainsRule(task, DbType.Int32, "ProjectId"),
                "ProjectId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(task, DbType.Int32, "CategoryId"),
                "CategoryId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(task, DbType.Int32, "StatusId"),
                "StatusId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(task, DbType.String, "Description"),
                "Description should be required");
        }

        [TestMethod]
        public void Task_Add()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            Assert.IsTrue(task.IsValid, "IsValid should be true");

            TaskService.TaskSave(task);
        }

        [TestMethod]
        public void Task_Add_With_Task_Labels()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task.TaskLabels.Add(DataHelper.RandomString(30));
            task.TaskLabels.Add(DataHelper.RandomString(30));
            task.TaskLabels.Add(DataHelper.RandomString(30));
            task.TaskLabels.Add(DataHelper.RandomString(30));
            task.TaskLabels.Add(DataHelper.RandomString(30));

            Assert.IsTrue(task.IsValid, "IsValid should be true");

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            Assert.IsTrue(task.TaskLabels.Count == 5, "TaskLabels count should be 5, but is {0}", task.TaskLabels.Count);
        }

        [TestMethod]
        public void Task_Can_Edit_Where_Is_Archived_Property_Is_True()
        {
            var task = BusinessHelper.CreateTaskThatIsArchivedAndLogon(
                TaskTests.UserName,
                TaskTests.UserPassword);

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

            Assert.IsTrue(exception == null, string.Format("Exception should be null, but is: {0}", exception));
        }

        [TestMethod]
        public void Task_Can_Write_To_Is_Archived_Property()
        {
            var task = BusinessHelper.CreateTaskAndLogon(
                TaskTests.UserName,
                TaskTests.UserPassword);

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

            Assert.IsTrue(exception == null, string.Format("Exception should be null, but is: {0}", exception));
        }

        [TestMethod]
        public void Task_Can_Delete_Where_Is_Archived_Property_Is_True()
        {
            var task = BusinessHelper.CreateTaskThatIsArchivedAndLogon(
                TaskTests.UserName,
                TaskTests.UserPassword);

            Exception exception = null;

            try
            {
                TaskService.TaskDelete(task);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Task_Edit_Status_To_Started()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();

            status.IsStarted = true;

            StatusService.StatusSave(status);

            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            Assert.IsTrue(task.StartDate == DateTime.MaxValue.Date, "StartDate should be empty");

            task.StatusId = status.StatusId;

            Assert.IsTrue(task.StartDate == DateTime.Now.Date, "StartDate should be equal to today's date");
        }

        [TestMethod]
        public void Task_Edit_Status_To_Completed()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();

            status.IsCompleted = true;

            StatusService.StatusSave(status);

            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            Assert.IsTrue(task.CompletedDate == DateTime.MaxValue.Date, "StartDate should be empty");
            Assert.IsTrue(task.EstimatedCompletedDate == DateTime.MaxValue.Date, "EstimatedCompletedDate should be empty");

            task.StatusId = status.StatusId;

            Assert.IsTrue(task.CompletedDate == DateTime.Now.Date, "CompletedDate should be equal to today's date");
            Assert.IsTrue(task.EstimatedCompletedDate == DateTime.Now.Date, "EstimatedCompletedDate should be equal to today's date");
        }

        [TestMethod]
        public void Task_Edit()
        {
            var task = TaskService.TaskNew();
            var description = DataHelper.RandomString(1000);

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            task.Description = DataHelper.RandomString(1000);

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            Assert.IsTrue(task.Description != description, "Description should have different value");
        }

        [TestMethod]
        public void Task_Edit_With_Task_Labels()
        {
            var task = TaskService.TaskNew();
            var description = DataHelper.RandomString(1000);

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task.TaskLabels.Add("AAAAA");
            task.TaskLabels.Add("BBBBB");
            task.TaskLabels.Add("CCCCC");
            task.TaskLabels.Add("DDDDD");
            task.TaskLabels.Add("EEEEE");

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            task.TaskLabels.Remove("AAAAA");

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            Assert.IsTrue(task.TaskLabels.Count == 4, "TaskLabels count should be 4, but is {0}", task.TaskLabels.Count);
        }

        [TestMethod]
        public void Task_Delete()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            TaskService.TaskDelete(task.TaskId);

            try
            {
                TaskService.TaskFetch(task.TaskId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Task_Fetch()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task = TaskService.TaskSave(task);

            task = TaskService.TaskFetch(task.TaskId);

            Assert.IsFalse(task == null, "Task should not be null");
        }

        [TestMethod]
        public void Task_Fetch_List()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            TaskService.TaskSave(task);

            task = TaskService.TaskNew();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            TaskService.TaskSave(task);

            var tasks = TaskService.TaskFetchInfoList();

            Assert.IsTrue(tasks.Count > 1, "Tasks should be greater than one");
        }
    }
}
