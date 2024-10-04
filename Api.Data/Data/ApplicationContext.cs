using Api.Core.Models;
using Api.Data.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace Api.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Brand> Brands { get; set; }


    }
}
