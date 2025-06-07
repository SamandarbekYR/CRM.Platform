using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;
using GenericServices;

namespace CRM.DataAccess.Repositories.Licenses;

public class LicenseRepository : BaseEntityRepository<long, License, CreateLicenseDlDto, UpdateLicenseDlDto>, ILicenseRepository
{
    public LicenseRepository(ICrudServices crudServices)
        : base(crudServices)
    {
    }
}