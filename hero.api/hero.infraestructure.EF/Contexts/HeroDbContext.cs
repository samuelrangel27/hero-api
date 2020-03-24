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

        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasKey(h => h.Id);
            modelBuilder.Entity<Hero>()
                .Property(h => h.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
