using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Urgen.Website.Data.DataService;
using Urgen.Website.Data.Entities;
using Urgen.Website.Data;

namespace Urgen.Website
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
            
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Database")));
                 services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<BlogDbSeeder>();
            services.AddAutoMapper();
            services.AddMvc()
                .AddRazorPagesOptions(opt =>
                {
                    opt.Conventions.AddPageRoute("/Tech/Index", "TechCorner");
                    opt.Conventions.AddPageRoute("/Travel/Index", "TravelCorner");
                    opt.Conventions.AddPageRoute("/Tech/TechDetail/{TechId?}", "TechDetail");
                    opt.Conventions.AddPageRoute("/Tech/TravelDetail/{TravelId?}", "TravelDetail");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)

             .AddJsonOptions(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                  options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

              });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<BlogDbSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
