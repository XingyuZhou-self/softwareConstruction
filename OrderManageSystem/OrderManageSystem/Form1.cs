//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;
//using Order = OrderManagement.Order; // Explicitly specify which "Order" to use
//using OrderManagement;
//using OrderManagementEF;

//namespace OrderManagementWinForm
//{
//    public partial class Form1 : Form
//    {
//        private OrderService orderService = new OrderService();
//        private BindingSource ordersBindingSource = new BindingSource();
//        private BindingSource orderDetailsBindingSource = new BindingSource();

//        public Form1()
//        {
//            InitializeComponent();
//            InitializeDataBindings();
//        }

//        // 初始化数据绑定：订单列表和订单明细主从绑定
//        private void InitializeDataBindings()
//        {
//            // 绑定订单列表
//            ordersBindingSource.DataSource = orderService.GetAllOrders();
//            dataGridViewOrders.DataSource = ordersBindingSource;

//            // 绑定订单明细：绑定到当前订单的 Details 属性
//            orderDetailsBindingSource.DataSource = ordersBindingSource;
//            orderDetailsBindingSource.DataMember = "Details";
//            dataGridViewDetails.DataSource = orderDetailsBindingSource;
//        }

//        // 刷新绑定数据
//        private void RefreshBindings()
//        {
//            ordersBindingSource.ResetBindings(false);
//            orderDetailsBindingSource.ResetBindings(false);
//        }

//        // 新建订单
//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            OrderEditForm editForm = new OrderEditForm(orderService);
//            if (editForm.ShowDialog() == DialogResult.OK)
//            {
//                RefreshBindings();
//            }
//        }

//        // 修改订单
//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (ordersBindingSource.Current is Order selectedOrder)
//            {
//                OrderEditForm editForm = new OrderEditForm(orderService, selectedOrder);
//                if (editForm.ShowDialog() == DialogResult.OK)
//                {
//                    RefreshBindings();
//                }
//            }
//            else
//            {
//                MessageBox.Show("请选择一个订单进行修改！");
//            }
//        }

//        // 删除订单
//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (ordersBindingSource.Current is Order selectedOrder)
//            {
//                try
//                {
//                    orderService.DeleteOrder(selectedOrder.OrderId);
//                    RefreshBindings();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message);
//                }
//            }
//            else
//            {
//                MessageBox.Show("请选择一个订单进行删除！");
//            }
//        }

//        // 按订单号查询订单（示例：文本框中输入订单号）
//        private void btnQuery_Click(object sender, EventArgs e)
//        {
//            string query = txtQuery.Text.Trim();
//            if (int.TryParse(query, out int orderId))
//            {
//                List<Order> results = orderService.QueryByOrderId(orderId);
//                ordersBindingSource.DataSource = results;
//            }
//            else
//            {
//                MessageBox.Show("请输入有效的订单号查询！");
//            }
//        }

//        // 重置查询，显示所有订单
//        private void btnReset_Click(object sender, EventArgs e)
//        {
//            ordersBindingSource.DataSource = orderService.GetAllOrders();
//            RefreshBindings();
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using OrderManagement;
using OrderManagementEF;

namespace OrderManagementWinForm
{
    public partial class Form1 : Form
    {
        // EF 数据上下文
        private OrderDBContext dbContext;
        // 绑定源：订单列表和订单明细
        private BindingSource ordersBindingSource = new BindingSource();
        private BindingSource orderDetailsBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitializeDataBindings();
        }

        /// <summary>
        /// 初始化数据绑定：加载 EF 数据，并将 Local 集合绑定到窗体控件上。
        /// </summary>
        private void InitializeDataBindings()
        {
            // 创建数据上下文实例
            dbContext = new OrderDBContext();

            // 通过 EF 的 Load() 方法加载订单数据到内存，
            // Orders.Local 返回一个 ObservableCollection，可以转换为 BindingList 用于数据绑定。
            dbContext.Orders.Load();
            ordersBindingSource.DataSource = dbContext.Orders.Local.ToBindingList();

            // 将订单列表绑定到 DataGridView
            dataGridViewOrders.DataSource = ordersBindingSource;

            // 主从绑定：订单明细绑定到当前订单（通过其 Details 属性）
            orderDetailsBindingSource.DataSource = ordersBindingSource;
            orderDetailsBindingSource.DataMember = "Details";
            dataGridViewDetails.DataSource = orderDetailsBindingSource;
        }

        /// <summary>
        /// 刷新绑定 —— 由于使用的是 Local 集合，
        /// 大部分更新操作会自动通知界面，但调用 ResetBindings 可确保 UI 重新刷新。
        /// </summary>
        private void RefreshBindings()
        {
            ordersBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// 新建订单（点击添加按钮事件）。
        /// 这里将 OrderEditForm 窗口传递数据上下文，以便直接操作 EF 的 Local 集合。
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // OrderEditForm 的构造函数应适应传递 dbContext
            OrderEditForm editForm = new OrderEditForm(dbContext);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // 保存新增订单后，数据将加入 Local 集合中，刷新绑定显示最新数据
                dbContext.SaveChanges();
                RefreshBindings();
            }
        }

        /// <summary>
        /// 修改订单（点击修改按钮事件）。
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ordersBindingSource.Current is Order selectedOrder)
            {
                // 编辑订单（传递当前订单和上下文）
                OrderEditForm editForm = new OrderEditForm(dbContext, selectedOrder);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    dbContext.SaveChanges();
                    RefreshBindings();
                }
            }
            else
            {
                MessageBox.Show("请选择一个订单进行修改！");
            }
        }

        /// <summary>
        /// 删除订单（点击删除按钮事件）。
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ordersBindingSource.Current is Order selectedOrder)
            {
                try
                {
                    // 从上下文中删除当前订单，会级联删除明细（如果已配置级联删除或者手动移除明细）
                    dbContext.Orders.Remove(selectedOrder);
                    dbContext.SaveChanges();
                    RefreshBindings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请选择一个订单进行删除！");
            }
        }

        /// <summary>
        /// 按订单号查询订单（点击查询按钮事件）。
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
            if (int.TryParse(query, out int orderId))
            {
                // 使用 Local 集合进行查询，生成一个新的 BindingList 并重新赋值 DataSource
                var orders = dbContext.Orders.Local.Where(o => o.OrderId == orderId).ToList();
                ordersBindingSource.DataSource = new BindingSource(new BindingList<Order>(orders), null).DataSource;
                RefreshBindings();
            }
            else
            {
                MessageBox.Show("请输入有效的订单号查询！");
            }
        }

        /// <summary>
        /// 重置查询，显示所有订单（点击重置按钮事件）。
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // 重新绑定全体数据
            ordersBindingSource.DataSource = dbContext.Orders.Local.ToBindingList();
            RefreshBindings();
        }
    }
}
