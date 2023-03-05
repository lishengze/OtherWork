using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using DB;

namespace 基金管理
{
    public partial class CurrentDayExchangeHZCtl_记录对比 : Form
    {
        public CurrentDayExchangeHZCtl_记录对比()
        {
            InitializeComponent();
            this.rb_查看基金产品.Checked = false;
            this.rb_查看大表股票信息.Checked = true;
        }

         
        int 成果库Count = 0;
        int 临时库Count = 0;

        int 成果库独有Count = 0;
        int 临时库独有Count = 0;

        int 同一记录计算结果不同Count = 0;

        private void RefreshDataGridView_股票每日交易汇总大表()
        {
            成果库Count = 0;
            临时库Count = 0;
            成果库独有Count = 0;
            临时库独有Count = 0;
            同一记录计算结果不同Count = 0; 
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 差异值_modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            #region 计算两个dataGridView数据差值

            #region dataGridView 成果库记录

            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = modelBLL.GetModelList(string.Format("时间 = '{0}' order by 产品名称,基金经理,股票代码", currentDayDate));

            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_基金经理净值贡献表> modelList_绩效考核_基金经理净值贡献表 = modelBLL_基金经理净值贡献表.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
            {
                foreach (Maticsoft.Model.绩效考核_基金经理净值贡献表 tempModel in modelList_绩效考核_基金经理净值贡献表)
                {
                    if (tempModel.基金产品 == model.产品名称 && tempModel.时间 == model.时间 && tempModel.基金经理 == model.基金经理)
                    {
                        model.本年净值贡献 = tempModel.本年净值贡献;
                        break;
                    }
                }
            }

            #endregion

            #region dataGridView 临时缓存区记录

            Maticsoft.BLL.临时缓存区_绩效考核_股票每日交易汇总大表 临时缓存区_modelBLL = new Maticsoft.BLL.临时缓存区_绩效考核_股票每日交易汇总大表();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 临时缓存区_modelList = 临时缓存区_modelBLL.GetModelList(string.Format("时间 = '{0}' order by 产品名称,基金经理,股票代码", currentDayDate));

            Maticsoft.BLL.临时缓存区_绩效考核_基金经理净值贡献表 临时缓存区_modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.临时缓存区_绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_基金经理净值贡献表> 临时缓存区_modelList_绩效考核_基金经理净值贡献表 = 临时缓存区_modelBLL_基金经理净值贡献表.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 临时缓存区_modelList)
            {
                foreach (Maticsoft.Model.绩效考核_基金经理净值贡献表 tempModel in 临时缓存区_modelList_绩效考核_基金经理净值贡献表)
                {
                    if (tempModel.基金产品 == model.产品名称 && tempModel.时间 == model.时间 && tempModel.基金经理 == model.基金经理)
                    {
                        model.本年净值贡献 = tempModel.本年净值贡献;
                        break;
                    }
                }
            }

            #endregion

            成果库Count = modelList.Count;
            临时库Count = 临时缓存区_modelList.Count;

            for (int i = modelList.Count - 1; i >= 0; i--)
            {
                Maticsoft.Model.绩效考核_股票每日交易汇总大表 model = modelList[i];
                model.归属 = Maticsoft.Model.归属.属于成果库;
                // bool IsExist = false; 
                for (int j = 临时缓存区_modelList.Count - 1; j >= 0; j--)
                {
                    Maticsoft.Model.绩效考核_股票每日交易汇总大表 临时model = 临时缓存区_modelList[j];
                    临时model.归属 = Maticsoft.Model.归属.属于临时库;
                    if (临时model.产品名称 == model.产品名称 && 临时model.基金经理 == model.基金经理 &&
                        临时model.股票代码 == model.股票代码 && 临时model.股票名称 == model.股票名称)
                    {
                        if (
                            (Math.Abs(临时model.本年净值贡献 - model.本年净值贡献) < smallInt)&& 
                            (Math.Abs(临时model.持股成本 - model.持股成本) < smallInt) &&
                            (Math.Abs(临时model.持股数量 - model.持股数量) < smallInt) && 
                            (Math.Abs(临时model.当日盈亏 - model.当日盈亏)  < smallInt)&&
                            (Math.Abs(临时model.浮盈浮亏 - model.浮盈浮亏) < smallInt) && 
                            (Math.Abs(临时model.浮盈浮亏率 - model.浮盈浮亏率) < smallInt) &&
                            (Math.Abs(临时model.今日均价 - model.今日均价) < smallInt) && 
                            (Math.Abs(临时model.今日市值 - model.今日市值)  < smallInt)&&
                            (Math.Abs(临时model.市场现价 - model.市场现价) < smallInt) && 
                            (Math.Abs(临时model.市值占比 - model.市值占比)  < smallInt)&&
                            (Math.Abs(临时model.投资成本 - model.投资成本)  < smallInt)&&
                            (Math.Abs(临时model.投资成本占比 - model.投资成本占比) < smallInt)) //完全相等，则直接删除
                        {
                            临时缓存区_modelList.Remove(临时model);
                            modelList.Remove(model);
                        }
                        else
                        {
                            临时model.归属 = Maticsoft.Model.归属.成果库和临时库内容不一致;
                            model.归属 = Maticsoft.Model.归属.成果库和临时库内容不一致;
                            差异值_modelList.Add(DivationTwoMode(model, 临时model));
                        }
                        //IsExist = true;
                        break; //产品名称、基金经理、股票代码三者一致，则跳出循环
                    }
                } //end for (int j = 临时缓存区_modelList.Count; j >= 0; j--)

            }
            成果库独有Count = modelList.Count;
            临时库独有Count = 临时缓存区_modelList.Count;
            同一记录计算结果不同Count = 差异值_modelList.Count;
            #endregion

            #region  填充dataGridView

            #region dataGridView 成果库记录

            this.dataGridView_成果库记录.DataSource =FromModelToTable(modelList);
            this.dataGridView_成果库记录.Columns["记录标识"].Visible = false;
            //this.dataGridView_成果库记录.Columns["买卖累计盈亏"].Visible = false;
            //this.dataGridView_成果库记录.Columns["今日均价"].Visible = false;

            //this.dataGridView_成果库记录.Columns["归属"].Visible = false;
            //this.dataGridView_成果库记录.Columns["昨日汇总大表"].Visible = false;
            //this.dataGridView_成果库记录.Columns["今日汇总小表"].Visible = false;
            #endregion

            #region dataGridView 临时缓存区记录

            this.dataGridView_缓存库记录.DataSource = FromModelToTable(临时缓存区_modelList);
            this.dataGridView_缓存库记录.Columns["记录标识"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["买卖累计盈亏"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["今日均价"].Visible = false;

            //this.dataGridView_缓存库记录.Columns["归属"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["昨日汇总大表"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["今日汇总小表"].Visible = false;
            #endregion

            #region dataGridView 两者差值结果

            this.dataGridView_两者差值结果.DataSource = FromModelToTable(差异值_modelList);
            this.dataGridView_两者差值结果.Columns["记录标识"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["买卖累计盈亏"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["今日均价"].Visible = false;

            //this.dataGridView_两者差值结果.Columns["归属"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["昨日汇总大表"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["今日汇总小表"].Visible = false;

            #endregion

            #endregion
        }

        private double smallInt = 0.00001;
        private void RefreshDataGridView_基金产品每日统计()
        {
            成果库Count = 0;
            临时库Count = 0;
            成果库独有Count = 0;
            临时库独有Count = 0;
            同一记录计算结果不同Count = 0;

            List<Maticsoft.Model.绩效考核_基金产品每日统计> 差异值_modelList = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            #region 计算两个dataGridView数据差值

            #region dataGridView 成果库记录

            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = modelBLL.GetModelList(string.Format("时间 = '{0}' order by 产品名称 ", currentDayDate));

            Maticsoft.BLL.临时缓存区_绩效考核_基金产品每日统计 临时缓存区_modelBLL = new Maticsoft.BLL.临时缓存区_绩效考核_基金产品每日统计();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 临时缓存区_modelList = 临时缓存区_modelBLL.GetModelList(string.Format("时间 = '{0}' order by 产品名称 ", currentDayDate));

            #endregion

            成果库Count = modelList.Count;
            临时库Count = 临时缓存区_modelList.Count;

            for (int i = modelList.Count - 1; i >= 0; i--)
            {
                Maticsoft.Model.绩效考核_基金产品每日统计 model = modelList[i];
                double model_回撤率 = 0; double model_今年收益率 = 0; double model_资金资产比例 = 0;
                double.TryParse(model.回撤率, out model_回撤率);
                double.TryParse(model.今年收益率, out model_今年收益率);
                double.TryParse(model.资金资产比例, out model_资金资产比例);

                for (int j = 临时缓存区_modelList.Count - 1; j >= 0; j--)
                {
                    Maticsoft.Model.绩效考核_基金产品每日统计 临时model = 临时缓存区_modelList[j];
                    double 临时model_回撤率 = 0; double 临时model_今年收益率 = 0; double 临时model_资金资产比例 = 0;
                    double.TryParse(临时model.回撤率, out 临时model_回撤率);
                    double.TryParse(临时model.今年收益率, out 临时model_今年收益率);
                    double.TryParse(临时model.资金资产比例, out 临时model_资金资产比例);

                    if (临时model.产品名称 == model.产品名称)
                    {
                        if (
                            (Math.Abs(临时model.单位净值 - model.单位净值) < smallInt) &&
                            (Math.Abs(临时model.股票资产总额 - model.股票资产总额) < smallInt) &&
                            (Math.Abs(临时model_回撤率 - model_回撤率)< smallInt) &&
                            (Math.Abs(临时model.基准日净值 - model.基准日净值)< smallInt) && 
                            (Math.Abs(临时model_今年收益率 - model_今年收益率)< smallInt) &&
                            (Math.Abs(临时model.今年最大净值 - model.今年最大净值)< smallInt) &&  
                            (Math.Abs(临时model.资产总额 - model.资产总额)< smallInt) && 
                            (Math.Abs(临时model.资金余额 - model.资金余额) < smallInt)&&
                            (Math.Abs(临时model_资金资产比例 - model_资金资产比例) < smallInt)) //完全相等，则直接删除
                        {
                            临时缓存区_modelList.Remove(临时model);
                            modelList.Remove(model);
                        }
                        else
                        {
                            差异值_modelList.Add(DivationTwoMode(model, 临时model));
                        }
                        //IsExist = true;
                        break; //产品名称一致，则跳出循环
                    }
                } //end for (int j = 临时缓存区_modelList.Count; j >= 0; j--)

            }
            成果库独有Count = modelList.Count;
            临时库独有Count = 临时缓存区_modelList.Count;
            同一记录计算结果不同Count = 差异值_modelList.Count;
            #endregion

            #region  填充dataGridView
             
            #region dataGridView 成果库记录
            DataSet ds = modelBLL.GetList(string.Format("时间 = '{0}' order by 产品名称 ", currentDayDate));

            this.dataGridView_成果库记录.DataSource = FromModelToTable(modelList);
            this.dataGridView_成果库记录.Columns["记录标识"].Visible = false;
            //this.dataGridView_成果库记录.Columns["期货资产总额"].Visible = false;
            //this.dataGridView_成果库记录.Columns["期货资金余额"].Visible = false;
            // this.dataGridView_成果库记录.Columns["期货今年收益率"].Visible = false;
            #endregion

            #region dataGridView 临时缓存区记录

            this.dataGridView_缓存库记录.DataSource = FromModelToTable(临时缓存区_modelList);
            this.dataGridView_缓存库记录.Columns["记录标识"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["期货资产总额"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["期货资金余额"].Visible = false;
            //this.dataGridView_缓存库记录.Columns["期货今年收益率"].Visible = false;
            #endregion

            #region dataGridView 两者差值结果

            this.dataGridView_两者差值结果.DataSource = FromModelToTable(差异值_modelList);
            this.dataGridView_两者差值结果.Columns["记录标识"].Visible = false;
            this.dataGridView_两者差值结果.Columns["基金份额"].Visible = false;
            this.dataGridView_两者差值结果.Columns["申购赎回调整数"].Visible = false;
            this.dataGridView_两者差值结果.Columns["基准日净值"].Visible = false;

            //this.dataGridView_两者差值结果.Columns["期货资产总额"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["期货资金余额"].Visible = false;
            //this.dataGridView_两者差值结果.Columns["期货今年收益率"].Visible = false;

            #endregion

            #endregion
        }

        private DataTable FromModelToTable(List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList)
        {
            DataTable table = new DataTable();
            table.Columns.Add("记录标识");
            table.Columns.Add("产品名称");
            table.Columns.Add("资产总额");
            table.Columns.Add("资金余额");
            table.Columns.Add("资金资产比例");
            table.Columns.Add("今年收益率");
            table.Columns.Add("单位净值");
            table.Columns.Add("今年最大净值");
            table.Columns.Add("回撤率");
            table.Columns.Add("时间");
            table.Columns.Add("基金份额");
            table.Columns.Add("基准日净值");
            table.Columns.Add("申购赎回调整数");
            table.Columns.Add("股票资产总额");
            foreach (Maticsoft.Model.绩效考核_基金产品每日统计 model in modelList)
            {
                DataRow row = table.NewRow();
                row["记录标识"] = model.记录标识;
                row["产品名称"] = model.产品名称;
                row["资产总额"] = model.资产总额;
                row["资金余额"] = model.资金余额;
                row["资金资产比例"] = model.资金资产比例;
                row["今年收益率"] = model.今年收益率;
                row["单位净值"] = model.单位净值;
                row["今年最大净值"] = model.今年最大净值;
                row["回撤率"] = model.回撤率;
                row["时间"] = model.时间;
                row["基金份额"] = model.基金份额;
                row["基准日净值"] = model.基准日净值;
                row["申购赎回调整数"] = model.申购赎回调整数;
                row["股票资产总额"] = model.股票资产总额;

                table.Rows.Add(row);
            } 
            return table;
        }

        private DataTable FromModelToTable(List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList)
        {
            DataTable table = new DataTable();
            table.Columns.Add("记录标识");
            table.Columns.Add("产品名称");
            table.Columns.Add("股票代码");
            table.Columns.Add("股票名称");
            table.Columns.Add("基金经理");
            table.Columns.Add("持股数量");
            table.Columns.Add("持股成本");
            table.Columns.Add("市场现价");
            table.Columns.Add("投资成本");
            table.Columns.Add("今日市值");
            table.Columns.Add("浮盈浮亏"); 
            table.Columns.Add("投资成本占比");
            table.Columns.Add("市值占比");
            table.Columns.Add("浮盈浮亏率");
            table.Columns.Add("时间");
            table.Columns.Add("买卖累计盈亏");
            table.Columns.Add("今日均价");
            table.Columns.Add("本年净值贡献");

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
            {
                DataRow row = table.NewRow();
                row["记录标识"] = model.记录标识;
                row["产品名称"] = model.产品名称; 
                row["股票代码"] = model.股票代码;
                row["股票名称"] = model.股票名称;
                row["基金经理"] = model.基金经理;
                row["持股数量"] = model.持股数量;
                row["持股成本"] = model.持股成本;
                row["市场现价"] = model.市场现价;
                row["投资成本"] = model.投资成本;
                row["今日市值"] = model.今日市值;
                row["浮盈浮亏"] = model.浮盈浮亏;
                row["投资成本占比"] = model.投资成本占比;
                row["市值占比"] = model.市值占比;
                row["浮盈浮亏率"] = model.浮盈浮亏率;
                row["本年净值贡献"] = model.本年净值贡献;
                row["时间"] = model.时间;
                row["买卖累计盈亏"] = model.买卖累计盈亏;
                row["今日均价"] = model.今日均价;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// 比较两个数据模型的差值
        /// </summary>
        private Maticsoft.Model.绩效考核_股票每日交易汇总大表 DivationTwoMode(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model1, Maticsoft.Model.绩效考核_股票每日交易汇总大表 model2)
        {
            Maticsoft.Model.绩效考核_股票每日交易汇总大表 NewModel = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
            NewModel.产品名称 = model1.产品名称;
            NewModel.基金经理 = model1.基金经理;
            NewModel.股票代码 = model1.股票代码;
            NewModel.股票名称 = model1.股票名称;
            NewModel.时间 = model1.时间;
            NewModel.本年净值贡献 = model1.本年净值贡献 - model2.本年净值贡献;
            NewModel.持股成本 = model1.持股成本 - model2.持股成本;
            NewModel.持股数量 = model1.持股数量 - model2.持股数量;
            NewModel.当日盈亏 = model1.当日盈亏 - model2.当日盈亏;
            NewModel.浮盈浮亏 = model1.浮盈浮亏 - model2.浮盈浮亏;
            NewModel.浮盈浮亏率 = model1.浮盈浮亏率 - model2.浮盈浮亏率;
            NewModel.今日均价 = model1.今日均价 - model2.今日均价;
            NewModel.今日市值 = model1.今日市值 - model2.今日市值;
            NewModel.市场现价 = model1.市场现价 - model2.市场现价;
            NewModel.市值占比 = model1.市值占比 - model2.市值占比;
            NewModel.投资成本 = model1.投资成本 - model2.投资成本;
            NewModel.投资成本占比 = model1.投资成本占比 - model2.投资成本占比;
            return NewModel;
        }

        /// <summary>
        /// 比较两个数据模型的差值
        /// </summary>
        private Maticsoft.Model.绩效考核_基金产品每日统计 DivationTwoMode(Maticsoft.Model.绩效考核_基金产品每日统计 model1, Maticsoft.Model.绩效考核_基金产品每日统计 model2)
        {
            Maticsoft.Model.绩效考核_基金产品每日统计 NewModel = new Maticsoft.Model.绩效考核_基金产品每日统计();
            NewModel.产品名称 = model1.产品名称;
            NewModel.时间 = model1.时间;
            NewModel.单位净值 = model1.单位净值 - model2.单位净值;
            NewModel.股票资产总额 = model1.股票资产总额 - model2.股票资产总额;
            double 回撤率1 = 0; double 回撤率2 = 0;
            double.TryParse(model1.回撤率, out 回撤率1);
            double.TryParse(model2.回撤率, out 回撤率2);
            NewModel.回撤率 = (回撤率1 - 回撤率2).ToString();
            NewModel.基金份额 = model1.基金份额 - model2.基金份额;
            NewModel.基准日净值 = model1.基准日净值 - model2.基准日净值;
            double 今年收益率1 = 0; double 今年收益率2 = 0;
            double.TryParse(model1.今年收益率, out 今年收益率1);
            double.TryParse(model2.今年收益率, out 今年收益率2);
            NewModel.今年收益率 = (今年收益率1 - 今年收益率2).ToString();
            NewModel.今年最大净值 = model1.今年最大净值 - model2.今年最大净值;
            NewModel.申购赎回调整数 = model1.申购赎回调整数 - model2.申购赎回调整数;
            NewModel.资产总额 = model1.资产总额 - model2.资产总额;
            NewModel.资金余额 = model1.资金余额 - model2.资金余额;

            double 资金资产比例1 = 0; double 资金资产比例2 = 0;
            double.TryParse(model1.资金资产比例, out 资金资产比例1);
            double.TryParse(model2.资金资产比例, out 资金资产比例2);
            NewModel.资金资产比例 = (资金资产比例1 - 资金资产比例2).ToString();

            return NewModel;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SelectChange();
        }
        private void rb_查看大表股票信息_CheckedChanged(object sender, EventArgs e)
        {
            SelectChange();
        }

        private void SelectChange()
        {
            if (this.rb_查看基金产品.Checked)
            {
                RefreshDataGridView_基金产品每日统计();
                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                this.label2.Text = string.Format("{0}基金产品信息：成果库中存在{1}条记录，缓存库中存在{2}条记录，\n\r 成果库与缓存库作差值后，成果库剩余{3}条记录， 缓存库剩余{4}条记录 \n\r 差值后基金产品、基金经理、股票代码相同，其他参数不同的有{5}记录",
                                                  currentDayDate, 成果库Count, 临时库Count, 成果库独有Count, 临时库独有Count, 同一记录计算结果不同Count);
            }
            else if (this.rb_查看大表股票信息.Checked)
            {
                RefreshDataGridView_股票每日交易汇总大表();
                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                this.label2.Text = string.Format("{0}股票信息：成果库中存在{1}条记录，缓存库中存在{2}条记录，\n\r 成果库与缓存库作差值后，成果库剩余{3}条记录， 缓存库剩余{4}条记录 \n\r 差值后基金产品、基金经理、股票代码相同，其他参数不同的有{5}记录",
                                                  currentDayDate, 成果库Count, 临时库Count, 成果库独有Count, 临时库独有Count, 同一记录计算结果不同Count);
            }
        }

        
    }


}



