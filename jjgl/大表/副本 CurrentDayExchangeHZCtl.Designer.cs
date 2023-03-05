namespace 基金管理
{
    partial class HistoryExchangeCtl 
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_生成当日投资统计汇总 = new System.Windows.Forms.Button();
            this.btn_导入历史投资统计汇总总表格 = new System.Windows.Forms.Button();
            this.btn_导出当日投资统计汇总总表格 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_生成当日投资统计汇总);
            this.panel1.Controls.Add(this.btn_导入历史投资统计汇总总表格);
            this.panel1.Controls.Add(this.btn_导出当日投资统计汇总总表格);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 49);
            this.panel1.TabIndex = 0; 
            // 
            // btn_生成当日投资统计汇总
            // 
            this.btn_生成当日投资统计汇总.Location = new System.Drawing.Point(270, 14);
            this.btn_生成当日投资统计汇总.Name = "btn_生成当日投资统计汇总";
            this.btn_生成当日投资统计汇总.Size = new System.Drawing.Size(213, 23);
            this.btn_生成当日投资统计汇总.TabIndex = 54;
            this.btn_生成当日投资统计汇总.Text = "生成当日投资统计汇总";
            this.btn_生成当日投资统计汇总.UseVisualStyleBackColor = true;
            this.btn_生成当日投资统计汇总.Click += new System.EventHandler(this.btn_生成当日投资统计汇总_Click);
            // 
            // btn_导入历史投资统计汇总总表格
            // 
            this.btn_导入历史投资统计汇总总表格.Location = new System.Drawing.Point(732, 13);
            this.btn_导入历史投资统计汇总总表格.Name = "btn_导入历史投资统计汇总总表格";
            this.btn_导入历史投资统计汇总总表格.Size = new System.Drawing.Size(213, 23);
            this.btn_导入历史投资统计汇总总表格.TabIndex = 53;
            this.btn_导入历史投资统计汇总总表格.Text = "导入历史投资统计汇总";
            this.btn_导入历史投资统计汇总总表格.UseVisualStyleBackColor = true;
            this.btn_导入历史投资统计汇总总表格.Click += new System.EventHandler(this.btn_导入历史投资统计汇总总表格_Click);
            // 
            // btn_导出当日投资统计汇总总表格
            // 
            this.btn_导出当日投资统计汇总总表格.Location = new System.Drawing.Point(503, 13);
            this.btn_导出当日投资统计汇总总表格.Name = "btn_导出当日投资统计汇总总表格";
            this.btn_导出当日投资统计汇总总表格.Size = new System.Drawing.Size(213, 23);
            this.btn_导出当日投资统计汇总总表格.TabIndex = 52;
            this.btn_导出当日投资统计汇总总表格.Text = "导出当日投资统计汇总";
            this.btn_导出当日投资统计汇总总表格.UseVisualStyleBackColor = true;
            this.btn_导出当日投资统计汇总总表格.Click += new System.EventHandler(this.btn_导出当日投资统计汇总总表格_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "当前日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(91, 16);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 21);
            this.dateTimePicker1.TabIndex = 50;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 440);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 440);
            this.tabControl1.TabIndex = 0;
            // 
            // HistoryExchangeCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HistoryExchangeCtl";
            this.Size = new System.Drawing.Size(982, 489);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1; 
        private System.Windows.Forms.Button btn_导出当日投资统计汇总总表格;
        private System.Windows.Forms.Button btn_导入历史投资统计汇总总表格;
        private System.Windows.Forms.Button btn_生成当日投资统计汇总;
    }
}
