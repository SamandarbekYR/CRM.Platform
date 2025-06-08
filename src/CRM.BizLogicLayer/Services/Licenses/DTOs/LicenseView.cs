using CRM.DataAccess.EfClass;
using GenericServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.BizLogicLayer.Services.Licenses;

public class LicenseView : ILinkToEntity<License>
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductPrice { get; set; } = string.Empty;
    public string MacAddress { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public bool IsActive { get; set; } = true;
}
