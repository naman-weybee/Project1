﻿using Microsoft.EntityFrameworkCore;
using Project1.Configurations;

namespace Project1.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
       where TEntity : class
       where TContext : AppDbContext, new()
    {
        internal bool _disposed;
        internal AppDbContext Context;
        internal DbSet<TEntity> DbSet;

        public Repository(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public AppDbContext GetDbContext()
        {
            return Context;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}