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
    public class InvoiceTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public InvoiceTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            InvoiceTests.UserName = DataHelper.RandomString(20);
            InvoiceTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                InvoiceTests.UserName,
                InvoiceTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                InvoiceTests.UserName,
                InvoiceTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Invoice_New()
        {
            var invoice = InvoiceService.InvoiceNew();

            Assert.IsTrue(invoice.IsNew, "IsNew should be true");
            Assert.IsTrue(invoice.IsDirty, "IsDirty should be true");
            Assert.IsFalse(invoice.IsValid, "IsValid should be false");
            Assert.IsTrue(invoice.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(invoice.IsSelfValid, "IsSelfValid should be false");
            Assert.IsFalse(invoice.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(invoice, DbType.Int32, "TaskId"),
                "TaskId should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(invoice, DbType.String, "Number"),
                "Number should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(invoice, DbType.String, "Description"),
                "Description should be required");
        }

        [TestMethod]
        public void Invoice_Add()
        {
            var invoice = InvoiceService.InvoiceNew();

            var task = BusinessHelper.CreateTask();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            Assert.IsTrue(invoice.IsValid, "IsValid should be true");

            InvoiceService.InvoiceSave(invoice);
        }

        [TestMethod]
        public void Invoice_Edit()
        {
            var invoice = InvoiceService.InvoiceNew();

            var task = BusinessHelper.CreateTask();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            invoice = InvoiceService.InvoiceSave(invoice);

            invoice = InvoiceService.InvoiceFetch(invoice.InvoiceId);

            invoice.Amount = DataHelper.RandomNumber(1000);

            invoice = InvoiceService.InvoiceSave(invoice);

            invoice = InvoiceService.InvoiceFetch(invoice.InvoiceId);

            Assert.IsTrue(invoice.Amount != 0, "Amount should have different value");
        }

        [TestMethod]
        public void Invoice_Delete()
        {
            var invoice = InvoiceService.InvoiceNew();

            var task = BusinessHelper.CreateTask();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            invoice = InvoiceService.InvoiceSave(invoice);

            invoice = InvoiceService.InvoiceFetch(invoice.InvoiceId);

            InvoiceService.InvoiceDelete(invoice.InvoiceId);

            try
            {
                InvoiceService.InvoiceFetch(invoice.InvoiceId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Invoice_Fetch()
        {
            var invoice = InvoiceService.InvoiceNew();

            var task = BusinessHelper.CreateTask();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            invoice = InvoiceService.InvoiceSave(invoice);

            invoice = InvoiceService.InvoiceFetch(invoice.InvoiceId);

            Assert.IsFalse(invoice == null, "Invoice should not be null");
        }

        [TestMethod]
        public void Invoice_Fetch_List()
        {
            var invoice = InvoiceService.InvoiceNew();

            var task = BusinessHelper.CreateTask();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            InvoiceService.InvoiceSave(invoice);

            invoice = InvoiceService.InvoiceNew();

            invoice.Number = DataHelper.RandomString(20);
            invoice.TaskId = task.TaskId;
            invoice.Description = task.Description;

            InvoiceService.InvoiceSave(invoice);

            var invoices = InvoiceService.InvoiceFetchInfoList();

            Assert.IsTrue(invoices.Count > 1, "Invoices should be greater than one");
        }
    }
}
