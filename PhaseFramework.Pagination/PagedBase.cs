namespace PhaseFramework.Pagination
{
    public class PagedBase
    {
        public PagedBase(int? index, int? size)
        {
            PageIndex = index;
            PageSize = size;
        }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

    }
}
