using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TantaWebAp.Filtters;
using TantaWebAp.Models;
using TantaWebAp.Repository;

namespace TantaWebAp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container. day 7|8
            //1) Built In Services and already REgister Container
            //2) Built in Services but need to register
            //builder.Services.AddControllersWithViews(options => {
            //    options.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            });
            //register ITIContext , DbContextOptions
            //if (builder.Configuration.GetSection("CurentCS").Value == "csLocal")
            //{
                builder.Services.AddDbContext<ITIContext>(optionBuilder =>
                {
                    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });
            //}
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                

            }).AddEntityFrameworkStores<ITIContext>();





            //3) Custom Service ,and need To Register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register IEmployeeRe
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register IEmployeeRe
            builder.Services.AddScoped<IService, Service>();


            var app = builder.Build();

            // Configure the HTTP request pipeline. middewares//Day2
            #region Custom Midddlewares (5%)
            //Inline Conponent
            //app.Use(async (httpcontext, next) =>
            //{
            //    //if(httpcontext.Request.)
            //    await httpcontext.Response.WriteAsync("1) Middelware 1\n");
            //    await next.Invoke();//<--
            //    await httpcontext.Response.WriteAsync("1-1) Middelware 1-1\n");

            //});
            //app.Use(async (httpcontext, next) =>
            //{
            //    //if(httpcontext.Request.)
            //    await httpcontext.Response.WriteAsync("2) Middelware 2\n");
            //    await next.Invoke();//<--
            //    await httpcontext.Response.WriteAsync("2-2) Middelware 2-2\n");

            //});
            //app.Run(async (httpcontext) =>
            //{
            //    //if
            //   await  httpcontext.Response.WriteAsync("3) Terminate\n");
            //});

            #endregion
            #region default PipLine
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();//security "Mapping""

            app.UseSession();//open session - cookie SessionId ,write  -read

            app.UseAuthorization();
            #region Naming Convention Route (MVC)

            //Route constrint
            //app.MapControllerRoute("rout1", "r1/{age:int:range(20,60)}/{name?}", new {controller="Route",action="Method1" });
            //app.MapControllerRoute("rout1", "r1", new {controller="Route",action="Method1" });
            //app.MapControllerRoute("rout2", "r2", new {controller="Route",action="Method2" });
            //app.MapControllerRoute("rout", "{controller=Employee}/{action=index}/{id?}");
            #endregion
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//middleware DEclare rout ,execute
            #endregion
            app.Run();
        }
    }
}
