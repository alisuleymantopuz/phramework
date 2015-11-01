using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseFramework.Storage
{
    public interface IStorageStrategy<in TKey, TValue>
    {
        void Put(TKey key, TValue value);

        TValue Get(TKey key);

        void Remove(TKey key);
    }
}
