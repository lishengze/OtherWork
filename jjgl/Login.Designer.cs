namespace 基金管理
{
    partial class Login
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
            this.btn_登录 = new System.Windows.Forms.Button();
            this.btn_重置 = new System.Windows.Forms.Button();
            this.txt_用户名 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_密码 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Error_用户名 = new System.Windows.Forms.Label();
            this.lbl_Error_密码 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_登录
            // 
            this.btn_登录.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_登录.Location = new System.Drawing.Point(110, 197);
            this.btn_登录.Name = "btn_登录";
            this.btn_登录.Size = new System.Drawing.Size(126, 45);
            this.btn_登录.TabIndex = 0;
            this.btn_登录.Text = "登  录";
            this.btn_登录.UseVisualStyleBackColor = true;
            this.btn_登录.Click += new System.EventHandler(this.btn_登录_Click);
            // 
            // btn_重置
            // 
            this.btn_重置.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_重置.Location = new System.Drawing.Point(268, 197);
            this.btn_重置.Name = "btn_重置";
            this.btn_重置.Size = new System.Drawing.Size(126, 45);
            this.btn_重置.TabIndex = 1;
            this.btn_重置.Text = "关  闭";
            this.btn_重置.UseVisualStyleBackColor = true;
            this.btn_重置.Click += new System.EventHandler(this.btn_重置_Click);
            // 
            // txt_用户名
            // 
            this.txt_用户名.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_用户名.Location = new System.Drawing.Point(165, 93);
            this.txt_用户名.Margin = new System.Windows.Forms.Padding(4);
            this.txt_用户名.Name = "txt_用户名";
            this.txt_用户名.Size = new System.Drawing.Size(213, 28);
            this.txt_用户名.TabIndex = 32;
            this.txt_用户名.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_密码_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(82, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "用户名";
            // 
            // txt_密码
            // 
            this.txt_密码.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_密码.Location = new System.Drawing.Point(165, 141);
            this.txt_密码.Margin = new System.Windows.Forms.Padding(4);
            this.txt_密码.Name = "txt_密码";
            this.txt_密码.PasswordChar = '*';
            this.txt_密码.Size = new System.Drawing.Size(213, 28);
            this.txt_密码.TabIndex = 34;
            this.txt_密码.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_密码_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(82, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "密  码";
            // 
            // lbl_Error_用户名
            // 
            this.lbl_Error_用户名.AutoSize = true;
            this.lbl_Error_用户名.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Error_用户名.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_用户名.Location = new System.Drawing.Point(385, 92);
            this.lbl_Error_用户名.Name = "lbl_Error_用户名";
            this.lbl_Error_用户名.Size = new System.Drawing.Size(0, 18);
            this.lbl_Error_用户名.TabIndex = 36;
            // 
            // lbl_Error_密码
            // 
            this.lbl_Error_密码.AutoSize = true;
            this.lbl_Error_密码.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Error_密码.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_密码.Location = new System.Drawing.Point(385, 145);
            this.lbl_Error_密码.Name = "lbl_Error_密码";
            this.lbl_Error_密码.Size = new System.Drawing.Size(0, 18);
            this.lbl_Error_密码.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(197, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 38;
            this.label2.Text = "用户登录";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(392, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 22);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "保存密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(547, 310);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Error_密码);
            this.Controls.Add(this.lbl_Error_用户名);
            this.Controls.Add(this.txt_密码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_用户名);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_重置);
            this.Controls.Add(this.btn_登录);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(547, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(547, 310);
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_登录;
        private System.Windows.Forms.Button btn_重置;
        private System.Windows.Forms.TextBox txt_用户名;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_密码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Error_用户名;
        private System.Windows.Forms.Label lbl_Error_密码;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}