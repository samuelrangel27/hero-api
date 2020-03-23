using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using hero.aplication.Mappers;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.transversal.Constants;
using hero.transversal.Results;

namespace hero.aplication.Services.Implementations
{
    public class BaseApplicationService<TEntity,TKey> : IApplicationService<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly IBaseRepository<TEntity,TKey> _repository;
        protected readonly IMapper mapper;

        public BaseApplicationService(IBaseRepository<TEntity,TKey> repository)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<HeroProfile>();
            });
            mapper = config.CreateMapper();
            this._repository = repository;
        }

        public virtual ApiResult<TEntity> Add(TEntity obj)
        {
            _repository.Add(obj);
            return ApiResult<TEntity>.Ok(obj, CommonMessages.OK);
        }

        public virtual ApiResult<TEntity> Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public virtual ApiResult<IEnumerable<TEntity>> GetAll()
        {
            var entities = _repository.GetAll();
            return ApiResult<IEnumerable<TEntity>>.Ok(entities, CommonMessages.OK);
            
        }

        public virtual ApiResult<TEntity> GetById(TKey id)
        {
            var entity = _repository.GetById(id);
            return ApiResult<TEntity>.Ok(entity, CommonMessages.OK);
        }

        public virtual ApiResult<TEntity> Update(TEntity obj)
        {
            _repository.Update(obj);
            return ApiResult<TEntity>.Ok(obj, CommonMessages.OK);
        }
    }

    public class BaseApplicationService<TEntity,TKey, TInsert> : BaseApplicationService<TEntity,TKey>, IApplicationService<TEntity, TKey, TInsert> where TEntity : BaseEntity<TKey>
    {
        public BaseApplicationService(IBaseRepository<TEntity,TKey> repository) : base(repository)
        {
        }

        public ApiResult<TEntity> Add(TInsert obj)
        {
            TEntity entity = mapper.Map<TEntity>(obj);
            return base.Add(entity);
        }

        public ApiResult<TEntity> Update(TInsert obj)
        {
            TEntity entity = mapper.Map<TEntity>(obj);
            return base.Update(entity);
        }
    }

    public class BaseApplicationService<TEntity, TKey, TInsert, TUpdate> : BaseApplicationService<TEntity, TKey, TInsert>, IApplicationService<TEntity, TKey, TInsert, TUpdate> where TEntity : BaseEntity<TKey>
    {
        public BaseApplicationService(IBaseRepository<TEntity,TKey> repository) : base(repository)
        {
        }

        public ApiResult<TEntity> Update(TUpdate obj)
        {
            var entity = mapper.Map<TEntity>(obj);
            return base.Update(entity);
        }
    }

    public class BaseApplicationService<TEntity> : BaseApplicationService<TEntity, int> where TEntity : BaseEntity<int>
    {
        public BaseApplicationService(IBaseRepository<TEntity, int> repository) : base(repository)
        {
        }
    }


}
