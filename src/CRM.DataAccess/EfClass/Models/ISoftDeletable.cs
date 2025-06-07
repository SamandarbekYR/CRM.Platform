namespace CRM.DataAccess.EfClass.Models;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
