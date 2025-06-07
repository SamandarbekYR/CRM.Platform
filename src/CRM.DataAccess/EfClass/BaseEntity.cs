using CRM.DataAccess.EfClass.Models;

namespace CRM.DataAccess.EfClass;

public class BaseEntity: IHaveId<long>, ISoftDeletable
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
