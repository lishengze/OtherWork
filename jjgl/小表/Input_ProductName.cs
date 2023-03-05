using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms; 

namespace 基金管理
{
    public partial class Input_ProductName : Form
    {
        public Input_ProductName()
        {
            InitializeComponent();
            //this.textBox1.Text = System.DateTime.Now.Year.ToString();  
        }

        private string _基金产品= string.Empty;
        public string 基金产品
        {
            get { return _基金产品; }
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("基金产品输入为空，请重新输入！", "系统提示");
                return;
            }
            else
            {
                this._基金产品 = this.textBox1.Text.Trim();
                Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
                if (!modelBLL.Exists(this._基金产品))
                {
                    MessageBox.Show("输入的基金产品名称不存在基金产品管理列表中,导入失败！", "系统提示");
                    return;
                    
                    //if (MessageBox.Show("输入的基金产品名称不存在基金产品管理列表中，确定执行继续执行吗？", "系统提示",
                    //   MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //}
                }
                else
                    this.DialogResult = System.Windows.Forms.DialogResult.OK; 
            }
        }

       

    }
}
