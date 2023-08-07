
using AutoMapper.Extensions.ExpressionMapping;
using CaseBL.ImplementationsOfManager;
using CaseBL.InterfacesOfManager;
using CaseDL;
using CaseDL.ImplementationsOfRepo;
using CaseDL.InterfacesOfRepo;
using CaseEL.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CaseAPI
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
            builder.Services.AddAutoMapper(x =>
            {
                x.AddExpressionMapping();
                x.AddProfile(typeof(Maps));
            });

            //DI yaþam döngüleri

            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<INoteManager, NoteManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}