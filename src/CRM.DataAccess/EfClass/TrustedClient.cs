namespace CRM.DataAccess.EfClass;

public class TrustedClient :BaseEntity
{
    public string Name { get; set; } = string.Empty; 
    public string ApiKey { get; set; } = string.Empty; 
    public string? MacAddress { get; set; }
    public bool IsUsed { get; set; } = false;
    public DateTime? FirstUsedAt { get; set; }
    public TimeSpan ExpirationAfterUse { get; set; } = TimeSpan.FromHours(1);
}
