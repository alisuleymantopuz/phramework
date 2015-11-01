using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseFramework.Storage
{
    public class InMemoryStorageStrategy : IStorageStrategy<string, CacheItem>
    {
        public static Hashtable Items { get; private set; }

        static InMemoryStorageStrategy()
        {
            Items = Hashtable.Synchronized(new Hashtable());
        }

        public InMemoryStorageStrategy()
        {
            Items = Hashtable.Synchronized(new Hashtable());
        }

        public void Put(string key, CacheItem value)
        {
            Items[(object)key] = (object)value;
        }

        public CacheItem Get(string key)
        {
            CacheItem cacheItem = (CacheItem)null;
            if (Items.ContainsKey((object)key))
                cacheItem = (CacheItem)Items[(object)key];
            return cacheItem;
        }

        public void Remove(string key)
        {
            if (!Items.ContainsKey((object)key))
                return;
            Items.Remove((object)key);
        }
    }
}
