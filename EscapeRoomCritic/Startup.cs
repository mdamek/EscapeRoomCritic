﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EscapeRoomCritic.Core.Repositories;
using EscapeRoomCritic.Core.Services;
using EscapeRoomCritic.Infrastructure;
using EscapeRoomCritic.Infrastructure.Repositories;
using EscapeRoomCritic.Web.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace EscapeRoomCritic.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContext<EscapeRoomCriticDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EscapeRoomCriticDatabase")));
            services.Add(new ServiceDescriptor(typeof(IIdentityService), typeof(IdentityService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEscapeRoomService), typeof(EscapeRoomService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEscapeRoomRepository), typeof(EscapeRoomRepository), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IReviewService), typeof(ReviewService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IReviewRepository), typeof(ReviewRepository), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IStatisticsService), typeof(StatisticsService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUserStatisticProvider), typeof(UserStatisticProvider), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEscapeRoomCityStatisticProvider), typeof(EscapeRoomCityCityStatisticProvider), ServiceLifetime.Scoped));
            services.AddSingleton(Configuration);
            var key = Encoding.ASCII.GetBytes(Configuration["IdentitySecret:Secret"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Title = "EscapeRoom Critic API",
                        Version = "V1",
                        Description = "API to create profiles of escape rooms and rate them",
                        License = new License {Name = "MIT license", Url = "https://opensource.org/licenses/MIT" },
                        Contact = new Contact { Name = "mdamek", Url = "https://github.com/mdamek" }
                    });
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

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

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
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
