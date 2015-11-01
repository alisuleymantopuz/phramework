using System.ComponentModel;
using System.Configuration;

namespace PhaseFramework.Configuration
{
    public abstract class ConfigurationStore : IConfigurationStore
    {
        public T GetValue<T>(string key, ConfigurationKeyRequirement requirement)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting) && requirement == ConfigurationKeyRequirement.Required)
            {
                throw new AppSettingNotFoundException(key);
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)(converter.ConvertFromInvariantString(appSetting));
        }

        public string GetValue(string key, ConfigurationKeyRequirement requirement)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting) && requirement == ConfigurationKeyRequirement.Required)
            {
                throw new AppSettingNotFoundException(key);
            }
            return appSetting;
        }

        public string GetStringValue(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }
    }
}
