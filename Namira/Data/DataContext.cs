using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Namira.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Namira.Data
{
    public class DataContext : DbContext
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _webHost;
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
        public DataContext(IConfiguration configuration, IWebHostEnvironment webHost)
        {
            _configuration = configuration;
            _webHost = webHost;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_webHost.IsEnvironment("Ubuntu")) 
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("UbuntuConnection"));
                return;
            }
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFabric>().HasKey(s => new { s.ProductId, s.FabricId });

            modelBuilder.Entity<ProductFabric>()
                .HasOne(s => s.Product)
                .WithMany(s => s.ProductFabrics)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<ProductFabric>()
                .HasOne(s => s.Fabric)
                .WithMany(s => s.ProductFabrics)
                .HasForeignKey(s => s.FabricId);
        }
    }
}
