using PhaseFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseFramework.Storage
{
    public class StorageConfiguration : ConfigurationStore
    {
        public string AppFabricCacheHostName
        {
            get
            {
                return this.GetStringValue("AppFabricCacheHostName");
            }
        }

        public int? AppFabricCachePortNumber
        {
            get
            {
                return this.GetValue<int>("AppFabricCachePortNumber", ConfigurationKeyRequirement.Required);
            }
        }

        public string AppFabricCacheRegionForApplication
        {
            get
            {
                return this.GetValue("AppFabricCacheRegionForApplication", ConfigurationKeyRequirement.Required);
            }
        }
    }
}
