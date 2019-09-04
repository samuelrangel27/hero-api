using System;
using System.Collections.Generic;
using hero.domain.Repositories;
using hero.infraestructure.EF.Contexts;
using System.Linq;
using hero.domain.Entities;

namespace hero.infraestructure.EF.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly HeroDbContext dbContext;

        public BaseRepository(HeroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity obj, bool saveChanges = true)
        {
            dbContext.Add(obj);
            if (saveChanges)
                dbContext.SaveChanges();
        }

        public void Update(TEntity obj, bool saveChanges = true)
        {
            dbContext.Set<TEntity>().Update(obj);
            if (saveChanges)
                dbContext.SaveChanges();
        }

        public void Delete(TEntity obj, bool saveChanges = true)
        {
            dbContext.Remove(obj);
            if (saveChanges)
                dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
