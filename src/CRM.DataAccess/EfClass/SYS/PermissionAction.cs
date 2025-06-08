using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class PermissionAction : BaseEntity
{
    public string Code { get; set; } = null!; // "CREATE", "READ", ...
    public string DisplayName { get; set; } = null!;
    [InverseProperty(nameof(RoleModulePermission.PermissionAction))]
    public ICollection<RoleModulePermission> RoleModulePermissions { get; set; } = new HashSet<RoleModulePermission>();
}
