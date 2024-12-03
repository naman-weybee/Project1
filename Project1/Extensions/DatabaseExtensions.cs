using Microsoft.EntityFrameworkCore;
using Project1.Configurations;

namespace Project1.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}