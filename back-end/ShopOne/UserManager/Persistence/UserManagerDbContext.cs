using Microsoft.EntityFrameworkCore;

using UserManager.Models;

namespace UserManager.Persistence
{
    public class UserManagerDbContext : DbContext
    {
        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options): base(options)
        {

        }
        public DbSet<UserModel> User { get; set; }
        public DbSet<PropertyModel> Property { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // => options.UseSqlite($"Data Source={Path.Combine(Environment.CurrentDirectory, "UserManager.db")}");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={"C://UserManager.db"}");
    }
}
