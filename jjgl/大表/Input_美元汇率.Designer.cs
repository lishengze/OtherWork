namespace 基金管理
{
    partial class Input_美元汇率
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_buy_cny = new System.Windows.Forms.TextBox();
            this.text_sell_cny = new System.Windows.Forms.TextBox();
            this.button_set_cny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 71;
            this.label2.Text = "美元人民币买入汇率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "美元人民币卖出汇率";
            // 
            // text_buy_cny
            // 
            this.text_buy_cny.Location = new System.Drawing.Point(194, 13);
            this.text_buy_cny.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.text_buy_cny.Name = "text_buy_cny";
            this.text_buy_cny.Size = new System.Drawing.Size(157, 25);
            this.text_buy_cny.TabIndex = 73;
            // 
            // text_sell_cny
            // 
            this.text_sell_cny.Location = new System.Drawing.Point(194, 53);
            this.text_sell_cny.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.text_sell_cny.Name = "text_sell_cny";
            this.text_sell_cny.Size = new System.Drawing.Size(157, 25);
            this.text_sell_cny.TabIndex = 74;
            // 
            // button_set_cny
            // 
            this.button_set_cny.Location = new System.Drawing.Point(221, 101);
            this.button_set_cny.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_set_cny.Name = "button_set_cny";
            this.button_set_cny.Size = new System.Drawing.Size(130, 35);
            this.button_set_cny.TabIndex = 75;
            this.button_set_cny.Text = "设置美股汇率";
            this.button_set_cny.UseVisualStyleBackColor = true;
            this.button_set_cny.Click += new System.EventHandler(this.button_set_cny_Click);
            // 
            // Input_美元汇率
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 156);
            this.Controls.Add(this.button_set_cny);
            this.Controls.Add(this.text_sell_cny);
            this.Controls.Add(this.text_buy_cny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Input_美元汇率";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_buy_cny;
        private System.Windows.Forms.TextBox text_sell_cny;
        private System.Windows.Forms.Button button_set_cny;
    }
}