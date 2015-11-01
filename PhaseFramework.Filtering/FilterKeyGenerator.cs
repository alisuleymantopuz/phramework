using System.Collections.Generic;
using System.Linq;
using PhaseFramework.Filtering;

namespace PhaseFramework.Filtering
{
    public class FilterKeyGenerator : IFilterKeyGenerator
    {
        public IList<FilterItem> FilterItems { get; private set; }

        public FilterKeyGenerator()
        {
            FilterItems = new List<FilterItem>();
        }

        public void AddItem(string key, string value)
        {
            if (FilterItems.FirstOrDefault(x => x.Key == key) != null)
                throw new DuplicatedFilterException(key);

            FilterItems.Add(new FilterItem() { Key = key, Value = value });
        }

        public string GeneratedFilterQuery
        {
            get
            {
                return FilterItems.Aggregate(string.Empty, (current, item) => current + string.Format("_{0}_{1}", item.Key, item.Value));
            }
        }
    }
}
