using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.txt_买入金额.ReadOnly = true;
        }

        private void txt_买入均价_TextChanged(object sender, EventArgs e)
        {
            double 今日买入股 = 0;
            double 买入均价 = 0;
            double.TryParse(this.txt_今日买入股.Text, out 今日买入股);
            double.TryParse(this.txt_买入均价.Text, out 买入均价);


            double 买入金额 = 今日买入股 * 买入均价;
            this.txt_买入金额.Text = 买入金额.ToString();
            this.txt_买入手续费.Text = (买入金额 * 0.001).ToString();
            this.txt_买入印花税.Text = this.txt_买入手续费.Text;   

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("增加成功！", "系统提示");
        }
    }
}
