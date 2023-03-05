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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "港币人民币买入汇率";
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(80, 117);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(146, 42);
            this.btn_确定.TabIndex = 66;
            this.btn_确定.Text = "确  定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // txt_买入汇率
            // 
            this.txt_买入汇率.Location = new System.Drawing.Point(239, 25);
            this.txt_买入汇率.Margin = new System.Windows.Forms.Padding(4);
            this.txt_买入汇率.Name = "txt_买入汇率";
            this.txt_买入汇率.Size = new System.Drawing.Size(176, 28);
            this.txt_买入汇率.TabIndex = 67;
            // 
            // txt_卖出汇率
            // 
            this.txt_卖出汇率.Location = new System.Drawing.Point(239, 74);
            this.txt_卖出汇率.Margin = new System.Windows.Forms.Padding(4);
            this.txt_卖出汇率.Name = "txt_卖出汇率";
            this.txt_卖出汇率.Size = new System.Drawing.Size(176, 28);
            this.txt_卖出汇率.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "港币人民币卖出汇率";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 70;
            this.button1.Text = "取  消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Input_汇率
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 176);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_卖出汇率);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_买入汇率);
            this.Controls.Add(this.btn_确定);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
    }
}