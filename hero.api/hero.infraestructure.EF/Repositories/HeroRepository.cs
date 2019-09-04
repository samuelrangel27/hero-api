using System;
using hero.domain.Entities;
using hero.domain.Repositories;
using hero.infraestructure.EF.Contexts;

namespace hero.infraestructure.EF.Repositories
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(HeroDbContext dbContext) : base(dbContext)
        {
        }
    }
}
