namespace PhaseFramework.Pagination
{
    public interface IPagedBaseManager
    {
        void SetPageIndexAndSizeIfItsNotExist(PagedBase pagedBase);
    }
}
