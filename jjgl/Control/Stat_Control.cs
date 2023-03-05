using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using DB;
//using dotnetCHARTING.WinForms;
//using EV.SDDZ.BLL;

namespace 基金管理
{
    public partial class Stat_Control : UserControl
    {
        private 当前执行动作 m_当前执行动作;
        public enum 当前执行动作
        {
            项目资产查询,
            证券持仓查询,
            证券交易查询
        }

        public Stat_Control()
        {
            InitializeComponent(); 
            FillControlValue();

            if (DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
            {
                this.btn_证券持仓查询.Visible = false;
                this.btn_证券交易查询.Visible = false; 
            }
        }

        private void FillControlValue()
        {
            this.startTimePicker.Value = DateTime.Now.AddMonths(-2);
            this.endTimePicker.Value = DateTime.Now.AddMonths(-1);

            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            modelList1.Add(new Maticsoft.Model.绩效考核_基金产品信息表("全部"));
            modelList1.AddRange(modelBLL1.GetModelList(""));

            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";
            if (modelList1.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;
        }

        private DataTable Function_项目资产查询()
        {
            DataTable table = new DataTable();
            string startTime = this.startTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.endTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();

            string 产品名称 = this.comboBox_产品名称.Text.Trim();
            string subSql = string.Empty;
            if (产品名称 == "全部")
                subSql = string.Format(" 时间 between '{0}' and '{1}'  order by  产品名称,时间 ", startTime, endTime);
            else
                subSql = string.Format("产品名称 ='{0}' and 时间 between '{1}' and '{2}' order by  时间 asc", 产品名称, startTime, endTime);
            DataSet ds = modelBLL.GetList_SelectColumn(subSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                table = ds.Tables[0];

                table.Columns.Add("仓位");
                foreach (DataRow row in table.Rows)
                {
                    double 资金资产比例 = 0;
                    double.TryParse(row["资金资产比例"].ToString(), out 资金资产比例);
                    row["仓位"] = 1 - 资金资产比例;
                }
            }
            return table;
        }

        private DataTable Function_证券汇总查询()
        {
            DataTable table = new DataTable();
            string startTime = this.startTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.endTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 产品名称 = this.comboBox_产品名称.Text.Trim();
            if (产品名称 == "全部")
            {
                MessageBox.Show("请选择一个基金产品！", "系统提示");
                return table;
            }
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            DataSet ds = modelBLL.GetList_SelectColumn(string.Format(" 产品名称= '{0}' and  时间 between '{1}' and '{2}' order by  产品名称,时间 ", 产品名称, startTime, endTime));
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                }
            }
            return table;
        }

        private DataTable Function_证券交易查询()
        {
            DataTable table = new DataTable();
            string startTime = this.startTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.endTimePicker.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 产品名称 = this.comboBox_产品名称.Text.Trim();
            if (产品名称 == "全部")
            {
                MessageBox.Show("请选择一个基金产品！", "系统提示");
                return table;
            }
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            DataSet ds = modelBLL.GetListByTwoTable_证券交易查询(startTime, endTime, 产品名称);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                }
            }
            return table;
        }

        private void btn_项目资产查询_Click(object sender, EventArgs e)
        {
            this.m_当前执行动作 = 当前执行动作.项目资产查询;
            this.dataGridView1.DataSource = this.Function_项目资产查询();
        }
         
        private void btn_证券交易查询_Click(object sender, EventArgs e)
        {
            this.m_当前执行动作 = 当前执行动作.证券交易查询;
            this.dataGridView1.DataSource = this.Function_证券交易查询();
        }
         
        private void btn_证券持仓查询_Click(object sender, EventArgs e)
        {
            this.m_当前执行动作 = 当前执行动作.证券持仓查询;
            this.dataGridView1.DataSource = this.Function_证券汇总查询();
        }

        private void btn_导出记录_Click(object sender, EventArgs e)
        {
            DataTable tempTable = this.dataGridView1.DataSource as DataTable;
            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                MessageBox.Show("导出失败，无查询结果记录", "系统提示");
                return;
            }

            ////创建 一个工作簿 
            string sheetName = string.Empty;
            if (m_当前执行动作 == 当前执行动作.项目资产查询)
                sheetName = "项目资产查询";
            if (m_当前执行动作 == 当前执行动作.证券持仓查询)
                sheetName = "证券持仓查询";
            if (m_当前执行动作 == 当前执行动作.证券交易查询)
                sheetName = "证券交易查询";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName =string.Format("基金产品信息统计({0})",sheetName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = (this.dataGridView1.DataSource as DataTable).Copy();
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();
               
                Stat_Control_ByPerson.CreateExcelSheet(excelEdit, sheetName, table);
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        /// <summary>
        /// 导出单位净值和仓位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tempTable = this.dataGridView1.DataSource as DataTable;
            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                MessageBox.Show("导出失败，无查询结果记录", "系统提示");
                return;
            }

            ////创建 一个工作簿 
            string sheetName = string.Empty;
            if (m_当前执行动作 == 当前执行动作.项目资产查询)
                sheetName = "项目资产查询";
            if (m_当前执行动作 == 当前执行动作.证券持仓查询)
                sheetName = "证券持仓查询";
            if (m_当前执行动作 == 当前执行动作.证券交易查询)
                sheetName = "证券交易查询";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("基金产品信息统计({0})", sheetName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = (this.dataGridView1.DataSource as DataTable).Copy();
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();

                Stat_Control_ByPerson.CreateExcelSheet(excelEdit, sheetName, table);
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }
    }
}
