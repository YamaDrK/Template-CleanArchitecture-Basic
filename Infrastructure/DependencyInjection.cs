using Application.Commons;
using Application.Commons.Mappers;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddApplicationDbContext(configuration);
            services.AddRedisDatabase(configuration);
            services.AddRepositoryScoped();
            services.AddServiceScoped();

            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);
            return services;
        }
    }
}
