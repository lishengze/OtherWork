namespace 基金管理
{
    partial class HistoryExchange_SubPanel 
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
            this.txt_股票总市值 = new System.Windows.Forms.TextBox();
            this.btn_保存修改 = new System.Windows.Forms.Button();
            this.txt_基准日净值 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_基金份额 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_回撤率 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_今年最大净值 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_单位净值 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_今年收益率 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_资金资产比例 = new System.Windows.Forms.TextBox();
            this.txt_资金余额 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_资产总额 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 126);
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
            this.dataGridView1.Size = new System.Drawing.Size(1493, 608);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_股票总市值);
            this.panel1.Controls.Add(this.btn_保存修改);
            this.panel1.Controls.Add(this.txt_基准日净值);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_基金份额);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_回撤率);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_今年最大净值);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_单位净值);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_今年收益率);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_资金资产比例);
            this.panel1.Controls.Add(this.txt_资金余额);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_资产总额);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1493, 126);
            this.panel1.TabIndex = 0;
            // 
            // txt_股票总市值
            // 
            this.txt_股票总市值.BackColor = System.Drawing.SystemColors.Window;
            this.txt_股票总市值.Enabled = false;
            this.txt_股票总市值.Location = new System.Drawing.Point(376, 21);
            this.txt_股票总市值.Name = "txt_股票总市值";
            this.txt_股票总市值.Size = new System.Drawing.Size(135, 28);
            this.txt_股票总市值.TabIndex = 59;
            // 
            // btn_保存修改
            // 
            this.btn_保存修改.Location = new System.Drawing.Point(1247, 31);
            this.btn_保存修改.Margin = new System.Windows.Forms.Padding(4);
            this.btn_保存修改.Name = "btn_保存修改";
            this.btn_保存修改.Size = new System.Drawing.Size(250, 69);
            this.btn_保存修改.TabIndex = 58;
            this.btn_保存修改.Text = "保存修改";
            this.btn_保存修改.UseVisualStyleBackColor = true;
            this.btn_保存修改.Click += new System.EventHandler(this.btn_保存修改_Click);
            // 
            // txt_基准日净值
            // 
            this.txt_基准日净值.BackColor = System.Drawing.SystemColors.Window;
            this.txt_基准日净值.Enabled = false;
            this.txt_基准日净值.Location = new System.Drawing.Point(114, 75);
            this.txt_基准日净值.Name = "txt_基准日净值";
            this.txt_基准日净值.Size = new System.Drawing.Size(140, 28);
            this.txt_基准日净值.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(539, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 56;
            this.label8.Text = "资产总额";
            // 
            // txt_基金份额
            // 
            this.txt_基金份额.BackColor = System.Drawing.SystemColors.Window;
            this.txt_基金份额.Enabled = false;
            this.txt_基金份额.Location = new System.Drawing.Point(1105, 17);
            this.txt_基金份额.Name = "txt_基金份额";
            this.txt_基金份额.Size = new System.Drawing.Size(135, 28);
            this.txt_基金份额.TabIndex = 55;
            this.txt_基金份额.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(760, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 18);
            this.label9.TabIndex = 54;
            this.label9.Text = "资金/资产比例";
            // 
            // txt_回撤率
            // 
            this.txt_回撤率.BackColor = System.Drawing.SystemColors.Window;
            this.txt_回撤率.Enabled = false;
            this.txt_回撤率.Location = new System.Drawing.Point(1101, 74);
            this.txt_回撤率.Name = "txt_回撤率";
            this.txt_回撤率.Size = new System.Drawing.Size(131, 28);
            this.txt_回撤率.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1035, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "回撤率";
            // 
            // txt_今年最大净值
            // 
            this.txt_今年最大净值.BackColor = System.Drawing.SystemColors.Window;
            this.txt_今年最大净值.Enabled = false;
            this.txt_今年最大净值.Location = new System.Drawing.Point(626, 75);
            this.txt_今年最大净值.Name = "txt_今年最大净值";
            this.txt_今年最大净值.Size = new System.Drawing.Size(135, 28);
            this.txt_今年最大净值.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 50;
            this.label7.Text = "股票总市值";
            // 
            // txt_单位净值
            // 
            this.txt_单位净值.BackColor = System.Drawing.SystemColors.Window;
            this.txt_单位净值.Enabled = false;
            this.txt_单位净值.Location = new System.Drawing.Point(373, 75);
            this.txt_单位净值.Name = "txt_单位净值";
            this.txt_单位净值.Size = new System.Drawing.Size(133, 28);
            this.txt_单位净值.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "单位净值";
            // 
            // txt_今年收益率
            // 
            this.txt_今年收益率.BackColor = System.Drawing.SystemColors.Window;
            this.txt_今年收益率.Enabled = false;
            this.txt_今年收益率.Location = new System.Drawing.Point(890, 75);
            this.txt_今年收益率.Name = "txt_今年收益率";
            this.txt_今年收益率.Size = new System.Drawing.Size(133, 28);
            this.txt_今年收益率.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(781, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 46;
            this.label2.Text = "今年收益率";
            // 
            // txt_资金资产比例
            // 
            this.txt_资金资产比例.Enabled = false;
            this.txt_资金资产比例.Location = new System.Drawing.Point(891, 23);
            this.txt_资金资产比例.Name = "txt_资金资产比例";
            this.txt_资金资产比例.Size = new System.Drawing.Size(131, 28);
            this.txt_资金资产比例.TabIndex = 45;
            // 
            // txt_资金余额
            // 
            this.txt_资金余额.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_资金余额.Location = new System.Drawing.Point(114, 21);
            this.txt_资金余额.Name = "txt_资金余额";
            this.txt_资金余额.Size = new System.Drawing.Size(140, 28);
            this.txt_资金余额.TabIndex = 43;
            this.txt_资金余额.TextChanged += new System.EventHandler(this.txt_资金余额_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "资金余额";
            // 
            // txt_资产总额
            // 
            this.txt_资产总额.Enabled = false;
            this.txt_资产总额.Location = new System.Drawing.Point(625, 23);
            this.txt_资产总额.Name = "txt_资产总额";
            this.txt_资产总额.Size = new System.Drawing.Size(133, 28);
            this.txt_资产总额.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 40;
            this.label6.Text = "基准日净值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "今年最大净值";
            // 
            // HistoryExchange_SubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryExchange_SubPanel";
            this.Size = new System.Drawing.Size(1493, 734);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_单位净值;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_今年收益率;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_资金资产比例;
        private System.Windows.Forms.TextBox txt_资金余额;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_资产总额;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_回撤率;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_今年最大净值;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_保存修改;
        private System.Windows.Forms.TextBox txt_基准日净值;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_基金份额;
        private System.Windows.Forms.TextBox txt_股票总市值;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
    }
}
