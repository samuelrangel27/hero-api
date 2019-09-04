using System;
using System.Collections.Generic;
using hero.domain.Entities;
using hero.transversal.Results;

namespace hero.aplication.Services.Interfaces
{
    public interface IApplicationService<TEntity> where TEntity: BaseEntity
    {
        ApiResult<TEntity> Add(TEntity obj);
        ApiResult<TEntity> Delete(int id);
        ApiResult<TEntity> Update(TEntity obj);
        ApiResult<TEntity> GetById(int id);
        ApiResult<IEnumerable<TEntity>> GetAll();
    }

    public interface IApplicationService<TEntity, TInsert> : IApplicationService<TEntity> where TEntity : BaseEntity
    {
        ApiResult<TEntity> Add(TInsert obj);
        ApiResult<TEntity> Update(TInsert obj);
    }

    public interface IApplicationService<TEntity,TInsert,TUpdate> : IApplicationService<TEntity,TInsert> where TEntity : BaseEntity
    {
        ApiResult<TEntity> Update(TUpdate obj);
    }
}
