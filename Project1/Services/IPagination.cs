using Project1.RequestModel;
using X.PagedList;

namespace Project1.Services
{
    public interface IPagination
    {
        Task<IPagedList<T>> SortResult<T>(List<T> source, RequestParams requestParams);
    }
}
