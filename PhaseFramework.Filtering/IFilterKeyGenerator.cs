namespace PhaseFramework.Filtering
{
    public interface IFilterKeyGenerator
    {
        void AddItem(string key, string value);
        string GeneratedFilterQuery { get; }
    }
}
