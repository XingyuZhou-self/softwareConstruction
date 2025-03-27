namespace OrderManagementWinForm
{
    partial class OrderEditForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.labelOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnRemoveDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOrderId
            // 
            this.labelOrderId.AutoSize = true;
            this.labelOrderId.Location = new System.Drawing.Point(12, 15);
            this.labelOrderId.Name = "labelOrderId";
            this.labelOrderId.Size = new System.Drawing.Size(53, 12);
            this.labelOrderId.TabIndex = 0;
            this.labelOrderId.Text = "订单号：";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(70, 12);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 21);
            this.txtOrderId.TabIndex = 1;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(200, 15);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(65, 12);
            this.labelCustomer.TabIndex = 2;
            this.labelCustomer.Text = "客户名称：";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(270, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(150, 21);
            this.txtCustomer.TabIndex = 3;
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(460, 200);
            this.dataGridViewDetails.TabIndex = 4;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddDetail.Location = new System.Drawing.Point(50, 270);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(80, 30);
            this.btnAddDetail.TabIndex = 5;
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnRemoveDetail
            // 
            this.btnRemoveDetail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveDetail.Location = new System.Drawing.Point(150, 270);
            this.btnRemoveDetail.Name = "btnRemoveDetail";
            this.btnRemoveDetail.Size = new System.Drawing.Size(80, 30);
            this.btnRemoveDetail.TabIndex = 6;
            this.btnRemoveDetail.Text = "删除明细";
            this.btnRemoveDetail.UseVisualStyleBackColor = true;
            this.btnRemoveDetail.Click += new System.EventHandler(this.btnRemoveDetail_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(260, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "保存订单";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(360, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderEditForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemoveDetail);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.dataGridViewDetails);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.labelOrderId);
            this.Name = "OrderEditForm";
            this.Text = "订单编辑";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnRemoveDetail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
