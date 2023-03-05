using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 基金管理.Control
{
    public partial class Stat仓位_Control_Sub : UserControl
    {
        public Stat仓位_Control_Sub(string 产品名称,DataTable table)
        {
            InitializeComponent(); 
            this.groupBox1.Text = 产品名称;
            this.dataGridView1.DataSource = table;

        }
    }
}
