using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderManagementEF
{
    public class OrderServiceEF
    {
        // 添加订单，同时确保客户、产品存在
        public void AddOrder(Order order)
        {
            using (var db = new OrderDBContext())
            {
                // 检查订单是否已存在
                if (db.Orders.Any(o => o.OrderId == order.OrderId))
                {
                    throw new ApplicationException($"订单号 {order.OrderId} 已经存在！");
                }
                // 处理客户和产品：若数据库中已经存在，则直接关联；否则新增
                // 例如：客户
                var customer = db.Customers.FirstOrDefault(c => c.Name == order.Customer.Name);
                if (customer == null)
                {
                    customer = new Customer { Name = order.Customer.Name };
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                order.CustomerId = customer.CustomerId;
                order.Customer = customer;

                // 订单明细里的产品也类似
                foreach (var detail in order.Details)
                {
                    var prod = db.Products.FirstOrDefault(p => p.Name == detail.Product.Name);
                    if (prod == null)
                    {
                        prod = new Product { Name = detail.Product.Name, Price = detail.Product.Price };
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

        // 删除订单
        public void DeleteOrder(int orderId)
        {
            using (var db = new OrderDBContext())
            {
                var order = db.Orders.Include(o => o.Details)
                                     .FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    throw new ApplicationException($"订单号 {orderId} 不存在！");
                }
                // 删除明细后删除订单
                db.OrderDetails.RemoveRange(order.Details);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        // 修改订单：假定根据订单号查找后修改
        public void UpdateOrder(Order updatedOrder)
        {
            using (var db = new OrderDBContext())
            {
                var order = db.Orders.Include(o => o.Details)
                                     .FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
                if (order == null)
                {
                    throw new ApplicationException($"订单号 {updatedOrder.OrderId} 不存在！");
                }
                // 更新客户
                var customer = db.Customers.FirstOrDefault(c => c.Name == updatedOrder.Customer.Name);
                if (customer == null)
                {
                    customer = new Customer { Name = updatedOrder.Customer.Name };
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                order.CustomerId = customer.CustomerId;
                order.Customer = customer;

                // 处理订单明细：先删除原有的明细，再添加新明细
                db.OrderDetails.RemoveRange(order.Details);
                db.SaveChanges();

                order.Details.Clear();
                foreach (var detail in updatedOrder.Details)
                {
                    var prod = db.Products.FirstOrDefault(p => p.Name == detail.Product.Name);
                    if (prod == null)
                    {
                        prod = new Product { Name = detail.Product.Name, Price = detail.Product.Price };
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
                         .Include(o => o.Customer)
                         .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
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
                         .Include(o => o.Customer)
                         .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
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
                         .Include(o => o.Customer)
                         .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
                         .Where(o => o.Customer.Name == customerName)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
            }
        }

        // 查询订单（按总金额大于等于指定值）
        public List<Order> QueryByTotalAmount(double amount)
        {
            using (var db = new OrderDBContext())
            {
                return db.Orders
                         .Include(o => o.Customer)
                         .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
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
                         .Include(o => o.Customer)
                         .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
                         .OrderBy(o => o.OrderId)
                         .ToList();
            }
        }
    }
}
