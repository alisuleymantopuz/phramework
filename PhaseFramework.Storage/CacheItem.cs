using System;
using System.Web.Caching;

namespace PhaseFramework.Storage
{
    [Serializable]
    public class CacheItem
    {
        public object Item { get; private set; }
        public CacheDependency CacheDependency { get; private set; }
        public DateTime AbsoluteExpiration { get; private set; }
        public TimeSpan SlidingExpiration { get; private set; }
        public CacheItemPriority CacheItemPriority { get; private set; }
        public CacheItemRemovedCallback CacheItemRemovedCallback { get; private set; }

        public CacheItem(object item, CacheDependency cacheDependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority cacheItemPriority, CacheItemRemovedCallback cacheItemRemovedCallback)
        {
            Item = item;
            CacheDependency = cacheDependency;
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
            CacheItemPriority = cacheItemPriority;
            CacheItemRemovedCallback = cacheItemRemovedCallback;
        }

        public CacheItem(object item)
        {
            Item = item;
            CacheDependency = (CacheDependency)null;
            AbsoluteExpiration = Cache.NoAbsoluteExpiration;
            SlidingExpiration = Cache.NoSlidingExpiration;
            CacheItemPriority = CacheItemPriority.NotRemovable;
            CacheItemRemovedCallback = (CacheItemRemovedCallback)null;
        }
    }
}
