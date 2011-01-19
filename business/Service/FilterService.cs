using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class FilterService
    {
        public static Filter FilterFetch(int filterId)
        {
            return Filter.FetchFilter(
                new FilterCriteria
                    {
                        FilterId = filterId
                    });
        }

        public static FilterInfoList FilterFetchInfoList()
        {
            return FilterService.FilterFetchInfoList(
                new FilterCriteria());
        }

        internal static FilterInfoList FilterFetchInfoList(FilterCriteria criteria)
        {
            return FilterInfoList.FetchFilterInfoList(criteria);
        }

        public static Filter FilterSave(Filter filter)
        {
            if (!filter.IsValid)
            {
                return filter;
            }

            Filter result;

            if (filter.IsNew)
            {
                result = FilterService.FilterInsert(filter);
            }
            else
            {
                result = FilterService.FilterUpdate(filter);
            }

            return result;
        }

        public static Filter FilterInsert(Filter filter)
        {
            return filter.Save();
        }

        public static Filter FilterUpdate(Filter filter)
        {
            return filter.Save();
        }

        public static Filter FilterNew()
        {
            return Filter.NewFilter();
        }

        public static bool FilterDelete(Filter filter)
        {
            Filter.DeleteFilter(
                new FilterCriteria
                    {
                        FilterId = filter.FilterId
                    });

            return true;
        }

        public static bool FilterDelete(int filterId)
        {
            return FilterService.FilterDelete(
                FilterService.FilterFetch(filterId));
        }
    }
}