using Project1.Middlewares;

namespace Project1.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}