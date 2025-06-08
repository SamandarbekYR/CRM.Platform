using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class UserRole : BaseEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(User.UserRoles))]
    public User User { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    [InverseProperty(nameof(Role.UserRoles))]
    public Role Role { get; set; } = null!;
}
