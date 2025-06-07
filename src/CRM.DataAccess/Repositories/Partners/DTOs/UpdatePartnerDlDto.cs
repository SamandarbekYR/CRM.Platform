using CRM.DataAccess.EfClass.Models;

namespace CRM.DataAccess.Repositories.Partners;

public class UpdatePartnerDlDto : PartnerDlDto<UpdatePartnerDlDto>, IHaveId<long>
{
    public long Id { get; set; }
}
