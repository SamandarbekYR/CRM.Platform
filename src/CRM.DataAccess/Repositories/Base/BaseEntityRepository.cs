using CRM.DataAccess.Ef;
using CRM.DataAccess.EfClass.Models;
using GenericServices;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.Repositories.Base;

public class BaseEntityRepository<TId, TEntity, TCreateDto, TUpdateDto> :
             BaseEntityRepository<TId, TEntity>,
             IBaseEntityRepository<TId, TEntity, TCreateDto, TUpdateDto>,
             IBaseEntityRepository<TId, TEntity>,
             IStatusGenericHandler,
             IStatusGeneric
             where TEntity : class, IHaveId<TId>, ISoftDeletable
             where TCreateDto : EntityDto<TCreateDto, TEntity>
             where TUpdateDto : EntityDto<TUpdateDto, TEntity>, IHaveId<TId>
{
    public BaseEntityRepository(ICrudServices crudServices) : base(crudServices) { }

    public virtual TEntity Create(TCreateDto createDto)
    {
        CreateValidate(createDto);
        Validate(null!, createDto, null);
        if (base.HasErrors) return null!;

        var entity = createDto.CreateEntity();
        base.Context.Entry(entity).State = EntityState.Added;
        base.DbSet.Add(entity);
        return entity;
    }
    public virtual TEntity Create(TEntity entity)
    {
        base.Context.Entry(entity).State = EntityState.Added;
        base.DbSet.Add(entity);
        return entity;
    }
    public virtual TEntity Update(TUpdateDto updateDto)
    {
        var entity = ById(updateDto.Id);
        if (entity == null || !base.IsValid)
        {
            AddError("Not found");
            return null!;
        }

        UpdateValidate(entity, updateDto);
        Validate(entity, null, updateDto);
        if (base.HasErrors) return null;

        updateDto.UpdateEntity(entity);
        base.Context.Entry(entity).State = EntityState.Modified;
        base.Context.Update(entity);
        return entity;
    }
    public virtual TEntity Update(TEntity entity)
    {
        base.Context.Entry(entity).State = EntityState.Modified;
        base.Context.Update(entity);
        return entity;
    }

    protected virtual void CreateValidate(TCreateDto dto) { }
    protected virtual void UpdateValidate(TEntity entity, TUpdateDto dto) { }
    protected virtual void Validate(TEntity entity, TCreateDto createDto, TUpdateDto updateDto) { }
}
