using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class LabelService
    {
        public static Label LabelAdd(ISource source, string name)
        {
            var result = LabelService.LabelAdd(source.SourceType, source.SourceId, name);

            return result;
        }

        public static Label LabelAdd(SourceType sourceType, int sourceId, string name)
        {
            var result = LabelService.LabelNew(sourceType, sourceId, name);

            result = LabelService.LabelSave(result);

            return result;
        }

        public static Label LabelFetch(SourceType sourceType, int sourceId, string name)
        {
            return Label.FetchLabel(
                new LabelCriteria
                {
                    SourceType = sourceType,
                    SourceId = sourceId,
                    Name = name
                });
        }

        public static LabelInfoList LabelFetchInfoList(ISource source)
        {
            return LabelService.LabelFetchInfoList(
                new LabelCriteria
                {
                    SourceType = source.SourceType,
                    SourceId = source.SourceId
                });
        }

        public static LabelInfoList LabelFetchInfoList(SourceType sourceType, int sourceId)
        {
            return LabelService.LabelFetchInfoList(
                new LabelCriteria
                {
                    SourceType = sourceType,
                    SourceId = sourceId
                });
        }

        public static LabelInfoList LabelFetchInfoList(LabelCriteria criteria)
        {
            return LabelInfoList.FetchLabelInfoList(criteria);
        }

        private static Label LabelSave(Label label)
        {
            if (!label.IsValid)
            {
                return label;
            }

            Label result;

            if (label.IsNew)
            {
                result = LabelService.LabelInsert(label);
            }
            else
            {
                result = LabelService.LabelUpdate(label);
            }

            return result;
        }

        private static Label LabelInsert(Label label)
        {
            label = label.Save();

            FeedService.FeedAdd("Created", label);

            return label;
        }

        private static Label LabelUpdate(Label label)
        {
            label = label.Save();

            FeedService.FeedAdd("Updated", label);

            return label;
        }

        private static Label LabelNew(SourceType sourceType, int sourceId, string name)
        {
            var result = Label.NewLabel(
               new LabelCriteria
               {
                   SourceType = sourceType,
                   SourceId = sourceId,
                   Name = name
               });

            return result;
        }

        public static bool LabelDelete(Label label)
        {
            Label.DeleteLabel(
                new LabelCriteria
                {
                    SourceType = label.SourceType,
                    SourceId = label.SourceId,
                    Name = label.Name
                });

            FeedService.FeedAdd("Deleted", label);

            return true;
        }

        public static bool LabelDelete(SourceType sourceType, int sourceId, string name)
        {
            return LabelService.LabelDelete(
                LabelService.LabelFetch(sourceType, sourceId, name));
        }
    }
}