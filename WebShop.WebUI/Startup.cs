using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebShop.Domain.Models;
using WebShop.Domain.Abstract;
using WebShop.Domain.Repositories;
using WebShop.WebUI.Utils;

namespace WebShop.WebUI
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connStr = AppConfiguration.GetConnectionString("shopDb");
            services.AddControllersWithViews(options=>
            options.ModelBinderProviders.Insert(0, new CartModeBinderProvider())
            );
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connStr));
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IRepository<Category>, CategoryEFRepository>();
            services.AddTransient<IRepository<Photo>, PhotoEFRepository>();
            services.AddTransient<IRepository<Product>, ProductEFRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "root",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index", category = (string)null });
                endpoints.MapControllerRoute(
                    name: "pages",
                    pattern: "page{page}",
                    defaults: new { controller = "Home", action = "Index", category = (string)null },
                    constraints: new { page = @"\d+" });
                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart/{action=Index}",
                    defaults: new { controller = "Cart" });
                endpoints.MapControllerRoute(
                    name: "categories",
                    pattern: "{category}",
                    defaults: new { controller = "Home", action = "Index", page = 1 }
                    );
                endpoints.MapControllerRoute(
                    name: "standart",
                    pattern: "{category}/page{page}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { page = @"\d+" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
