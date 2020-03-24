using System;
using hero.aplication.DTOs.Inputs.Hero;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;

namespace hero.aplication.Services.Implementations
{
    public class HeroApplicationService : BaseApplicationService<Hero,int,AddHeroInput,UpdateHeroInput>, IHeroApplicationService
    {
        public HeroApplicationService(IHeroRepository repository) : base(repository)
        {
        }
    }
}
