using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public class FeedService
    {
        public static Feed FeedAdd(string type, Project project)
        {
            var feed = FeedService.FeedNew();

            feed.Type = type;
            feed.Data = string.Format(
                "ProjectId:{0}, ProjectName:{1}, Text:{2}",
                project.ProjectId,
                project.Name,
                project.Description);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedFetch(int feedId)
        {
            return Feed.FetchFeed(
                new FeedCriteria
                    {
                        FeedId = feedId
                    });
        }

        public static FeedInfoList FeedFetchInfoList()
        {
            return FeedService.FeedFetchInfoList(
                new FeedCriteria());
        }

        public static FeedInfoList FeedFetchInfoList(FeedCriteria criteria)
        {
            return FeedInfoList.FetchFeedInfoList(criteria);
        }

        public static Feed FeedSave(Feed feed)
        {
            if (!feed.IsValid)
            {
                return feed;
            }

            Feed result;

            if (feed.IsNew)
            {
                result = FeedService.FeedInsert(feed);
            }
            else
            {
                throw new NotImplementedException();
            }

            return result;
        }

        public static Feed FeedInsert(Feed feed)
        {
            return feed.Save();
        }

        public static Feed FeedNew()
        {
            return Feed.NewFeed();
        }

        public static bool FeedDelete(Feed feed)
        {
            throw new NotImplementedException();
        }

        public static bool FeedDelete(int feedId)
        {
            return FeedService.FeedDelete(
                FeedService.FeedFetch(feedId));
        }
    }
}