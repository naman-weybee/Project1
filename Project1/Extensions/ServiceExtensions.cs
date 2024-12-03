using Project1.Models;
using Project1.Repositories;
using Project1.Services;

namespace Project1.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();

            services.AddScoped<IPagination, Pagination>();

            return services;
        }
    }
}