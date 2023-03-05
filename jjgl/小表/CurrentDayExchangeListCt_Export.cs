using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class CurrentDayExchangeListCt_Export : Form
    {
        public CurrentDayExchangeListCt_Export()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = System.DateTime.Now;
            this.dateTimePicker2.Value = System.DateTime.Now.AddDays(-30);


        }

        private void btn_导出当日记录_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "*.xls|*.xls";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    DataTable table = (this.dataGridView1.DataSource as DataTable).Copy();
                
            //    DataSet ds = new DataSet();
            //    ds.Tables.Add(table);

            //    //移除基金经理和产品名称两列数据
            //    table.Columns.Remove("基金经理");
            //    table.Columns.Remove("产品名称");

            //    ExcelEdit excelEdit = new ExcelEdit();
            //    excelEdit.CreateExcel();

            //    foreach (DataTable table1 in ds.Tables)
            //    {
            //        //创建一个工作簿
            //        excelEdit.CreateWorkSheet("齐红超1");
            //        //写入数据
            //        excelEdit.CellsUnite(1, 1, 1, 18, "自营证券投资统计表");
            //        excelEdit.WriteData(table, 2, 1);
            //        //通用设置
            //        int columnsCount = excelEdit.myExcel.Cells.Columns.Count;
            //        int rowsCount = excelEdit.myExcel.Cells.Rows.Count;
            //        excelEdit.FontNameSize(1, 1, rowsCount, columnsCount, "宋体", 9, false); 
            //        //特殊设置
            //        excelEdit.CellsAlignment(1, 1, 1, 18, ExcelHAlign.居中, ExcelVAlign.居中);
            //        excelEdit.FontNameSize(1, 1, 1, 18, "宋体", 9, true); 
            //    }  
                 
            //    excelEdit.SaveAs(sfd.FileName);
            //    excelEdit.Close(); 
            //}
        }


    }
}
