namespace 基金管理
{
    partial class CurrentDayExchangeListCtl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_基金经理 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_导出当日记录 = new System.Windows.Forms.Button();
            this.btn_导入历史记录 = new System.Windows.Forms.Button();
            this.comboBox_产品名称 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_修改 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_删除 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_管理未成功导入数据 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_管理未成功导入数据);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox_基金经理);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_导出当日记录);
            this.panel1.Controls.Add(this.btn_导入历史记录);
            this.panel1.Controls.Add(this.comboBox_产品名称);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1690, 98);
            this.panel1.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(768, 31);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(136, 36);
            this.btn_Search.TabIndex = 28;
            this.btn_Search.Text = "查  询 ";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "基金经理";
            // 
            // comboBox_基金经理
            // 
            this.comboBox_基金经理.FormattingEnabled = true;
            this.comboBox_基金经理.Location = new System.Drawing.Point(605, 34);
            this.comboBox_基金经理.Name = "comboBox_基金经理";
            this.comboBox_基金经理.Size = new System.Drawing.Size(149, 26);
            this.comboBox_基金经理.TabIndex = 26;
            this.comboBox_基金经理.SelectedIndexChanged += new System.EventHandler(this.comboBox_基金经理_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 28);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "当前日期";
            // 
            // btn_导出当日记录
            // 
            this.btn_导出当日记录.Location = new System.Drawing.Point(923, 33);
            this.btn_导出当日记录.Name = "btn_导出当日记录";
            this.btn_导出当日记录.Size = new System.Drawing.Size(136, 36);
            this.btn_导出当日记录.TabIndex = 22;
            this.btn_导出当日记录.Text = "导出历史记录";
            this.btn_导出当日记录.UseVisualStyleBackColor = true;
            this.btn_导出当日记录.Click += new System.EventHandler(this.btn_导出当日记录_Click);
            // 
            // btn_导入历史记录
            // 
            this.btn_导入历史记录.Location = new System.Drawing.Point(1074, 32);
            this.btn_导入历史记录.Name = "btn_导入历史记录";
            this.btn_导入历史记录.Size = new System.Drawing.Size(136, 36);
            this.btn_导入历史记录.TabIndex = 21;
            this.btn_导入历史记录.Text = "导入历史记录";
            this.btn_导入历史记录.UseVisualStyleBackColor = true;
            this.btn_导入历史记录.Click += new System.EventHandler(this.btn_导入历史记录_Click);
            // 
            // comboBox_产品名称
            // 
            this.comboBox_产品名称.FormattingEnabled = true;
            this.comboBox_产品名称.Location = new System.Drawing.Point(364, 34);
            this.comboBox_产品名称.Name = "comboBox_产品名称";
            this.comboBox_产品名称.Size = new System.Drawing.Size(143, 26);
            this.comboBox_产品名称.TabIndex = 20;
            this.comboBox_产品名称.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "产品名称";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1690, 636);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1690, 636);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_修改,
            this.tsmi_删除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 60);
            // 
            // tsmi_修改
            // 
            this.tsmi_修改.Name = "tsmi_修改";
            this.tsmi_修改.Size = new System.Drawing.Size(116, 28);
            this.tsmi_修改.Text = "修改";
            this.tsmi_修改.Visible = false;
            // 
            // tsmi_删除
            // 
            this.tsmi_删除.Name = "tsmi_删除";
            this.tsmi_删除.Size = new System.Drawing.Size(116, 28);
            this.tsmi_删除.Text = "删除";
            this.tsmi_删除.Click += new System.EventHandler(this.tsmi_删除_Click);
            // 
            // btn_管理未成功导入数据
            // 
            this.btn_管理未成功导入数据.Location = new System.Drawing.Point(1223, 32);
            this.btn_管理未成功导入数据.Name = "btn_管理未成功导入数据";
            this.btn_管理未成功导入数据.Size = new System.Drawing.Size(184, 36);
            this.btn_管理未成功导入数据.TabIndex = 29;
            this.btn_管理未成功导入数据.Text = "管理未成功导入数据";
            this.btn_管理未成功导入数据.UseVisualStyleBackColor = true;
            this.btn_管理未成功导入数据.Click += new System.EventHandler(this.btn_管理未成功导入数据_Click);
            // 
            // CurrentDayExchangeListCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CurrentDayExchangeListCtl";
            this.Size = new System.Drawing.Size(1690, 734);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_产品名称;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_导入历史记录;
        private System.Windows.Forms.Button btn_导出当日记录;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_基金经理;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_修改;
        private System.Windows.Forms.ToolStripMenuItem tsmi_删除;
        private System.Windows.Forms.Button btn_管理未成功导入数据;
    }
}
