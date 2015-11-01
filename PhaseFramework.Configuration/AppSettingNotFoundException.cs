using System;

namespace PhaseFramework.Configuration
{
    public class AppSettingNotFoundException : SystemException
    {
        private readonly string _notFoundedKey;

        public AppSettingNotFoundException(string key)
        {
            _notFoundedKey = key;
        }

        public override string Message
        {
            get
            {
                const string message = "Application setting key not found";
                return !string.IsNullOrEmpty(_notFoundedKey) ? string.Format(message + " : {0}", _notFoundedKey) : message;
            }
        }
    }
}