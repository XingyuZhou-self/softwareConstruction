using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Order = OrderManagement.Order; // Explicitly specify which "Order" to use
using OrderManagement;
using OrderManagementEF;

namespace OrderManagementWinForm
{
    public partial class Form1 : Form
    {
        private OrderService orderService = new OrderService();
        //private OrderServiceEF orderService = new OrderServiceEF();
        private BindingSource ordersBindingSource = new BindingSource();
        private BindingSource orderDetailsBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitializeDataBindings();
        }

        // 初始化数据绑定：订单列表和订单明细主从绑定
        private void InitializeDataBindings()
        {
            // 绑定订单列表
            ordersBindingSource.DataSource = orderService.GetAllOrders();
            dataGridViewOrders.DataSource = ordersBindingSource;

            // 绑定订单明细：绑定到当前订单的 Details 属性
            orderDetailsBindingSource.DataSource = ordersBindingSource;
            orderDetailsBindingSource.DataMember = "Details";
            dataGridViewDetails.DataSource = orderDetailsBindingSource;
        }

        // 刷新绑定数据
        private void RefreshBindings()
        {
            ordersBindingSource.ResetBindings(false);
            orderDetailsBindingSource.ResetBindings(false);
        }

        // 新建订单
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderEditForm editForm = new OrderEditForm(orderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshBindings();
            }
        }

        // 修改订单
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ordersBindingSource.Current is Order selectedOrder)
            {
                OrderEditForm editForm = new OrderEditForm(orderService, selectedOrder);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshBindings();
                }
            }
            else
            {
                MessageBox.Show("请选择一个订单进行修改！");
            }
        }

        // 删除订单
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ordersBindingSource.Current is Order selectedOrder)
            {
                try
                {
                    orderService.DeleteOrder(selectedOrder.OrderId);
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

        // 按订单号查询订单（示例：文本框中输入订单号）
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
            if (int.TryParse(query, out int orderId))
            {
                List<Order> results = orderService.QueryByOrderId(orderId);
                ordersBindingSource.DataSource = results;
            }
            else
            {
                MessageBox.Show("请输入有效的订单号查询！");
            }
        }

        // 重置查询，显示所有订单
        private void btnReset_Click(object sender, EventArgs e)
        {
            ordersBindingSource.DataSource = orderService.GetAllOrders();
            RefreshBindings();
        }

    }
}
