using Microsoft.EntityFrameworkCore;

namespace OrderApi
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            Database.EnsureCreated(); // 确保数据库已创建
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 如果已经配置了 options，则不重复配置
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;user=root;password=123456;database=orderservice";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Goods { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        }
    }

