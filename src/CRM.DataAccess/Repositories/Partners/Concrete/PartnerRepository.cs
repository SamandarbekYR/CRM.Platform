using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;
using GenericServices;

namespace CRM.DataAccess.Repositories.Partners;

public class PartnerRepository : BaseEntityRepository<long, Partner, CreatePartnerDlDto, UpdatePartnerDlDto>, IPartnerRepository
{
    public PartnerRepository(ICrudServices crudServices)
        : base(crudServices)
    { }
}
