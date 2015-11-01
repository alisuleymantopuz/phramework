using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhaseFramework.Storage
{
    public class HttpContextStorageStrategy : IStorageStrategy<string, CacheItem>
    {
        public void Put(string key, CacheItem value)
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
                current.Items[(object)key] = (object)value;
            else
                CallContext.SetData(key, (object)value);
        }

        public CacheItem Get(string key)
        {
            HttpContext current = HttpContext.Current;
            if (current == null)
                return CallContext.GetData(key) as CacheItem;
            if (current.Items.Contains((object)key))
                return current.Items[(object)key] as CacheItem;
            else
                return null;
        }

        public void Remove(string key)
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
                current.Items.Remove((object)key);
            else
                CallContext.FreeNamedDataSlot(key);
        }
    }
}
