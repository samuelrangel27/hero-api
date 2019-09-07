using System;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.transversal.Results;

namespace hero.aplication.Services.Implementations
{
    public class HeroApplicationService : BaseApplicationService<Hero>
    {
        public HeroApplicationService(IBaseRepository<Hero> repository) : base(repository)
        {
        }
    }
}
