using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Business;
using Epiworx.Security;
using Epiworx.Service;
using Epiworx.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epiworx.Tests
{
    [TestClass]
    public class FeedTests
    {
        public static string UserData { get; set; }
        public static string UserPassword { get; set; }

        public FeedTests()
        {
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            FeedTests.UserData = DataHelper.RandomString(20);
            FeedTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                FeedTests.UserData,
                FeedTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                FeedTests.UserData,
                FeedTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Feed_New()
        {
            var feed = FeedService.FeedNew();

            Assert.IsTrue(feed.IsNew, "IsNew should be true");
            Assert.IsTrue(feed.IsDirty, "IsDirty should be true");
            Assert.IsFalse(feed.IsValid, "IsValid should be false");
            Assert.IsTrue(feed.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(feed.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(feed, DbType.String, "Type"),
                "Type should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(feed, DbType.String, "Data"),
                "Data should be required");
        }

        [TestMethod]
        public void Feed_Add()
        {
            var feed = FeedService.FeedNew();

            feed.Type = DataHelper.RandomString(30);
            feed.Data = DataHelper.RandomString(1000);

            Assert.IsTrue(feed.IsValid, "IsValid should be true");

            FeedService.FeedSave(feed);
        }

        [TestMethod]
        public void Feed_Edit()
        {
            var feed = FeedService.FeedNew();
            var data = DataHelper.RandomString(1000);

            feed.Type = DataHelper.RandomString(30);
            feed.Data = data;

            feed = FeedService.FeedSave(feed);

            feed = FeedService.FeedFetch(feed.FeedId);

            feed.Data = DataHelper.RandomString(1000);

            try
            {
                FeedService.FeedSave(feed);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is NotImplementedException);
            }
        }

        [TestMethod]
        public void Feed_Delete()
        {
            var feed = FeedService.FeedNew();

            feed.Type = DataHelper.RandomString(30);
            feed.Data = DataHelper.RandomString(1000);

            feed = FeedService.FeedSave(feed);

            feed = FeedService.FeedFetch(feed.FeedId);

            try
            {
                FeedService.FeedDelete(feed.FeedId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is NotImplementedException);
            }
        }

        [TestMethod]
        public void Feed_Fetch()
        {
            var feed = FeedService.FeedNew();

            feed.Type = DataHelper.RandomString(30);
            feed.Data = DataHelper.RandomString(1000);

            feed = FeedService.FeedSave(feed);

            feed = FeedService.FeedFetch(feed.FeedId);

            Assert.IsFalse(feed == null, "Feed should not be null");
        }

        [TestMethod]
        public void Feed_Fetch_List()
        {
            var feed = FeedService.FeedNew();

            feed.Data = DataHelper.RandomString(1000);

            feed = FeedService.FeedSave(feed);

            feed.Type = DataHelper.RandomString(30);
            feed.Data = DataHelper.RandomString(1000);

            FeedService.FeedSave(feed);

            var feeds = FeedService.FeedFetchInfoList();

            Assert.IsTrue(feeds.Count > 1, "Feeds should be greater than one");
        }

    }
}
