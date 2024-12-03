using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System.Linq.Expressions;

namespace Project1.Configurations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var markedAsDeleted = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is Base baseDto)
                {
                    item.State = EntityState.Unchanged;
                    baseDto.IsDeleted = true;
                    baseDto.DeletedDate = DateTime.Now;
                }
            }

            return Task.FromResult(base.SaveChanges());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(Base).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType);
                    var deletedCheck = Expression.Lambda(Expression.Equal(Expression.Property(parameter, "IsDeleted"), Expression.Constant(false)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(deletedCheck);
                }
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasIndex(p => p.Id)
            .HasDatabaseName("IX_Product_Id")
            .IsUnique();

            modelBuilder.Entity<Category>()
            .HasIndex(p => p.Id)
            .HasDatabaseName("IX_Category_Id")
            .IsUnique();

            modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });
        }
    }
}