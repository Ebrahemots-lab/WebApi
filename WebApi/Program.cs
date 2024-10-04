
using Api.Core.Interfaces;
using Api.Core.Mapping;
using Api.Data;
using Api.Data.Data;
using Api.Data.Repositories;
using Api.Services.Services.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region DatabsaeConnection
            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
             );
            #endregion

            builder.Services.AddAutoMapper(typeof(Profiles));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            #region Migrations

            using var scope = app.Services.CreateScope(); // this method will be used to resolve the Application dbcontext services
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            #region Apply Migrations
            //first regiester the method to get all avaliable services to scoped
            try
            {
                await context.Database.MigrateAsync();
                await ApplicationSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                var logRes = loggerFactory.CreateLogger<Program>();

                logRes.LogError(ex, "Error Happend");
            }
            #endregion
            #endregion





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
