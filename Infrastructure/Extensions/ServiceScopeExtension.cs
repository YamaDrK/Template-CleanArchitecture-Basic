using Application.Commons;
using Application.Interfaces.Services;
using Infrastructure.Implements.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceScopeExtension
    {
        public static IServiceCollection AddServiceScoped(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
