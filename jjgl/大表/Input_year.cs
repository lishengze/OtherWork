using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class Input_year : Form
    {
        public Input_year()
        {
            InitializeComponent();
            this.textBox1.Text = System.DateTime.Now.Year.ToString();  
        }

        private int _year;
        public int Year
        {
            get { return _year; }
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            int year = 0;
            int.TryParse(this.textBox1.Text.Trim(), out year);
            if (year < 2000 || year > 2050)
            {
                MessageBox.Show("填写失败，有效年份有效数字范围为2000-2050", "系统提示");
                return;
            }
            else
            {
                this._year = year;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

       

    }
}
