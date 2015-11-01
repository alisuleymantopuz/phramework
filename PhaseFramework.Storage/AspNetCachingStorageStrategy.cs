using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace PhaseFramework.Storage
{

    public class AspNetCachingStorageStrategy : IStorageStrategy<string, CacheItem>
    {
        private readonly Cache items;

        public AspNetCachingStorageStrategy()
        {
            items = HttpRuntime.Cache;
        }

        public void Put(string key, CacheItem value)
        {
            items.Insert(key, (object)value, value.CacheDependency, value.AbsoluteExpiration, value.SlidingExpiration, value.CacheItemPriority, value.CacheItemRemovedCallback);
        }

        public CacheItem Get(string key)
        {
            return items[key] as CacheItem;
        }

        public void Remove(string key)
        {
            items.Remove(key);
        }
    }
}
