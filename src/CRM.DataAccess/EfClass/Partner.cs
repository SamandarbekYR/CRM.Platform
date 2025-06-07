using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class Partner : BaseEntity
{
    public Partner()
    {
        Licenses = new HashSet<License>();
    }
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    [InverseProperty(nameof(License.Partner))]
    public virtual ICollection<License> Licenses { get; set; } = new List<License>();
}