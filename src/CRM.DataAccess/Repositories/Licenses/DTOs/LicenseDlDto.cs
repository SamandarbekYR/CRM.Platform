using CRM.DataAccess.Ef;
using CRM.DataAccess.EfClass;

namespace CRM.DataAccess.Repositories.Licenses;

public class LicenseDlDto<TDto> : EntityDto<TDto, License>
    where TDto : LicenseDlDto<TDto>
{
    public long? PartnerId { get; set; }
    public string? MacAddress { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public bool? IsActive { get; set; } = true;
    public string? ProductName { get; set; } = string.Empty;
}
