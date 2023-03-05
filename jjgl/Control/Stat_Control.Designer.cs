namespace 基金管理
{
    partial class Stat_Control 
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_证券交易查询 = new System.Windows.Forms.Button();
            this.btn_证券持仓查询 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_产品名称 = new System.Windows.Forms.ComboBox();
            this.btn_项目资产查询 = new System.Windows.Forms.Button();
            this.btn_导出记录 = new System.Windows.Forms.Button();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1550, 646);
            this.dataGridView1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_证券交易查询);
            this.panel1.Controls.Add(this.btn_证券持仓查询);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_产品名称);
            this.panel1.Controls.Add(this.btn_项目资产查询);
            this.panel1.Controls.Add(this.btn_导出记录);
            this.panel1.Controls.Add(this.endTimePicker);
            this.panel1.Controls.Add(this.startTimePicker);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1550, 88);
            this.panel1.TabIndex = 0;
            // 
            // btn_证券交易查询
            // 
            this.btn_证券交易查询.Location = new System.Drawing.Point(1126, 17);
            this.btn_证券交易查询.Margin = new System.Windows.Forms.Padding(4);
            this.btn_证券交易查询.Name = "btn_证券交易查询";
            this.btn_证券交易查询.Size = new System.Drawing.Size(128, 45);
            this.btn_证券交易查询.TabIndex = 55;
            this.btn_证券交易查询.Text = "证券交易查询";
            this.btn_证券交易查询.UseVisualStyleBackColor = true;
            this.btn_证券交易查询.Click += new System.EventHandler(this.btn_证券交易查询_Click);
            // 
            // btn_证券持仓查询
            // 
            this.btn_证券持仓查询.Location = new System.Drawing.Point(987, 17);
            this.btn_证券持仓查询.Margin = new System.Windows.Forms.Padding(4);
            this.btn_证券持仓查询.Name = "btn_证券持仓查询";
            this.btn_证券持仓查询.Size = new System.Drawing.Size(128, 45);
            this.btn_证券持仓查询.TabIndex = 54;
            this.btn_证券持仓查询.Text = "证券持仓查询";
            this.btn_证券持仓查询.UseVisualStyleBackColor = true;
            this.btn_证券持仓查询.Click += new System.EventHandler(this.btn_证券持仓查询_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(604, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "基金产品";
            // 
            // comboBox_产品名称
            // 
            this.comboBox_产品名称.FormattingEnabled = true;
            this.comboBox_产品名称.Location = new System.Drawing.Point(694, 27);
            this.comboBox_产品名称.Name = "comboBox_产品名称";
            this.comboBox_产品名称.Size = new System.Drawing.Size(144, 26);
            this.comboBox_产品名称.TabIndex = 52;
            // 
            // btn_项目资产查询
            // 
            this.btn_项目资产查询.Location = new System.Drawing.Point(849, 17);
            this.btn_项目资产查询.Margin = new System.Windows.Forms.Padding(4);
            this.btn_项目资产查询.Name = "btn_项目资产查询";
            this.btn_项目资产查询.Size = new System.Drawing.Size(128, 45);
            this.btn_项目资产查询.TabIndex = 51;
            this.btn_项目资产查询.Text = "项目资产查询";
            this.btn_项目资产查询.UseVisualStyleBackColor = true;
            this.btn_项目资产查询.Click += new System.EventHandler(this.btn_项目资产查询_Click);
            // 
            // btn_导出记录
            // 
            this.btn_导出记录.Location = new System.Drawing.Point(1260, 17);
            this.btn_导出记录.Margin = new System.Windows.Forms.Padding(4);
            this.btn_导出记录.Name = "btn_导出记录";
            this.btn_导出记录.Size = new System.Drawing.Size(99, 45);
            this.btn_导出记录.TabIndex = 50;
            this.btn_导出记录.Text = "导出记录";
            this.btn_导出记录.UseVisualStyleBackColor = true;
            this.btn_导出记录.Click += new System.EventHandler(this.btn_导出记录_Click);
            // 
            // endTimePicker
            // 
            this.endTimePicker.Location = new System.Drawing.Point(404, 24);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(194, 28);
            this.endTimePicker.TabIndex = 49;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(108, 26);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(188, 28);
            this.startTimePicker.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "结束时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 40;
            this.label6.Text = "起始时间";
            // 
            // Stat_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Stat_Control";
            this.Size = new System.Drawing.Size(1550, 734);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Button btn_导出记录;
        private System.Windows.Forms.Button btn_项目资产查询;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_产品名称;
        private System.Windows.Forms.Button btn_证券交易查询;
        private System.Windows.Forms.Button btn_证券持仓查询;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label5;
    }
}
