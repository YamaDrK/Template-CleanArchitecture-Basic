using WebAPI.Middlewares;

namespace WebAPI.Extensions
{
    public static class MiddlewareExtension
    {
        public static IServiceCollection AddMiddlewareServices(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlingMiddleware>();
            return services;
        }

        public static WebApplication UseMiddlewareServices(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}
