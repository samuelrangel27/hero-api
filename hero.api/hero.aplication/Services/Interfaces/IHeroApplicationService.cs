using System;
using hero.aplication.DTOs.Inputs.Hero;
using hero.domain.Entities;

namespace hero.aplication.Services.Interfaces
{
    public interface IHeroApplicationService : IApplicationService<Hero,int, AddHeroInput, UpdateHeroInput>
    {
    }
}
