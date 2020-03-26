using System;
using hero.aplication.DTOs.Inputs.Hero;
using hero.domain.Entities;
using Netploy.Common.Application.Base;

namespace hero.aplication.Services.Interfaces
{
    public interface IHeroApplicationService : IApplicationService<Hero,int, AddHeroInput, UpdateHeroInput>
    {
    }
}
