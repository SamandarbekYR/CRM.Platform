using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;

namespace CRM.DataAccess.Repositories.Partners;

public interface IPartnerRepository : IBaseEntityRepository<long, Partner, CreatePartnerDlDto, UpdatePartnerDlDto>
{ }