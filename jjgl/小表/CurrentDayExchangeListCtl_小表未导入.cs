using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class CurrentDayExchangeListCtl_小表未导入 : Form
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt1">起始时间</param>
        /// <param name="dt2">结束时间</param>
        public CurrentDayExchangeListCtl_小表未导入(DateTime dt1, DateTime dt2)
        {
            InitializeComponent();

            this.startTime.Value = dt1;
            this.endTime.Value = dt2;

            btn_Search_小表股票信息_Click(null, null);
        } 

        private void btn_Search_小表股票信息_Click(object sender, EventArgs e)
        {
            ExecuteSearch_小表_股票信息();
        }

        Maticsoft.BLL.绩效考核_股票每日交易汇总小表_格式不符 小表汇总_格式不符BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表_格式不符();

        public void ExecuteSearch_小表_股票信息()
        {
            string subSql2 = string.Format("时间 between '{0}' and '{1}'",
                startTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo),
                endTime.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList = 小表汇总_格式不符BLL.GetModelList(subSql2);
            this.dataGridView_股票信息.DataSource = modelList;
        }

        private void btn_修改_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList = this.dataGridView_股票信息.DataSource as List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>;
            if (modelList == null) 
                return;
            int count = 0;
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in modelList)
            {
                model.股票代码 = model.股票代码.Trim();
                model.基金经理 = model.基金经理.Trim();
                model.产品名称 = model.产品名称.Trim();

                if (小表汇总_格式不符BLL.Update(model))
                    count++;
            }
            if (count > 0)
                MessageBox.Show("提交修改成功！", "系统提示");
        }

        private void btn_迁入数据库中_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
           
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList = this.dataGridView_股票信息.DataSource as List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>;
            if (modelList == null)
                return;
            int count = 0;
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in modelList)
            {
                model.股票代码 = model.股票代码.Trim();
                model.基金经理 = model.基金经理.Trim();
                model.产品名称 = model.产品名称.Trim();
                model.时间 = model.时间.Trim();
                long old记录标识 = model.记录标识;
                if (model.股票代码 != "" && model.基金经理 != "" && model.产品名称 != "" && model.时间 != "")
                {
                    long maxID = 小表汇总BLL.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                    if (maxID < 0)
                    {//不存在记录，则 增加 
                        model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表");
                        if (小表汇总BLL.Add(model))
                            count++;
                    }
                    else
                    {//存在记录，则更新
                        model.记录标识 = maxID;
                        if (小表汇总BLL.Update(model))
                            count++;
                    }
                    小表汇总_格式不符BLL.Delete(old记录标识);
                }
                else //不符合规范数据，added by qhc（20151221）
                {
                    
                }
            } //end foreach 
            if (count > 0)
            {
                this.ExecuteSearch_小表_股票信息();
                MessageBox.Show("成功迁入产品库中！", "系统提示"); 
            }
        }

        private void btn_删除记录_Click(object sender, EventArgs e)
        {
            int deletedCount = 0; 
            List<int> rowIndex = new List<int>();
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
                if (小表汇总_格式不符BLL.Delete(记录标识))
                { 
                    deletedCount++;
                }
            }
            if (deletedCount > 0)
            {
                this.ExecuteSearch_小表_股票信息();
                MessageBox.Show("删除成功！", "系统提示");
            }
            else
                MessageBox.Show("删除失败！", "系统提示");
        }





    }

}
