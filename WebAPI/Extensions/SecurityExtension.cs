using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI.Extensions
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            return services;
        }

        public static WebApplication UseSecurityServices(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
