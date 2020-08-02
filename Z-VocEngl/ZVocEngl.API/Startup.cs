using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.API
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
            var connectionString = Configuration.GetConnectionString("LocalDb");
            services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<User, IdentityRole>(set =>
            {
                set.Password = new PasswordOptions()
                {
                    RequireNonAlphanumeric = false,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequiredLength = 8
                };
                set.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
            });
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "Sprint Controller", Version = "v2" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                     {"Bearer", new string[0] }
                };
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the bearer scheme",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //     {
                //         new OpenApiSecurityScheme
                //         {
                //             Reference = new OpenApiReference
                //             {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = "Bearer"
                //             },
                //             Scheme = "oauth2",
                //             Name = "Bearer",
                //             In = ParameterLocation.Header,
                //         },
                //         new List<string>()
                //     }
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.None,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}