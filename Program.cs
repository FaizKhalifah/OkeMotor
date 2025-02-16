using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OkeMotor.Areas.Auth.Services;
using OkeMotor.Data;
using OkeMotor.Models.Entities;
using OkeMotor.Seeder;

namespace OkeMotor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //set up postgres
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
              ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            //set up identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //assign services
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

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

            //var scope = app.Services.CreateScope();
            //var services = scope.ServiceProvider;

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    await DatabaseSeeder.SeedDataAsync(services); // Perhatikan bahwa ini ada dalam scope async
            //}


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
