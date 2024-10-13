using Microsoft.EntityFrameworkCore;

using ProductManager.Models;

namespace ProductManager.Persistence
{
    public class ProductManagerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProductManagerDbContext(DbContextOptions<ProductManagerDbContext> options) : base(options)
        {

        }
        // public DbSet<UserModel> User { get; set; }
        // public ProductManagerDbContext(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }

        // Defina as suas entidades
        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais, se necessário
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = _configuration.GetConnectionString("DefaultConnection");
        //    options.UseSqlServer(connectionString);
        //}

    }
}
