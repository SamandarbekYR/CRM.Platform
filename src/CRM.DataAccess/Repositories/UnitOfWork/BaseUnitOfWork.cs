using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CRM.DataAccess.Repositories.UnitOfWork;

public class BaseUnitOfWork : IBaseUnitOfWork
{
    private  IDbContextTransaction? _currentTransaction;
    private readonly IServiceProvider _serviceProvider;
    public DbContext Context { get; }

    public IDbContextTransaction? CurrencyTransaction => _currentTransaction;
    public BaseUnitOfWork(DbContext context, IServiceProvider serviceProvider)
    {
        Context = context;
        _serviceProvider = serviceProvider;
    }
    public TRepository GetRepository<TRepository>()
    {
        return _serviceProvider.GetRequiredService<TRepository>();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        _currentTransaction ??= Context.Database.CurrentTransaction ?? await Context.Database.BeginTransactionAsync();
        return _currentTransaction;
    }

    public async Task<bool> SaveAsync()
    {
        return await Context.SaveChangesAsync() > 0;
    }
}
