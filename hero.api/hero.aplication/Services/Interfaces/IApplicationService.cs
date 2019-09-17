using System;
using System.Collections.Generic;
using hero.domain.Entities;
using hero.transversal.Results;

namespace hero.aplication.Services.Interfaces
{
    public interface IApplicationServiceBase<TEntity> where TEntity: BaseEntity
    {
        ApiResult<TEntity> GetById(int id);
        ApiResult<IEnumerable<TEntity>> GetAll();
        ApiResult<TEntity> Delete(int id);
    }

    public interface IApplicationService<TEntity>: IApplicationServiceBase<TEntity>,
        IApplicationServiceAdd<TEntity, TEntity>,
        IApplicationServiceUpdate<TEntity,TEntity>
        where TEntity: BaseEntity
    {
    }

    public interface IApplicationService<TEntity, TInsert> : IApplicationServiceBase<TEntity>,
        IApplicationServiceAdd<TEntity,TInsert>,
        IApplicationServiceUpdate<TEntity,TEntity>
        where TEntity : BaseEntity
    {
    }

    public interface IApplicationService<TEntity,TInsert,TUpdate> : IApplicationServiceBase<TEntity>,
        IApplicationServiceAdd<TEntity, TInsert>,
        IApplicationServiceUpdate<TEntity, TUpdate>
        where TEntity : BaseEntity
    {
    }

    public interface IApplicationServiceAdd<TEntity,TInsert> where TEntity: BaseEntity
    {
        ApiResult<TEntity> Add(TInsert obj);
    }

    public interface IApplicationServiceUpdate<TEntity, TUpdate> where TEntity : BaseEntity
    {
        ApiResult<TEntity> Update(TUpdate obj);
    }
}
