using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.TrustedClients;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BizLogicLayer.Services.TrustedClients;

public interface ITrustedClientService :IStatusGeneric
{
    Task<bool> Add(CreateTrustedClientDto dto);
    List<TrustedClient> GetAll();
}
