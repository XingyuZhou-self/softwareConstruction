using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OrderManagementEF
{
    // 客户类
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }  // 主键
        public string Name { get; set; }

        // 导航属性：一个客户对应多个订单
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString() => $"客户：{Name}";
    }

    // 货物类
    public class Product
    {
        [Key]
        public int ProductId { get; set; }  // 主键
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString() => $"货物：{Name}, 单价：{Price}";
    }

    // 订单明细类：描述某个订单中的一项明细，表示购买了某种商品及其数量  
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; } // 主键

        public int OrderId { get; set; }       // 外键
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }     // 外键
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public double Amount => Product.Price * Quantity;

        public override string ToString() => $"{Product} 数量：{Quantity}, 小计：{Amount}";
    }

    // 订单类
    public class Order
    {
        [Key]
        public int OrderId { get; set; }       // 主键

        public int CustomerId { get; set; }    // 外键
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        // 导航属性：一个订单对应多个订单明细
        public virtual ICollection<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public double TotalAmount => Details.Sum(d => d.Amount);

        public override string ToString()
        {
            string detailsStr = string.Join("\n\t", Details.Select(d => d.ToString()));
            return $"订单号：{OrderId}\n{Customer}\n订单明细：\n\t{detailsStr}\n订单总金额：{TotalAmount}";
        }
    }
}
