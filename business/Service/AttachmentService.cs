using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class AttachmentService
    {
        public static Attachment AttachmentFetch(int attachmentId)
        {
            return Attachment.FetchAttachment(
                new AttachmentCriteria
                    {
                        AttachmentId = attachmentId
                    });
        }

        public static AttachmentInfoList AttachmentFetchInfoList(ISource source)
        {
            return AttachmentService.AttachmentFetchInfoList(
                new AttachmentCriteria
                {
                    SourceType = source.SourceType,
                    SourceId = source.SourceId
                });
        }

        public static AttachmentInfoList AttachmentFetchInfoList(SourceType sourceType, int sourceId)
        {
            return AttachmentService.AttachmentFetchInfoList(
                new AttachmentCriteria
                {
                    SourceType = sourceType,
                    SourceId = sourceId
                });
        }

        public static AttachmentInfoList AttachmentFetchInfoList(AttachmentCriteria criteria)
        {
            return AttachmentInfoList.FetchAttachmentInfoList(criteria);
        }

        public static Attachment AttachmentSave(Attachment attachment)
        {
            if (!attachment.IsValid)
            {
                return attachment;
            }

            Attachment result;

            if (attachment.IsNew)
            {
                result = AttachmentService.AttachmentInsert(attachment);
            }
            else
            {
                result = AttachmentService.AttachmentUpdate(attachment);
            }

            return result;
        }

        public static Attachment AttachmentInsert(Attachment attachment)
        {
            attachment = attachment.Save();

            FeedService.FeedAdd("Created", attachment);

            return attachment;
        }

        public static Attachment AttachmentUpdate(Attachment attachment)
        {
            attachment = attachment.Save();

            FeedService.FeedAdd("Updated", attachment);

            return attachment;
        }

        public static Attachment AttachmentNew(SourceType sourceType, int sourceId)
        {
            var result = Attachment.NewAttachment(
                new AttachmentCriteria
                {
                    SourceType = sourceType,
                    SourceId = sourceId
                });

            return result;
        }

        public static bool AttachmentDelete(Attachment attachment)
        {
            Attachment.DeleteAttachment(
                new AttachmentCriteria
                    {
                        AttachmentId = attachment.AttachmentId
                    });

            FeedService.FeedAdd("Deleted", attachment);

            return true;
        }

        public static bool AttachmentDelete(int attachmentId)
        {
            return AttachmentService.AttachmentDelete(
                AttachmentService.AttachmentFetch(attachmentId));
        }
    }
}