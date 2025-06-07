using CRM.DataAccess.EfClass.Models;

namespace CRM.DataAccess.Repositories.Licenses;

public class UpdateLicenseDlDto : LicenseDlDto<UpdateLicenseDlDto>, IHaveId<long>
{
    public long Id { get; set; } 
}
