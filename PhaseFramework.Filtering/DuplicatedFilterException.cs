using System;

namespace PhaseFramework.Filtering
{
    public class DuplicatedFilterException : SystemException
    {
        private readonly string _duplicatedFilter;

        public DuplicatedFilterException(string key)
        {
            _duplicatedFilter = key;
        }

        public override string Message
        {
            get
            {
                const string message = "The key is already exist";
                return !string.IsNullOrEmpty(_duplicatedFilter) ? string.Format(message + " : {0}", _duplicatedFilter) : message;
            }
        }
    }
}