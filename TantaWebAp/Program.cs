namespace TantaWebAp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. day 7|8
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
