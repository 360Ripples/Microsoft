
using EmployeeManagementSystem.Repository;

namespace EmployeeManagementSystem
{
    public class EmployeeMain
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           
            builder.Services.AddControllersWithViews();
           

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // scoped service

            builder.Services.AddControllers();
            //builder.Services.AddTransient<MyCustomMiddleware>();





            var app = builder.Build();
            /* app.Use(async (context, next) =>
             {
                 await context.Response.WriteAsync("Use Middleware Incoming Request \n");
                 await next();
                 await context.Response.WriteAsync("Use Middleware Outgoing Response \n");
             });
             app.UseMiddleware<MyCustomMiddleware>();

             app.Run(async context => {
                 await context.Response.WriteAsync("Run Middleware Component\n");
             });*/
            

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            app.UseRouting();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


        }
    }
}