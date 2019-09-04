using System;
using System.Collections.Generic;
using hero.domain.Entities;

namespace hero.domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T obj, bool saveChanges = true);
        void Update(T obj, bool saveChanges = true);
        void Delete(T obj, bool saveChanges = true);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
