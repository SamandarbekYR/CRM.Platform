using CRM.DataAccess.EfClass;
using CRM.DataAccess.Repositories.Base;

namespace CRM.DataAccess.Repositories.Licenses;

public interface ILicenseRepository : IBaseEntityRepository<long, License, CreateLicenseDlDto, UpdateLicenseDlDto>
{ }