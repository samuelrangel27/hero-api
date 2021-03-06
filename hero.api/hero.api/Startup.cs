﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using hero.infraestructure.EF.Contexts;
using hero.domain.Repositories;
using hero.infraestructure.EF.Repositories;
using hero.domain.Entities;
using hero.aplication.Services.Interfaces;
using hero.aplication.Services.Implementations;
using hero.transversal.ErrorHandling;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Netploy.Common.Base.Repositories;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;

namespace hero.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetSection("Settings").GetConnectionString("DefaultConnection");
            services.AddDbContext<HeroDbContext>(options => options.UseMySQL(connectionString));

            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IHeroRepository, HeroRepository>();

            // Application Services
            services.AddScoped<IHeroApplicationService, HeroApplicationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseErrorHandling();
            
            app.UseMvc(x =>
            {
                x.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();
                x.EnableDependencyInjection();
                x.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            using (var serviceScope = app.ApplicationServices
                                        .GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<HeroDbContext>())
                {
                    if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                        context.Database.EnsureCreated();
                    else if (context.Database.GetPendingMigrations().Count() > 0)
                        context.Database.Migrate();
                }
            }
        }

        private static IEdmModel GetEdmModel()
        {
            Type contextType = typeof(HeroDbContext);
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            PropertyInfo[] propertyInfos = contextType.GetProperties().Where(pi => pi.PropertyType.Name.StartsWith("DbSet", StringComparison.Ordinal)).ToArray();
            MethodInfo builderMethodInfo = typeof(ODataConventionModelBuilder).GetMethod("EntitySet");
            foreach (var pi in propertyInfos)
            {
                var typeName = pi.PropertyType.GenericTypeArguments[0];
                MethodInfo genericBuilder = builderMethodInfo.MakeGenericMethod(typeName);
                genericBuilder.Invoke(builder, new object[] { typeName.Name });
            }
            return builder.GetEdmModel();
        }
    }
}
