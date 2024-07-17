using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductDetailsDisplay.Contexts;
using ProductDetailsDisplay.Interfaces;
using ProductDetailsDisplay.Models;
using ProductDetailsDisplay.Repositories;
using ProductDetailsDisplay.Services;

namespace ProductDetailsDisplay
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            const string secretName = "SanjaiAzureSqlConnectionString";
            var keyVaultName = "rgSanjaiKeyVault";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secretValue = "";

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

            secretValue = secret.Value.Value;

            #region Contexts
            builder.Services.AddDbContext<ProductDetailsContext>(
                options => options.UseSqlServer(secretValue)
                );
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region Service
            builder.Services.AddScoped<IProductServices, ProductServices>();
            #endregion

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

            app.Run();
        }
    }
}
