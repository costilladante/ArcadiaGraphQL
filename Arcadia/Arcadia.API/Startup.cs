﻿using Arcadia.API.Models;
using Arcadia.API.ModelTypes;
using Arcadia.API.Mutations;
using Arcadia.API.Queries;
using Arcadia.Repository;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Arcadia.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // CORS Config
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.WithOrigins("http://localhost:3000"); // replace this with your own origin
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("ArcadiaCORSPolicy", corsBuilder.Build());
            });

            services.AddScoped<ArcadiaQuery>();
            services.AddScoped<ArcadiaMutation>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IHeroRepository, HeroRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddDbContext<ArcadiaContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("ArcadiaDatabase")));
            
            services.AddTransient<HeroType>();
            services.AddTransient<CompanyType>();
            services.AddTransient<GameType>();
            services.AddTransient<CompanyInputType>();

            var sp = services.BuildServiceProvider();
            services.AddTransient<ISchema>(_ => new ArcadiaSchema(type => (GraphType) sp.GetService(type))
            {
                Query = sp.GetService<ArcadiaQuery>(),
                Mutation = sp.GetService<ArcadiaMutation>()
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ArcadiaContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("ArcadiaCORSPolicy");

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
