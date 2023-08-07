using AutoMapper.Extensions.ExpressionMapping;
using CaseBL.ImplementationsOfManager;
using CaseBL.InterfacesOfManager;
using CaseDL;
using CaseDL.ImplementationsOfRepo;
using CaseDL.InterfacesOfRepo;
using CaseEL.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CaseUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<NoteContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));

            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(x =>
            {
                x.AddExpressionMapping();
                x.AddProfile(typeof(Maps));
            });

            //DI yaþam döngüleri

            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<INoteManager, NoteManager>();

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