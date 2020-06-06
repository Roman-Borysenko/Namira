using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Namira.Entities;
using System.IO;

namespace Namira.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<NumberPurchase> NumberPurchases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLanguage> ProductLanguages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
