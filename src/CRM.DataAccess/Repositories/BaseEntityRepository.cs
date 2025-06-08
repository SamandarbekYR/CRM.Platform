using CRM.DataAccess.EfClass.Models;
using GenericServices;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using System.Linq.Expressions;

namespace CRM.DataAccess.Repositories;

public class BaseEntityRepository<TId, TEntity> : StatusGenericHandler, IBaseEntityRepository<TId, TEntity>,
                                                  IStatusGenericHandler, IStatusGeneric where TEntity : class, IHaveId<TId>, ISoftDeletable
{
    public DbSet<TEntity> DbSet { get; }

    public DbContext Context { get; }

    public ICrudServices CrudServices { get; }

    public virtual IQueryable<TEntity> AllAsQueryable => InjectFilter(DbSet.AsQueryable());
    public virtual IQueryable<TEntity> GetAll => InjectFilter(DbSet.AsQueryable());

    public BaseEntityRepository(ICrudServices crudServices)
    {
        Context = crudServices.Context;
        CrudServices = crudServices;
        DbSet = Context.Set<TEntity>();
    }

    public virtual IQueryable<TDto> ReadAsNoTracked<TDto>() where TDto : class
    {
        return CrudServices.ProjectFromEntityToDto<TEntity, TDto>(InjectFilter);
    }

    public virtual IQueryable<TDto> ReadAsNoTracked<TDto>(Expression<Func<TEntity, bool>> predicate) where TDto : class
    {
        return CrudServices.ProjectFromEntityToDto<TEntity, TDto>(delegate (IQueryable<TEntity> query)
        {
            query = InjectFilter(query);
            return query.Where(predicate);
        });
    }
    public virtual TEntity ById(TId id)
    {
        TEntity? val = ByIdQuery().FirstOrDefault((TEntity a) => a.Id.Equals(id) && !a.IsDeleted);
        if (val == null)
        {
            AddEntityNotFoundError();
        }

        return val;
    }

    public virtual TDto ById<TDto>(TId id) where TDto : class
    {
        TDto? val = ReadAsNoTracked<TDto>((TEntity a) => a.Id.Equals(id) && !a.IsDeleted).FirstOrDefault();
        if (val == null)
        {
            AddEntityNotFoundError();
        }

        return val;
    }

    protected virtual IQueryable<TEntity> InjectFilter(IQueryable<TEntity> query)
    {
        return query.Where(a => !a.IsDeleted);
    }

    protected virtual void AddEntityNotFoundError()
    {
        AddError("No record found matching your request");
    }

    protected virtual IQueryable<TEntity> ByIdQuery()
    {
        return AllAsQueryable;
    }

    public async Task<TEntity> DeleteAsync(TId id)
    {
        TEntity val = ById(id);

        if (val == null)
        {
            AddError("Entity not found.");
            return null;
        }

        if (base.IsValid)
        {
            DeleteValidate(val);
        }

        if (base.HasErrors)
        {
            return null;
        }

        var model = Context.Entry(val);

        model.Property("IsDeleted").CurrentValue = true;
        model.State = EntityState.Modified;

        await Context.SaveChangesAsync();
        return val;
    }
    public virtual TEntity DeleteOrg(TId id)
    {
        TEntity val = ById(id);

        if (val == null)
        {
            AddError("Entity not found.");
            return null;
        }

        if (base.IsValid)
        {
            DeleteValidate(val);
        }

        if (base.HasErrors)
        {
            return null;
        }

        Context.Remove(val);

        return val;
    }


    protected virtual void DeleteValidate(TEntity entity)
    {
    }

    public bool Exists(TId id)
    {
        return ByIdQuery().Any(a => a.Id!.Equals(id));
    }
}

