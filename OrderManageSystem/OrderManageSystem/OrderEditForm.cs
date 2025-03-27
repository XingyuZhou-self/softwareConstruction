using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using OrderManagement;

namespace OrderManagementWinForm
{
    public partial class OrderEditForm : Form
    {
        private OrderService orderService;
        private bool isEditMode = false;
        private Order editingOrder;
        // 使用 BindingList 来绑定订单明细数据
        private BindingList<OrderDetailsViewModel> detailsBindingList = new BindingList<OrderDetailsViewModel>();

        // 订单明细临时数据模型（方便 DataGridView 绑定）
        public class OrderDetailsViewModel
        {
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }

        // 构造函数：新建订单
        public OrderEditForm(OrderService service)
        {
            InitializeComponent();
            orderService = service;
            isEditMode = false;
            InitializeGrid();
        }

        // 构造函数：编辑订单
        public OrderEditForm(OrderService service, Order order) : this(service)
        {
            isEditMode = true;
            editingOrder = order;
            txtOrderId.Text = order.OrderId.ToString();
            txtOrderId.ReadOnly = true; // 修改时订单号不可修改
            txtCustomer.Text = order.Customer.Name;

            // 将订单明细填充到 BindingList 中
            foreach (var detail in order.Details)
            {
                detailsBindingList.Add(new OrderDetailsViewModel
                {
                    ProductName = detail.Product.Name,
                    Price = detail.Product.Price,
                    Quantity = detail.Quantity
                });
            }
        }

        // 初始化 DataGridView 的数据绑定
        private void InitializeGrid()
        {
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = detailsBindingList;

            // 添加列：产品名称
            DataGridViewTextBoxColumn colProduct = new DataGridViewTextBoxColumn();
            colProduct.DataPropertyName = "ProductName";
            colProduct.HeaderText = "产品名称";
            dataGridViewDetails.Columns.Add(colProduct);

            // 添加列：单价
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "单价";
            dataGridViewDetails.Columns.Add(colPrice);

            // 添加列：数量
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "数量";
            dataGridViewDetails.Columns.Add(colQuantity);
        }

        // 添加订单明细
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            // 直接添加空行，用户可在 DataGridView 中编辑
            detailsBindingList.Add(new OrderDetailsViewModel());
        }

        // 删除选中订单明细
        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.CurrentRow != null)
            {
                detailsBindingList.RemoveAt(dataGridViewDetails.CurrentRow.Index);
            }
        }

        // 确认保存订单
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId;
                if (!int.TryParse(txtOrderId.Text.Trim(), out orderId))
                {
                    MessageBox.Show("请输入有效的订单号！");
                    return;
                }
                string customerName = txtCustomer.Text.Trim();
                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show("请输入客户名称！");
                    return;
                }

                // 构造订单对象
                Order order = new Order(orderId, new Customer(customerName));
                foreach (var item in detailsBindingList)
                {
                    if (string.IsNullOrEmpty(item.ProductName))
                    {
                        continue; // 忽略空行
                    }
                    // 这里为了简化，直接使用用户输入的价格，如果需要可做更严谨的数据验证
                    Product product = new Product(item.ProductName, item.Price);
                    OrderDetails detail = new OrderDetails(product, item.Quantity);
                    order.Details.Add(detail);
                }

                if (order.Details.Count == 0)
                {
                    MessageBox.Show("订单明细不能为空！");
                    return;
                }

                if (isEditMode)
                {
                    orderService.UpdateOrder(order);
                }
                else
                {
                    orderService.AddOrder(order);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
