using System.Text.Json.Serialization;
using Asp.Versioning;

namespace WebAPI.Extensions
{
    public static class DefaultExtension
    {
        public static IServiceCollection AddDefaultAPIServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version")
                );
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }

        public static WebApplication UseDefaultAPIServices(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.MapControllers();
            return app;
        }
    }
}
