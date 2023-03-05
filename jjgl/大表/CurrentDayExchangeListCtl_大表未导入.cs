using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class CurrentDayExchangeListCtl_大表未导入 : Form
    {

        private 大表数据审查_查询操作 m_查询操作 = 大表数据审查_查询操作.查询大表产品信息;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt1">起始时间</param>
        /// <param name="dt2">结束时间</param>
        public CurrentDayExchangeListCtl_大表未导入(DateTime dt1, DateTime dt2)
        {
            InitializeComponent();

            this.startTime.Value = dt1;
            this.endTime.Value = dt2;

            btn_Search_大表产品信息_Click(null, null);
        }


        private void btn_Search_大表产品信息_Click(object sender, EventArgs e)
        {
            string currentDayDate = this.startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            ExecuteSearch_大表_基金产品();
            ExecuteSearch_大表_股票信息();
        }

        public void ExecuteSearch_大表_基金产品()
        {
            string subSql2 = string.Format("时间 between '{0}' and '{1}' ",
                startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = 格式不符_大表产品BLL.GetModelList(subSql2);
            this.dataGridView_产品信息.DataSource = modelList;

            this.dataGridView_产品信息.Columns["记录标识"].DisplayIndex = 0;
            this.dataGridView_产品信息.Columns["产品名称"].DisplayIndex = 1;
            this.dataGridView_产品信息.Columns["时间"].DisplayIndex = 2;

        }

        public void ExecuteSearch_大表_股票信息()
        {
            string subSql2 = string.Format("时间 between '{0}' and '{1}'",
                startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = 格式不符_大表股票BLL.GetModelList(subSql2);
            this.dataGridView_股票信息.DataSource = modelList;
            this.dataGridView_股票信息.Columns["昨日汇总大表"].Visible = false;
            this.dataGridView_股票信息.Columns["今日汇总小表"].Visible = false;
            this.dataGridView_股票信息.Columns["归属"].Visible = false;
        }

        Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表股票BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
        Maticsoft.BLL.绩效考核_基金产品每日统计 大表产品BLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();

        Maticsoft.BLL.绩效考核_基金产品每日统计_格式不符 格式不符_大表产品BLL = new Maticsoft.BLL.绩效考核_基金产品每日统计_格式不符();
        Maticsoft.BLL.绩效考核_股票每日交易汇总大表_格式不符 格式不符_大表股票BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表_格式不符();

        private void btn_提交修改_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage_大表_产品信息)
            {
                List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = this.dataGridView_产品信息.DataSource as List<Maticsoft.Model.绩效考核_基金产品每日统计>;
                if (modelList == null)
                    return;
                int count = 0;
                foreach (Maticsoft.Model.绩效考核_基金产品每日统计 model in modelList)
                {
                    model.产品名称 = model.产品名称.Trim();

                    if (格式不符_大表产品BLL.Update(model))
                        count++;
                }
                if (count > 0)
                    MessageBox.Show("提交修改成功！", "系统提示");
            }
            else if (this.tabControl1.SelectedTab == this.tabPage_大表_股票信息)
            {
                List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = this.dataGridView_股票信息.DataSource as List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>;
                if (modelList == null)
                    return;
                int count = 0;
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
                {
                    model.股票代码 = model.股票代码.Trim();
                    model.基金经理 = model.基金经理.Trim();
                    model.产品名称 = model.产品名称.Trim();

                    if (格式不符_大表股票BLL.Update(model))
                        count++;
                }
                if (count > 0)
                    MessageBox.Show("提交修改成功！", "系统提示");
            }

        }

        private void btn_迁入数据库中_Click(object sender, EventArgs e)
        {
            #region 当前操作大表股票信息
            if (this.tabControl1.SelectedTab == this.tabPage_大表_股票信息)
            {
                List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = this.dataGridView_股票信息.DataSource as List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>;
                int count1 = 0;
                if (modelList == null)
                    return;
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
                {
                    model.股票代码 = model.股票代码.Trim();
                    model.基金经理 = model.基金经理.Trim();
                    model.产品名称 = model.产品名称.Trim();
                    model.时间 = model.时间.Trim();
                    long old记录标识 = model.记录标识;
                    if (model.股票代码 != "" && model.基金经理 != "" && model.产品名称 != "" && model.时间 != "")
                    {
                        long maxID = 大表股票BLL.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                            if (大表股票BLL.Add(model))
                                count1++;
                        }
                        else
                        {//存在记录，则更新
                            model.记录标识 = maxID;
                            if (大表股票BLL.Update(model))
                                count1++;
                        }
                        格式不符_大表股票BLL.Delete(old记录标识);
                    }
                    else //不符合规范数据，added by qhc（20151221）
                    { 
                        //if (model.基金经理 == "")
                        //{
                        //    MessageBox.Show(string.Format("记录标识为“{0}”的行，基金经理为空，不能迁入产品库中", model.记录标识), "系统提示");
                        //    continue;
                        //} 
                    }
                } //end foreach 
                if (count1 > 0)
                { 
                    this.ExecuteSearch_大表_股票信息();
                    MessageBox.Show(string.Format("成功迁入“{0}”条记录至产品库中！",count1), "系统提示");
                }
            }
            #endregion

            #region 当前操作大表基金产品

            else if (this.tabControl1.SelectedTab == this.tabPage_大表_产品信息)
            {
                List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList1 = this.dataGridView_产品信息.DataSource as List<Maticsoft.Model.绩效考核_基金产品每日统计>;
                int count2 = 0;
                if (modelList1 == null)
                    return;
                foreach (Maticsoft.Model.绩效考核_基金产品每日统计 model in modelList1)
                {
                    model.产品名称 = model.产品名称.Trim();
                    model.时间 = model.时间.Trim();
                    long old记录标识 = model.记录标识;
                    if (model.产品名称 != "" && model.时间 != "")
                    {
                        long maxID = 大表产品BLL.Exists(model.产品名称, model.时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                            if (大表产品BLL.Add(model))
                                count2++;
                        }
                        else
                        {//存在记录，则更新
                            model.记录标识 = maxID;
                            if (大表产品BLL.Update(model))
                                count2++;
                        }
                        格式不符_大表产品BLL.Delete(old记录标识);
                    }
                    else //不符合规范数据，added by qhc（20151221）
                    {
                        //if (model.产品名称 == "")
                        //{
                        //    MessageBox.Show(string.Format("记录标识为“{0}”行，产品名称为空，不能迁入产品库中", model.记录标识), "系统提示");
                        //    continue;
                        //} 
                    }
                } //end foreach 
                if (count2 > 0)
                { //更新DataGridView
                    ExecuteSearch_大表_基金产品();
                    MessageBox.Show(string.Format("成功迁入“{0}”条记录至产品库中！", count2), "系统提示");
                }
                else
                    MessageBox.Show("格式规范，迁入失败！", "系统提示");
            }
            #endregion
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            int deletedCount = 0;
            List<int> rowIndex = new List<int>();
            #region 当前操作大表基金产品信息
            if (this.tabControl1.SelectedTab == this.tabPage_大表_产品信息)
            {
                DataGridViewSelectedCellCollection cellCollection = this.dataGridView_产品信息.SelectedCells;
                for (int i = 0; i < cellCollection.Count; i++)
                {
                    if (!rowIndex.Contains(cellCollection[i].RowIndex))
                    {
                        rowIndex.Add(cellCollection[i].RowIndex);
                    }
                }
                for (int i = rowIndex.Count - 1; i >= 0; i--)
                {
                    long 记录标识 = 0;
                    long.TryParse(this.dataGridView_产品信息.Rows[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                    if (格式不符_大表产品BLL.Delete(记录标识))
                    {
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    this.ExecuteSearch_大表_基金产品();
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
            #endregion

            #region 当前操作大表股票信息

            else if (this.tabControl1.SelectedTab == this.tabPage_大表_股票信息)
            {
                DataGridViewSelectedCellCollection cellCollection = this.dataGridView_股票信息.SelectedCells;
                for (int i = 0; i < cellCollection.Count; i++)
                {
                    if (!rowIndex.Contains(cellCollection[i].RowIndex))
                    {
                        rowIndex.Add(cellCollection[i].RowIndex);
                    }
                }
                for (int i = rowIndex.Count - 1; i >= 0; i--)
                {
                    long 记录标识 = 0;
                    long.TryParse(this.dataGridView_股票信息.Rows[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                    if (格式不符_大表股票BLL.Delete(记录标识))
                    {
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    this.ExecuteSearch_大表_股票信息();
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }

            #endregion
        }


    }

}
