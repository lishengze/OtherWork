using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class 确认上个交易日日期frm : Form
    {
        public 确认上个交易日日期frm(DateTime 当前时间)
        {
            InitializeComponent();
            if (DayOfWeek.Monday == 当前时间.DayOfWeek) //今天为周一，上个交易日前移3天
                this.startTimePicker.Value = 当前时间.AddDays(-3);
            if (DayOfWeek.Sunday == 当前时间.DayOfWeek) //今天为周六，上个交易日前移2天
                this.startTimePicker.Value = 当前时间.AddDays(-2);
            else //否则前移一天
                this.startTimePicker.Value = 当前时间.AddDays(-1); 
        }

        private DateTime _上个交易日日期;
        public DateTime 上个交易日日期
        {
            get { return _上个交易日日期; }
        }
         
        private void btn_确定_Click(object sender, EventArgs e)
        {
            this._上个交易日日期 = this.startTimePicker.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

       

    }
}
