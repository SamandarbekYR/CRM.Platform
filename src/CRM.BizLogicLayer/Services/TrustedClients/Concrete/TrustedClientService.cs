using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.TrustedClients;
using CRM.DataAccess.Repositories.UnitOfWork;
using StatusGeneric;

namespace CRM.BizLogicLayer.Services.TrustedClients;

public class TrustedClientService : StatusGenericHandler, ITrustedClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public TrustedClientService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<bool> Add(CreateTrustedClientDto dto)
    {
        await _unitOfWork.TrustedClient.CreateAsync(dto);
       
        if (!await _unitOfWork.SaveAsync())
        {
            AddError("Client qo'shayotganda xatolik yuz berdi !!!");
            return false;
        }

        return true;
    }

    public List<TrustedClient> GetAll()
    => _unitOfWork.TrustedClient.GetAll.ToList();
}
