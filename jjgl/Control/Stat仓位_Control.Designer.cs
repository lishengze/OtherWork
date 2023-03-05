using System.Windows.Forms;
namespace 基金管理
{
    partial class Stat仓位_Control 
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
            this.btn_持仓统计 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_导出记录 = new System.Windows.Forms.Button();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comCheckBoxList1 = new 基金管理.ComCheckBoxList();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comCheckBoxList1);
            this.panel1.Controls.Add(this.btn_持仓统计);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_导出记录);
            this.panel1.Controls.Add(this.startTimePicker);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 88);
            this.panel1.TabIndex = 0;
            // 
            // btn_持仓统计
            // 
            this.btn_持仓统计.Location = new System.Drawing.Point(753, 19);
            this.btn_持仓统计.Margin = new System.Windows.Forms.Padding(4);
            this.btn_持仓统计.Name = "btn_持仓统计";
            this.btn_持仓统计.Size = new System.Drawing.Size(146, 45);
            this.btn_持仓统计.TabIndex = 54;
            this.btn_持仓统计.Text = "持仓统计";
            this.btn_持仓统计.UseVisualStyleBackColor = true;
            this.btn_持仓统计.Click += new System.EventHandler(this.btn_持仓统计_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "基金产品";
            // 
            // btn_导出记录
            // 
            this.btn_导出记录.Location = new System.Drawing.Point(981, 19);
            this.btn_导出记录.Margin = new System.Windows.Forms.Padding(4);
            this.btn_导出记录.Name = "btn_导出记录";
            this.btn_导出记录.Size = new System.Drawing.Size(146, 45);
            this.btn_导出记录.TabIndex = 50;
            this.btn_导出记录.Text = "导出记录";
            this.btn_导出记录.UseVisualStyleBackColor = true;
            this.btn_导出记录.Click += new System.EventHandler(this.btn_导出记录_Click);
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(108, 26);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(188, 28);
            this.startTimePicker.TabIndex = 48;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 455);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1194, 455);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // comCheckBoxList1
            // 
            this.comCheckBoxList1.DataSource = null;
            this.comCheckBoxList1.Location = new System.Drawing.Point(435, 32);
            this.comCheckBoxList1.Name = "comCheckBoxList1";
            this.comCheckBoxList1.Size = new System.Drawing.Size(183, 27);
            this.comCheckBoxList1.TabIndex = 56;
            // 
            // Stat仓位_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Stat仓位_Control";
            this.Size = new System.Drawing.Size(1194, 543);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Button btn_导出记录;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_持仓统计;
        private  ComCheckBoxList comCheckBoxList1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
