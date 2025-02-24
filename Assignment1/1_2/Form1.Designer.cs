namespace WinProg_2_20
{
    partial class Form1
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

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.operatorResult = new System.Windows.Forms.Button();
            this.operatorBack = new System.Windows.Forms.Button();
            this.operatorClear = new System.Windows.Forms.Button();
            this.Num3 = new System.Windows.Forms.Button();
            this.Num2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Num1 = new System.Windows.Forms.Button();
            this.Num4 = new System.Windows.Forms.Button();
            this.Num5 = new System.Windows.Forms.Button();
            this.Num6 = new System.Windows.Forms.Button();
            this.Num7 = new System.Windows.Forms.Button();
            this.Num8 = new System.Windows.Forms.Button();
            this.Num9 = new System.Windows.Forms.Button();
            this.operatorAdd = new System.Windows.Forms.Button();
            this.operatorSub = new System.Windows.Forms.Button();
            this.operatorMult = new System.Windows.Forms.Button();
            this.operatorDiv = new System.Windows.Forms.Button();
            this.Num0 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.operatorResult, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.operatorBack, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.operatorClear, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Num3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Num2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Num1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Num4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Num5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Num6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Num7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Num8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Num9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.operatorAdd, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.operatorSub, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.operatorMult, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.operatorDiv, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Num0, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // operatorResult
            // 
            this.operatorResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorResult.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorResult.Location = new System.Drawing.Point(651, 213);
            this.operatorResult.Name = "operatorResult";
            this.operatorResult.Size = new System.Drawing.Size(210, 99);
            this.operatorResult.TabIndex = 21;
            this.operatorResult.Text = "=";
            this.operatorResult.UseVisualStyleBackColor = true;
            this.operatorResult.Click += new System.EventHandler(this.operatorResult_Click);
            // 
            // operatorBack
            // 
            this.operatorBack.BackColor = System.Drawing.Color.White;
            this.operatorBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorBack.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorBack.Location = new System.Drawing.Point(651, 108);
            this.operatorBack.Name = "operatorBack";
            this.operatorBack.Size = new System.Drawing.Size(210, 99);
            this.operatorBack.TabIndex = 20;
            this.operatorBack.Text = "Back";
            this.operatorBack.UseVisualStyleBackColor = false;
            this.operatorBack.Click += new System.EventHandler(this.operatorBack_Click);
            // 
            // operatorClear
            // 
            this.operatorClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorClear.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorClear.Location = new System.Drawing.Point(651, 3);
            this.operatorClear.Name = "operatorClear";
            this.operatorClear.Size = new System.Drawing.Size(210, 99);
            this.operatorClear.TabIndex = 19;
            this.operatorClear.Text = "C";
            this.operatorClear.UseVisualStyleBackColor = true;
            this.operatorClear.Click += new System.EventHandler(this.operatorClear_Click);
            // 
            // Num3
            // 
            this.Num3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num3.Location = new System.Drawing.Point(435, 108);
            this.Num3.Name = "Num3";
            this.Num3.Size = new System.Drawing.Size(210, 99);
            this.Num3.TabIndex = 3;
            this.Num3.Text = "3";
            this.Num3.UseVisualStyleBackColor = true;
            this.Num3.Click += new System.EventHandler(this.Num3_Click);
            // 
            // Num2
            // 
            this.Num2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num2.Location = new System.Drawing.Point(219, 108);
            this.Num2.Name = "Num2";
            this.Num2.Size = new System.Drawing.Size(210, 99);
            this.Num2.TabIndex = 2;
            this.Num2.Text = "2";
            this.Num2.UseVisualStyleBackColor = true;
            this.Num2.Click += new System.EventHandler(this.Num2_Click);
            // 
            // textBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(642, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Num1
            // 
            this.Num1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num1.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Num1.Location = new System.Drawing.Point(3, 108);
            this.Num1.Name = "Num1";
            this.Num1.Size = new System.Drawing.Size(210, 99);
            this.Num1.TabIndex = 1;
            this.Num1.Text = "1";
            this.Num1.UseVisualStyleBackColor = true;
            this.Num1.Click += new System.EventHandler(this.Num1_Click);
            // 
            // Num4
            // 
            this.Num4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num4.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num4.Location = new System.Drawing.Point(3, 213);
            this.Num4.Name = "Num4";
            this.Num4.Size = new System.Drawing.Size(210, 99);
            this.Num4.TabIndex = 4;
            this.Num4.Text = "4";
            this.Num4.UseVisualStyleBackColor = true;
            this.Num4.Click += new System.EventHandler(this.Num4_Click);
            // 
            // Num5
            // 
            this.Num5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num5.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num5.Location = new System.Drawing.Point(219, 213);
            this.Num5.Name = "Num5";
            this.Num5.Size = new System.Drawing.Size(210, 99);
            this.Num5.TabIndex = 5;
            this.Num5.Text = "5";
            this.Num5.UseVisualStyleBackColor = true;
            this.Num5.Click += new System.EventHandler(this.Num5_Click);
            // 
            // Num6
            // 
            this.Num6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num6.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num6.Location = new System.Drawing.Point(435, 213);
            this.Num6.Name = "Num6";
            this.Num6.Size = new System.Drawing.Size(210, 99);
            this.Num6.TabIndex = 6;
            this.Num6.Text = "6";
            this.Num6.UseVisualStyleBackColor = true;
            this.Num6.Click += new System.EventHandler(this.Num6_Click);
            // 
            // Num7
            // 
            this.Num7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num7.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num7.Location = new System.Drawing.Point(3, 318);
            this.Num7.Name = "Num7";
            this.Num7.Size = new System.Drawing.Size(210, 99);
            this.Num7.TabIndex = 7;
            this.Num7.Text = "7";
            this.Num7.UseVisualStyleBackColor = true;
            this.Num7.Click += new System.EventHandler(this.Num7_Click);
            // 
            // Num8
            // 
            this.Num8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num8.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num8.Location = new System.Drawing.Point(219, 318);
            this.Num8.Name = "Num8";
            this.Num8.Size = new System.Drawing.Size(210, 99);
            this.Num8.TabIndex = 8;
            this.Num8.Text = "8";
            this.Num8.UseVisualStyleBackColor = true;
            this.Num8.Click += new System.EventHandler(this.Num8_Click);
            // 
            // Num9
            // 
            this.Num9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num9.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num9.Location = new System.Drawing.Point(435, 318);
            this.Num9.Name = "Num9";
            this.Num9.Size = new System.Drawing.Size(210, 99);
            this.Num9.TabIndex = 9;
            this.Num9.Text = "9";
            this.Num9.UseVisualStyleBackColor = true;
            this.Num9.Click += new System.EventHandler(this.Num9_Click);
            // 
            // operatorAdd
            // 
            this.operatorAdd.BackColor = System.Drawing.Color.White;
            this.operatorAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorAdd.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.operatorAdd.Location = new System.Drawing.Point(3, 423);
            this.operatorAdd.Name = "operatorAdd";
            this.operatorAdd.Size = new System.Drawing.Size(210, 101);
            this.operatorAdd.TabIndex = 10;
            this.operatorAdd.Text = "+";
            this.operatorAdd.UseVisualStyleBackColor = false;
            this.operatorAdd.Click += new System.EventHandler(this.operatorAdd_Click);
            // 
            // operatorSub
            // 
            this.operatorSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorSub.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorSub.Location = new System.Drawing.Point(219, 423);
            this.operatorSub.Name = "operatorSub";
            this.operatorSub.Size = new System.Drawing.Size(210, 101);
            this.operatorSub.TabIndex = 11;
            this.operatorSub.Text = "-";
            this.operatorSub.UseVisualStyleBackColor = true;
            this.operatorSub.Click += new System.EventHandler(this.operatorSub_Click);
            // 
            // operatorMult
            // 
            this.operatorMult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorMult.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorMult.Location = new System.Drawing.Point(435, 423);
            this.operatorMult.Name = "operatorMult";
            this.operatorMult.Size = new System.Drawing.Size(210, 101);
            this.operatorMult.TabIndex = 12;
            this.operatorMult.Text = "×";
            this.operatorMult.UseVisualStyleBackColor = true;
            this.operatorMult.Click += new System.EventHandler(this.operatorMult_Click);
            // 
            // operatorDiv
            // 
            this.operatorDiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorDiv.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.operatorDiv.Location = new System.Drawing.Point(651, 423);
            this.operatorDiv.Name = "operatorDiv";
            this.operatorDiv.Size = new System.Drawing.Size(210, 101);
            this.operatorDiv.TabIndex = 13;
            this.operatorDiv.Text = "÷";
            this.operatorDiv.UseVisualStyleBackColor = true;
            this.operatorDiv.Click += new System.EventHandler(this.operatorDiv_Click);
            // 
            // Num0
            // 
            this.Num0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Num0.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Num0.Location = new System.Drawing.Point(651, 318);
            this.Num0.Name = "Num0";
            this.Num0.Size = new System.Drawing.Size(210, 99);
            this.Num0.TabIndex = 22;
            this.Num0.Text = "0";
            this.Num0.UseVisualStyleBackColor = true;
            this.Num0.Click += new System.EventHandler(this.Num0_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 527);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Num3;
        private System.Windows.Forms.Button Num1;
        private System.Windows.Forms.Button Num4;
        private System.Windows.Forms.Button Num5;
        private System.Windows.Forms.Button Num6;
        private System.Windows.Forms.Button Num7;
        private System.Windows.Forms.Button Num8;
        private System.Windows.Forms.Button Num9;
        private System.Windows.Forms.Button operatorAdd;
        private System.Windows.Forms.Button operatorSub;
        private System.Windows.Forms.Button operatorMult;
        private System.Windows.Forms.Button Num2;
        private System.Windows.Forms.Button operatorDiv;
        private System.Windows.Forms.Button operatorClear;
        private System.Windows.Forms.Button operatorResult;
        private System.Windows.Forms.Button operatorBack;
        private System.Windows.Forms.Button Num0;
    }
}

