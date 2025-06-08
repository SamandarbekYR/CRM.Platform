using CRM.DataAccess.Repositories.Licenses;
using CRM.DataAccess.Repositories.Partners;
using CRM.DataAccess.Repositories.TrustedClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.Repositories.UnitOfWork;

public interface IUnitOfWork : IBaseUnitOfWork
{
    IPartnerRepository Partner { get; }
    ILicenseRepository License { get; }
    ITruestedClientRepository TrustedClient { get; }
}
