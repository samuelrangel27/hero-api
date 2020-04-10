using System;
using hero.aplication.DTOs.Inputs.Hero;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.infraestructure.EF.Repositories;
using Netploy.Common.Application.Base;

namespace hero.aplication.Services.Implementations
{
    public class HeroApplicationService : BaseApplicationService<Hero,int,AddHeroInput,UpdateHeroInput>, IHeroApplicationService
    {
        public HeroApplicationService(BaseRepository<Hero> repository) : base(repository)
        {
        }
    }
}
