using System;
using hero.domain.Entities;
using Netploy.Common.Base.Repositories;

namespace hero.domain.Repositories
{
    public interface IHeroRepository : IBaseRepository<Hero,int>
    {
    }
}
