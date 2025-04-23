using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace OrderApi
{
    /**
     * The service class to manage orders
     */
    public class OrderService
    {
        private readonly DbContextOptions<OrderContext> _options;

        public OrderService(DbContextOptions<OrderContext> options = null)
        {
            var builder = new DbContextOptionsBuilder<OrderContext>();
            // Configure the MySQL connection
            var connString = "server=localhost;user=root;password=123456;database=orderservice";
            builder.UseMySql(connString, ServerVersion.AutoDetect(connString));
            _options = options ?? builder.Options;

            // Seed initial data
            using (var ctx = new OrderContext(_options))
            {
                if (!ctx.Goods.Any())
                {
                    ctx.Goods.Add(new Product("apple", 100.0));
                    ctx.Goods.Add(new Product("egg", 200.0));
                    ctx.SaveChanges();
                }
                if (!ctx.Customers.Any())
                {
                    ctx.Customers.Add(new Customer("li"));
                    ctx.Customers.Add(new Customer("zhang"));
                    ctx.SaveChanges();
                }
            }
        }

        // Helper to create a context
        private OrderContext CreateContext() => new OrderContext(_options);

        public List<Order> Orders
        {
            get
            {
                using (var ctx = CreateContext())
                {
                    return ctx.Orders
                        .Include(o => o.Details)
                            .ThenInclude(d => d.Product)
                        .Include(o => o.Customer)
                        .ToList();
                }
            }
        }

        public Order GetOrder(string id)
        {
            using (var ctx = CreateContext())
            {
                return ctx.Orders
                    .Include(o => o.Details)
                        .ThenInclude(d => d.Product)
                    .Include(o => o.Customer)
                    .SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void AddOrder(Order order)
        {
            FixOrder(order);
            using (var ctx = CreateContext())
            {
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
        }

        public void RemoveOrder(string orderId)
        {
            using (var ctx = CreateContext())
            {
                var order = ctx.Orders
                    .Include(o => o.Details)
                    .SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                ctx.OrderDetails.RemoveRange(order.Details);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
        }

        public List<Order> QueryOrdersByProductName(string productName)
        {
            using (var ctx = CreateContext())
            {
                return ctx.Orders
                    .Include(o => o.Details)
                        .ThenInclude(d => d.Product)
                    .Include(o => o.Customer)
                    .Where(o => o.Details.Any(d => d.Product.Name == productName))
                    .ToList();
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var ctx = CreateContext())
            {
                return ctx.Orders
                    .Include(o => o.Details)
                        .ThenInclude(d => d.Product)
                    .Include(o => o.Customer)
                    .Where(o => o.Customer.Name == customerName)
                    .ToList();
            }
        }

        public List<Order> QueryByTotalPrice(double price)
        {
            using (var ctx = CreateContext())
            {
                return ctx.Orders
                    .Include(o => o.Details)
                        .ThenInclude(d => d.Product)
                    .Include(o => o.Customer)
                    .Where(o => o.Details.Sum(d => d.Quantity * d.Product.Price) > price)
                    .ToList();
            }
        }

        public void UpdateOrder(Order newOrder)
        {
            using (var ctx = CreateContext())
            {
                // Remove existing order and its details
                var existing = ctx.Orders
                    .Include(o => o.Details)
                    .SingleOrDefault(o => o.OrderId == newOrder.OrderId);
                if (existing != null)
                {
                    ctx.OrderDetails.RemoveRange(existing.Details);
                    ctx.Orders.Remove(existing);
                }
                FixOrder(newOrder);
                ctx.Orders.Add(newOrder);
                ctx.SaveChanges();
            }
        }

        // Avoid cascading insert/update on Customer and Product entities
        private static void FixOrder(Order newOrder)
        {
            newOrder.CustomerId = newOrder.Customer.Id;
            newOrder.Customer = null;
            foreach (var d in newOrder.Details)
            {
                d.ProductId = d.Product.Id;
                d.Product = null;
            }
        }

        public void Export(string fileName)
        {
            var xs = new XmlSerializer(typeof(List<Order>));
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            var xs = new XmlSerializer(typeof(List<Order>));
            using (var fs = new FileStream(path, FileMode.Open))
            using (var ctx = CreateContext())
            {
                var temp = (List<Order>)xs.Deserialize(fs);
                foreach (var order in temp)
                {
                    if (!ctx.Orders.Any(o => o.OrderId == order.OrderId))
                    {
                        FixOrder(order);
                        ctx.Orders.Add(order);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
