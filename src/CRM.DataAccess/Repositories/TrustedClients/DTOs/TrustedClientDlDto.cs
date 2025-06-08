using CRM.DataAccess.Ef;
using CRM.DataAccess.EfClass;

namespace CRM.DataAccess.Repositories.TrustedClients;

public class TrustedClientDlDto<TDto> : EntityDto<TDto, TrustedClient> where TDto : TrustedClientDlDto<TDto>
{
    public string? Name { get; set; } = string.Empty;
    public string? ApiKey { get; set; } = string.Empty;
    public string? MacAddress { get; set; }
    public bool? IsUsed { get; set; } = false;
    public DateTime? FirstUsedAt { get; set; }
    public TimeSpan? ExpirationAfterUse { get; set; } = TimeSpan.FromHours(1);
}
