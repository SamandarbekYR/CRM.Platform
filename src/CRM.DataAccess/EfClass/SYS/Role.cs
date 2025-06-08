using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class Role : BaseEntity
{
    public string Code { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public bool IsDefault { get; set; }
    public int StateId { get; set; }

    [ForeignKey(nameof(StateId))]
    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    [InverseProperty(nameof(RoleModulePermission.Role))]
    public ICollection<RoleModulePermission> RoleModulePermissions { get; set; } = new HashSet<RoleModulePermission>();
}
