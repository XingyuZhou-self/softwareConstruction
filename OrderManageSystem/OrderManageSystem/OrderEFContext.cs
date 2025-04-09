using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace OrderManagementEF
{
    public class OrderDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
            string connectionString = config.GetConnectionString("OrderDBContext")
                ?? "server=localhost;port=3306;database=OrderDB;user=root;password=123456;";
            optionsBuilder.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));
        }
    }
}
