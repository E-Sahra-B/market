﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Web.Mvc;
using UI.Entities;
using UI.Services;

namespace UI
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
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options=>options
            .UseSqlServer("Server=(localdb\\mssqllocaldb;Datebase=Northwind;Trusted_Connection=true)"));
            services.AddIdentity<CustomIdentityUser,CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDistributedMemoryCache();
        }
        // Denemeeeee
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseIdentity();
            //app.UseMiddleware();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                 name: "areas",
                 areaName: "areas",
                 pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
