using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using OrderManagement;
using OrderManagementEF;

namespace OrderManagementWinForm
{
    public partial class OrderEditForm : Form
    {
        // 使用 OrderDBContext 替换 OrderService
        private OrderDBContext dbContext;
        private bool isEditMode = false;
        private Order editingOrder;

        // 使用 BindingList 来绑定订单明细数据（用于 DataGridView 显示）
        private BindingList<OrderDetailsViewModel> detailsBindingList = new BindingList<OrderDetailsViewModel>();

        // 订单明细临时数据模型，便于 DataGridView 绑定
        public class OrderDetailsViewModel
        {
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }

        /// <summary>
        /// 构造函数：新建订单。直接传入 EF 数据上下文。
        /// </summary>
        /// <param name="context">EF 数据上下文</param>
        public OrderEditForm(OrderDBContext context)
        {
            InitializeComponent();
            dbContext = context;
            isEditMode = false;
            InitializeGrid();
        }

        /// <summary>
        /// 构造函数：编辑订单。传入现有订单及 EF 数据上下文。
        /// </summary>
        /// <param name="context">EF 数据上下文</param>
        /// <param name="order">要编辑的订单</param>
        public OrderEditForm(OrderDBContext context, Order order) : this(context)
        {
            isEditMode = true;
            editingOrder = order;
            txtOrderId.Text = order.OrderId.ToString();
            txtOrderId.ReadOnly = true; // 编辑时订单号不可修改
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

        /// <summary>
        /// 初始化 DataGridView 的数据绑定
        /// </summary>
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

        // 添加订单明细：直接添加一行，用户可在 DataGridView 中编辑
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
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

        // 确认保存订单（新增或编辑）
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtOrderId.Text.Trim(), out int orderId))
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

                Order order;
                if (isEditMode)
                {
                    // 编辑模式下：使用现有订单实例，并清空旧的订单明细
                    order = editingOrder;
                    // 更新客户信息（这里简单处理，新实例；实际可查询后更新已有客户）
                    order.Customer = new Customer(customerName);
                    order.CustomerId = order.Customer.CustomerId; // 或按需更新
                    order.Details.Clear();
                }
                else
                {
                    // 新建订单
                    order = new Order(orderId, new Customer(customerName));
                }

                // 遍历订单明细临时数据模型，构造并添加订单明细
                foreach (var item in detailsBindingList)
                {
                    if (string.IsNullOrEmpty(item.ProductName))
                    {
                        continue; // 忽略空行
                    }
                    // 使用用户输入的产品名称和价格构造产品（实际应用中可加入数据验证）
                    Product product = new Product(item.ProductName, item.Price);
                    OrderDetails detail = new OrderDetails(product, item.Quantity);
                    order.Details.Add(detail);
                }

                if (order.Details.Count == 0)
                {
                    MessageBox.Show("订单明细不能为空！");
                    return;
                }

                if (!isEditMode)
                {
                    // 新订单加入 EF 上下文
                    dbContext.Orders.Add(order);
                }
                // 保存修改（对于编辑模式，EF 会自动检测实体的变化）
                dbContext.SaveChanges();

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
