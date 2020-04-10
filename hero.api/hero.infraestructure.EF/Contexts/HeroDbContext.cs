using System;
using hero.domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace hero.infraestructure.EF.Contexts
{
    public class HeroDbContext: DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Mission> Missions { get; set; }

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
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Sensei)
                .WithMany(h => h.Students);

            modelBuilder.Entity<Power>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Power>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Team>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<HeroPower>()
                .HasKey(hp => new { hp.HeroId, hp.PowerId });
            modelBuilder.Entity<HeroPower>()
                .HasOne(hp => hp.Hero)
                .WithMany(hp => hp.Powers)
                .HasForeignKey(hp => hp.HeroId);
            modelBuilder.Entity<HeroPower>()
                .HasOne(hp => hp.Power)
                .WithMany(hp => hp.Heroes)
                .HasForeignKey(hp => hp.PowerId);

            modelBuilder.Entity<HeroTeam>()
                .HasKey(hp => new { hp.HeroId, hp.TeamId });
            modelBuilder.Entity<HeroTeam>()
                .HasOne(hp => hp.Hero)
                .WithMany(hp => hp.Teams)
                .HasForeignKey(hp => hp.HeroId);
            modelBuilder.Entity<HeroTeam>()
                .HasOne(hp => hp.Team)
                .WithMany(hp => hp.Members)
                .HasForeignKey(hp => hp.TeamId);

            modelBuilder.Entity<Mission>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MissionHero>()
                .HasKey(mh => new { mh.HeroId, mh.MissionId });
            modelBuilder.Entity<MissionHero>()
                .HasOne(mh => mh.Mission)
                .WithMany(mh => mh.Heroes);
            modelBuilder.Entity<MissionHero>()
                .HasOne(mh => mh.Hero)
                .WithMany(mh => mh.Missions);
        }
    }
}
