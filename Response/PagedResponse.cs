using System.Text.Json.Serialization;

namespace MongoRepoX.Response
{
    [method: JsonConstructor]
    public class PagedResponse<TData>(
        TData? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = 25)
    {
        public TData? Data { get; set; } = data;
        public int CurrentPage { get; set; } = currentPage;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = pageSize;
        public int TotalCount { get; set; } = totalCount;
    }
}
