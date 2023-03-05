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
    /// <summary>
    ///  
    /// </summary>
    public partial class CurrentDayExchangeListCtl_小表数据审查 : UserControl
    {

        public enum 查询操作
        {
            查询小表,
            查询股票名称异常的记录,
            查询基金产品名称异常的记录 
        }
        private   查询操作 m_查询操作 = 查询操作.查询小表;
        public CurrentDayExchangeListCtl_小表数据审查()
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

        /// <summary>
        /// 查询小表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new DataTable();
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
            ExecuteSearch_小表(产品名称, 基金经理);
            m_查询操作 = 查询操作.查询小表;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate">当前时间</param>
        /// <param name="cpmc"></param>
        private void ExecuteSearch_小表(string 产品名称, string 基金经理 )
        {
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> 小表汇总_List = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();

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
            DataSet ds = 小表汇总BLL.GetList(subSql2);
            if (ds != null && ds.Tables.Count > 0)
                this.dataGridView1.DataSource = ds.Tables[0];
        }
 
         
        private void btn_查询股票信息管理中不存在的股票_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new DataTable();
            string subSql = string.Empty;
            List<Maticsoft.Model.绩效考核_股票信息表>  股票modelList = DataConvertor.Get所有股票List();
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
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                DataSet ds = 小表汇总BLL.GetList(subSql1);
                if (ds != null && ds.Tables.Count > 0)
                    this.dataGridView1.DataSource = ds.Tables[0];
            }

            m_查询操作 = 查询操作.查询股票名称异常的记录;
        }

        private void btn_查询基金产品管理中不存在的基金产品_Click(object sender, EventArgs e)
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
                string subSql1 = string.Format("  时间 between '{0}' and '{1}' and  产品名称 not in({2})",
                     startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                     endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), subSql);
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                DataSet ds = 小表汇总BLL.GetList(subSql1);
                if (ds != null && ds.Tables.Count > 0)
                    this.dataGridView1.DataSource = ds.Tables[0];
            } 
            m_查询操作 = 查询操作.查询基金产品名称异常的记录;
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表(); 
            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView1.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    long 记录标识 = 0;
                    long.TryParse(collection[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                    if (modelBLL.Delete(记录标识))
                    {
                        this.dataGridView1.Rows.Remove(collection[i]);
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    MessageBox.Show(string.Format("删除成功，共删除“{0}”条记录！",deletedCount), "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void btn_修改_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择修改记录！", "系统提示");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            long 记录标识 = 0;
            long.TryParse(row.Cells["记录标识"].Value.ToString(), out 记录标识); 
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = modelBLL.GetModel(记录标识);
            
            小表数据审查_修改 frm = new 小表数据审查_修改(model);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (this.m_查询操作 == 查询操作.查询小表)
                {
                    this.btn_Search_Click(null, null);
                }
                else if (this.m_查询操作 == 查询操作.查询股票名称异常的记录)
                {
                    btn_查询股票信息管理中不存在的股票_Click(null, null);
                }
                else if (this.m_查询操作 == 查询操作.查询基金产品名称异常的记录)
                {
                    btn_查询基金产品管理中不存在的基金产品_Click(null, null);
                }
            }
        }

    

    }

}
