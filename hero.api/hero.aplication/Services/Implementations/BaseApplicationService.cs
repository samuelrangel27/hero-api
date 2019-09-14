﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.transversal.Constants;
using hero.transversal.Results;

namespace hero.aplication.Services.Implementations
{
    public class BaseApplicationService<TEntity> : IApplicationService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseApplicationService(IBaseRepository<TEntity> repository)
        {
            
            this._repository = repository;
        }

        public virtual ApiResult<TEntity> Add(TEntity obj)
        {
            _repository.Add(obj);
            return ApiResult<TEntity>.Ok(obj, CommonMessages.OK);
        }

        public virtual ApiResult<TEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual ApiResult<IEnumerable<TEntity>> GetAll()
        {
            var entities = _repository.GetAll();
            return ApiResult<IEnumerable<TEntity>>.Ok(entities, CommonMessages.OK);
            
        }

        public virtual ApiResult<TEntity> GetById(int id)
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

    public class BaseApplicationService<TEntity, TInsert> : BaseApplicationService<TEntity>, IApplicationService<TEntity, TInsert> where TEntity : BaseEntity
    {
        public BaseApplicationService(IBaseRepository<TEntity> repository) : base(repository)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TInsert, TEntity>());
        }

        public ApiResult<TEntity> Add(TInsert obj)
        {
            TEntity entity = Mapper.Map<TEntity>(obj);
            return base.Add(entity);
        }

        public ApiResult<TEntity> Update(TInsert obj)
        {
            TEntity entity = Mapper.Map<TEntity>(obj);
            return base.Update(entity);
        }
    }

    public class BaseApplicationService<TEntity, TInsert, TUpdate> : BaseApplicationService<TEntity, TInsert>, IApplicationService<TEntity, TInsert, TUpdate> where TEntity : BaseEntity
    {
        public BaseApplicationService(IBaseRepository<TEntity> repository) : base(repository)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TUpdate, TEntity>());
        }

        public ApiResult<TEntity> Update(TUpdate obj)
        {
            var entity = Mapper.Map<TEntity>(obj);
            return base.Update(entity);
        }
    }
}
