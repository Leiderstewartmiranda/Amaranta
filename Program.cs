using AMARANTA.Models;
using Microsoft.EntityFrameworkCore;

namespace AMARANTA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var conString = builder.Configuration.GetConnectionString("Conexion") ??
            throw new InvalidOperationException("No se encontro la conexion");
            builder.Services.AddDbContext<AmarantaContext>(options =>
                options.UseSqlServer(conString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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

            app.Run();
        }
    }
}
