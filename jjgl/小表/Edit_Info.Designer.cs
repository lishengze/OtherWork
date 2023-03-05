namespace 基金管理
{
    partial class Edit_Info 
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
            this.label4 = new System.Windows.Forms.Label();
            this.btn_确定 = new System.Windows.Forms.Button();
            this.txt_买入股数 = new System.Windows.Forms.TextBox();
            this.txt_卖出股数 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_卖出均价 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_买入均价 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "买入股数";
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(64, 236);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(103, 43);
            this.btn_确定.TabIndex = 66;
            this.btn_确定.Text = "确  定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // txt_买入股数
            // 
            this.txt_买入股数.Location = new System.Drawing.Point(146, 44);
            this.txt_买入股数.Margin = new System.Windows.Forms.Padding(4);
            this.txt_买入股数.Name = "txt_买入股数";
            this.txt_买入股数.Size = new System.Drawing.Size(207, 28);
            this.txt_买入股数.TabIndex = 67;
            // 
            // txt_卖出股数
            // 
            this.txt_卖出股数.Location = new System.Drawing.Point(142, 136);
            this.txt_卖出股数.Margin = new System.Windows.Forms.Padding(4);
            this.txt_卖出股数.Name = "txt_卖出股数";
            this.txt_卖出股数.Size = new System.Drawing.Size(207, 28);
            this.txt_卖出股数.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "卖出股数";
            // 
            // txt_卖出均价
            // 
            this.txt_卖出均价.Location = new System.Drawing.Point(142, 183);
            this.txt_卖出均价.Margin = new System.Windows.Forms.Padding(4);
            this.txt_卖出均价.Name = "txt_卖出均价";
            this.txt_卖出均价.Size = new System.Drawing.Size(207, 28);
            this.txt_卖出均价.TabIndex = 73;
            this.txt_卖出均价.TextChanged += new System.EventHandler(this.txt_卖出均价_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "卖出均价";
            // 
            // txt_买入均价
            // 
            this.txt_买入均价.Location = new System.Drawing.Point(146, 91);
            this.txt_买入均价.Margin = new System.Windows.Forms.Padding(4);
            this.txt_买入均价.Name = "txt_买入均价";
            this.txt_买入均价.Size = new System.Drawing.Size(207, 28);
            this.txt_买入均价.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 70;
            this.label3.Text = "买入均价";
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(220, 236);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(103, 43);
            this.btn_取消.TabIndex = 74;
            this.btn_取消.Text = "取  消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // Edit_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 297);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.txt_卖出均价);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_买入均价);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_卖出股数);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_买入股数);
            this.Controls.Add(this.btn_确定);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改交易信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.TextBox txt_买入股数;
        private System.Windows.Forms.TextBox txt_卖出股数;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_卖出均价;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_买入均价;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_取消;
    }
}