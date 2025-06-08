
using CRM.DataAccess.Repositories.UnitOfWork;
using StatusGeneric;

namespace CRM.BizLogicLayer.Services.Partners;

public class PartnerService : StatusGenericHandler, IPartnerService
{
    private readonly IUnitOfWork _unitOfWork;

    public PartnerService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public IQueryable<PartnerView> GetAll()
    {
        return _unitOfWork.Partner.ReadAsNoTracked<PartnerView>();
    }

    public async Task<bool> Add(AddPartner addPartnerDto)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync();
        var partner = await _unitOfWork.Partner.CreateAsync(addPartnerDto.CreatePartner);
        var partnerId = partner.Id;

        if (partner == null)
        {
            addPartnerDto.CreateLicense.PartnerId = partnerId;
            await _unitOfWork.License.CreateAsync(addPartnerDto.CreateLicense);
        }

        if(!await _unitOfWork.SaveAsync())
        {
            await transaction.RollbackAsync();
            return false;
        }
        await transaction.CommitAsync();
        return true; 
    }
}
