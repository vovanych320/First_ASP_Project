using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Microsoft.Extensions.Configuration;
using Shop.Data;
using Shop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Shop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot confString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(confString.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContent>();
            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContent>();
            services.AddControllersWithViews();


            services.AddTransient<IMedicines, MedicineRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.getCart(sp));


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
            //services.AddIdentityCore<>

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Medicines/{action}/{category?}", defaults: new { Controller = "Medicines", action = "List" });
            }
            );



            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent con = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DbObjects.Initial(con);
            }
            
        }
    }
}
