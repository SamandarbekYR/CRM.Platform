using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string PasswordSalt { get; set; } = null!;

    [InverseProperty(nameof(UserRole.User))]
    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
}

