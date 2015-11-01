using System.Collections.Generic;
using System.Linq;

namespace PhaseFramework.Pagination
{
    public static class PagingExtensionMethods
    {
        public static PagedSearchList<T> ToPage<T>(this IEnumerable<T> collection, PagedBase pagedBase)
        {
            if (pagedBase == null || !pagedBase.PageIndex.HasValue || !pagedBase.PageSize.HasValue)
                return null;

            var pagedSearchList = new PagedSearchList<T>
            {
                PageIndex = pagedBase.PageIndex.Value,
                PageSize = pagedBase.PageSize.Value
            };

            var enumerable = collection as T[] ?? collection.ToArray();
            pagedSearchList.TotalItemCount = enumerable.Count();

            if (pagedSearchList.PageSize != null)
            {
                pagedSearchList.TotalPageCount = pagedSearchList.TotalItemCount / pagedSearchList.PageSize.Value;
                if (pagedSearchList.TotalItemCount % pagedSearchList.PageSize.Value > 0)
                {
                    pagedSearchList.TotalPageCount++;
                }
            }

            pagedSearchList.SearchList =
                enumerable.Skip((pagedBase.PageIndex.Value - 1) * pagedBase.PageSize.Value)
                    .Take(pagedBase.PageSize.Value)
                    .ToList();

            return pagedSearchList;
        }

    }
}
