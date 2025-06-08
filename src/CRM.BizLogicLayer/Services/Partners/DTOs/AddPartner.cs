using CRM.DataAccess.Repositories.Licenses;
using CRM.DataAccess.Repositories.Partners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BizLogicLayer.Services.Partners;

public class AddPartner
{
   public CreatePartnerDlDto CreatePartner { get; set; } = new CreatePartnerDlDto();
   public CreateLicenseDlDto CreateLicense { get; set; } = new CreateLicenseDlDto();
}
