using AutoMapper;
using TransportSystemWebApp.Entities;
using TransportSystemWebApp.Mappers;
using TransportSystemWebApp.Models;
using TransportSystemWebApp.Services;


namespace TransportSystemWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRepository<City>, Repository<City,DataContext>>();
            builder.Services.AddSingleton<IRepository<Way>, Repository<Way, DataContext>>();
            builder.Services.AddSingleton<IRepository<Car>, Repository<Car, DataContext>>();
            builder.Services.AddSingleton<IRepository<CarType>, Repository<CarType, DataContext>>();
            builder.Services.AddSingleton<IRepository<Order>, Repository<Order, DataContext>>();

            builder.Services.AddSingleton<IService<City>, Service<City>>();
            builder.Services.AddSingleton<IService<Way>, Service<Way>>();
            builder.Services.AddSingleton<IService<Car>, Service<Car>>();
            builder.Services.AddSingleton<IService<CarType>, Service<CarType>>();
            builder.Services.AddSingleton<IService<Order>, Service<Order>>();

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddSingleton<DataContext>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

           await app.RunAsync();
        }
    }
}
