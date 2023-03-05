namespace 基金管理
{
    partial class Edit_ShuHui_Frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_ShuHui_Frm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.btn_确定 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_产品名称 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_份额 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_查看历史份额 = new System.Windows.Forms.Button();
            this.dataGridView_基金经理表 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsButton_删除基金份额历史 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_基金份额历史表 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButton_删除申购赎回调整数 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_申购赎回调整数历史表 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_赎回时间 = new System.Windows.Forms.DateTimePicker();
            this.tsButton_导入 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_基金经理表)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_基金份额历史表)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_申购赎回调整数历史表)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(297, 367);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(135, 48);
            this.btn_取消.TabIndex = 39;
            this.btn_取消.Text = "取  消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(130, 367);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(133, 48);
            this.btn_确定.TabIndex = 37;
            this.btn_确定.Text = "确  定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "基金经理";
            // 
            // txt_产品名称
            // 
            this.txt_产品名称.Location = new System.Drawing.Point(115, 24);
            this.txt_产品名称.Name = "txt_产品名称";
            this.txt_产品名称.Size = new System.Drawing.Size(317, 28);
            this.txt_产品名称.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "产品名称";
            // 
            // txt_份额
            // 
            this.txt_份额.Location = new System.Drawing.Point(115, 68);
            this.txt_份额.Name = "txt_份额";
            this.txt_份额.Size = new System.Drawing.Size(317, 28);
            this.txt_份额.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 43;
            this.label3.Text = "基金份额";
            // 
            // btn_查看历史份额
            // 
            this.btn_查看历史份额.Location = new System.Drawing.Point(180, 0);
            this.btn_查看历史份额.Name = "btn_查看历史份额";
            this.btn_查看历史份额.Size = new System.Drawing.Size(91, 38);
            this.btn_查看历史份额.TabIndex = 45;
            this.btn_查看历史份额.Text = "查看历史";
            this.btn_查看历史份额.UseVisualStyleBackColor = true;
            this.btn_查看历史份额.Visible = false;
            this.btn_查看历史份额.Click += new System.EventHandler(this.btn_查看历史份额_Click);
            // 
            // dataGridView_基金经理表
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_基金经理表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_基金经理表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_基金经理表.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView_基金经理表.Location = new System.Drawing.Point(115, 160);
            this.dataGridView_基金经理表.Name = "dataGridView_基金经理表";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_基金经理表.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView_基金经理表.RowHeadersWidth = 4;
            this.dataGridView_基金经理表.RowTemplate.Height = 30;
            this.dataGridView_基金经理表.Size = new System.Drawing.Size(317, 198);
            this.dataGridView_基金经理表.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Controls.Add(this.dataGridView_基金份额历史表);
            this.groupBox1.Controls.Add(this.btn_查看历史份额);
            this.groupBox1.Location = new System.Drawing.Point(455, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基金份额历史数据";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_删除基金份额历史});
            this.toolStrip2.Location = new System.Drawing.Point(3, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(259, 31);
            this.toolStrip2.TabIndex = 49;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsButton_删除基金份额历史
            // 
            this.tsButton_删除基金份额历史.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton_删除基金份额历史.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_删除基金份额历史.Image")));
            this.tsButton_删除基金份额历史.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_删除基金份额历史.Name = "tsButton_删除基金份额历史";
            this.tsButton_删除基金份额历史.Size = new System.Drawing.Size(50, 28);
            this.tsButton_删除基金份额历史.Text = "删除";
            this.tsButton_删除基金份额历史.Click += new System.EventHandler(this.tsButton_删除基金份额历史_Click);
            // 
            // dataGridView_基金份额历史表
            // 
            this.dataGridView_基金份额历史表.AllowUserToAddRows = false;
            this.dataGridView_基金份额历史表.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_基金份额历史表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView_基金份额历史表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_基金份额历史表.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView_基金份额历史表.Location = new System.Drawing.Point(3, 60);
            this.dataGridView_基金份额历史表.Name = "dataGridView_基金份额历史表";
            this.dataGridView_基金份额历史表.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_基金份额历史表.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView_基金份额历史表.RowHeadersWidth = 4;
            this.dataGridView_基金份额历史表.RowTemplate.Height = 30;
            this.dataGridView_基金份额历史表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_基金份额历史表.Size = new System.Drawing.Size(275, 340);
            this.dataGridView_基金份额历史表.TabIndex = 47;
            this.dataGridView_基金份额历史表.SelectionChanged += new System.EventHandler(this.dataGridView_基金份额历史表_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.dataGridView_申购赎回调整数历史表);
            this.groupBox2.Location = new System.Drawing.Point(726, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 403);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "申购赎回调整数历史数据";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_删除申购赎回调整数,
            this.tsButton_导入});
            this.toolStrip1.Location = new System.Drawing.Point(3, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(300, 31);
            this.toolStrip1.TabIndex = 48;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButton_删除申购赎回调整数
            // 
            this.tsButton_删除申购赎回调整数.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton_删除申购赎回调整数.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_删除申购赎回调整数.Image")));
            this.tsButton_删除申购赎回调整数.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_删除申购赎回调整数.Name = "tsButton_删除申购赎回调整数";
            this.tsButton_删除申购赎回调整数.Size = new System.Drawing.Size(50, 28);
            this.tsButton_删除申购赎回调整数.Text = "删除";
            this.tsButton_删除申购赎回调整数.Click += new System.EventHandler(this.tsButton_删除申购赎回调整数_Click);
            // 
            // dataGridView_申购赎回调整数历史表
            // 
            this.dataGridView_申购赎回调整数历史表.AllowUserToAddRows = false;
            this.dataGridView_申购赎回调整数历史表.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_申购赎回调整数历史表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView_申购赎回调整数历史表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_申购赎回调整数历史表.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView_申购赎回调整数历史表.Location = new System.Drawing.Point(3, 57);
            this.dataGridView_申购赎回调整数历史表.Name = "dataGridView_申购赎回调整数历史表";
            this.dataGridView_申购赎回调整数历史表.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_申购赎回调整数历史表.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView_申购赎回调整数历史表.RowHeadersWidth = 4;
            this.dataGridView_申购赎回调整数历史表.RowTemplate.Height = 30;
            this.dataGridView_申购赎回调整数历史表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_申购赎回调整数历史表.Size = new System.Drawing.Size(303, 343);
            this.dataGridView_申购赎回调整数历史表.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "申赎时间";
            // 
            // dateTimePicker_赎回时间
            // 
            this.dateTimePicker_赎回时间.Location = new System.Drawing.Point(115, 114);
            this.dateTimePicker_赎回时间.Name = "dateTimePicker_赎回时间";
            this.dateTimePicker_赎回时间.Size = new System.Drawing.Size(317, 28);
            this.dateTimePicker_赎回时间.TabIndex = 49;
            // 
            // tsButton_导入
            // 
            this.tsButton_导入.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButton_导入.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_导入.Image")));
            this.tsButton_导入.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_导入.Name = "tsButton_导入";
            this.tsButton_导入.Size = new System.Drawing.Size(50, 28);
            this.tsButton_导入.Text = "导入";
            this.tsButton_导入.Click += new System.EventHandler(this.tsButton_导入_Click);
            // 
            // Edit_ShuHui_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 430);
            this.Controls.Add(this.dateTimePicker_赎回时间);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_产品名称);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_基金经理表);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_份额);
            this.Controls.Add(this.btn_确定);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_ShuHui_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改基金份额和申购赎回调整数";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_基金经理表)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_基金份额历史表)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_申购赎回调整数历史表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_产品名称;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_份额;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_查看历史份额;
        private System.Windows.Forms.DataGridView dataGridView_基金经理表;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_基金份额历史表;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_申购赎回调整数历史表;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButton_删除申购赎回调整数;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsButton_删除基金份额历史;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_赎回时间;
        private System.Windows.Forms.ToolStripButton tsButton_导入;
    }
}