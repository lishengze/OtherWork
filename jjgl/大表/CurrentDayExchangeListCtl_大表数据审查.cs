using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using DB;

namespace 基金管理
{
    public enum 大表数据审查_查询操作
    {
        查询大表产品信息,
        查询大表股票信息,
        大表产品信息表_产品名称异常记录,
        大表股票信息表_股票名称异常记录,
        大表股票信息表_产品名称异常记录
    }
    /// <summary>
    ///  
    /// </summary>
    public partial class CurrentDayExchangeListCtl_大表数据审查 : UserControl
    {

        private 大表数据审查_查询操作 m_查询操作 = 大表数据审查_查询操作.查询大表产品信息;

        public CurrentDayExchangeListCtl_大表数据审查()
        {
            InitializeComponent();

            this.endTime.Value = System.DateTime.Now;
            this.startTime.Value = System.DateTime.Now.AddMonths(-1);
            FillInitValue1();

        }

        private void FillInitValue1()
        {
            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList2 = new List<Maticsoft.Model.绩效考核_基金经理信息表>();
            modelList2.Add(new Maticsoft.Model.绩效考核_基金经理信息表("全部", "全部"));
            modelList2.AddRange(modelBLL2.GetModelList(""));

            this.comboBox_基金经理.DataSource = modelList2;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
            if (modelList2.Count > 0)
                this.comboBox_基金经理.SelectedIndex = 0;

            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
            modelList1.Add(new Maticsoft.Model.绩效考核_基金产品信息表("全部"));
            modelList1.AddRange(modelBLL1.GetModelList(""));

            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";

            if (modelList1.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;
        }


      
        private void btn_Search_大表产品信息_Click(object sender, EventArgs e)
        {
            string currentDayDate = this.startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 产品名称 = string.Empty;
            string 基金经理 = string.Empty;
            if (this.comboBox_产品名称.SelectedItem != null)
            {
                Maticsoft.Model.绩效考核_基金产品信息表 model1 = this.comboBox_产品名称.SelectedItem as Maticsoft.Model.绩效考核_基金产品信息表;
                if (model1 != null)
                    产品名称 = model1.产品名称;
            }
            if (this.comboBox_基金经理.SelectedItem != null)
            {
                Maticsoft.Model.绩效考核_基金经理信息表 model2 = this.comboBox_基金经理.SelectedItem as Maticsoft.Model.绩效考核_基金经理信息表;
                if (model2 != null)
                    基金经理 = model2.基金经理;
            }
            ExecuteSearch_大表_基金产品(产品名称, 基金经理);
            m_查询操作 = 大表数据审查_查询操作.查询大表产品信息;
        }

        private void btn_Search_大表股票信息_Click(object sender, EventArgs e)
        {
            string currentDayDate = this.startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 产品名称 = string.Empty;
            string 基金经理 = string.Empty;
            if (this.comboBox_产品名称.SelectedItem != null)
            {
                Maticsoft.Model.绩效考核_基金产品信息表 model1 = this.comboBox_产品名称.SelectedItem as Maticsoft.Model.绩效考核_基金产品信息表;
                if (model1 != null)
                    产品名称 = model1.产品名称;
            }
            if (this.comboBox_基金经理.SelectedItem != null)
            {
                Maticsoft.Model.绩效考核_基金经理信息表 model2 = this.comboBox_基金经理.SelectedItem as Maticsoft.Model.绩效考核_基金经理信息表;
                if (model2 != null)
                    基金经理 = model2.基金经理;
            }
            ExecuteSearch_大表_股票信息(产品名称, 基金经理);
            m_查询操作 = 大表数据审查_查询操作.查询大表股票信息;
        }

        private void ExecuteSearch_大表_基金产品(string 产品名称, string 基金经理)
        {
            Maticsoft.BLL.绩效考核_基金产品每日统计 大表汇总BLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();

            string subSql = string.Empty;
            if (产品名称 != "全部")
            {
                subSql += "and 产品名称 ='" + 产品名称 + "'";
            }
            string subSql2 = string.Format("时间 between '{0}' and '{1}' {2}", 
                startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
            DataSet ds = 大表汇总BLL.GetList(subSql2);
            if (ds != null && ds.Tables.Count > 0)
                this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void ExecuteSearch_大表_股票信息(string 产品名称, string 基金经理)
        {
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();

            string subSql = string.Empty;
            if (产品名称 != "全部")
            {
                subSql += "and 产品名称 ='" + 产品名称 + "'";
            }
            if (基金经理 != "全部")
            {
                subSql += "and 基金经理 ='" + 基金经理 + "'";
            }
            string subSql2 = string.Format("时间 between '{0}' and '{1}' {2}",
                startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
            DataSet ds = 大表汇总BLL.GetList(subSql2);
            if (ds != null && ds.Tables.Count > 0)
                this.dataGridView1.DataSource = ds.Tables[0];
        }

        #region 大表产品信息表

        private void btn_大表产品信息表_产品名称异常记录_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            string subSql = string.Empty;
            List<Maticsoft.Model.绩效考核_基金产品信息表> 基金产品modelList = modelBLL.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in 基金产品modelList)
            {
                subSql += string.Format("'{0}',", model.产品名称);
            }
            if (subSql.Length > 0)
                subSql = subSql.Substring(0, subSql.Length - 1);
            if (subSql.Length > 0)
            {
                string subSql1 = string.Format(" 时间 between '{0}' and '{1}' and 产品名称 not in({2})",
                    startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                    endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
                Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品每日统计BLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
                DataSet ds = 基金产品每日统计BLL.GetList(subSql1);
                if (ds != null && ds.Tables.Count > 0)
                    this.dataGridView1.DataSource = ds.Tables[0];
            } 
            m_查询操作 = 大表数据审查_查询操作.大表产品信息表_产品名称异常记录;
        }

        #endregion

        #region 大表股票信息表

        private void btn_大表股票信息表_股票名称异常记录_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new DataTable();
            string subSql = string.Empty;
            List<Maticsoft.Model.绩效考核_股票信息表> 股票modelList = DataConvertor.Get所有股票List();
            foreach (Maticsoft.Model.绩效考核_股票信息表 model in 股票modelList)
            {
                subSql += string.Format("'{0}',", model.股票名称);
            }
            if (subSql.Length > 0)
                subSql = subSql.Substring(0, subSql.Length - 1);
            if (subSql.Length > 0)
            {
                string subSql1 = string.Format(" 时间 between '{0}' and '{1}' and 股票名称 not in({2})",
                    startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                    endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
                Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
                DataSet ds = 大表汇总BLL.GetList(subSql1);
                if (ds != null && ds.Tables.Count > 0)
                    this.dataGridView1.DataSource = ds.Tables[0];
            }
            m_查询操作 = 大表数据审查_查询操作.大表股票信息表_股票名称异常记录;
        }

        private void btn_大表股票信息表_产品名称异常记录_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            string subSql = string.Empty;
            List<Maticsoft.Model.绩效考核_基金产品信息表> 基金产品modelList = modelBLL.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in 基金产品modelList)
            {
                subSql += string.Format("'{0}',", model.产品名称);
            }
            if (subSql.Length > 0)
                subSql = subSql.Substring(0, subSql.Length - 1);
            if (subSql.Length > 0)
            {
                string subSql1 = string.Format(" 时间 between '{0}' and '{1}' and 产品名称 not in({2})",
                     startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                     endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
                Maticsoft.BLL.绩效考核_股票每日交易汇总大表 股票每日交易汇总大表BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
                DataSet ds = 股票每日交易汇总大表BLL.GetList(subSql1);
                if (ds != null && ds.Tables.Count > 0)
                    this.dataGridView1.DataSource = ds.Tables[0];
            }
            m_查询操作 = 大表数据审查_查询操作.大表股票信息表_产品名称异常记录;
        }

        #endregion

        private void btn_修改_Click(object sender, EventArgs e)
        { 
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择修改记录！", "系统提示");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            string 产品名称 = string.Empty;
            string 股票名称 = string.Empty;

            if (this.dataGridView1.Columns.Contains("产品名称"))
            {
                产品名称 = row.Cells["产品名称"].Value.ToString();
            }
            if (this.dataGridView1.Columns.Contains("股票名称"))
            {
                股票名称 = row.Cells["股票名称"].Value.ToString();
            }  
            大表数据审查_修改 frm = new 大表数据审查_修改(产品名称, 股票名称,m_查询操作);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (this.m_查询操作 ==  大表数据审查_查询操作.查询大表产品信息)
                {
                    this.btn_Search_大表产品信息_Click(null, null);
                }
                else if (this.m_查询操作 == 大表数据审查_查询操作.查询大表股票信息)
                {
                    btn_Search_大表股票信息_Click(null, null);
                }
                else if (this.m_查询操作 == 大表数据审查_查询操作.大表产品信息表_产品名称异常记录)
                {
                    btn_大表产品信息表_产品名称异常记录_Click(null, null);
                }
                else if (this.m_查询操作 == 大表数据审查_查询操作.大表股票信息表_产品名称异常记录)
                { 
                    btn_大表股票信息表_产品名称异常记录_Click(null, null);
                }
                else if (this.m_查询操作 == 大表数据审查_查询操作.大表股票信息表_股票名称异常记录)
                {
                    btn_大表股票信息表_股票名称异常记录_Click(null, null);
                }

            }
        }

        private void btn_导出当日记录_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表股票BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品BLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();

            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView1.SelectedRows;
                if (m_查询操作 == 大表数据审查_查询操作.查询大表产品信息 || m_查询操作 == 大表数据审查_查询操作.大表产品信息表_产品名称异常记录)
                {
                    for (int i = collection.Count - 1; i >= 0; i--)
                    {
                        long 记录标识 = 0;
                        long.TryParse(collection[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                        if (基金产品BLL.Delete(记录标识))
                        {
                            this.dataGridView1.Rows.Remove(collection[i]);
                            deletedCount++;
                        }
                    }
                }
                else
                {
                    for (int i = collection.Count - 1; i >= 0; i--)
                    {
                        long 记录标识 = 0;
                        long.TryParse(collection[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                        if (大表股票BLL.Delete(记录标识))
                        {
                            this.dataGridView1.Rows.Remove(collection[i]);
                            deletedCount++;
                        }
                    }
                }
                if (deletedCount > 0)
                {
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

         
    }

}
