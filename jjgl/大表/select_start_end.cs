using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class select_start_end : Form
    {
        public DateTime m_startDT;
        public DateTime m_endDT;
        public bool successfule = false;

        public select_start_end()
        {
            InitializeComponent();
            this.dateTimePicker_start.Value = System.DateTime.Now;
            this.dateTimePicker_end.Value = System.DateTime.Now; 
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            int result =this.dateTimePicker_start.Value.CompareTo(this.dateTimePicker_end.Value);
            if (result > 0)
            {
                MessageBox.Show("起始和结束日期输入有误！","系统提示");
            }

            this.m_startDT = this.dateTimePicker_start.Value;
            this.m_endDT = this.dateTimePicker_end.Value;
            this.successfule = true;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         


    }
}
