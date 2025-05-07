using System.Text;
using Application.Commons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Extensions
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, AppConfiguration configuration) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.JwtConfig.Issuer,
                    ValidAudience = configuration.JwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.JwtConfig.SecretKey))
                };
            });
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
