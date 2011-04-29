using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public class FeedService
    {
        public static Feed FeedAdd(string action, Attachment attachment)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Attachment";
            feed.Data = string.Format(
                "Action={0}|AttachmentId={1}|SourceType={2}|SourceId={3}|SourceName={4}|Text={5}",
                action,
                attachment.AttachmentId,
                (int)attachment.SourceType,
                attachment.SourceId,
                ForeignKeyMapper.FetchSourceName(attachment.SourceType, attachment.SourceId),
                attachment.Name);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Invoice invoice)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Invoice";
            feed.Data = string.Format(
                "Action={0}|InvoiceId={1}|InvoiceNumber={2}|ProjectId={3}|ProjectName={4}|Text={5}",
                action,
                invoice.InvoiceId,
                invoice.Number,
                invoice.ProjectId,
                invoice.ProjectName,
                invoice.Description);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Hour hour)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Hour";
            feed.Data = string.Format(
                "Action={0}|HourId={1}|Date={2:d}|TaskId={3}|ProjectId={4}|ProjectName={5}|Text={6}",
                action,
                hour.HourId,
                hour.Date,
                hour.TaskId,
                hour.ProjectId,
                hour.ProjectName,
                hour.Notes);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Sprint sprint)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Sprint";
            feed.Data = string.Format(
                "Action={0}|SprintId={1}|SprintName={2}|ProjectId={3}|ProjectName={4}|Text=Estimated completed date of {5:d}",
                action,
                sprint.SprintId,
                sprint.Name,
                sprint.ProjectId,
                sprint.ProjectName,
                sprint.EstimatedCompletedDate);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Task task)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Task";
            feed.Data = string.Format(
                "Action={0}|TaskId={1}|ProjectId={2}|ProjectName={3}|Text={4}",
                action,
                task.TaskId,
                task.ProjectId,
                task.ProjectName,
                task.Description);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Label label)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Label";
            feed.Data = string.Format(
                "Action={0}|Name={1}|SourceType={2}|SourceId={3}|SourceName={4}",
                action,
                label.Name,
                (int)label.SourceType,
                label.SourceId,
                ForeignKeyMapper.FetchSourceName(label.SourceType, label.SourceId));

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Note note)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Note";
            feed.Data = string.Format(
                "Action={0}|NoteId={1}|SourceType={2}|SourceId={3}|SourceName={4}|Text={5}",
                action,
                note.NoteId,
                (int)note.SourceType,
                note.SourceId,
                ForeignKeyMapper.FetchSourceName(note.SourceType, note.SourceId),
                note.Body);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Project project)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Project";
            feed.Data = string.Format(
                "Action={0}|ProjectId={1}|ProjectName={2}|Text={3}",
                action,
                project.ProjectId,
                project.Name,
                project.Description);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, User user)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "User";
            feed.Data = string.Format(
                "Action={0}|UserId={1}|UserName={2}",
                action,
                user.UserId,
                user.Name);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Category category)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Category";
            feed.Data = string.Format(
                "Action={0}|CategoryId={1}|CategoryName={2}|Text={3}",
                action,
                category.CategoryId,
                category.Name,
                category.Description);

            feed = FeedService.FeedSave(feed);

            return feed;
        }

        public static Feed FeedAdd(string action, Status status)
        {
            var feed = FeedService.FeedNew();

            feed.Type = "Status";
            feed.Data = string.Format(
                "Action={0}|StatusId={1}|StatusName={2}|Text={3}",
                action,
                status.StatusId,
                status.Name,
                status.Description);

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

        public static FeedInfoList FeedFetchInfoList(int maximumRecords)
        {
            return FeedService.FeedFetchInfoList(
                new FeedCriteria
                {
                    SortBy = "CreatedDate",
                    SortOrder = ListSortDirection.Descending,
                    MaximumRecords = maximumRecords
                });
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