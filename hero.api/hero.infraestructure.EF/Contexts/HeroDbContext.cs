using System;
using hero.domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace hero.infraestructure.EF.Contexts
{
    public class HeroDbContext: DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public HeroDbContext()
        {
        }

        public HeroDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
