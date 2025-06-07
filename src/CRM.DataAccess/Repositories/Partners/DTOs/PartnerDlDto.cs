using CRM.DataAccess.Ef;
using CRM.DataAccess.EfClass;

namespace CRM.DataAccess.Repositories.Partners;

public class PartnerDlDto<TDto> : EntityDto<TDto, Partner>
    where TDto : PartnerDlDto<TDto>
{
    public string? FullName { get; set; } = string.Empty;
    public string? UserName { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; } = string.Empty;
}
