using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class Input_汇率 : Form
    {
        private string m_时间 = string.Empty;
        public Input_汇率(string  时间)
        {
            InitializeComponent();
            m_时间 = 时间;
            this.Text = string.Format("请输入“{0}”汇率", m_时间);
        }

        private double _港币人民币买入汇率;
        public double 港币人民币买入汇率
        {
            get { return _港币人民币买入汇率; }
        }

        private double _港币人民币卖出汇率;
        public double 港币人民币卖出汇率
        { 
            get { return _港币人民币卖出汇率; }
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            double 买入汇率 = 0;
            double 卖出汇率 = 0;
            double.TryParse(this.txt_买入汇率.Text.Trim(), out 买入汇率);
            double.TryParse(this.txt_卖出汇率.Text.Trim(), out 卖出汇率);
            if (买入汇率 <= 0)
            {
                MessageBox.Show("提交失败，买入汇率有效范围为必须大于0", "系统提示");
                return;
            }
            if (卖出汇率 <= 0)
            {
                MessageBox.Show("提交失败，卖出汇率有效范围为必须大于0", "系统提示");
                return;
            }
            this._港币人民币买入汇率 = 买入汇率;
            this._港币人民币卖出汇率 = 卖出汇率;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
