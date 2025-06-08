using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;
using GenericServices;

namespace CRM.DataAccess.Repositories.TrustedClients;

public class TrustedClientRepository : BaseEntityRepository<long, TrustedClient, CreateTrustedClientDto, UpdateTrustedClienDto>, ITruestedClientRepository
{
    public TrustedClientRepository(ICrudServices crudServices)
        : base(crudServices)
    { }
}