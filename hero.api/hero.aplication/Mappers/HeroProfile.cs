using System;
using AutoMapper;
using hero.aplication.DTOs.Inputs.Hero;
using hero.domain.Entities;

namespace hero.aplication.Mappers
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<AddHeroInput, Hero>();
            CreateMap<UpdateHeroInput, Hero>();
        }
    }
}
