/*
版本: 1.1.1
时间: 2023.3_20
内容: 增加美股汇率输入框;

*/

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
        public Input_汇率(string  时间,string type)
        {
            InitializeComponent();
            m_时间 = 时间;
            this.Text = string.Format("请输入“{0}” {1} 汇率", m_时间, type);
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

        private double m_buy_cny;
        public double BuyCny
        {
            get { return m_buy_cny; }
        }

        private double m_sell_cny;
        public double SellCny
        {
            get { return m_sell_cny; }
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

        private void button_set_cny_Click(object sender, EventArgs e)
        {
            double buy_cny = -1;
            double sell_cny = -1;
            double.TryParse(this.text_buy_cny.Text.Trim(), out buy_cny);
            double.TryParse(this.text_sell_cny.Text.Trim(), out sell_cny);
            if (buy_cny <= 0)
            {
                MessageBox.Show("提交失败，美股买入汇率有效范围为必须大于0", "系统提示");
                return;
            }
            if (sell_cny <= 0)
            {
                MessageBox.Show("提交失败，美股卖出汇率有效范围为必须大于0", "系统提示");
                return;
            }
            this.m_buy_cny = buy_cny;
            this.m_sell_cny = sell_cny;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
