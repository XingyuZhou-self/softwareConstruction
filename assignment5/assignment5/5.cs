/*
 * 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能。
 * 并对各个Public方法编写测试用例。
 * 提示：主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。
 * 在Program里面可以调用OrderService的方法完成各种订单操作。

要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5） OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    // 客户类
    public class Customer
    {
        public string Name { get; set; }
        public Customer(string name)
        {
            Name = name;
        }
        public override string ToString() => $"客户：{Name}";
    }

    // 货物类
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString() => $"货物：{Name}, 单价：{Price}";
    }

    // 订单明细类    描述订单中的一项明细，即某种货物及其购买数量
    public class OrderDetails
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderDetails(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public double Amount => Product.Price * Quantity;

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails details)
                return Product.Name == details.Product.Name && Quantity == details.Quantity;
            return false;
        }
        public override int GetHashCode() => (Product.Name, Quantity).GetHashCode();
        public override string ToString() => $"{Product} 数量：{Quantity}, 小计：{Amount}";
    }

    // 订单类
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
        }

        // 计算订单总金额
        public double TotalAmount => Details.Sum(d => d.Amount);

        // 重写Equals保证订单号唯一
        public override bool Equals(object obj)
        {
            if (obj is Order order)
                return OrderId == order.OrderId;
            return false;
        }
        public override int GetHashCode() => OrderId.GetHashCode();

        public override string ToString()
        {
            string detailsStr = string.Join("\n\t", Details.Select(d => d.ToString()));
            return $"订单号：{OrderId}\n{Customer}\n订单明细：\n\t{detailsStr}\n订单总金额：{TotalAmount}";
        }
    }

    // 订单服务类
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        // 添加订单，如果订单已存在则抛出异常
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"订单号{order.OrderId}已经存在！");
            }
            orders.Add(order);
        }

        // 删除订单，如果订单不存在则抛出异常
        public void DeleteOrder(int orderId)
        {
            Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new ApplicationException($"订单号{orderId}不存在，无法删除！");
            }
            orders.Remove(order);
        }

        // 修改订单：根据订单号替换为新的订单对象，如果未找到则抛出异常
        public void UpdateOrder(Order updatedOrder)
        {
            int index = orders.FindIndex(o => o.OrderId == updatedOrder.OrderId);
            if (index < 0)
            {
                throw new ApplicationException($"订单号{updatedOrder.OrderId}不存在，无法修改！");
            }
            orders[index] = updatedOrder;
        }

        // 查询订单（按订单号）
        public List<Order> QueryByOrderId(int orderId)
        {
            var query = orders.Where(o => o.OrderId == orderId)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单（按商品名称）
        public List<Order> QueryByProductName(string productName)
        {
            var query = orders.Where(o => o.Details.Any(d => d.Product.Name == productName))
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单（按客户名称）
        public List<Order> QueryByCustomer(string customerName)
        {
            var query = orders.Where(o => o.Customer.Name == customerName)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单（按订单总金额，大于等于给定金额）
        public List<Order> QueryByTotalAmount(double amount)
        {
            var query = orders.Where(o => o.TotalAmount >= amount)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 默认按照订单号排序
        public void SortOrders()
        {
            orders.Sort((o1, o2) => o1.OrderId.CompareTo(o2.OrderId));
        }

        // 使用Lambda表达式进行自定义排序
        public void SortOrders(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }

        // 返回所有订单
        public List<Order> GetAllOrders() => orders;
    }

    // 测试用例与程序入口
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 创建测试数据
                Customer customer1 = new Customer("Alice");
                Customer customer2 = new Customer("Bob");

                Product product1 = new Product("电脑", 5000);
                Product product2 = new Product("手机", 3000);
                Product product3 = new Product("耳机", 300);

                Order order1 = new Order(1, customer1);
                order1.Details.Add(new OrderDetails(product1, 1));
                order1.Details.Add(new OrderDetails(product3, 2));

                Order order2 = new Order(2, customer2);
                order2.Details.Add(new OrderDetails(product2, 1));
                order2.Details.Add(new OrderDetails(product3, 1));

                Order order3 = new Order(3, customer1);
                order3.Details.Add(new OrderDetails(product1, 2));
                order3.Details.Add(new OrderDetails(product2, 1));

                // 创建订单服务实例
                OrderService service = new OrderService();

                // 测试添加订单
                Console.WriteLine("=== 测试添加订单 ===");
                service.AddOrder(order1);
                service.AddOrder(order2);
                service.AddOrder(order3);
                foreach (var order in service.GetAllOrders())
                {
                    Console.WriteLine(order);
                }

                // 测试查询订单：按照订单号查询
                Console.WriteLine("\n=== 按订单号查询订单 ===");
                var queryById = service.QueryByOrderId(2);
                foreach (var order in queryById)
                {
                    Console.WriteLine(order);
                }

                // 测试查询订单：按照商品名称查询
                Console.WriteLine("\n=== 按商品名称查询订单（查询“电脑”）===");
                var queryByProduct = service.QueryByProductName("电脑");
                foreach (var order in queryByProduct)
                {
                    Console.WriteLine(order);
                }

                // 测试查询订单：按照客户查询
                Console.WriteLine("\n=== 按客户查询订单（查询“Alice”）===");
                var queryByCustomer = service.QueryByCustomer("Alice");
                foreach (var order in queryByCustomer)
                {
                    Console.WriteLine(order);
                }

                // 测试查询订单：按照订单金额查询（大于等于一定金额）
                Console.WriteLine("\n=== 按订单金额查询订单（金额>=10000）===");
                var queryByAmount = service.QueryByTotalAmount(10000);
                foreach (var order in queryByAmount)
                {
                    Console.WriteLine(order);
                }

                // 测试修改订单（例如修改订单2的客户信息）
                Console.WriteLine("\n=== 测试修改订单 ===");
                Order updatedOrder2 = new Order(2, customer1); // 修改客户为 Alice
                updatedOrder2.Details.Add(new OrderDetails(product2, 1));
                updatedOrder2.Details.Add(new OrderDetails(product3, 2));
                service.UpdateOrder(updatedOrder2);
                Console.WriteLine("修改后的订单：");
                Console.WriteLine(service.QueryByOrderId(2)[0]);

                // 测试删除订单
                Console.WriteLine("\n=== 测试删除订单 ===");
                service.DeleteOrder(1);
                Console.WriteLine("删除订单1后所有订单：");
                foreach (var order in service.GetAllOrders())
                {
                    Console.WriteLine(order);
                }

                // 测试排序：默认按照订单号排序
                Console.WriteLine("\n=== 测试默认排序（订单号） ===");
                service.SortOrders();
                foreach (var order in service.GetAllOrders())
                {
                    Console.WriteLine(order);
                }

                // 测试自定义排序：按照订单总金额降序排序
                Console.WriteLine("\n=== 测试自定义排序（订单总金额降序） ===");
                service.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
                foreach (var order in service.GetAllOrders())
                {
                    Console.WriteLine(order);
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"错误：{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生异常：{ex.Message}");
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}
