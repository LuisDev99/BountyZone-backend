using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Repositories;
using BountyZone.Core.Interfaces.Services;
using BountyZone.Core.Services;
using BountyZone.Infrastructure;
using BountyZone.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BountyZone.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
                );

            services.AddControllers().AddNewtonsoftJson(x =>
                x.UseMemberCasing()
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BountyZone.API", Version = "v1" });
            });

            services.AddDbContext<BountyZoneDbContext>((options) =>
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

            services.AddScoped<IHunterRepository, HunterRepository>();
            services.AddScoped<ILeaderRepository, LeaderRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IHunterService, HunterService>();
            services.AddScoped<ILeaderService, LeaderService>();
            services.AddScoped<IPlayerService, PlayerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BountyZone.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
