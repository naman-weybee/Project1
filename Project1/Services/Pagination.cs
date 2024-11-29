using Project1.RequestModel;
using X.PagedList;

namespace Project1.Services
{
    public class Pagination : IPagination
    {
        public async Task<IPagedList<T>> SortResult<T>(List<T> source, RequestParams requestParams)
        {
            var data = source.AsQueryable();
            if (!string.IsNullOrEmpty(requestParams.sortBy))
            {
                var property = typeof(T).GetProperty(requestParams.sortBy);
                if (property != null)
                {
                    data = string.Equals(requestParams.orderBy?.Trim(), "DESC", StringComparison.OrdinalIgnoreCase)
                        ? data.OrderByDescending(e => property.GetValue(e))
                        : data.OrderBy(e => property.GetValue(e));
                }
            }
            else
            {
                var nameProperty = typeof(T).GetProperty("Name");
                if (nameProperty != null)
                    data = data.OrderBy(e => nameProperty.GetValue(e));
            }

            return await data.ToPagedListAsync(requestParams.pageNumber, requestParams.pageSize);
        }
    }
}