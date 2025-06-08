using CRM.BizLogicLayer.Services.Partners;
using CRM.DataAccess.EfCode;
using GenericServices.Setup;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace CRM.API.Configurations;

public static class GenericService
{
    public static void ConfigureGenericServices(this IServiceCollection services)
    {
        services.GenericServicesSimpleSetup<AppDbContext>(
            Assembly.GetAssembly(typeof(AppDbContext)), //Data layer
            Assembly.GetAssembly(typeof(PartnerView)) //Service layer
        );

        services.RegisterAssemblyPublicNonGenericClasses(
            Assembly.GetAssembly(typeof(AppDbContext)), //Data layer
            Assembly.GetAssembly(typeof(PartnerView)) //Service layer
        ).IgnoreThisInterface<IHostedService>()
         .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
    }
}
