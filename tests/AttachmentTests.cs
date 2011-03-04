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
    public class AttachmentTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            AttachmentTests.UserName = DataHelper.RandomString(20);
            AttachmentTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                AttachmentTests.UserName,
                AttachmentTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                AttachmentTests.UserName,
                AttachmentTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Attachment_New()
        {
            var attachment = AttachmentService.AttachmentNew(SourceType.None, 0);

            Assert.IsTrue(attachment.IsNew, "IsNew should be true");
            Assert.IsTrue(attachment.IsDirty, "IsDirty should be true");
            Assert.IsFalse(attachment.IsValid, "IsValid should be false");
            Assert.IsTrue(attachment.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(attachment.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(attachment, DbType.String, "Name"),
                "Name should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(attachment, DbType.String, "FileType"),
                "FileType should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(attachment, DbType.Int32, "SourceId"),
                "SourceId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(attachment, "rule://epiworx.business.attachmentsourcetyperequired/SourceType"),
                "SourceType should be required");
        }

        [TestMethod]
        public void Attachment_Add()
        {
            var task = BusinessHelper.CreateTask();
            var attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);

            attachment.Name = DataHelper.RandomString(100);
            attachment.FileType = DataHelper.RandomString(30);

            Assert.IsTrue(attachment.IsValid, string.Format("IsValid should be true, but has following errors: {0}", attachment.BrokenRulesCollection));

            attachment = AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

            Assert.IsTrue(attachment != null, "Object should not be null");
        }

        [TestMethod]
        public void Attachment_Edit()
        {
            var task = BusinessHelper.CreateTask();
            var attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);
            var name = DataHelper.RandomString(100);

            attachment.Name = name;
            attachment.FileType = DataHelper.RandomString(30);

            Assert.IsTrue(attachment.IsValid, string.Format("IsValid should be true, but has following errors: {0}", attachment.BrokenRulesCollection));

            attachment = AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

            attachment.Name = DataHelper.RandomString(100);

            attachment = AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

            Assert.IsTrue(attachment.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Attachment_Delete()
        {
            var task = BusinessHelper.CreateTask();
            var attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);

            attachment.Name = DataHelper.RandomString(100);
            attachment.FileType = DataHelper.RandomString(30);

            attachment = AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

            AttachmentService.AttachmentDelete(attachment.AttachmentId);

            try
            {
                AttachmentService.AttachmentFetch(attachment.AttachmentId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Attachment_Fetch()
        {
            var task = BusinessHelper.CreateTask();
            var attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);

            attachment.Name = DataHelper.RandomString(100);
            attachment.FileType = DataHelper.RandomString(30);

            attachment = AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

            Assert.IsFalse(attachment == null, "Attachment should not be null");
        }

        [TestMethod]
        public void Attachment_Fetch_List()
        {
            var task = BusinessHelper.CreateTask();
            var attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);

            attachment.Name = DataHelper.RandomString(100);
            attachment.FileType = DataHelper.RandomString(30);

            AttachmentService.AttachmentSave(attachment);

            attachment = AttachmentService.AttachmentNew(SourceType.Task, task.TaskId);

            attachment.Name = DataHelper.RandomString(100);
            attachment.FileType = DataHelper.RandomString(30);

            AttachmentService.AttachmentSave(attachment);

            var attachments = AttachmentService.AttachmentFetchInfoList(SourceType.Task, task.TaskId);

            Assert.IsTrue(attachments.Count > 1, "Attachments should be greater than one");
        }
    }
}
