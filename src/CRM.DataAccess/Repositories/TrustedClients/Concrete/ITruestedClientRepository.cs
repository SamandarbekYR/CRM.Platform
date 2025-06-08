using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.Repositories.TrustedClients;

public interface ITruestedClientRepository : IBaseEntityRepository<long, TrustedClient, CreateTrustedClientDto, UpdateTrustedClienDto>
{ }