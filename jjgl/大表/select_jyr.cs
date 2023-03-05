using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class select_jyr : Form
    {
        public select_jyr()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = System.DateTime.Now; 
        }

        private void btn_导出当日记录_Click(object sender, EventArgs e)
        {
            
        }


    }
}
