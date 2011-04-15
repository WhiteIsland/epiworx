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
    public class InvoiceTestsWithRoleContribute
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public InvoiceTestsWithRoleContribute()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            InvoiceTestsWithRoleContribute.UserName = DataHelper.RandomString(20);
            InvoiceTestsWithRoleContribute.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithContribute(
                InvoiceTestsWithRoleContribute.UserName,
                InvoiceTestsWithRoleContribute.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                InvoiceTestsWithRoleContribute.UserName,
                InvoiceTestsWithRoleContribute.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Invoice_New()
        {
            Exception exception = null;

            try
            {
                InvoiceService.InvoiceNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Invoice_Edit()
        {
            var invoice = BusinessHelper.CreateInvoiceAndLogon(
                InvoiceTestsWithRoleContribute.UserName,
                InvoiceTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                invoice = InvoiceService.InvoiceFetch(invoice.InvoiceId);

                invoice.Notes = DataHelper.RandomString(20);

                InvoiceService.InvoiceSave(invoice);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Invoice_Delete()
        {
            var invoice = BusinessHelper.CreateInvoiceAndLogon(
                 InvoiceTestsWithRoleContribute.UserName,
                 InvoiceTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                InvoiceService.InvoiceDelete(invoice.InvoiceId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Invoice_Fetch()
        {
            var invoice = BusinessHelper.CreateInvoiceAndLogon(
                 InvoiceTestsWithRoleContribute.UserName,
                 InvoiceTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                InvoiceService.InvoiceFetch(invoice.InvoiceId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Invoice_Fetch_List()
        {
            BusinessHelper.CreateInvoiceAndLogon(
                 InvoiceTestsWithRoleContribute.UserName,
                 InvoiceTestsWithRoleContribute.UserPassword);

            BusinessHelper.CreateInvoiceAndLogon(
                 InvoiceTestsWithRoleContribute.UserName,
                 InvoiceTestsWithRoleContribute.UserPassword);

            Exception exception = null;

            try
            {
                InvoiceService.InvoiceFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }
    }
}
