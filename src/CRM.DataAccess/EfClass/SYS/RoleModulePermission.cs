using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class RoleModulePermission : BaseEntity
{
    public long RoleId { get; set; }
    public long ModuleId { get; set; }
    public int PermissionActionId { get; set; }


    [ForeignKey("ModuleId")]
    [InverseProperty(nameof(Module.RoleModulePermissions))]
    public Module Module { get; set; } = null!;
  
    [ForeignKey("RoleId")]
    [InverseProperty(nameof(Role.RoleModulePermissions))]
    public Role Role { get; set; } = null!;

    [ForeignKey("PermissionActionId")]
    [InverseProperty(nameof(PermissionAction.RoleModulePermissions))]
    public PermissionAction PermissionAction { get; set; } = null!;
}
