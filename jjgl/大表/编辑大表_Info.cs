using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using DB;

namespace 基金管理
{
    public partial class 编辑大表_Info : Form
    {
        private Maticsoft.Model.绩效考核_股票每日交易汇总大表 m_今日大表Model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
        public Maticsoft.Model.绩效考核_股票每日交易汇总大表 Model
        {
            get { return m_今日大表Model; }
        }
        private DateTime m_Currenttime;
        public 编辑大表_Info(Maticsoft.Model.绩效考核_股票每日交易汇总大表 _model, DateTime dt)
        {
            InitializeComponent();
            this.m_今日大表Model = _model;
            this.m_Currenttime = dt;
            this.txt_时间.Text = m_今日大表Model.时间;
            this.txt_基金产品.Text = m_今日大表Model.产品名称.ToString();
            this.txt_股票名称.Text = m_今日大表Model.股票名称.ToString();
            this.txt_持股数量.Text = m_今日大表Model.持股数量.ToString();
            this.txt_持股成本.Text = m_今日大表Model.持股成本.ToString();
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            double 持股数量 = 0; double 持股成本 = 0;
            double.TryParse(this.txt_持股数量.Text.Trim(), out 持股数量);
            double.TryParse(this.txt_持股成本.Text.Trim(), out 持股成本);
            if (持股数量 <= 0)
            {
                MessageBox.Show("持股数量输入值不合法！", "系统提示");
                return;
            }
            if (持股成本 <= 0)
            {
                MessageBox.Show("持股成本输入值不合法！", "系统提示");
                return;
            }
            m_今日大表Model.持股数量 = 持股数量;
            m_今日大表Model.持股成本 = 持股成本;

            EditRecord();
        }


        /// <summary>
        /// 重新计算“持股数量”、“持股成本”引起的参数变化
        /// </summary>
        private void EditRecord()
        {
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_基金产品 = new Maticsoft.BLL.绩效考核_基金产品每日统计();

            #region  股票信息
            m_今日大表Model.今日市值 = m_今日大表Model.持股数量 * m_今日大表Model.市场现价;
            m_今日大表Model.投资成本 = m_今日大表Model.持股数量 * m_今日大表Model.持股成本; 
            m_今日大表Model.浮盈浮亏 = m_今日大表Model.今日市值 - m_今日大表Model.投资成本;
            if (m_今日大表Model.投资成本 != 0)
            {
                if (Math.Abs(m_今日大表Model.浮盈浮亏) < 0.0001) //若浮盈浮亏很小，则直接设置为0
                    m_今日大表Model.浮盈浮亏率 = 0;
                else
                    m_今日大表Model.浮盈浮亏率 = m_今日大表Model.浮盈浮亏 / m_今日大表Model.投资成本;
            }
            
            //计算“当日盈亏”===20151104 当日盈亏(“实现盈亏”)= （卖出价格-投资成本）*股数 


            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            string subSql = string.Format("产品名称='{0}' and 基金经理='{1}' and 股票代码='{2}' and 时间='{3}'",
                                               m_今日大表Model.产品名称, m_今日大表Model.基金经理, m_今日大表Model.股票代码, m_今日大表Model.时间);
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> 今日汇总小表List= modelBLL_股票小表.GetModelList(subSql);
           
            if (今日汇总小表List != null)
            {
                if (今日汇总小表List.Count > 0)
                {
                    m_今日大表Model.今日汇总小表 = 今日汇总小表List[0];
                    double temp今日卖出均价 = 0;
                    if (m_今日大表Model.今日汇总小表.今日卖出股 != 0)
                    {
                        temp今日卖出均价 = m_今日大表Model.今日汇总小表.卖出清算金额 / m_今日大表Model.今日汇总小表.今日卖出股;
                    }
                    m_今日大表Model.当日盈亏 = (temp今日卖出均价 - m_今日大表Model.持股成本) * m_今日大表Model.今日汇总小表.今日卖出股;
                }
            } 
            if (m_今日大表Model.产品名称 != "")
            {
                modelBLL_股票大表.Update(m_今日大表Model);
            }
            #endregion

            #region  基金产品
            string subsql = string.Format(" 产品名称 ='{0}' and 时间 = '{1}'", m_今日大表Model.产品名称, m_今日大表Model.时间);
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品ModelList = modelBLL_基金产品.GetModelList(subsql);
            Maticsoft.Model.绩效考核_基金产品每日统计 基金产品Model = new Maticsoft.Model.绩效考核_基金产品每日统计();
            if (基金产品ModelList.Count > 0)
            {
                基金产品Model = 基金产品ModelList[0];
            }
            double 今日市值_total = 0;
            string sql = string.Format("select  SUM(今日市值) as 今日市值总额 from 绩效考核_股票每日交易汇总大表 where 时间='{0}' and 产品名称= '{1}'", m_今日大表Model.时间, m_今日大表Model.产品名称);
            object obj1 = DbHelperSQL.GetSingle(sql);
            if (obj1 != null)
            {
                double.TryParse(obj1.ToString(), out 今日市值_total);
            }
            //以下是变化的参数
            基金产品Model.资产总额 = 基金产品Model.资金余额 + 今日市值_total / 10000.0;
            if (基金产品Model.基金份额 != 0)
                基金产品Model.单位净值 = 基金产品Model.资产总额 / (基金产品Model.基金份额 / 10000.0);

            if (基金产品Model.基准日净值 != 0)
                基金产品Model.今年收益率 = (基金产品Model.单位净值 / 基金产品Model.基准日净值 - 1).ToString();
            //从今年1月1号-今日的上一天的最大净值； 
            string 今年第一日 = string.Format("{0}/01/01", m_Currenttime.Year);
            string sql2 = string.Format("select max(单位净值) from 绩效考核_基金产品每日统计 where 时间 between '{0}' and '{1}' and 产品名称= '{2}'",
                                         今年第一日, m_Currenttime.AddDays(-1), m_今日大表Model.产品名称);

            double temp今年最大净值 = 0;
            object obj2 = DbHelperSQL.GetSingle(sql2);
            if (obj2 != null)
            {
                double.TryParse(obj2.ToString(), out temp今年最大净值);
            }
            基金产品Model.今年最大净值 = DataConvertor.Get_今年最大净值(temp今年最大净值, 基金产品Model.单位净值, 基金产品Model.基准日净值);

            if (基金产品Model.今年最大净值 != 0)
            {
                基金产品Model.回撤率 = (基金产品Model.单位净值 / 基金产品Model.今年最大净值 - 1).ToString();
            }
            if (基金产品Model.资产总额 != 0)
                基金产品Model.资金资产比例 = (基金产品Model.资金余额 / 基金产品Model.资产总额).ToString();

            modelBLL_基金产品.Update(基金产品Model);

            #endregion

            #region 股票其他信息
            // 再更新  
             
            double 投资成本占比 = 0;
            if (基金产品Model.资产总额 != 0)
                投资成本占比 = (m_今日大表Model.投资成本 / 基金产品Model.资产总额) / 10000;
            m_今日大表Model.投资成本占比 = 投资成本占比;

            double 市值占比 = 0;
            if (基金产品Model.资产总额 != 0)
                市值占比 = (m_今日大表Model.今日市值 / 基金产品Model.资产总额) / 10000;
            m_今日大表Model.市值占比 = 市值占比;

            //修改过持股数量、持股成本，此处将该变量设置为True
            m_今日大表Model.是否修改过持股数量和持股成本 = true;
            modelBLL_股票大表.Update(m_今日大表Model); 

            #region   "本年净值贡献"

            string currentDayDate = this.m_Currenttime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 基准日_时间 = DataConvertor.Get最后一个交易日时间(this.m_Currenttime.Year - 1);
            string 计算期间_起始时间 = string.Format("{0}/01/01", m_Currenttime.Year);

            //--由于净值贡献需要基金产品+基金经理购买股票情况的综合信息，因此放在最后单独计算
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 申购赎回调整历史表_BLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
            List<Maticsoft.Model.绩效考核_申购赎回调整历史表> 申购赎回调整历史表_modelList = 申购赎回调整历史表_BLL.GetModelList(string.Format(" 赎回时间 between '{0}' and '{1}'",计算期间_起始时间, currentDayDate));
             
            // 计算“本年净值贡献” //今日的买卖盈亏和浮动盈亏都会对“本年净值贡献”有影响
            m_今日大表Model.本年净值贡献 = DataConvertor.Get_本年净值贡献(m_今日大表Model.产品名称, m_今日大表Model.基金经理, 计算期间_起始时间,
                                                                     currentDayDate, 基准日_时间, 申购赎回调整历史表_modelList, 基金产品Model.基金份额);


            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            Maticsoft.Model.绩效考核_基金经理净值贡献表 model_基金经理净值贡献表 = new Maticsoft.Model.绩效考核_基金经理净值贡献表(m_今日大表Model.基金经理, m_今日大表Model.时间, m_今日大表Model.产品名称, m_今日大表Model.本年净值贡献);
            if (modelBLL_基金经理净值贡献表.Exists(m_今日大表Model.基金经理, m_今日大表Model.时间, m_今日大表Model.产品名称))
            {
                modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
            }
            else
            {
                modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
            }

            #endregion

 
            #endregion

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
