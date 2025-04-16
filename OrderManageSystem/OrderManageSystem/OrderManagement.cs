//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace OrderManagement
//{
//    // 客户类
//    public class Customer
//    {
//        public string Name { get; set; }
//        public Customer(string name)
//        {
//            Name = name;
//        }
//        public override string ToString() => $"客户：{Name}";
//    }

//    // 货物类
//    public class Product
//    {
//        public string Name { get; set; }
//        public double Price { get; set; }
//        public Product(string name, double price)
//        {
//            Name = name;
//            Price = price;
//        }
//        public override string ToString() => $"货物：{Name}, 单价：{Price}";
//    }

//    // 订单明细类，描述订单中的一项明细（某种货物及其数量）
//    public class OrderDetails
//    {
//        public Product Product { get; set; }
//        public int Quantity { get; set; }
//        public OrderDetails(Product product, int quantity)
//        {
//            Product = product;
//            Quantity = quantity;
//        }
//        public double Amount => Product.Price * Quantity;

//        public override bool Equals(object obj)
//        {
//            if (obj is OrderDetails details)
//                return Product.Name == details.Product.Name && Quantity == details.Quantity;
//            return false;
//        }
//        public override int GetHashCode() => (Product.Name, Quantity).GetHashCode();
//        public override string ToString() => $"{Product} 数量：{Quantity}, 小计：{Amount}";
//    }

//    // 订单类
//    public class Order
//    {
//        // 订单号
//        public int OrderId { get; set; }
//        // 订单客户
//        public Customer Customer { get; set; }
//        // 订单明细列表
//        // 一条OrderDetails就是一个订单明细（某种货物及其数量）
//        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

//        public Order(int orderId, Customer customer)
//        {
//            OrderId = orderId;
//            Customer = customer;
//        }

//        // 计算订单总金额
//        public double TotalAmount => Details.Sum(d => d.Amount);

//        // 重写 Equals 保证订单号唯一
//        public override bool Equals(object obj)
//        {
//            if (obj is Order order)
//                return OrderId == order.OrderId;
//            return false;
//        }
//        public override int GetHashCode() => OrderId.GetHashCode();

//        public override string ToString()
//        {
//            string detailsStr = string.Join("\n\t", Details.Select(d => d.ToString()));
//            return $"订单号：{OrderId}\n{Customer}\n订单明细：\n\t{detailsStr}\n订单总金额：{TotalAmount}";
//        }
//    }

//    // 订单服务类
//    public class OrderService
//    {
//        private List<Order> orders = new List<Order>();

//        // 添加订单，如果订单已存在则抛出异常
//        public void AddOrder(Order order)
//        {
//            if (orders.Contains(order))
//            {
//                throw new ApplicationException($"订单号 {order.OrderId} 已经存在！");
//            }
//            orders.Add(order);
//        }

//        // 删除订单，如果订单不存在则抛出异常
//        public void DeleteOrder(int orderId)
//        {
//            Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
//            if (order == null)
//            {
//                throw new ApplicationException($"订单号 {orderId} 不存在，无法删除！");
//            }
//            orders.Remove(order);
//        }

//        // 修改订单：根据订单号替换为新的订单对象，如果未找到则抛出异常
//        public void UpdateOrder(Order updatedOrder)
//        {
//            int index = orders.FindIndex(o => o.OrderId == updatedOrder.OrderId);
//            if (index < 0)
//            {
//                throw new ApplicationException($"订单号 {updatedOrder.OrderId} 不存在，无法修改！");
//            }
//            orders[index] = updatedOrder;
//        }

//        // 查询订单（按订单号）
//        public List<Order> QueryByOrderId(int orderId)
//        {
//            var query = orders.Where(o => o.OrderId == orderId)
//                              .OrderBy(o => o.TotalAmount);
//            return query.ToList();
//        }

//        // 查询订单（按商品名称）
//        public List<Order> QueryByProductName(string productName)
//        {
//            var query = orders.Where(o => o.Details.Any(d => d.Product.Name == productName))
//                              .OrderBy(o => o.TotalAmount);
//            return query.ToList();
//        }

//        // 查询订单（按客户名称）
//        public List<Order> QueryByCustomer(string customerName)
//        {
//            var query = orders.Where(o => o.Customer.Name == customerName)
//                              .OrderBy(o => o.TotalAmount);
//            return query.ToList();
//        }

//        // 查询订单（按订单总金额，大于等于给定金额）
//        public List<Order> QueryByTotalAmount(double amount)
//        {
//            var query = orders.Where(o => o.TotalAmount >= amount)
//                              .OrderBy(o => o.TotalAmount);
//            return query.ToList();
//        }

//        // 默认按照订单号排序
//        public void SortOrders()
//        {
//            orders.Sort((o1, o2) => o1.OrderId.CompareTo(o2.OrderId));
//        }

//        // 使用 Lambda 表达式进行自定义排序
//        public void SortOrders(Comparison<Order> comparison)
//        {
//            orders.Sort(comparison);
//        }

//        // 返回所有订单
//        public List<Order> GetAllOrders() => orders;
//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using OrderManagementEF;

namespace OrderManagement
{
    // 客户类
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        // 必须提供无参构造函数以便 EF 实例化
        public Customer() { }

        public Customer(string name)
        {
            Name = name;
        }
        public override string ToString() => $"客户：{Name}";
    }

    // 货物类
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        public Product() { }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString() => $"货物：{Name}, 单价：{Price}";
    }

    // 订单明细类，描述订单中的一项明细（某种货物及其数量）
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsId { get; set; }

        // 外键：所属订单
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        // 外键：对应货物
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public OrderDetails() { }

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
        [Key]
        // 注意：若希望由数据库自动生成主键，请添加 DatabaseGenerated 选项，
        // 此处如果你想使用用户传入的订单号，也可以取消 Identity 配置
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        // 外键：所属客户
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        // 订单明细列表（导航属性）
        public virtual ICollection<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public Order() { }

        public Order(int orderId, Customer customer) : this()
        {
            OrderId = orderId;
            Customer = customer;
            if (customer != null)
            {
                CustomerId = customer.CustomerId;
            }
        }

        // 计算订单总金额
        public double TotalAmount => Details.Sum(d => d.Amount);

        // 重写 Equals 保证订单号唯一
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

    // 订单服务类（基于 EF 实现数据的增删改查）
    public class OrderService
    {
        // 添加订单，如果订单已存在则抛出异常
        public void AddOrder(Order order)
        {
            using (var db = new OrderDBContext())
            {
                if (db.Orders.Any(o => o.OrderId == order.OrderId))
                {
                    throw new ApplicationException($"订单号 {order.OrderId} 已经存在！");
                }

                // 处理客户，如果数据库中存在相同名称的客户则直接关联，否则新增
                var customer = db.Customers.FirstOrDefault(c => c.Name == order.Customer.Name);
                if (customer == null)
                {
                    customer = order.Customer;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                order.CustomerId = customer.CustomerId;
                order.Customer = customer;

                // 处理订单明细中的产品
                foreach (var detail in order.Details)
                {
                    var prod = db.Products.FirstOrDefault(p => p.Name == detail.Product.Name);
                    if (prod == null)
                    {
                        prod = detail.Product;
                        db.Products.Add(prod);
                        db.SaveChanges();
                    }
                    detail.ProductId = prod.ProductId;
                    detail.Product = prod;
                }

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        // 删除订单，如果订单不存在则抛出异常
        public void DeleteOrder(int orderId)
        {
            using (var db = new OrderDBContext())
            {
                var order = db.Orders.Include("Details").FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    throw new ApplicationException($"订单号 {orderId} 不存在，无法删除！");
                }
                // 先删除订单明细
                foreach (var detail in order.Details.ToList())
                {
                    db.OrderDetails.Remove(detail);
                }
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        // 修改订单：根据订单号替换为新的订单对象，如果未找到则抛出异常
        public void UpdateOrder(Order updatedOrder)
        {
            using (var db = new OrderDBContext())
            {
                var order = db.Orders.Include("Details").FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
                if (order == null)
                {
                    throw new ApplicationException($"订单号 {updatedOrder.OrderId} 不存在，无法修改！");
                }

                // 更新客户信息
                var customer = db.Customers.FirstOrDefault(c => c.Name == updatedOrder.Customer.Name);
                if (customer == null)
                {
                    customer = updatedOrder.Customer;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                order.CustomerId = customer.CustomerId;
                order.Customer = customer;

                // 删除旧的订单明细
                foreach (var detail in order.Details.ToList())
                {
                    db.OrderDetails.Remove(detail);
                }
                db.SaveChanges();

                order.Details.Clear();
                foreach (var detail in updatedOrder.Details)
                {
                    var prod = db.Products.FirstOrDefault(p => p.Name == detail.Product.Name);
                    if (prod == null)
                    {
                        prod = detail.Product;
                        db.Products.Add(prod);
                        db.SaveChanges();
                    }
                    detail.ProductId = prod.ProductId;
                    detail.Product = prod;
                    order.Details.Add(detail);
                }
                db.SaveChanges();
            }
        }

        // 查询订单（按订单号）
        public List<Order> QueryByOrderId(int orderId)
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include("Customer")
                         .Include("Details.Product")
                         .Where(o => o.OrderId == orderId)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
            }
        }

        // 查询订单（按商品名称）
        public List<Order> QueryByProductName(string productName)
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include("Customer")
                         .Include("Details.Product")
                         .Where(o => o.Details.Any(d => d.Product.Name == productName))
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
            }
        }

        // 查询订单（按客户名称）
        public List<Order> QueryByCustomer(string customerName)
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include("Customer")
                         .Include("Details.Product")
                         .Where(o => o.Customer.Name == customerName)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
            }
        }

        // 查询订单（按订单总金额，大于等于给定金额）
        public List<Order> QueryByTotalAmount(double amount)
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include("Customer")
                         .Include("Details.Product")
                         .Where(o => o.TotalAmount >= amount)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
            }
        }

        // 返回所有订单
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include("Customer")
                         .Include("Details.Product")
                         .OrderBy(o => o.OrderId)
                         .ToList();
            }
        }
    }
}
