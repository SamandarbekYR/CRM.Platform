using CRM.BizLogicLayer.Services.Licenses;
using CRM.DataAccess.EfClass;
using GenericServices;

namespace CRM.BizLogicLayer.Services.Partners;

public class PartnerView : ILinkToEntity<Partner>
{
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public double? PaymentSum { get; set; }
    public virtual ICollection<LicenseView> Licenses { get; set; } = new HashSet<LicenseView>();
}