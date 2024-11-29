using Project1.Configurations;

namespace Project1.Repositories
{
    public interface IRepository<TEntity, TContext>
         where TEntity : class
         where TContext : AppDbContext, new()
    {
        AppDbContext GetDbContext();

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}