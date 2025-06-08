using CRM.DataAccess.EfClass.Models;

namespace CRM.DataAccess.Repositories.TrustedClients;

public class UpdateTrustedClienDto : TrustedClientDlDto<UpdateTrustedClienDto>, IHaveId<long>
{
    public long Id { get; set; } 
}
