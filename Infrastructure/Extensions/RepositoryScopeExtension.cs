using Application.Interfaces.Base;
using Application.Interfaces.Repositories;
using Infrastructure.Implements.Base;
using Infrastructure.Implements.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class RepositoryScopeExtension
    {
        public static IServiceCollection AddRepositoryScoped(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
