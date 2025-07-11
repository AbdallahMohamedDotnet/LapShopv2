using LapShopv2.Models;
using LapShopv2.Models.IContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LapShopv2.BL;
using LapShopv2.BL.Icontract;
namespace LapShopv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // setup the dependency injection for the database context and repositories
            builder.Services.AddDbContext<MyDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // setup the dependency injection for the repositories
            builder.Services.AddScoped<I_DB_TBItem, ClsItem>();
            builder.Services.AddScoped<I_DB_TB_category, ClsCategories>();
            builder.Services.AddScoped<I_DB_ItemType, ClsItemTypes>();
            builder.Services.AddScoped<I_DB_Os, ClsOs>();
            // setup the dependency injection for the Objects data models
            builder.Services.AddScoped<IVmHomePage , VmHomePage >();
            var app = builder.Build(); 
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();



            #region Routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "LandingPages",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "ali",
                pattern: "ali/{controller=Home}/{action=Index}/{id?}");

            }
            );
            #endregion

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();
            //app.MapAreaControllerRoute(
            //    name: "admin",
            //    areaName: "admin",
            //    pattern: "admin/{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();
            //app.MapAreaControllerRoute(
            //    name: "categories",
            //    areaName: "admin",
            //    pattern: "admin/{controller=categories}/{action=List}/{id?}")
            //    .WithStaticAssets();
            //app.MapAreaControllerRoute(
            //    name: "categories",
            //    areaName: "admin",
            //    pattern: "admin/{controller=categories}/{action=Save}/{id?}")
            //    .WithStaticAssets();
            //app.MapAreaControllerRoute(
            //    name: "categories",
            //    areaName: "admin",
            //    pattern: "admin/{controller=categories}/{action=Edit}/{id?}")
            //    .WithStaticAssets();

            app.Run();
        }
    }
}


