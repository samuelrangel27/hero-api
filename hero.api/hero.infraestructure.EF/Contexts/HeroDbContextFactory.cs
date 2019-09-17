using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace hero.infraestructure.EF.Contexts
{
    public class HeroDbContextFactory : IDesignTimeDbContextFactory<HeroDbContext>
    {
        public HeroDbContext CreateDbContext(string[] args)
        {
            // IDesignTimeDbContextFactory is used usually when you execute EF Core commands like Add-Migration, Update-Database, and so on
            // So it is usually your local development machine environment
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Prepare configuration builder
            var ef = Directory.GetCurrentDirectory();
            var di = new DirectoryInfo(Directory.GetCurrentDirectory());
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(di.Parent.FullName,"hero.api"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();

            // Bind your custom settings class instance to values from appsettings.json
            var settingsSection = configuration.GetSection("Settings");
            var connString = settingsSection.GetConnectionString("DefaultConnection");

            // Create DB context with connection from your AppSettings 
            var optionsBuilder = new DbContextOptionsBuilder<HeroDbContext>()
                .UseMySQL(connString);

            return new HeroDbContext(optionsBuilder.Options);

        }
    }
}
