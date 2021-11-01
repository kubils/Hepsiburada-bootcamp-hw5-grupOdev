using API.Configurations;
using Application;
using Core.Entities;
using Hangfire;
using Hangfire.PostgreSql;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Mongo;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Schedule.BackgroundJob.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {

            services.AddHangfire(x => x.UsePostgreSqlStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services
        .Configure<ECommerceMongoDbSettings>(
        Configuration.GetSection(nameof(ECommerceMongoDbSettings))
        );

            services.AddSingleton<IECommerceMongoDbSettings>(sp =>
              sp.GetRequiredService<IOptions<ECommerceMongoDbSettings>>().Value);

            services.AddDbContext<ECommerceDbContext>(options =>
                      options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //options=>options.MigrationsAssembly("DB_CONTEXT_PROJECT_NAME")));

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders();

            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:SecretKey"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
              IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption

              ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Issuer"],

                };
            });

            services.AddHttpContextAccessor();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddCommandQueryInjectionSetup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            app.UseHangfireDashboard();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RecurringJobs.TopOrderOperation();
        }
    }
}
