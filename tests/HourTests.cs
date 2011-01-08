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
    public class HourTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public HourTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            HourTests.UserName = DataHelper.RandomString(20);
            HourTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                HourTests.UserName,
                HourTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                HourTests.UserName,
                HourTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Hour_New()
        {
            var hour = HourService.HourNew();

            Assert.IsTrue(hour.IsNew, "IsNew should be true");
            Assert.IsTrue(hour.IsDirty, "IsDirty should be true");
            Assert.IsFalse(hour.IsValid, "IsValid should be false");
            Assert.IsTrue(hour.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(hour.IsSelfValid, "IsSelfValid should be false");
            Assert.IsFalse(hour.IsArchived, "IsArchived should be false");
            Assert.IsTrue(hour.UserId == BusinessPrincipal.GetCurrentIdentity().UserId,
                string.Format("UserId should be '{0}'", BusinessPrincipal.GetCurrentIdentity().UserId));
            Assert.IsTrue(hour.Date == DateTime.Now.Date,
                string.Format("Date should be '{0:d}'", DateTime.Now.Date));

            // we init some values, so we want to make sure the rules are captured so
            // we reset the values to default
            hour.UserId = 0;
            hour.Date = DateTime.MaxValue.Date;

            Assert.IsTrue(ValidationHelper.ContainsRule(hour, DbType.Int32, "TaskId"),
                "TaskId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(hour, DbType.Int32, "UserId"),
                "UserId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(hour, DbType.DateTime, "Date"),
                "Date should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(hour, DbType.Decimal, "Duration"),
             "Duration should be required");
        }

        [TestMethod]
        public void Hour_Add()
        {
            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            Assert.IsTrue(hour.IsValid, "IsValid should be true");

            hour = HourService.HourSave(hour);
        }

        [TestMethod]
        public void Hour_Edit()
        {
            var hour = HourService.HourNew();
            var notes = DataHelper.RandomString(100);

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = notes;

            Assert.IsTrue(hour.IsValid, "IsValid should be true");

            hour = HourService.HourSave(hour);

            hour = HourService.HourFetch(hour.HourId);

            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            hour = HourService.HourFetch(hour.HourId);

            Assert.IsTrue(hour.Notes != notes, "Notes should have different value");
        }

        [TestMethod]
        public void Hour_Delete()
        {
            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            hour = HourService.HourFetch(hour.HourId);

            HourService.HourDelete(hour.HourId);

            try
            {
                HourService.HourFetch(hour.HourId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Hour_Fetch()
        {
            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            hour = HourService.HourFetch(hour.HourId);

            Assert.IsFalse(hour == null, "Hour should not be null");
        }

        [TestMethod]
        public void Hour_Fetch_List()
        {
            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            HourService.HourSave(hour);

            hour = HourService.HourNew();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            HourService.HourSave(hour);

            var hours = HourService.HourFetchInfoList();

            Assert.IsTrue(hours.Count > 1, "Hours should be greater than one");
        }
    }
}
