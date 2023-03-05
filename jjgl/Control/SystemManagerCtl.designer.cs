namespace 基金管理
{
    partial class SystemManagerCtl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_汇率 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_重置汇率 = new System.Windows.Forms.Button();
            this.datetimer_汇率_时间 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_买入汇率 = new System.Windows.Forms.TextBox();
            this.btn_删除汇率 = new System.Windows.Forms.Button();
            this.btn_修改汇率 = new System.Windows.Forms.Button();
            this.btn_增加汇率 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_卖出汇率 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_用户 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_角色 = new System.Windows.Forms.ComboBox();
            this.btn_修改管理员密码 = new System.Windows.Forms.Button();
            this.btn_重置用户 = new System.Windows.Forms.Button();
            this.txt_用户姓名 = new System.Windows.Forms.TextBox();
            this.txt_用户密码 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_删除用户 = new System.Windows.Forms.Button();
            this.btn_修改用户 = new System.Windows.Forms.Button();
            this.btn_增加用户 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_用户名 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_汇率)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_用户)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1534, 696);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_汇率);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(770, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 690);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "汇率管理";
            // 
            // dataGridView_汇率
            // 
            this.dataGridView_汇率.AllowUserToAddRows = false;
            this.dataGridView_汇率.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_汇率.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_汇率.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_汇率.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_汇率.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_汇率.Location = new System.Drawing.Point(3, 195);
            this.dataGridView_汇率.Name = "dataGridView_汇率";
            this.dataGridView_汇率.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_汇率.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_汇率.RowTemplate.Height = 30;
            this.dataGridView_汇率.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_汇率.Size = new System.Drawing.Size(755, 492);
            this.dataGridView_汇率.TabIndex = 17;
            this.dataGridView_汇率.SelectionChanged += new System.EventHandler(this.dataGridView_汇率_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_重置汇率);
            this.panel1.Controls.Add(this.datetimer_汇率_时间);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_买入汇率);
            this.panel1.Controls.Add(this.btn_删除汇率);
            this.panel1.Controls.Add(this.btn_修改汇率);
            this.panel1.Controls.Add(this.btn_增加汇率);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_卖出汇率);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 171);
            this.panel1.TabIndex = 16;
            // 
            // btn_重置汇率
            // 
            this.btn_重置汇率.Location = new System.Drawing.Point(534, 114);
            this.btn_重置汇率.Name = "btn_重置汇率";
            this.btn_重置汇率.Size = new System.Drawing.Size(118, 34);
            this.btn_重置汇率.TabIndex = 51;
            this.btn_重置汇率.Text = "重  置";
            this.btn_重置汇率.UseVisualStyleBackColor = true;
            this.btn_重置汇率.Click += new System.EventHandler(this.btn_重置汇率_Click);
            // 
            // datetimer_汇率_时间
            // 
            this.datetimer_汇率_时间.Location = new System.Drawing.Point(116, 26);
            this.datetimer_汇率_时间.Name = "datetimer_汇率_时间";
            this.datetimer_汇率_时间.Size = new System.Drawing.Size(230, 28);
            this.datetimer_汇率_时间.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 49;
            this.label6.Text = "时间";
            // 
            // txt_买入汇率
            // 
            this.txt_买入汇率.Location = new System.Drawing.Point(116, 72);
            this.txt_买入汇率.Name = "txt_买入汇率";
            this.txt_买入汇率.Size = new System.Drawing.Size(230, 28);
            this.txt_买入汇率.TabIndex = 33;
            // 
            // btn_删除汇率
            // 
            this.btn_删除汇率.Location = new System.Drawing.Point(399, 114);
            this.btn_删除汇率.Name = "btn_删除汇率";
            this.btn_删除汇率.Size = new System.Drawing.Size(118, 34);
            this.btn_删除汇率.TabIndex = 32;
            this.btn_删除汇率.Text = "删  除";
            this.btn_删除汇率.UseVisualStyleBackColor = true;
            this.btn_删除汇率.Click += new System.EventHandler(this.btn_删除汇率_Click);
            // 
            // btn_修改汇率
            // 
            this.btn_修改汇率.Location = new System.Drawing.Point(266, 114);
            this.btn_修改汇率.Name = "btn_修改汇率";
            this.btn_修改汇率.Size = new System.Drawing.Size(118, 34);
            this.btn_修改汇率.TabIndex = 31;
            this.btn_修改汇率.Text = "修  改";
            this.btn_修改汇率.UseVisualStyleBackColor = true;
            this.btn_修改汇率.Click += new System.EventHandler(this.btn_修改汇率_Click);
            // 
            // btn_增加汇率
            // 
            this.btn_增加汇率.Location = new System.Drawing.Point(119, 114);
            this.btn_增加汇率.Name = "btn_增加汇率";
            this.btn_增加汇率.Size = new System.Drawing.Size(118, 34);
            this.btn_增加汇率.TabIndex = 30;
            this.btn_增加汇率.Text = "增  加";
            this.btn_增加汇率.UseVisualStyleBackColor = true;
            this.btn_增加汇率.Click += new System.EventHandler(this.btn_增加汇率_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "买入汇率";
            // 
            // txt_卖出汇率
            // 
            this.txt_卖出汇率.Location = new System.Drawing.Point(459, 69);
            this.txt_卖出汇率.Name = "txt_卖出汇率";
            this.txt_卖出汇率.Size = new System.Drawing.Size(230, 28);
            this.txt_卖出汇率.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "卖出汇率";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_用户);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(761, 690);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户管理";
            // 
            // dataGridView_用户
            // 
            this.dataGridView_用户.AllowUserToAddRows = false;
            this.dataGridView_用户.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_用户.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_用户.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_用户.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_用户.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_用户.Location = new System.Drawing.Point(3, 195);
            this.dataGridView_用户.Name = "dataGridView_用户";
            this.dataGridView_用户.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_用户.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_用户.RowTemplate.Height = 30;
            this.dataGridView_用户.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_用户.Size = new System.Drawing.Size(755, 492);
            this.dataGridView_用户.TabIndex = 17;
            this.dataGridView_用户.SelectionChanged += new System.EventHandler(this.dataGridView_用户_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmb_角色);
            this.panel2.Controls.Add(this.btn_修改管理员密码);
            this.panel2.Controls.Add(this.btn_重置用户);
            this.panel2.Controls.Add(this.txt_用户姓名);
            this.panel2.Controls.Add(this.txt_用户密码);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btn_删除用户);
            this.panel2.Controls.Add(this.btn_修改用户);
            this.panel2.Controls.Add(this.btn_增加用户);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_用户名);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 171);
            this.panel2.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "用户角色";
            // 
            // cmb_角色
            // 
            this.cmb_角色.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_角色.FormattingEnabled = true;
            this.cmb_角色.Items.AddRange(new object[] {
            "管理员",
            "普通用户",
            "市场部用户"});
            this.cmb_角色.Location = new System.Drawing.Point(436, 70);
            this.cmb_角色.Name = "cmb_角色";
            this.cmb_角色.Size = new System.Drawing.Size(196, 26);
            this.cmb_角色.TabIndex = 38;
            // 
            // btn_修改管理员密码
            // 
            this.btn_修改管理员密码.Location = new System.Drawing.Point(556, 114);
            this.btn_修改管理员密码.Name = "btn_修改管理员密码";
            this.btn_修改管理员密码.Size = new System.Drawing.Size(181, 34);
            this.btn_修改管理员密码.TabIndex = 37;
            this.btn_修改管理员密码.Text = "修改超级管理员密码";
            this.btn_修改管理员密码.UseVisualStyleBackColor = true;
            this.btn_修改管理员密码.Click += new System.EventHandler(this.btn_修改管理员密码_Click);
            // 
            // btn_重置用户
            // 
            this.btn_重置用户.Location = new System.Drawing.Point(425, 114);
            this.btn_重置用户.Name = "btn_重置用户";
            this.btn_重置用户.Size = new System.Drawing.Size(118, 34);
            this.btn_重置用户.TabIndex = 36;
            this.btn_重置用户.Text = "重  置";
            this.btn_重置用户.UseVisualStyleBackColor = true;
            this.btn_重置用户.Click += new System.EventHandler(this.btn_重置用户_Click);
            // 
            // txt_用户姓名
            // 
            this.txt_用户姓名.Location = new System.Drawing.Point(115, 69);
            this.txt_用户姓名.Name = "txt_用户姓名";
            this.txt_用户姓名.Size = new System.Drawing.Size(196, 28);
            this.txt_用户姓名.TabIndex = 35;
            // 
            // txt_用户密码
            // 
            this.txt_用户密码.Location = new System.Drawing.Point(436, 21);
            this.txt_用户密码.Name = "txt_用户密码";
            this.txt_用户密码.PasswordChar = '*';
            this.txt_用户密码.Size = new System.Drawing.Size(196, 28);
            this.txt_用户密码.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "用户密码";
            // 
            // btn_删除用户
            // 
            this.btn_删除用户.Location = new System.Drawing.Point(287, 114);
            this.btn_删除用户.Name = "btn_删除用户";
            this.btn_删除用户.Size = new System.Drawing.Size(118, 34);
            this.btn_删除用户.TabIndex = 32;
            this.btn_删除用户.Text = "删  除";
            this.btn_删除用户.UseVisualStyleBackColor = true;
            this.btn_删除用户.Click += new System.EventHandler(this.btn_删除用户_Click);
            // 
            // btn_修改用户
            // 
            this.btn_修改用户.Location = new System.Drawing.Point(150, 114);
            this.btn_修改用户.Name = "btn_修改用户";
            this.btn_修改用户.Size = new System.Drawing.Size(118, 34);
            this.btn_修改用户.TabIndex = 31;
            this.btn_修改用户.Text = "修  改";
            this.btn_修改用户.UseVisualStyleBackColor = true;
            this.btn_修改用户.Click += new System.EventHandler(this.btn_修改用户_Click);
            // 
            // btn_增加用户
            // 
            this.btn_增加用户.Location = new System.Drawing.Point(15, 114);
            this.btn_增加用户.Name = "btn_增加用户";
            this.btn_增加用户.Size = new System.Drawing.Size(118, 34);
            this.btn_增加用户.TabIndex = 30;
            this.btn_增加用户.Text = "增  加";
            this.btn_增加用户.UseVisualStyleBackColor = true;
            this.btn_增加用户.Click += new System.EventHandler(this.btn_增加用户_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "用户姓名";
            // 
            // txt_用户名
            // 
            this.txt_用户名.Location = new System.Drawing.Point(116, 21);
            this.txt_用户名.Name = "txt_用户名";
            this.txt_用户名.Size = new System.Drawing.Size(196, 28);
            this.txt_用户名.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "用户名";
            // 
            // SystemManagerCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SystemManagerCtl";
            this.Size = new System.Drawing.Size(1534, 696);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_汇率)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_用户)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_用户;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_用户名;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_修改用户;
        private System.Windows.Forms.Button btn_增加用户;
        private System.Windows.Forms.Button btn_删除用户;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_汇率;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_删除汇率;
        private System.Windows.Forms.Button btn_修改汇率;
        private System.Windows.Forms.Button btn_增加汇率;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_卖出汇率;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_用户密码;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_用户姓名;
        private System.Windows.Forms.TextBox txt_买入汇率;
        private System.Windows.Forms.DateTimePicker datetimer_汇率_时间;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_重置用户;
        private System.Windows.Forms.Button btn_重置汇率;
        private System.Windows.Forms.Button btn_修改管理员密码;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_角色;
    }
}
