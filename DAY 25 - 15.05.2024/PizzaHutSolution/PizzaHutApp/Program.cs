using Microsoft.EntityFrameworkCore;
using PizzaHutApp.Contexts;
using PizzaHutApp.Interfaces;
using PizzaHutApp.Models;
using PizzaHutApp.Repositories;
using PizzaHutApp.Services;

namespace PizzaHutApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Contexts
            builder.Services.AddDbContext<PizzaHutContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<ICustomerServices, CustomerService>();
            builder.Services.AddScoped<IUserServices, UserService>();
            builder.Services.AddScoped<IPizzaServices, PizzaService>();
            #endregion

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
