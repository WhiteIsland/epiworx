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
    public class NoteTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            NoteTests.UserName = DataHelper.RandomString(20);
            NoteTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                NoteTests.UserName,
                NoteTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                NoteTests.UserName,
                NoteTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Note_New()
        {
            var note = NoteService.NoteNew(SourceType.None, 0);

            Assert.IsTrue(note.IsNew, "IsNew should be true");
            Assert.IsTrue(note.IsDirty, "IsDirty should be true");
            Assert.IsFalse(note.IsValid, "IsValid should be false");
            Assert.IsTrue(note.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(note.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(note, DbType.String, "Body"),
                "Body should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(note, DbType.Int32, "SourceId"),
                "SourceId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(note, "rule://epiworx.business.notesourcetyperequired/SourceType"),
                "SourceType should be required");
        }

        [TestMethod]
        public void Note_Add()
        {
            var task = BusinessHelper.CreateTask();
            var note = NoteService.NoteNew(SourceType.Task, task.TaskId);

            note.Body = DataHelper.RandomString(1000);

            Assert.IsTrue(note.IsValid, "IsValid should be true");

            note = NoteService.NoteSave(note);

            note = NoteService.NoteFetch(note.NoteId);

            Assert.IsTrue(note != null, "Object should not be null");
        }

        [TestMethod]
        public void Note_Edit()
        {
            var task = BusinessHelper.CreateTask();
            var note = NoteService.NoteNew(SourceType.Task, task.TaskId);
            var body = DataHelper.RandomString(1000);

            note.Body = body;

            Assert.IsTrue(note.IsValid, "IsValid should be true");

            note = NoteService.NoteSave(note);

            note = NoteService.NoteFetch(note.NoteId);

            note.Body = DataHelper.RandomString(1000);

            note = NoteService.NoteSave(note);

            note = NoteService.NoteFetch(note.NoteId);

            Assert.IsTrue(note.Body != body, "Body should have different value");
        }

        [TestMethod]
        public void Note_Delete()
        {
            var task = BusinessHelper.CreateTask();
            var note = NoteService.NoteNew(SourceType.Task, task.TaskId);

            note.Body = DataHelper.RandomString(1000);

            note = NoteService.NoteSave(note);

            note = NoteService.NoteFetch(note.NoteId);

            NoteService.NoteDelete(note.NoteId);

            try
            {
                NoteService.NoteFetch(note.NoteId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Note_Fetch()
        {
            var task = BusinessHelper.CreateTask();
            var note = NoteService.NoteNew(SourceType.Task, task.TaskId);

            note.Body = DataHelper.RandomString(1000);

            note = NoteService.NoteSave(note);

            note = NoteService.NoteFetch(note.NoteId);

            Assert.IsFalse(note == null, "Note should not be null");
        }

        [TestMethod]
        public void Note_Fetch_List()
        {
            var task = BusinessHelper.CreateTask();
            var note = NoteService.NoteNew(SourceType.Task, task.TaskId);

            note.Body = DataHelper.RandomString(1000);

            NoteService.NoteSave(note);

            note = NoteService.NoteNew(SourceType.Task, task.TaskId);

            note.Body = DataHelper.RandomString(1000);

            NoteService.NoteSave(note);

            var notes = NoteService.NoteFetchInfoList(SourceType.Task, task.TaskId);

            Assert.IsTrue(notes.Count > 1, "Notes should be greater than one");
        }
    }
}
