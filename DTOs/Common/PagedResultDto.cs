// DTOs/Common/PagedResultDto.cs

namespace LandRegistrySystem.DTOs.Common
{
    /// <summary>
    /// DTO عمومی برای نتایج صفحه‌بندی شده
    /// </summary>
    public class PagedResultDto<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}