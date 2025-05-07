using WebAPI.Extensions;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
        {
            services.AddDefaultAPIServices();
            services.AddMiddlewareServices();
            services.AddSecurityServices();
            services.AddWebAPIServiceScoped();
            services.AddSignalRServices();
            services.AddSwaggerServices();
            return services;
        }

        public static WebApplication UseWebAPIServices(this WebApplication app)
        {
            app.UseDefaultAPIServices();
            app.UseMiddlewareServices();
            app.UseSecurityServices();
            app.UseSignalRServices();
            app.UseSwaggerServices();
            return app;
        }
    }
}
