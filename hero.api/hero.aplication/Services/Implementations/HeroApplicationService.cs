using System;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.transversal.Results;

namespace hero.aplication.Services.Implementations
{
    public class HeroApplicationService : BaseApplicationService<Hero>, IHeroApplicationService
    {
        public HeroApplicationService(IHeroRepository repository) : base(repository)
        {
        }
    }
}
