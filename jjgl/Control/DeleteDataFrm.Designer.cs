namespace 基金管理
{
    partial class DeleteDataFrm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_清理大表数据 = new System.Windows.Forms.Button();
            this.btn_清理小表数据 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page_数据清理 = new System.Windows.Forms.TabPage();
            this.page_数据备份 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbData = new System.Windows.Forms.ComboBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.page_数据清理.SuspendLayout();
            this.page_数据备份.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "选择开始日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(261, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(262, 28);
            this.dateTimePicker1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "选择结束日期";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(261, 116);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(262, 28);
            this.dateTimePicker2.TabIndex = 64;
            // 
            // btn_清理大表数据
            // 
            this.btn_清理大表数据.Location = new System.Drawing.Point(59, 174);
            this.btn_清理大表数据.Name = "btn_清理大表数据";
            this.btn_清理大表数据.Size = new System.Drawing.Size(217, 41);
            this.btn_清理大表数据.TabIndex = 66;
            this.btn_清理大表数据.Text = "清理大表数据";
            this.btn_清理大表数据.UseVisualStyleBackColor = true;
            this.btn_清理大表数据.Click += new System.EventHandler(this.btn_清理大表数据_Click);
            // 
            // btn_清理小表数据
            // 
            this.btn_清理小表数据.Location = new System.Drawing.Point(319, 174);
            this.btn_清理小表数据.Name = "btn_清理小表数据";
            this.btn_清理小表数据.Size = new System.Drawing.Size(217, 41);
            this.btn_清理小表数据.TabIndex = 67;
            this.btn_清理小表数据.Text = "清理小表数据";
            this.btn_清理小表数据.UseVisualStyleBackColor = true;
            this.btn_清理小表数据.Click += new System.EventHandler(this.btn_清理小表数据_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.page_数据清理);
            this.tabControl1.Controls.Add(this.page_数据备份);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 393);
            this.tabControl1.TabIndex = 68;
            // 
            // page_数据清理
            // 
            this.page_数据清理.BackColor = System.Drawing.SystemColors.Control;
            this.page_数据清理.Controls.Add(this.label4);
            this.page_数据清理.Controls.Add(this.btn_清理小表数据);
            this.page_数据清理.Controls.Add(this.dateTimePicker1);
            this.page_数据清理.Controls.Add(this.btn_清理大表数据);
            this.page_数据清理.Controls.Add(this.dateTimePicker2);
            this.page_数据清理.Controls.Add(this.label1);
            this.page_数据清理.Location = new System.Drawing.Point(4, 28);
            this.page_数据清理.Name = "page_数据清理";
            this.page_数据清理.Padding = new System.Windows.Forms.Padding(3);
            this.page_数据清理.Size = new System.Drawing.Size(593, 361);
            this.page_数据清理.TabIndex = 0;
            this.page_数据清理.Text = "数据清理"; 
            // 
            // page_数据备份
            // 
            this.page_数据备份.BackColor = System.Drawing.SystemColors.Control;
            this.page_数据备份.Controls.Add(this.button3);
            this.page_数据备份.Controls.Add(this.button2);
            this.page_数据备份.Controls.Add(this.button1);
            this.page_数据备份.Controls.Add(this.cbbData);
            this.page_数据备份.Controls.Add(this.txtPath);
            this.page_数据备份.Controls.Add(this.label3);
            this.page_数据备份.Controls.Add(this.label2);
            this.page_数据备份.Controls.Add(this.txtBackupName);
            this.page_数据备份.Controls.Add(this.label5);
            this.page_数据备份.Location = new System.Drawing.Point(4, 28);
            this.page_数据备份.Name = "page_数据备份";
            this.page_数据备份.Padding = new System.Windows.Forms.Padding(3);
            this.page_数据备份.Size = new System.Drawing.Size(593, 361);
            this.page_数据备份.TabIndex = 1;
            this.page_数据备份.Text = "数据备份";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 196);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 17;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 196);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 16;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 128);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 34);
            this.button1.TabIndex = 15;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbData
            // 
            this.cbbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbData.FormattingEnabled = true;
            this.cbbData.Location = new System.Drawing.Point(412, 67);
            this.cbbData.Margin = new System.Windows.Forms.Padding(4);
            this.cbbData.Name = "cbbData";
            this.cbbData.Size = new System.Drawing.Size(157, 26);
            this.cbbData.TabIndex = 14;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(148, 131);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(352, 28);
            this.txtPath.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "文件存储路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "选择备份数据库：";
            // 
            // txtBackupName
            // 
            this.txtBackupName.Location = new System.Drawing.Point(109, 68);
            this.txtBackupName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupName.Name = "txtBackupName";
            this.txtBackupName.Size = new System.Drawing.Size(148, 28);
            this.txtBackupName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "文件名：";
            // 
            // DeleteDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 393);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteDataFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据维护";
            this.tabControl1.ResumeLayout(false);
            this.page_数据清理.ResumeLayout(false);
            this.page_数据清理.PerformLayout();
            this.page_数据备份.ResumeLayout(false);
            this.page_数据备份.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_清理大表数据;
        private System.Windows.Forms.Button btn_清理小表数据;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage page_数据清理;
        private System.Windows.Forms.TabPage page_数据备份;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbData;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}