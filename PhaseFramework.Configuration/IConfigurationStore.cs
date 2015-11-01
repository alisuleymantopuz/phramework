namespace PhaseFramework.Configuration
{
    public interface IConfigurationStore
    {
        T GetValue<T>(string key, ConfigurationKeyRequirement requirement);
        string GetValue(string key, ConfigurationKeyRequirement requirement);
        string GetStringValue(string key);
    }
}
