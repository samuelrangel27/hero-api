using System;
using hero.aplication.DTOs.Inputs.Hero;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;

namespace hero.aplication.Services.Implementations
{
    public class HeroApplicationService : BaseApplicationService<Hero,AddHeroInput,UpdateHeroInput>, IHeroApplicationService
    {
        public HeroApplicationService(IBaseRepository<Hero> repository) : base(repository)
        {
        }
    }
}
