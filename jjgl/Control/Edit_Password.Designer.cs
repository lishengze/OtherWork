namespace 基金管理
{
    partial class Edit_Password 
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
            this.btn_确定 = new System.Windows.Forms.Button();
            this.txt_新密码 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_新密码确认 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.txt_原始密码 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_用户名 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(118, 231);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(103, 43);
            this.btn_确定.TabIndex = 66;
            this.btn_确定.Text = "确  定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // txt_新密码
            // 
            this.txt_新密码.Location = new System.Drawing.Point(170, 133);
            this.txt_新密码.Margin = new System.Windows.Forms.Padding(4);
            this.txt_新密码.Name = "txt_新密码";
            this.txt_新密码.PasswordChar = '*';
            this.txt_新密码.Size = new System.Drawing.Size(207, 28);
            this.txt_新密码.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "新密码";
            // 
            // txt_新密码确认
            // 
            this.txt_新密码确认.Location = new System.Drawing.Point(170, 176);
            this.txt_新密码确认.Margin = new System.Windows.Forms.Padding(4);
            this.txt_新密码确认.Name = "txt_新密码确认";
            this.txt_新密码确认.PasswordChar = '*';
            this.txt_新密码确认.Size = new System.Drawing.Size(207, 28);
            this.txt_新密码确认.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "新密码确认";
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(274, 231);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(103, 43);
            this.btn_取消.TabIndex = 74;
            this.btn_取消.Text = "取  消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // txt_原始密码
            // 
            this.txt_原始密码.Location = new System.Drawing.Point(170, 84);
            this.txt_原始密码.Margin = new System.Windows.Forms.Padding(4);
            this.txt_原始密码.Name = "txt_原始密码";
            this.txt_原始密码.PasswordChar = '*';
            this.txt_原始密码.Size = new System.Drawing.Size(207, 28);
            this.txt_原始密码.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "原始密码";
            // 
            // txt_用户名
            // 
            this.txt_用户名.Location = new System.Drawing.Point(170, 34);
            this.txt_用户名.Margin = new System.Windows.Forms.Padding(4);
            this.txt_用户名.Name = "txt_用户名";
            this.txt_用户名.Size = new System.Drawing.Size(207, 28);
            this.txt_用户名.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 77;
            this.label4.Text = "管理员用户名";
            // 
            // Edit_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 312);
            this.Controls.Add(this.txt_用户名);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_原始密码);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.txt_新密码确认);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_新密码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_确定);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改超级管理员密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.TextBox txt_新密码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_新密码确认;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.TextBox txt_原始密码;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_用户名;
        private System.Windows.Forms.Label label4;
    }
}