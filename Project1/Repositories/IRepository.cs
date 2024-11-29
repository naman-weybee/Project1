using Microsoft.EntityFrameworkCore;
using Project1.Configurations;

namespace Project1.Repositories
{
    public interface IRepository<TEntity>
         where TEntity : class
    {
        DbContext GetDbContext();

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}