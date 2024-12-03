using Microsoft.EntityFrameworkCore;
using Project1.Configurations;
using Project1.RequestModel;
using Project1.Services;
using X.PagedList;

namespace Project1.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        internal AppDbContext _context;
        internal DbSet<TEntity> DbSet;
        private readonly IPagination _pagination;

        public Repository(AppDbContext context, IPagination pagination)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
            _pagination = pagination;
        }

        public async Task<IPagedList<TEntity>> GetAllAsync(RequestParams requestParams)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(requestParams.search))
            {
                var nameProperty = typeof(TEntity).GetProperty("Name");
                if (nameProperty != null)
                {
                    var searchTerm = $"%{requestParams.search}%";
                    query = query.Where(e => EF.Functions.Like(EF.Property<string>(e, "Name"), searchTerm));
                }
            }

            requestParams.recordCount = await query.CountAsync();

            return await _pagination.SortResult(query, requestParams);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
                return await DbSet.FindAsync(id);
            else
                throw new Exception($"Data for Id = {id} is not Available...!");
        }

        public virtual async Task<TEntity> GetByIdAsync(int id1, int id2)
        {
            var entity = await DbSet.FindAsync(id1, id2);
            if (entity != null)
                return await DbSet.FindAsync(id1, id2);
            else
                throw new Exception($"Data for Ids = {id1}, {id2} is not Available...!");
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Data for Id = {id} is not Available...!");
            }
        }

        public virtual async Task DeleteAsync(int key1, int key2)
        {
            var entity = await DbSet.FindAsync(key1, key2);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Data for keys ({key1}, {key2}) is not available...!");
            }
        }
    }
}