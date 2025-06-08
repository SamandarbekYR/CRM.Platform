using CRM.DataAccess.EfClass.Models;
using GenericServices;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using System.Linq.Expressions;
namespace CRM.DataAccess.Repositories;

public interface IBaseEntityRepository<TId, TEntity> : IStatusGenericHandler, IStatusGeneric where TEntity : class, IHaveId<TId>, ISoftDeletable
{
    DbSet<TEntity> DbSet { get; }

    DbContext Context { get; }

    ICrudServices CrudServices { get; }

    IQueryable<TEntity> AllAsQueryable { get; }
    IQueryable<TEntity> GetAll { get; }
    bool Exists(TId id);
    IQueryable<TDto> ReadAsNoTracked<TDto>() where TDto : class;

    IQueryable<TDto> ReadAsNoTracked<TDto>(Expression<Func<TEntity, bool>> predicate) where TDto : class;

    TEntity ById(TId id);

    TDto ById<TDto>(TId id) where TDto : class;

    Task<TEntity> DeleteAsync(TId id);

    TEntity DeleteOrg(TId id);
}
