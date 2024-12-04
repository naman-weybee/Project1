using Project1.RequestModel;
using X.PagedList;

namespace Project1.Repositories
{
    public interface IRepository<TEntity>
         where TEntity : class
    {
        Task<IPagedList<TEntity>> GetAllAsync(RequestParams requestParams);

        Task<IPagedList<TEntity>> GetAllWithoutPaginationAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(int id1, int id2);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task DeleteAsync(int id1, int id2);
    }
}