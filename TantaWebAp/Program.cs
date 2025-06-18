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
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            });
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

            app.UseRouting();

            app.UseSession();//open session - cookie SessionId ,write  -read

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
