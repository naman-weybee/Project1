using Project1.RequestModel;
using X.PagedList;

namespace Project1.Services
{
    public class Pagination : IPagination
    {
        public async Task<IPagedList<T>> SortResult<T>(IQueryable<T> source, RequestParams requestParams)
        {
            if (!string.IsNullOrEmpty(requestParams.sortBy))
            {
                var property = typeof(T).GetProperty(requestParams.sortBy);
                if (property != null)
                {
                    source = string.Equals(requestParams.orderBy?.Trim(), "DESC", StringComparison.OrdinalIgnoreCase)
                        ? source.AsEnumerable().OrderByDescending(e => property.GetValue(e)).AsQueryable()
                        : source.AsEnumerable().OrderBy(e => property.GetValue(e)).AsQueryable();
                }
            }
            else
            {
                var nameProperty = typeof(T).GetProperty("CreatedDate");
                if (nameProperty != null)
                    source = source.AsEnumerable().OrderByDescending(e => nameProperty.GetValue(e)).AsQueryable();
            }

            return await source.ToPagedListAsync(requestParams.pageNumber, requestParams.pageSize);
        }
    }
}