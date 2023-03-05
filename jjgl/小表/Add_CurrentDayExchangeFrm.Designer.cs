namespace 基金管理
{
    partial class Add_CurrentDayExchangeFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_列出全部基金经理 = new System.Windows.Forms.Button();
            this.btn_列出全部产品 = new System.Windows.Forms.Button();
            this.btn_关闭 = new System.Windows.Forms.Button();
            this.txt_买入均价 = new System.Windows.Forms.TextBox();
            this.txt_股票名称 = new System.Windows.Forms.TextBox();
            this.txt_股票代码 = new System.Windows.Forms.TextBox();
            this.btn_增加记录 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_基金经理 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_产品名称 = new System.Windows.Forms.ComboBox();
            this.txt_卖出均价 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_查看当日交易 = new System.Windows.Forms.Button();
            this.txt_买入股数 = new System.Windows.Forms.TextBox();
            this.txt_卖出股数 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_列出全部基金经理
            // 
            this.btn_列出全部基金经理.Location = new System.Drawing.Point(567, 77);
            this.btn_列出全部基金经理.Name = "btn_列出全部基金经理";
            this.btn_列出全部基金经理.Size = new System.Drawing.Size(70, 31);
            this.btn_列出全部基金经理.TabIndex = 1001;
            this.btn_列出全部基金经理.Text = "全部";
            this.btn_列出全部基金经理.UseVisualStyleBackColor = true;
            this.btn_列出全部基金经理.Click += new System.EventHandler(this.btn_列出全部基金经理_Click);
            // 
            // btn_列出全部产品
            // 
            this.btn_列出全部产品.Location = new System.Drawing.Point(244, 79);
            this.btn_列出全部产品.Name = "btn_列出全部产品";
            this.btn_列出全部产品.Size = new System.Drawing.Size(70, 31);
            this.btn_列出全部产品.TabIndex = 1000;
            this.btn_列出全部产品.Text = "全部";
            this.btn_列出全部产品.UseVisualStyleBackColor = true;
            this.btn_列出全部产品.Click += new System.EventHandler(this.btn_列出全部产品_Click);
            // 
            // btn_关闭
            // 
            this.btn_关闭.Location = new System.Drawing.Point(416, 353);
            this.btn_关闭.Name = "btn_关闭";
            this.btn_关闭.Size = new System.Drawing.Size(132, 41);
            this.btn_关闭.TabIndex = 22;
            this.btn_关闭.Text = "关  闭";
            this.btn_关闭.UseVisualStyleBackColor = true;
            this.btn_关闭.Click += new System.EventHandler(this.btn_关闭_Click);
            this.btn_关闭.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txt_买入均价
            // 
            this.txt_买入均价.Location = new System.Drawing.Point(422, 191);
            this.txt_买入均价.Margin = new System.Windows.Forms.Padding(4);
            this.txt_买入均价.Name = "txt_买入均价";
            this.txt_买入均价.Size = new System.Drawing.Size(215, 28);
            this.txt_买入均价.TabIndex = 17;
            this.txt_买入均价.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txt_股票名称
            // 
            this.txt_股票名称.Location = new System.Drawing.Point(422, 139);
            this.txt_股票名称.Margin = new System.Windows.Forms.Padding(4);
            this.txt_股票名称.Name = "txt_股票名称";
            this.txt_股票名称.ReadOnly = true;
            this.txt_股票名称.Size = new System.Drawing.Size(215, 28);
            this.txt_股票名称.TabIndex = 999;
            this.txt_股票名称.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txt_股票代码
            // 
            this.txt_股票代码.Location = new System.Drawing.Point(106, 137);
            this.txt_股票代码.Margin = new System.Windows.Forms.Padding(4);
            this.txt_股票代码.Name = "txt_股票代码";
            this.txt_股票代码.Size = new System.Drawing.Size(203, 28);
            this.txt_股票代码.TabIndex = 15;
            this.txt_股票代码.TextChanged += new System.EventHandler(this.txt_股票代码_TextChanged);
            this.txt_股票代码.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // btn_增加记录
            // 
            this.btn_增加记录.Location = new System.Drawing.Point(90, 353);
            this.btn_增加记录.Name = "btn_增加记录";
            this.btn_增加记录.Size = new System.Drawing.Size(136, 41);
            this.btn_增加记录.TabIndex = 20;
            this.btn_增加记录.Text = "增加记录";
            this.btn_增加记录.UseVisualStyleBackColor = true;
            this.btn_增加记录.Click += new System.EventHandler(this.btn_增加记录_Click);
            this.btn_增加记录.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "买入股数";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 34;
            this.label9.Text = "买入均价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "股票代码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "股票名称";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(106, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(293, 28);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "当前日期";
            // 
            // comboBox_基金经理
            // 
            this.comboBox_基金经理.FormattingEnabled = true;
            this.comboBox_基金经理.Location = new System.Drawing.Point(422, 80);
            this.comboBox_基金经理.Name = "comboBox_基金经理";
            this.comboBox_基金经理.Size = new System.Drawing.Size(131, 26);
            this.comboBox_基金经理.TabIndex = 13;
            this.comboBox_基金经理.SelectedIndexChanged += new System.EventHandler(this.comboBox_基金经理_SelectedIndexChanged);
            this.comboBox_基金经理.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "基金经理";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "产品名称";
            // 
            // comboBox_产品名称
            // 
            this.comboBox_产品名称.FormattingEnabled = true;
            this.comboBox_产品名称.Location = new System.Drawing.Point(105, 80);
            this.comboBox_产品名称.Name = "comboBox_产品名称";
            this.comboBox_产品名称.Size = new System.Drawing.Size(134, 26);
            this.comboBox_产品名称.TabIndex = 12;
            this.comboBox_产品名称.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txt_卖出均价
            // 
            this.txt_卖出均价.Location = new System.Drawing.Point(422, 255);
            this.txt_卖出均价.Margin = new System.Windows.Forms.Padding(4);
            this.txt_卖出均价.Name = "txt_卖出均价";
            this.txt_卖出均价.Size = new System.Drawing.Size(215, 28);
            this.txt_卖出均价.TabIndex = 19;
            this.txt_卖出均价.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 1005;
            this.label5.Text = "卖出股数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 1004;
            this.label8.Text = "卖出均价";
            // 
            // btn_查看当日交易
            // 
            this.btn_查看当日交易.Location = new System.Drawing.Point(254, 353);
            this.btn_查看当日交易.Name = "btn_查看当日交易";
            this.btn_查看当日交易.Size = new System.Drawing.Size(136, 41);
            this.btn_查看当日交易.TabIndex = 21;
            this.btn_查看当日交易.Text = "查看当日交易";
            this.btn_查看当日交易.UseVisualStyleBackColor = true;
            this.btn_查看当日交易.Click += new System.EventHandler(this.btn_当日交易汇总查看_Click);
            // 
            // txt_买入股数
            // 
            this.txt_买入股数.Location = new System.Drawing.Point(106, 199);
            this.txt_买入股数.Margin = new System.Windows.Forms.Padding(4);
            this.txt_买入股数.Name = "txt_买入股数";
            this.txt_买入股数.Size = new System.Drawing.Size(203, 28);
            this.txt_买入股数.TabIndex = 16;
            this.txt_买入股数.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txt_卖出股数
            // 
            this.txt_卖出股数.Location = new System.Drawing.Point(105, 255);
            this.txt_卖出股数.Margin = new System.Windows.Forms.Padding(4);
            this.txt_卖出股数.Name = "txt_卖出股数";
            this.txt_卖出股数.Size = new System.Drawing.Size(203, 28);
            this.txt_卖出股数.TabIndex = 18;
            this.txt_卖出股数.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(19, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 18);
            this.label10.TabIndex = 1006;
            this.label10.Text = "是否为止损指令";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(168, 307);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 21);
            this.checkBox1.TabIndex = 1007;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Add_CurrentDayExchangeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 420);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_卖出股数);
            this.Controls.Add(this.txt_买入股数);
            this.Controls.Add(this.btn_查看当日交易);
            this.Controls.Add(this.txt_卖出均价);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_列出全部基金经理);
            this.Controls.Add(this.btn_列出全部产品);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox_产品名称);
            this.Controls.Add(this.btn_关闭);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_买入均价);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_基金经理);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_股票名称);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_股票代码);
            this.Controls.Add(this.btn_增加记录);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_CurrentDayExchangeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加当日交易记录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_基金经理;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_产品名称;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_增加记录;
        private System.Windows.Forms.TextBox txt_股票代码;
        private System.Windows.Forms.TextBox txt_股票名称;
        private System.Windows.Forms.TextBox txt_买入均价;
        private System.Windows.Forms.Button btn_关闭;
        private System.Windows.Forms.Button btn_列出全部基金经理;
        private System.Windows.Forms.Button btn_列出全部产品;
        private System.Windows.Forms.TextBox txt_卖出均价;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_查看当日交易;
        private System.Windows.Forms.TextBox txt_买入股数;
        private System.Windows.Forms.TextBox txt_卖出股数;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

