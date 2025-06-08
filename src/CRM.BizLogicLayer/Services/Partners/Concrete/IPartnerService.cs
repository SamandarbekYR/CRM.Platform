using StatusGeneric;

namespace CRM.BizLogicLayer.Services.Partners;

public interface IPartnerService : IStatusGeneric
{
    Task<bool> Add(AddPartner addPartnerDto);
    IQueryable<PartnerView> GetAll();
}