using CRM.DataAccess.Repositories.Licenses;
using CRM.DataAccess.Repositories.Partners;
using CRM.DataAccess.Repositories.TrustedClients;
using GenericServices;

namespace CRM.DataAccess.Repositories.UnitOfWork;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    public UnitOfWork(ICrudServices crudServices, IServiceProvider serviceProvider)
        : base(crudServices.Context, serviceProvider)
    {
        CrudServices = crudServices;
        _serviceProvider = serviceProvider;
    }
    public ICrudServices CrudServices { get; }

    public IPartnerRepository Partner { get => GetRepository<IPartnerRepository>(); }

    public ILicenseRepository License { get => GetRepository<ILicenseRepository>(); }
    public ITruestedClientRepository TrustedClient { get => GetRepository<ITruestedClientRepository>(); }
}