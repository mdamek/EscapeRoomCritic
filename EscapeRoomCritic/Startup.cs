﻿using System.Threading.Tasks;
using EscapeRoomCritic.Core.IdentityManager;
using EscapeRoomCritic.Core.Repositories;
using EscapeRoomCritic.Core.Services;
using EscapeRoomCritic.Infrastructure;
using EscapeRoomCritic.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EscapeRoomCritic.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EscapeRoom critic", Version = "v1"});
            });
            services.AddDbContext<EscapeRoomCriticDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EscapeRoomCriticDatabase")));
            services.Add(new ServiceDescriptor(typeof(IIdentityService), typeof(IdentityService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISecretProvider), typeof(SecretProvider), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Scoped));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EscapeRoom critic");
                c.RoutePrefix = "api/swagger";
            });
            app.Run(context => {
                context.Response.Redirect("swagger");
                return Task.CompletedTask;
            });
        }
    }
}
