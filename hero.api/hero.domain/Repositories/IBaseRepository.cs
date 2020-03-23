using System;
using System.Collections.Generic;
using hero.domain.Entities;

namespace hero.domain.Repositories
{
    public interface IBaseRepository<T,TKey> where T : BaseEntity<TKey>
    {
        void Add(T obj, bool saveChanges = true);
        void Update(T obj, bool saveChanges = true);
        void Delete(T obj, bool saveChanges = true);
        T GetById(TKey id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }

    public interface IBaseRepository<T> : IBaseRepository<T,int> where T : BaseEntity<int>
    {

    }
}
