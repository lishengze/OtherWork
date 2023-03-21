namespace 基金管理
{
    partial class Input_汇率
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
            this.txt_买入汇率 = new System.Windows.Forms.TextBox();
            this.txt_卖出汇率 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_buy_cny = new System.Windows.Forms.TextBox();
            this.text_sell_cny = new System.Windows.Forms.TextBox();
            this.button_set_cny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 63;
            this.label4.Text = "港币人民币买入汇率";
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(239, 110);
            this.btn_确定.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(130, 35);
            this.btn_确定.TabIndex = 66;
            this.btn_确定.Text = "设置港股汇率";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // txt_买入汇率
            // 
            this.txt_买入汇率.Location = new System.Drawing.Point(212, 21);
            this.txt_买入汇率.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_买入汇率.Name = "txt_买入汇率";
            this.txt_买入汇率.Size = new System.Drawing.Size(157, 25);
            this.txt_买入汇率.TabIndex = 67;
            // 
            // txt_卖出汇率
            // 
            this.txt_卖出汇率.Location = new System.Drawing.Point(212, 62);
            this.txt_卖出汇率.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_卖出汇率.Name = "txt_卖出汇率";
            this.txt_卖出汇率.Size = new System.Drawing.Size(157, 25);
            this.txt_卖出汇率.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "港币人民币卖出汇率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 71;
            this.label2.Text = "美元人民币买入汇率";
            // this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "美元人民币卖出汇率";
            // 
            // text_buy_cny
            // 
            this.text_buy_cny.Location = new System.Drawing.Point(600, 22);
            this.text_buy_cny.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.text_buy_cny.Name = "text_buy_cny";
            this.text_buy_cny.Size = new System.Drawing.Size(157, 25);
            this.text_buy_cny.TabIndex = 73;
            // 
            // text_sell_cny
            // 
            this.text_sell_cny.Location = new System.Drawing.Point(600, 62);
            this.text_sell_cny.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.text_sell_cny.Name = "text_sell_cny";
            this.text_sell_cny.Size = new System.Drawing.Size(157, 25);
            this.text_sell_cny.TabIndex = 74;
            // 
            // button_set_cny
            // 
            this.button_set_cny.Location = new System.Drawing.Point(627, 110);
            this.button_set_cny.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_set_cny.Name = "button_set_cny";
            this.button_set_cny.Size = new System.Drawing.Size(130, 35);
            this.button_set_cny.TabIndex = 75;
            this.button_set_cny.Text = "设置美股汇率";
            this.button_set_cny.UseVisualStyleBackColor = true;
            this.button_set_cny.Click += new System.EventHandler(this.button_set_cny_Click);
            // 
            // Input_汇率
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 156);
            this.Controls.Add(this.button_set_cny);
            this.Controls.Add(this.text_sell_cny);
            this.Controls.Add(this.text_buy_cny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_卖出汇率);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_买入汇率);
            this.Controls.Add(this.btn_确定);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Input_汇率";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.TextBox txt_买入汇率;
        private System.Windows.Forms.TextBox txt_卖出汇率;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_buy_cny;
        private System.Windows.Forms.TextBox text_sell_cny;
        private System.Windows.Forms.Button button_set_cny;
    }
}