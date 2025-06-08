using CRM.DataAccess.EfCode;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace CRM.API.Configurations;

public static class ServiceConfig
{
    public static void AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
                });
    }

    public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connection);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
