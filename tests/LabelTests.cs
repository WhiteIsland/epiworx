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
    public class LabelTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            LabelTests.UserName = DataHelper.RandomString(20);
            LabelTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                LabelTests.UserName,
                LabelTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                LabelTests.UserName,
                LabelTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Label_New()
        {
            var label = LabelService.LabelAdd(SourceType.None, 0, string.Empty);

            Assert.IsTrue(label.IsNew, "IsNew should be true");
            Assert.IsTrue(label.IsDirty, "IsDirty should be true");
            Assert.IsFalse(label.IsValid, "IsValid should be false");
            Assert.IsTrue(label.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(label.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(label, DbType.String, "Name"),
                "Name should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(label, DbType.Int32, "SourceId"),
                "SourceId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(label, "rule://epiworx.business.labelsourcetyperequired/SourceType"),
                "SourceType should be required");
        }

        [TestMethod]
        public void Label_Add()
        {
            var task = BusinessHelper.CreateTask();
            var name = DataHelper.RandomString(30);
            var label = LabelService.LabelAdd(SourceType.Task, task.TaskId, name);

            Assert.IsTrue(label.IsValid, "IsValid should be true");

            label = LabelService.LabelFetch(SourceType.Task, task.TaskId, name);

            Assert.IsTrue(label != null, "Object should not be null");
        }

        [TestMethod]
        public void Label_Delete()
        {
            var task = BusinessHelper.CreateTask();
            var name = DataHelper.RandomString(30);

            LabelService.LabelAdd(SourceType.Task, task.TaskId, name);

            LabelService.LabelFetch(SourceType.Task, task.TaskId, name);

            LabelService.LabelDelete(SourceType.Task, task.TaskId, name);

            try
            {
                LabelService.LabelFetch(SourceType.Task, task.TaskId, name);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Label_Fetch()
        {
            var task = BusinessHelper.CreateTask();
            var name = DataHelper.RandomString(30);
            var label = LabelService.LabelAdd(SourceType.Task, task.TaskId, name);

            label = LabelService.LabelFetch(SourceType.Task, task.TaskId, name);

            Assert.IsFalse(label == null, "Label should not be null");
        }

        [TestMethod]
        public void Label_Fetch_List()
        {
            var task = BusinessHelper.CreateTask();

            LabelService.LabelAdd(SourceType.Task, task.TaskId, DataHelper.RandomString(30));
            LabelService.LabelAdd(SourceType.Task, task.TaskId, DataHelper.RandomString(30));

            var labels = LabelService.LabelFetchInfoList(SourceType.Task, task.TaskId);

            Assert.IsTrue(labels.Count > 1, "Labels should be greater than one");
        }
    }
}
