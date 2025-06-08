using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DataAccess.EfClass;

public class Partner : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public double? PaymentSum { get; set; } 
    [InverseProperty(nameof(License.Partner))]
    public virtual ICollection<License> Licenses { get; set; } = new HashSet<License>();
}