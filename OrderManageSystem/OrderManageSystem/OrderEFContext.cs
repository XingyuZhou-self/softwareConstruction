using MySql.Data.EntityFramework;
using OrderManagement;
using System.Data.Entity;
namespace OrderManagementEF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderDBContext : DbContext
    {
        public OrderDBContext() : base("OrderDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderDBContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
