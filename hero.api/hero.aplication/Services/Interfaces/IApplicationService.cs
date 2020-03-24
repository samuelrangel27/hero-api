using System;
using System.Collections.Generic;
using hero.domain.Entities;
using hero.transversal.Results;
using Netploy.Common.Base.Entities;

namespace hero.aplication.Services.Interfaces
{
    public interface IApplicationServiceBase<TEntity,TKey> where TEntity: BaseEntity<TKey>
    {
        ApiResult<TEntity> GetById(TKey id);
        ApiResult<IEnumerable<TEntity>> GetAll();
        ApiResult<TEntity> Delete(TKey id);
    }

    public interface IApplicationService<TEntity,TKey>: IApplicationServiceBase<TEntity,TKey>,
        IApplicationServiceAdd<TEntity, TKey, TEntity>,
        IApplicationServiceUpdate<TEntity, TKey,TEntity>
        where TEntity: BaseEntity<TKey>
    {
    }

    public interface IApplicationService<TEntity,TKey, TInsert> : IApplicationServiceBase<TEntity,TKey>,
        IApplicationServiceAdd<TEntity,TKey,TInsert>,
        IApplicationServiceUpdate<TEntity,TKey,TInsert>
        where TEntity : BaseEntity<TKey>
    {
    }

    public interface IApplicationService<TEntity,TKey,TInsert,TUpdate> : IApplicationServiceBase<TEntity,TKey>,
        IApplicationServiceAdd<TEntity,TKey, TInsert>,
        IApplicationServiceUpdate<TEntity,TKey, TUpdate>
        where TEntity : BaseEntity<TKey>
    {
    }

    public interface IApplicationServiceAdd<TEntity,TKey,TInsert> where TEntity: BaseEntity<TKey>
    {
        ApiResult<TEntity> Add(TInsert obj);
    }

    public interface IApplicationServiceUpdate<TEntity,TKey, TUpdate> where TEntity : BaseEntity<TKey>
    {
        ApiResult<TEntity> Update(TUpdate obj);
    }
}
