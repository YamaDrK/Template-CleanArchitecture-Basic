using Application.Interfaces.Base;
using Application.Interfaces.Services;
using Infrastructure.Implements.Base;
using Infrastructure.Implements.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetService<,>), typeof(GetService<,>));
            services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudService<,,,>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
