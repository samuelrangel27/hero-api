using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace hero.infraestructure.EF.Contexts
{
    public class HeroDbContextFactory : IDesignTimeDbContextFactory<HeroDbContext>
    {
        public HeroDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HeroDbContext>();
            var connectionString = "Data Source=Hero.db";
            optionsBuilder.UseSqlite(connectionString, b => b.MigrationsAssembly("hero.infraestructure.EF"));
            return new HeroDbContext(optionsBuilder.Options);
        }
    }
}
