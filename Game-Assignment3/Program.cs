// Importing required namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Game_Assignment3.Data;

namespace Game_Assignment3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creating a new web application builder
            var builder = WebApplication.CreateBuilder(args);

            // Configuring the database context using Entity Framework Core
            builder.Services.AddDbContext<Game_Assignment3Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Game_Assignment3Context")
                    ?? throw new InvalidOperationException("Connection string 'Game_Assignment3Context' not found.")));

            // Adding services to the container (dependency injection)
            builder.Services.AddControllersWithViews();

            // Building the application
            var app = builder.Build();

            // Configuring the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                // Ussing error handling for non-development environments
                app.UseExceptionHandler("/Home/Error");

                // Configure HTTPS Strict Transport Security (HSTS)
                app.UseHsts();
            }

            // Redirecting HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Serving static files (CSS, JavaScript, images, etc.)
            app.UseStaticFiles();

            // Enabling routing for incoming requests
            app.UseRouting();

            // Appling authorization policies
            app.UseAuthorization();

            // Configuring controller routes using the default route pattern
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=GameModels}/{action=Index}/{id?}");

            // Running the application
            app.Run();
        }
    }
}
