using Application.Interfaces.Services;
using Infrastructure.Implements.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceScopeExtension
    {
        public static IServiceCollection AddServiceScoped(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
