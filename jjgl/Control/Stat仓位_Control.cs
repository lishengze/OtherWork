using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using 基金管理;
using Maticsoft.DBUtility;
using 基金管理.Control;
//using dotnetCHARTING.WinForms;
//using EV.SDDZ.BLL;

namespace 基金管理
{
    public partial class Stat仓位_Control : UserControl
    {

        public Stat仓位_Control()
        {
            InitializeComponent();
            FillControlValue();
        }

        private void FillControlValue()
        {
            this.startTimePicker.Value = DateTime.Now.AddMonths(-2);

            #region 对输出产品排序
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = modelBLL1.GetModelList("  输出序号>0 order by 输出序号 asc ");
            modelList1.AddRange(modelBLL1.GetModelList("  输出序号<=0 or 输出序号 is null "));

            #endregion

            if (modelList1 != null)
            {
                comCheckBoxList1.DataSource = modelList1;
                comCheckBoxList1.DisplayMember = "产品名称";
                comCheckBoxList1.ValueMember = "产品名称";
            }
        }

        private void btn_导出记录_Click(object sender, EventArgs e)
        {
            int CheckListBoxCount = this.comCheckBoxList1.CheckListBox.CheckedItems.Count;
            int ExcelColumCount = CheckListBoxCount * 4;
            string 时间 = this.startTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            if (CheckListBoxCount <= 0)
            {
                MessageBox.Show("导出失败，当前未选择需要导出的基金产品", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = 时间.Replace("/", "") + "仓位统计.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();
                ////创建 一个工作簿 
                string sheetName = string.Empty;
                //  excelEdit.CreateWorkSheet(sheetName);

                // 设置 第一行 背景色（黄色高亮）  
                excelEdit.SetRangeBackground(1, 1, 1, ExcelColumCount, Color.Yellow);
                int currentColumn = 0;
                for (int i = 0; i < CheckListBoxCount; i++)
                {
                    object obj = this.comCheckBoxList1.CheckListBox.CheckedItems[i];
                    Maticsoft.Model.绩效考核_基金产品信息表 model = this.comCheckBoxList1.CheckListBox.CheckedItems[i] as Maticsoft.Model.绩效考核_基金产品信息表;
                    if (model != null)
                    {
                        #region 导出表结构

                        DataTable table = this.GetDataTable(model.产品名称, 时间);
                        //第一行写入基金产品名称
                        excelEdit.WriteData(model.产品名称, 1, currentColumn + 1);
                        //第二行写入表头
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            excelEdit.WriteData(table.Columns[j].ColumnName, 2, currentColumn + j + 1);
                        }
                        //增加到表格最后一行（汇总值）
                        double total = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            double 市值占比 = 0;
                            double.TryParse(row["市值占比"].ToString(), out 市值占比);
                            total += 市值占比;
                        }
                        table.Rows.Add(new object[] { "总计", "",total });

                        //格式化单元格内容("市值占比" 列为%格式，保留两位有效数字) 
                        excelEdit.setCells_PercentFormat(3, currentColumn + 3, table.Rows.Count + 2, currentColumn + 3);
                        // 格式化单元格内容 （“股票代码”列设置 为文本列）
                        excelEdit.setCells_TextFormat(3, currentColumn + 1, table.Rows.Count + 2, currentColumn + 1);

                        //从第三行开始写入数据 
                        excelEdit.WriteData(table, 3, currentColumn + 1);
                        //设置单元格边框
                        excelEdit.CellsDrawFrame(1, currentColumn + 1, table.Rows.Count + 2, currentColumn + 3);

                        currentColumn = currentColumn + 4;
                        #endregion
                    }
                } //  for (int i = 0; i < ColumnCount; i++)

                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        private void btn_持仓统计_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            int CheckListBoxCount = this.comCheckBoxList1.CheckListBox.CheckedItems.Count;
            string 时间 = this.startTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            if (CheckListBoxCount <= 0)
            {
                MessageBox.Show("请选择基金产品进行持仓统计！", "系统提示");
                return;
            }

            for (int i = 0; i < CheckListBoxCount; i++)
            {
                object obj = this.comCheckBoxList1.CheckListBox.CheckedItems[i];
                Maticsoft.Model.绩效考核_基金产品信息表 model = this.comCheckBoxList1.CheckListBox.CheckedItems[i] as Maticsoft.Model.绩效考核_基金产品信息表;
                if (model != null)
                {
                    DataTable table = GetDataTable(model.产品名称, 时间);
                    double total = 0;

                    DataTable newtable = new DataTable();
                    newtable.Columns.Add("股票代码");
                    newtable.Columns.Add("股票名称");
                    newtable.Columns.Add("市值占比");
                    //调整输出格式 
                    foreach (DataRow row in table.Rows)
                    {
                        DataRow  newRow = newtable.NewRow();
                        newRow["股票名称"] = row["股票名称"];
                        newRow["股票代码"] = row["股票代码"]; 
                        double 市值占比 = 0;
                        double.TryParse(row["市值占比"].ToString(), out 市值占比);
                        total += 市值占比;
                        //百分比形式，并且保留两位小数  
                        newRow["市值占比"] = 市值占比.ToString("P");
                        newtable.Rows.Add(newRow);
                    }
                    if (newtable.Rows.Count > 0)
                    { //增加“总计”行 
                        DataRow newRow = newtable.NewRow();
                        newRow["股票名称"] = "总计";
                        newRow["股票代码"] = "";
                        newRow["市值占比"] = total.ToString("P");
                        newtable.Rows.Add(newRow);
                    }
                    Stat仓位_Control_Sub Control_Sub = new Stat仓位_Control_Sub(model.产品名称, newtable);
                    this.flowLayoutPanel1.Controls.Add(Control_Sub);
                }
            }
        }


        private DataTable GetDataTable(string 产品名称, string 时间)
        {
            DataTable table = new DataTable();
            string sql = string.Format("SELECT 股票代码,股票名称, sum(市值占比) as 市值占比  from 绩效考核_股票每日交易汇总大表  where 产品名称= '{0}' and 时间 = '{1}' and 股票代码 != '' group by 股票代码,股票名称 order by 市值占比 desc", 产品名称, 时间);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                }
            }
            return table;
        }

    }
}
