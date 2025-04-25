using System;
using Application.Commons;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, AppConfiguration configuration)
        {
            if (configuration.DatabaseConfig.IsMemoryDB)
            {
                services.AddDbContext<ApplicationDbContext>(option => option.UseInMemoryDatabase("test"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.DatabaseConfig.ConnectionString));
            }
            return services;
        }

        public static IServiceCollection AddRedisDatabase(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.RedisConfig.ConnectionString;
                options.InstanceName = configuration.RedisConfig.InstanceName;
            });
            return services;
        }
    }
}
