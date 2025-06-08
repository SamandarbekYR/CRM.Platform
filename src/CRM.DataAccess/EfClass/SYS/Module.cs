using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class Module
{
    public long Id { get; set; }
    public string Code { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public long SubGroupId { get; set; }
    public int StateId { get; set; }
    [InverseProperty(nameof(RoleModulePermission.Module))]
    public ICollection<RoleModulePermission> RoleModulePermissions { get; set; } = new HashSet<RoleModulePermission>();
}