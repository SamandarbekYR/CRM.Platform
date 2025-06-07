using CRM.DataAccess.Ef;
using CRM.DataAccess.EfClass.Models;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.Repositories.Base;

public interface IBaseEntityRepository<TId, TEntity, TCreateDto, TUpdateDto> :
                 IBaseEntityRepository<TId, TEntity>, IStatusGenericHandler,
                 IStatusGeneric where TEntity : class, ISoftDeletable,
                 IHaveId<TId> where TCreateDto : EntityDto<TCreateDto, TEntity> where TUpdateDto : EntityDto<TUpdateDto, TEntity>, IHaveId<TId>
{
    TEntity Create(TCreateDto createDto);
    TEntity Update(TUpdateDto updateDto);
    TEntity Update(TEntity entity);
    TEntity Create(TEntity entity);
}

