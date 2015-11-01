using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationServer.Caching;

namespace PhaseFramework.Storage
{
    public class AppFabricCacheStorageStrategy : IStorageStrategy<string, CacheItem>
    {
        public StorageConfiguration StorageConfiguration { get; private set; }

        public DataCacheFactory Factory { get; private set; }

        public DataCache Cache { get; private set; }

        public AppFabricCacheStorageStrategy(StorageConfiguration storageConfiguration)
        {
            StorageConfiguration = storageConfiguration;
            Initialize();
        }


        private void Initialize()
        {
            if (string.IsNullOrEmpty(StorageConfiguration.AppFabricCacheHostName))
                throw new ConfigurationErrorsException("AppFabricCacheHostName should be declared in configuration for AppFabric Caching to work.");

            if (!StorageConfiguration.AppFabricCachePortNumber.HasValue)
                throw new ConfigurationErrorsException("AppFabricCachePortNumber should be declared in configuration for AppFabric Caching to work.");

            List<DataCacheServerEndpoint> list1 = new List<DataCacheServerEndpoint>();
            list1.Add(new DataCacheServerEndpoint(StorageConfiguration.AppFabricCacheHostName, StorageConfiguration.AppFabricCachePortNumber.Value));

            List<DataCacheServerEndpoint> list2 = list1;
            DataCacheFactoryConfiguration factoryConfiguration = new DataCacheFactoryConfiguration();
            factoryConfiguration.Servers = list2;
            factoryConfiguration.LocalCacheProperties = new DataCacheLocalCacheProperties();

            DataCacheFactoryConfiguration configuration = factoryConfiguration;
            int num = (int)DataCacheClientLogManager.ChangeLogLevel(TraceLevel.Off);
            Factory = new DataCacheFactory(configuration);
            Cache = Factory.GetCache("default");
            Cache.CreateRegion(StorageConfiguration.AppFabricCacheRegionForApplication);
        }


        public void Put(string key, CacheItem value)
        {
            Cache.Put(key, (object)value, StorageConfiguration.AppFabricCacheRegionForApplication);
        }

        public CacheItem Get(string key)
        {
            return (CacheItem)Cache.Get(key, StorageConfiguration.AppFabricCacheRegionForApplication);
        }

        public void Remove(string key)
        {
            Cache.Remove(key, StorageConfiguration.AppFabricCacheRegionForApplication);
        }
    }
}
