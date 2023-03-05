namespace 基金管理
{
    partial class 小表_导出历史记录
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
            this.dateTime_start = new System.Windows.Forms.DateTimePicker();
            this.btn_导出当日记录 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTime_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.comboBox_产品名称 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "选择开始日期";
            // 
            // dateTime_start
            // 
            this.dateTime_start.Location = new System.Drawing.Point(148, 42);
            this.dateTime_start.Name = "dateTime_start";
            this.dateTime_start.Size = new System.Drawing.Size(218, 28);
            this.dateTime_start.TabIndex = 62;
            // 
            // btn_导出当日记录
            // 
            this.btn_导出当日记录.Location = new System.Drawing.Point(22, 207);
            this.btn_导出当日记录.Name = "btn_导出当日记录";
            this.btn_导出当日记录.Size = new System.Drawing.Size(154, 41);
            this.btn_导出当日记录.TabIndex = 66;
            this.btn_导出当日记录.Text = "确  定";
            this.btn_导出当日记录.UseVisualStyleBackColor = true;
            this.btn_导出当日记录.Click += new System.EventHandler(this.btn_导出当日记录_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "选择结束日期";
            // 
            // dateTime_end
            // 
            this.dateTime_end.Location = new System.Drawing.Point(148, 95);
            this.dateTime_end.Name = "dateTime_end";
            this.dateTime_end.Size = new System.Drawing.Size(218, 28);
            this.dateTime_end.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 70;
            this.label2.Text = "基金产品";
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(222, 207);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(154, 41);
            this.btn_取消.TabIndex = 71;
            this.btn_取消.Text = "取  消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // comboBox_产品名称
            // 
            this.comboBox_产品名称.FormattingEnabled = true;
            this.comboBox_产品名称.Location = new System.Drawing.Point(148, 151);
            this.comboBox_产品名称.Name = "comboBox_产品名称";
            this.comboBox_产品名称.Size = new System.Drawing.Size(218, 26);
            this.comboBox_产品名称.TabIndex = 72;
            // 
            // 小表_导出历史记录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 279);
            this.Controls.Add(this.comboBox_产品名称);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTime_end);
            this.Controls.Add(this.btn_导出当日记录);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTime_start);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "小表_导出历史记录";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出小表投资记录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTime_start;
        private System.Windows.Forms.Button btn_导出当日记录;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTime_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.ComboBox comboBox_产品名称;
    }
}