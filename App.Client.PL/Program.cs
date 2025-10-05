using App.Client.BLL.Interfaces;
using App.Client.BLL.Repositories;
using App.Client.DAL.Data.Contexts;
using App.Client.PL.Mapping;
using App.Client.PL.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Client.PL {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentReposoitory>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAutoMapper(m => m.AddProfile(new EmployeeProfile()));

            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddTransient<ITransentService, TransentService>();
            builder.Services.AddSingleton<ISingeltonService, SingeltonService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
