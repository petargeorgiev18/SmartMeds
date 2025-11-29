using CentralAPI.Implementations;
using CentralAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Implementation;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data;
using SmartMeds.Data.Entities;

namespace SmartMeds.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SmartMedsDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<SmartMedsUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SmartMedsDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IListingService, ListingService>();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IListings, ListingImpl>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
            app.MapRazorPages();

            app.Run();
        }
    }
}
