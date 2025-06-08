using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess.Repositories.UnitOfWork;

public interface IBaseUnitOfWork
{
    DbContext Context { get; }

    IDbContextTransaction? CurrencyTransaction { get; }

    TRepository GetRepository<TRepository>();

    Task<IDbContextTransaction> BeginTransactionAsync();
    Task<bool>SaveAsync();
}
