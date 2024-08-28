using Microsoft.EntityFrameworkCore;
using MyBread.Models;

namespace MyBread.Db
{
    public class Data : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Data()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=123321;database=chickenbd;", 
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
    
}