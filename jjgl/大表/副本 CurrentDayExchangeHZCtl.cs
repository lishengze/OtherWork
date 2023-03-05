using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
//using WindCSharp;
using System.Threading;
using Maticsoft.DBUtility;
using WAPIWrapperCSharp;

namespace 基金管理
{
    /// <summary>
    ///  每日交易汇总（所有产品）
    /// </summary>
    public partial class HistoryExchangeCtl : UserControl
    {
        public HistoryExchangeCtl()
        {
            InitializeComponent();
            InitializeControl();
        }

        /// <summary>
        /// 在生成当日投资汇总统计时需要获取UseControl下用户设置的数据，
        /// </summary>
        private List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品每日统计_ModelList = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();


        private void InitializeControl()
        {
            //清理所有TabPage页面
            this.tabControl1.Controls.Clear();
            List<string> 基金产品名称列表 = new List<string>();
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string sql = string.Format("select distinct(产品名称) from 绩效考核_股票每日交易汇总小表 where 时间 = '{0}' union select distinct(产品名称) from 绩效考核_股票每日交易汇总大表 where 时间 = '{0}'", currentDayDate);
            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AddtabPage(row["产品名称"].ToString());
                }
            }
        }


        private void AddtabPage(string name)
        {
            System.Windows.Forms.TabPage tabPage1 = new TabPage();
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Name = name;
            //tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1465, 628);
            //tabPage1.TabIndex = 0;
            tabPage1.Text = name;
            tabPage1.UseVisualStyleBackColor = true;

            HistoryExchange_SubPanel subPanel1 = new HistoryExchange_SubPanel(name, this.dateTimePicker1.Value);
            subPanel1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(subPanel1);

            this.tabControl1.Controls.Add(tabPage1);
        }


        private int m_count = 0;


        private WindAPI m_WindAPI = null;

        private double GetClosePrice(Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model, string date)
        {
            string windCodes = string.Empty;
            string indicators, startTime, endTime, options;
            if (今日大表Model.股票代码.Length == 6)
            {
                if (今日大表Model.股票代码.Substring(0, 1) == "6")
                    windCodes = 今日大表Model.股票代码 + ".SH";
                else
                    windCodes = 今日大表Model.股票代码 + ".SZ";
            }
            else if (今日大表Model.股票代码.Length == 4)
            {
                windCodes = 今日大表Model.股票代码 + ".HK";
            }
            indicators = "close";
            startTime = date.Trim() + " 8:00:00";//开盘时间 9点
            endTime = date.Trim() + " 17:00:00"; //收盘时间 16点
            options = "Fill=Previous";
            WindData wd = m_WindAPI.wsd(windCodes, indicators, startTime, endTime, options);
            if (wd != null)
            {
                if (wd.errorCode != 0)
                {
                    if (DialogResult.Cancel == MessageBox.Show(string.Format("从Wind软件接口中获取股票“{0}”当日收盘价失败！是否继续统计其他股票信息",
                        今日大表Model.股票名称), "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                    {
                        return -1;
                    }
                }
            }
            if (wd.errorCode == 0) //0表示执行成功，负值表示执行失败
            {
                object[,] odata = (object[,])wd.getDataByFunc("wsd", false);
                double 市场现价 = 0;
                if (odata.Length >= 0)
                {
                    double.TryParse(string.Format("{0}", odata[0, 0]), out 市场现价);
                }
                return 市场现价;
            }
            return -1;
        }
        /// <summary>
        /// 先计算每个股票的基本信息，然后计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_生成当日投资统计汇总_Click(object sender, EventArgs e)
        {
            m_count = 0;
            GetModelValue();

            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //如果今天是周一，则向前推三天到上周五；
            //请写出哪些节假日是停牌日？？？？？？？？？
            //string yestoryDayDate = this.dateTimePicker1.Value.AddDays(-1).ToString("yyyy/MM/dd");
            //if (DayOfWeek.Monday == this.dateTimePicker1.Value.DayOfWeek)
            //    yestoryDayDate = this.dateTimePicker1.Value.AddDays(-3).ToString("yyyy/MM/dd");
            string yestoryDayDate = GetJJR_LastDay(this.dateTimePicker1.Value);
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表ModelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表ModelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            Maticsoft.BLL.绩效考核_基金产品信息表 基金产品信息表_BLL = new Maticsoft.BLL.绩效考核_基金产品信息表();

            Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> DIC_绩效考核_基金产品信息表 = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();
            List<Maticsoft.Model.绩效考核_基金产品信息表> 绩效考核_基金产品信息表_List = 基金产品信息表_BLL.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in 绩效考核_基金产品信息表_List)
            {
                if (!DIC_绩效考核_基金产品信息表.ContainsKey(model.产品名称))
                    DIC_绩效考核_基金产品信息表.Add(model.产品名称, model);
            }
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> 今天小表_resultList = 小表ModelBLL.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));

            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 昨天大表_resultList = 大表ModelBLL.GetModelList(string.Format(" 时间 = '{0}'", yestoryDayDate));
            // 需要在步骤3中更新的记录
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今天大表_needUpdate_resultList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            //所有记录
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今天大表_resultList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            //今天大表_resultList = 今天大表_needUpdate_resultList + m_昨天大表_今日无交易_resultList(即不需要更新的记录列表)
            if (今天小表_resultList.Count <= 0)
            {
                MessageBox.Show("当日股票交易汇总小表无数据，无法生成当日投资统计", "系统提示");
                return;
            }

            if (昨天大表_resultList.Count <= 0)
            {
                if (MessageBox.Show("无上一个交易日投资统计汇总大表记录，生成今日投资统计汇总数据不准确，确定继续吗？", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
            }
            bool Wind软件_Success = false;
            #region 初始化Wind软件

            if (m_WindAPI == null)
            {
                try
                {
                    m_WindAPI = new WindAPI();
                    int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
                    if (LogRet == 0)
                    {
                        if (!m_WindAPI.isconnected())
                        {
                            MessageBox.Show("Wind软件接口读取失败", "系统提示");
                            //return;
                        }
                        Wind软件_Success = true;
                    }
                    else
                    {
                        MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
                        // return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
                    //  return;
                }
            }
            else
            {
                if (!Wind软件_Success)
                {
                    try
                    {
                        int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
                        if (LogRet == 0)
                        {
                            if (!m_WindAPI.isconnected())
                            {
                                MessageBox.Show("Wind软件接口读取失败", "系统提示");
                                //return;
                            }
                            Wind软件_Success = true;
                        }
                        else
                        {
                            MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
                            // return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
                        //  return;
                    }
                }
            }
            if (!Wind软件_Success) //Wind软件未联通，则弹出提示
            {
                if (MessageBox.Show("Wind软件接入失败，无法计算今日股市的“市场现价”，确定继续吗", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
            }
            #endregion

            #region 增加  股票每日交易汇总大表 步骤1
            m_昨天大表_今日无交易_resultList.Clear();
            m_昨天大表_今日无交易_resultList.AddRange(昨天大表_resultList);
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in 今天小表_resultList)
            {
                Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
                今日大表Model.今日汇总小表 = model;
                今日大表Model.产品名称 = model.产品名称;
                今日大表Model.基金经理 = model.基金经理;
                今日大表Model.股票代码 = model.股票代码;
                今日大表Model.股票名称 = model.股票名称;

                今日大表Model.昨日汇总大表 = Get昨日Model(今日大表Model);

                double 今日变化 = model.今日买入股 - model.今日卖出股;
                //“持股数量” 相当于小表中的“ 累计余股”
                今日大表Model.持股数量 = 今日大表Model.昨日汇总大表.持股数量 + 今日变化;

                if (今日大表Model.昨日汇总大表.持股数量 != 0)
                    今日大表Model.今日均价 = 今日大表Model.昨日汇总大表.投资成本 / 今日大表Model.昨日汇总大表.持股数量;

                if (今日大表Model.昨日汇总大表 != null)
                    今日大表Model.投资成本 = 今日大表Model.昨日汇总大表.投资成本 + model.买入清算金额 - model.今日卖出股 * 今日大表Model.昨日汇总大表.今日均价;
                if (今日大表Model.持股数量 != 0)
                    今日大表Model.持股成本 = 今日大表Model.投资成本 / 今日大表Model.持股数量;

                #region 通过Wind软件开放的接口，获取市场现价（即股市每日的收盘价）
                if (Wind软件_Success) //Wind软件联通，以下操作有意义
                {
                    double 市场现价 = GetClosePrice(今日大表Model, currentDayDate);
                    if (市场现价 > 0)
                        今日大表Model.市场现价 = 市场现价;
                }
                #endregion

                今日大表Model.今日市值 = 今日大表Model.持股数量 * 今日大表Model.市场现价;
                今日大表Model.浮盈浮亏 = 今日大表Model.今日市值 - 今日大表Model.投资成本;
                if (今日大表Model.投资成本 != 0)
                    今日大表Model.浮盈浮亏率 = ((今日大表Model.浮盈浮亏 / 今日大表Model.投资成本) * 100).ToString() + "%";

                //以下注释掉的字段等待计算完基金产品的统计信息后，再更新
                //private double _投资成本占比;
                //private double _市值占比; 
                //private double _本年净值贡献;
                //private double _当日盈亏;  
                if (今日大表Model.股票代码 == null)
                    今日大表Model.股票代码 = "";
                if (今日大表Model.股票名称 == null)
                    今日大表Model.股票名称 = "";

                今日大表Model.时间 = currentDayDate;
                if (今日大表Model.股票代码 != "" && 今日大表Model.股票名称 != "")
                {
                    long maxID = 大表ModelBLL.Exists(今日大表Model.股票代码, 今日大表Model.基金经理, 今日大表Model.产品名称, 今日大表Model.时间);
                    if (maxID <= 0)
                    { //不存在，则增加 
                        今日大表Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                        if (大表ModelBLL.Add(今日大表Model))
                        {
                            m_count++;
                            今天大表_needUpdate_resultList.Add(今日大表Model);
                        }
                    }
                    else
                    { //存在，则更新
                        今日大表Model.记录标识 = maxID;
                        if (大表ModelBLL.Update(今日大表Model))
                        {
                            m_count++;
                            今天大表_needUpdate_resultList.Add(今日大表Model);
                        }
                    }
                }
            }
            今天大表_resultList.AddRange(今天大表_needUpdate_resultList);

            #region add 20150815（解决今天没有交易的股票，大表中仍然保持昨天记录） 
            // 20151001 今日无交易时，持股数量/持股成本/投资成本以及由三这个参数推导出的参数值不变，其他参数是变化的； 
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 昨日大表Model in m_昨天大表_今日无交易_resultList)
            {
                #region 给变化的参数重新赋值
                
                昨日大表Model.时间 = currentDayDate;
                if (Wind软件_Success) //更新为今日市场现价；若Wind软件联通失败，则今日产品市场现价为0；
                {
                    double 市场现价 = GetClosePrice(昨日大表Model, currentDayDate);
                    if (市场现价 > 0)
                        昨日大表Model.市场现价 = 市场现价;
                }
                else
                    昨日大表Model.市场现价 = 0;

                昨日大表Model.今日市值 = 昨日大表Model.持股数量 * 昨日大表Model.市场现价;
                昨日大表Model.浮盈浮亏 = 昨日大表Model.今日市值 - 昨日大表Model.投资成本;
                if (昨日大表Model.投资成本 != 0)
                    昨日大表Model.浮盈浮亏率 = ((昨日大表Model.浮盈浮亏 / 昨日大表Model.投资成本) * 100).ToString() + "%";

                #endregion

                long maxID = 大表ModelBLL.Exists(昨日大表Model.股票代码, 昨日大表Model.基金经理, 昨日大表Model.产品名称, 昨日大表Model.时间);
                if (maxID <= 0)
                { //今天没有交易，则增加交易记录
                    昨日大表Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                    if (大表ModelBLL.Add(昨日大表Model))
                    {
                        m_count++;
                        今天大表_resultList.Add(昨日大表Model);
                    }
                }
                else
                { //存在，则更新
                    昨日大表Model.记录标识 = maxID;
                    if (大表ModelBLL.Update(昨日大表Model))
                    {
                        m_count++;
                        今天大表_resultList.Add(昨日大表Model);
                    }
                }
            }
            #endregion

            #endregion

            #region 增加 基金产品每日统计  步骤2

            Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品ModelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品List = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();

            List<string> 产品List = new List<string>();
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
            {
                if (!产品List.Contains(model.产品名称))
                {
                    产品List.Add(model.产品名称);
                }
            }
            //时间=从今年年初到今天这个时间段内的最大净值；
            string thisYearStart = string.Format("{0}/01/01", this.dateTimePicker1.Value.Year.ToString());
            Dictionary<string, double> 今年最大净值_DIC = 基金产品ModelBLL.Get_今年最大净值(thisYearStart, currentDayDate);

            foreach (string temp产品 in 产品List)
            {
                List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
                double 今日市值_total = 0;
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
                {
                    if (temp产品 == model.产品名称)
                    {
                        modelList.Add(model);
                    }
                }
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
                {
                    今日市值_total += model.今日市值;
                }

                Maticsoft.Model.绩效考核_基金产品每日统计 基金产品Model = new Maticsoft.Model.绩效考核_基金产品每日统计();
                Maticsoft.Model.绩效考核_基金产品每日统计 手动录入_基金产品Model = this.GetModelValueFromModelList(temp产品);

                基金产品Model.产品名称 = temp产品;
                //============从录入项目中获取数据（开始）=================//
                基金产品Model.资金余额 = 手动录入_基金产品Model.资金余额;
                基金产品Model.今年最大净值 = 手动录入_基金产品Model.今年最大净值;
                基金产品Model.基金份额 = 手动录入_基金产品Model.基金份额;
                基金产品Model.基准日净值 = 手动录入_基金产品Model.基准日净值;
                基金产品Model.申购赎回调整数 = 手动录入_基金产品Model.申购赎回调整数;

                //edit by qhc(20151008)从“绩效考核_基金产品信息表”中获取基金的份额； 
                if (DIC_绩效考核_基金产品信息表.ContainsKey(基金产品Model.产品名称))
                {
                    基金产品Model.基金份额 = DIC_绩效考核_基金产品信息表[基金产品Model.产品名称].份额;
                    基金产品Model.基准日净值 = DIC_绩效考核_基金产品信息表[基金产品Model.产品名称].基准日净值;
                }
                //============从录入项目中获取数据（结束）=================// 

                //============通过计算获取数据（开始）=================//
                基金产品Model.资产总额 = 基金产品Model.资金余额 + 今日市值_total / 10000.0;
                if (基金产品Model.基金份额 != 0)
                    基金产品Model.单位净值 = 基金产品Model.资产总额 / 基金产品Model.基金份额;

                if (基金产品Model.基准日净值 != 0)
                    基金产品Model.今年收益率 = (基金产品Model.单位净值 / 基金产品Model.基准日净值).ToString() + "%";

                if (基金产品Model.产品名称 != "")
                {
                    if (今年最大净值_DIC.ContainsKey(基金产品Model.产品名称))
                    {
                        基金产品Model.今年最大净值 = 今年最大净值_DIC[基金产品Model.产品名称];
                    }
                }

                if (基金产品Model.今年最大净值 != 0)
                {
                    double 回撤率 = 基金产品Model.单位净值 / 基金产品Model.今年最大净值 - 1;
                    基金产品Model.回撤率 = (回撤率 * 100).ToString() + "%";
                }
                基金产品Model.时间 = currentDayDate;
                if (基金产品Model.资产总额 != 0)
                {
                    if (基金产品Model.资金余额 != 0)
                        基金产品Model.资金资产比例 = ((基金产品Model.资金余额 / 基金产品Model.资产总额) * 100).ToString() + "%";
                    else 基金产品Model.资金资产比例 = "";
                }
                //============通过计算获取数据（结束）=================//

                long maxID = 基金产品ModelBLL.Exists(基金产品Model.产品名称, 基金产品Model.时间);
                if (maxID <= 0)
                { //不存在，则增加
                    基金产品Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                    if (基金产品ModelBLL.Add(基金产品Model))
                        基金产品List.Add(基金产品Model);
                }
                else
                { //存在，则更新
                    基金产品Model.记录标识 = maxID;
                    if (基金产品ModelBLL.Update(基金产品Model))
                        基金产品List.Add(基金产品Model);
                }
            }

            #endregion

            #region 更新  股票每日交易汇总大表  步骤3

            //以下更新以下字段： 
            //private double _投资成本占比;
            //private double _市值占比; 
            //private double _本年净值贡献; //
            //private double _当日盈亏;  

            Maticsoft.BLL.绩效考核_基金经理_产品份额表 基金经理_产品份额表_BLL = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
            List<Maticsoft.Model.绩效考核_基金经理_产品份额表> 基金经理_产品份额表_modelList = 基金经理_产品份额表_BLL.GetModelList("");


            //？？【QHC】疑问：基准日是什么时间？？？-- 上一年的最后一天为基准日
            int lastYear = this.dateTimePicker1.Value.Year - 1;
            string 基准日_时间 = string.Format("{0}/12/31", lastYear);

            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 基准日_resultList = 大表ModelBLL.GetModelList(string.Format(" 时间 = '{0}'", 基准日_时间));
            if (基准日_resultList.Count <= 0)
            {
                MessageBox.Show(string.Format("基准日时间：“{0}”交易汇总大表无相关记录，“本年净值贡献”不能有效计算", 基准日_时间), "系统提示");
            }

            //edit by qhc （20151010）--所有记录都需要更新以下参数（投资成本占比、市值占比、本年净值贡献）；
           // foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_needUpdate_resultList)
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
            { //[ADDED == ]
                Maticsoft.Model.绩效考核_基金产品每日统计 temp基金产品1 = null;
                foreach (Maticsoft.Model.绩效考核_基金产品每日统计 temp基金产品 in 基金产品List)
                {
                    if (temp基金产品.产品名称 == model.产品名称)
                    {
                        temp基金产品1 = temp基金产品;
                        break;
                    }
                }
                if (temp基金产品1 != null)
                {
                    double 投资成本占比 = 0;
                    if (temp基金产品1.资产总额 != 0)
                        投资成本占比 = (model.投资成本 / temp基金产品1.资产总额) / 10000;
                    if (投资成本占比 != 0)
                        model.投资成本占比 = (投资成本占比 * 100).ToString() + "%";

                    double 市值占比 = 0;
                    if (temp基金产品1.资产总额 != 0)
                        市值占比 = (model.今日市值 / temp基金产品1.资产总额) / 10000;
                    if (市值占比 != 0)
                        model.市值占比 = (市值占比 * 100).ToString() + "%";

                    #region 计算“本年净值贡献”
                    double 当天总浮动盈亏 = 0;
                    double 基准日前一日总浮动盈亏 = 0;
                    double 计算期间买卖总盈亏 = 大表ModelBLL.Get_期间买卖总盈亏(model.产品名称, model.基金经理, 基准日_时间, currentDayDate);
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 今天大表_needUpdate_resultList)
                    {
                        if (tempModel.基金经理 == model.基金经理 && tempModel.产品名称 == model.产品名称)
                        {
                            当天总浮动盈亏 += model.当日盈亏;
                        }
                    }
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 基准日_resultList)
                    {
                        if (tempModel.基金经理 == model.基金经理 && tempModel.产品名称 == model.产品名称)
                        {
                            基准日前一日总浮动盈亏 += model.当日盈亏;
                        }
                    }

                    double 申购赎回调整数 = 0;
                    foreach (Maticsoft.Model.绩效考核_基金经理_产品份额表 TempModel in 基金经理_产品份额表_modelList)
                    {
                        if (TempModel.基金产品 == model.产品名称 && TempModel.基金经理 == model.基金经理)
                        {
                            申购赎回调整数 = TempModel.申购赎回调整数;
                            break;
                        }
                    }
                    if (temp基金产品1.基金份额 != 0)
                        model.本年净值贡献 = (当天总浮动盈亏 - 基准日前一日总浮动盈亏 + 计算期间买卖总盈亏 + 申购赎回调整数) / temp基金产品1.基金份额;
                    //added by qhc (绩效考核_基金经理净值贡献表 )
                    Maticsoft.Model.绩效考核_基金经理净值贡献表 model_基金经理净值贡献表 = new Maticsoft.Model.绩效考核_基金经理净值贡献表(model.基金经理, model.时间, model.产品名称, model.本年净值贡献);
                    bool flag = false;

                    if (model.基金经理 == null)
                        model.基金经理 = "";
                    if (model.产品名称 == null)
                        model.产品名称 = "";
                    if (model.基金经理 != "" && model.时间 != "" && model.产品名称 != "")
                    {
                        if (modelBLL_基金经理净值贡献表.Exists(model.基金经理, model.时间, model.产品名称))
                        {
                            flag = modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
                        }
                        else
                        {
                            if (model.本年净值贡献 > 0)
                                flag = modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
                        }
                    }
                    #endregion

                    //当日盈亏(“实现盈亏”)= “卖出清算金额”- “今日卖出股”*“昨日均价”
                    if (model.昨日汇总大表 != null)
                        model.当日盈亏 = model.今日汇总小表.卖出清算金额 - model.今日汇总小表.今日卖出股 * model.昨日汇总大表.今日均价;
                    if (flag)
                    {
                        大表ModelBLL.Update(model);
                    }
                }
            }
            #endregion

            InitializeControl();

            if (m_count > 0)
                MessageBox.Show(string.Format("“股票每日交易汇总大表”中更新“{0}”条记录！", m_count), "系统提示");
            else
                MessageBox.Show("成功失败！", "系统提示");

        }

        private void GetModelValue()
        {
            基金产品每日统计_ModelList.Clear();

            foreach (Control subsubctl in this.tabControl1.Controls)
            {
                TabPage page = subsubctl as TabPage;
                if (page != null)
                {
                    Maticsoft.Model.绩效考核_基金产品每日统计 model = new Maticsoft.Model.绩效考核_基金产品每日统计();
                    model.产品名称 = page.Name;
                    foreach (UserControl uc in page.Controls)
                    {
                        foreach (Control ctl in uc.Controls)
                        {
                            Panel tempPanel = ctl as Panel;
                            if (tempPanel != null)
                            {
                                foreach (Control subcontrol in tempPanel.Controls)
                                {
                                    TextBox txtBox = subcontrol as TextBox;
                                    if (txtBox != null)
                                    {
                                        //if (txtBox.Name == "txt_基金份额")
                                        //{
                                        //    double 基金份额 = 0;
                                        //    double.TryParse(txtBox.Text, out 基金份额);
                                        //    model.基金份额 = 基金份额;
                                        //}
                                        if (txtBox.Name == "txt_基准日净值")
                                        {
                                            double 基准日净值 = 0;
                                            double.TryParse(txtBox.Text, out 基准日净值);
                                            model.基准日净值 = 基准日净值;
                                        }
                                        else if (txtBox.Name == "txt_资金余额")
                                        {
                                            double 资金余额 = 0;
                                            double.TryParse(txtBox.Text, out 资金余额);
                                            model.资金余额 = 资金余额;
                                        }
                                        else if (txtBox.Name == "txt_今年收益率")
                                        {
                                            model.今年收益率 = txtBox.Text;
                                        }
                                        else if (txtBox.Name == "txt_单位净值")
                                        {
                                            double 单位净值 = 0;
                                            double.TryParse(txtBox.Text, out 单位净值);
                                            model.单位净值 = 单位净值;
                                        }
                                        else if (txtBox.Name == "txt_今年最大净值")
                                        {
                                            double 今年最大净值 = 0;
                                            double.TryParse(txtBox.Text, out 今年最大净值);
                                            model.今年最大净值 = 今年最大净值;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    基金产品每日统计_ModelList.Add(model);
                }  //if (page != null)

            }
        }

        private Maticsoft.Model.绩效考核_基金产品每日统计 GetModelValueFromModelList(string 产品名称)
        {
            foreach (Maticsoft.Model.绩效考核_基金产品每日统计 tempmodel in this.基金产品每日统计_ModelList)
            {
                if (tempmodel.产品名称 == 产品名称)
                {
                    return tempmodel;
                }
            }
            return new Maticsoft.Model.绩效考核_基金产品每日统计();
        }

        private List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> m_昨天大表_今日无交易_resultList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();

        /// <summary> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Maticsoft.Model.绩效考核_股票每日交易汇总大表 Get昨日Model(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model)
        {
            if (model.基金经理 == null)
                model.基金经理 = "";
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempmodel in m_昨天大表_今日无交易_resultList)
            {
                if (tempmodel.产品名称 == model.产品名称 && tempmodel.股票代码 == model.股票代码 && tempmodel.基金经理 == model.基金经理)
                {
                    m_昨天大表_今日无交易_resultList.Remove(tempmodel);
                    return tempmodel;
                }
            }
            return new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
        }


        private string m_当前导入的产品名称 = string.Empty;

        /// <summary>
        ///  基金产品 （简称+全称）
        /// </summary>
        public static Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> JIJINCHANPIN_DIC = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();

        private void btn_导入历史投资统计汇总总表格_Click(object sender, EventArgs e)
        {
            if (_IsProssesing)
            {
                MessageBox.Show("导入历史投资统计汇总总表格，", "系统提示");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(btn_导入历史投资统计汇总总表格_EventHandler));
                thread.Start(ofd.FileName);
                //btn_导入历史投资统计汇总总表格_EventHandler(ofd.FileName);
            } //  end if (ofd.ShowDialog() == DialogResult.OK)
        }

        /// <summary>
        /// 是否执行中，“导入历史投资统计汇总总表格”
        /// false：执行完成或未执行
        /// true：执行中
        /// </summary>
        private bool _IsProssesing = false;

        /// <summary>
        /// 仍然存在多次导入数据重复导入问题；【QHC】
        /// </summary>
        /// <param name="fileName"></param>
        private void btn_导入历史投资统计汇总总表格_EventHandler(object fileName)
        {
            _IsProssesing = true;
            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_基金产品每日统计 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();


            #region 更新字典
            JIJINCHANPIN_DIC.Clear();
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList2 = modelBLL2.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in modelList2)
            {
                if (model.产品名称 != "")
                {
                    if (!JIJINCHANPIN_DIC.ContainsKey(model.产品名称.Trim()))
                    {
                        JIJINCHANPIN_DIC.Add(model.产品名称.Trim(), model);
                    }
                }
            }
            Dictionary<string, string> DockCodeName_DIC = new Dictionary<string, string>();
            Maticsoft.BLL.绩效考核_股票信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_股票信息表();
            List<Maticsoft.Model.绩效考核_股票信息表> modelList1 = modelBLL1.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_股票信息表 model in modelList1)
            {
                if (!DockCodeName_DIC.ContainsKey(model.股票代码.Trim()))
                {
                    DockCodeName_DIC.Add(model.股票代码.Trim(), model.股票名称.Trim());
                }
            }
            #endregion

            DataSet ds = DataConvertor.GetDataSetFromExcel(fileName.ToString());
            int 年_INT = 0;
            if (年_INT > 2050 || 年_INT < 2000)
            {
                Input_year frm = new Input_year();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    年_INT = frm.Year;
                }
                else
                { //不选择年份，结束导入动作
                    _IsProssesing = false;
                    return;
                }
            }

            foreach (DataTable table in ds.Tables)
            {

                #region 通过table文件名获取日期

                string oldName = table.TableName;
                string[] names = oldName.Split(new char[] { '月' });
                string 月 = string.Empty;
                string 日 = string.Empty;
                if (names.Length >= 2)
                {
                    if (names[0].Contains("'"))
                    {
                        月 = names[0].Substring(1, names[0].Length - 1);
                    }
                    string[] temp = names[1].Split(new char[] { '日' });
                    if (temp.Length >= 1)
                    {
                        日 = temp[0];
                    }
                } int 月_INT = 0; int 日_INT = 0;
                int.TryParse(月, out 月_INT);
                int.TryParse(日, out 日_INT);

                if (月_INT > 12 || 月_INT < 1)
                {
                    MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
                    _IsProssesing = false;
                    return;
                }
                if (日_INT > 31 || 日_INT < 1)
                {
                    MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
                    _IsProssesing = false;
                    return;
                }
                DateTime dt = new DateTime(年_INT, int.Parse(月), int.Parse(日));
                string currentDT = dt.ToString("yyyy/MM/dd");

                #endregion

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    #region 股票行 ----[绩效考核_股票每日交易汇总大表]
                    if (row[0].ToString() == "代码" && row[1].ToString() == "名称")
                    {
                        continue;
                    }
                    else if (row[0].ToString() != "" && row[1].ToString() != "") //代码和名称列同时有值，证明该行为股票行
                    {
                        if (row.ItemArray.Length < 13) continue;
                        Maticsoft.Model.绩效考核_股票每日交易汇总大表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();

                        string 基金经理简称 = string.Empty;
                        if (row[1] != null && row[1].ToString() != "")
                        {
                            //东江环保（徐）
                            string[] 股票名称Array = row[1].ToString().Split(new char[] { '（', '(' });
                            if (股票名称Array.Length >= 1)
                            {
                                model.股票名称 = 股票名称Array[0];
                            }
                            if (股票名称Array.Length >= 2)
                            {
                                基金经理简称 = 股票名称Array[1].Substring(0, 1);
                            }
                        }
                        #region 取股票代码，股票代码经常不够4位或6位，因此需要补位
                        // //edit by qhc （20151009）
                        if (row[0] != null && row[0].ToString() != "")
                        {
                            string temp股票代码 = row[0].ToString();
                            if (temp股票代码.Length == 6)
                            {
                                model.股票代码 = temp股票代码;
                            }
                            else if (temp股票代码.Length == 4)
                            {
                                if (DockCodeName_DIC.ContainsKey(temp股票代码))
                                {
                                    if (DockCodeName_DIC[temp股票代码] == model.股票名称)
                                    {
                                        model.股票代码 = temp股票代码;
                                    }
                                    else
                                    {
                                        model.股票代码 = "00" + temp股票代码;
                                    }
                                }
                                else
                                    model.股票代码 = "00" + temp股票代码;
                            }
                            else if (temp股票代码.Length == 5)
                            {
                                model.股票代码 = "0" + temp股票代码;
                            }
                            else if (temp股票代码.Length < 4)//小于4的情况
                            {
                                string ZeroStringArray = string.Empty; //增加若干个零
                                for (int j = 0; j < 6 - temp股票代码.Length; j++)
                                {
                                    ZeroStringArray += "0";
                                }
                                string temp股票代码_6位 = ZeroStringArray + temp股票代码;

                                for (int j = 0; j < 4 - temp股票代码.Length; j++)
                                {
                                    ZeroStringArray += "0";
                                }
                                string temp股票代码_4位 = ZeroStringArray + temp股票代码;


                                if (DockCodeName_DIC.ContainsKey(temp股票代码_6位))
                                {
                                    if (DockCodeName_DIC[temp股票代码_6位] == model.股票名称)
                                    {
                                        model.股票代码 = temp股票代码_6位;
                                    }
                                    else
                                    {
                                        model.股票代码 = temp股票代码_4位;
                                    }
                                }
                                else
                                    model.股票代码 = temp股票代码_4位;
                            }
                        }  // if (row[0] != null && row[0].ToString() != "")
                        #endregion

                        double 持股数量 = 0; double 持股成本 = 0; double 市场现价 = 0;
                        if (row[2] != null && row[2].ToString() != "")
                        {
                            double.TryParse(row[2].ToString(), out 持股数量);
                            model.持股数量 = 持股数量;
                        }
                        if (row[3] != null && row[3].ToString() != "")
                        {
                            double.TryParse(row[3].ToString(), out 持股成本);
                            model.持股成本 = 持股成本;
                        }
                        if (row[4] != null && row[4].ToString() != "")
                        {
                            double.TryParse(row[4].ToString(), out 市场现价);
                            model.市场现价 = 市场现价;
                        }

                        double 投资成本 = 0; double 今日市值 = 0; double 浮盈浮亏 = 0;
                        if (row[5] != null && row[5].ToString() != "")
                        {
                            double.TryParse(row[5].ToString(), out 投资成本);
                            model.投资成本 = 投资成本;
                        }
                        if (row[6] != null && row[6].ToString() != "")
                        {
                            double.TryParse(row[6].ToString(), out 今日市值);
                            model.今日市值 = 今日市值;
                        }
                        if (row[7] != null && row[7].ToString() != "")
                        {
                            double.TryParse(row[7].ToString(), out 浮盈浮亏);
                            model.浮盈浮亏 = 浮盈浮亏;
                        }
                        if (row[8] != null && row[8].ToString() != "")
                            model.投资成本占比 = row[8].ToString();
                        if (row[9] != null && row[9].ToString() != "")
                            model.市值占比 = row[9].ToString();
                        if (row[10] != null && row[10].ToString() != "")
                            model.浮盈浮亏率 = row[10].ToString();

                        model.时间 = currentDT;
                        model.产品名称 = m_当前导入的产品名称;
                        if (基金经理简称.Length >= 1)
                        {
                            if (MainFrm.JIJINJINGLI_DIC.ContainsKey(基金经理简称))
                                model.基金经理 = MainFrm.JIJINJINGLI_DIC[基金经理简称];
                        }
                        else
                            model.基金经理 = string.Empty;


                        #region 存储“本年净值贡献”

                        double 本年净值贡献 = 0;
                        if (row[11] != null && row[11].ToString() != "")
                        {
                            double.TryParse(row[11].ToString(), out 本年净值贡献);
                            model.本年净值贡献 = 本年净值贡献;
                        }
                        if (本年净值贡献 != 0)
                        {
                            bool flag = false;
                            if (model.基金经理 != "" && currentDT != "" && m_当前导入的产品名称 != "")
                            {
                                Maticsoft.Model.绩效考核_基金经理净值贡献表 model_基金经理净值贡献表 = new Maticsoft.Model.绩效考核_基金经理净值贡献表(model.基金经理, currentDT, m_当前导入的产品名称, model.本年净值贡献);
                                if (modelBLL_基金经理净值贡献表.Exists(model.基金经理, currentDT, m_当前导入的产品名称))
                                {
                                    flag = modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
                                }
                                else
                                {
                                    flag = modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
                                }
                            }
                        }

                        #endregion

                        double 当日盈亏 = 0;
                        if (row[12] != null && row[12].ToString() != "")
                        {
                            double.TryParse(row[12].ToString(), out 当日盈亏);
                            model.当日盈亏 = 当日盈亏;
                        }


                        long maxID = modelBLL_股票每日交易汇总大表.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                            modelBLL_股票每日交易汇总大表.Add(model);
                        }
                        else
                        {//存在记录，则更新
                            model.记录标识 = maxID;
                            modelBLL_股票每日交易汇总大表.Update(model);
                        }

                    }
                    #endregion

                    #region 合计行
                    else if (row[0].ToString() == "合计" || row[0].ToString() == "股票合计")
                    {
                        continue;
                    }
                    #endregion

                    #region 产品行 ---- [绩效考核_基金产品每日统计]

                    #region "资产总额"行，可增加，可更新
                    else if (row[2].ToString() == "资产总额")  // && row[4].ToString() == "资金余额")
                    {
                        if (table.Columns.Count < 12) continue;

                        Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        if (row[0] != null || row[0].ToString() != "")
                        {
                            model1.产品名称 = row[0].ToString();
                            m_当前导入的产品名称 = model1.产品名称;
                            //////////====================/////////
                            if (JIJINCHANPIN_DIC.ContainsKey(model1.产品名称))
                            {
                                Maticsoft.Model.绩效考核_基金产品信息表 temp绩效考核_基金产品信息表 = JIJINCHANPIN_DIC[model1.产品名称];
                                model1.基金份额 = temp绩效考核_基金产品信息表.份额;
                                //  model1.申购赎回调整数 = temp绩效考核_基金产品信息表.申购赎回调整数;
                            }
                        }

                        double 资产总额 = 0;
                        double 资金余额 = 0;

                        if (row[3] != null && row[3].ToString() != "")
                        {
                            double.TryParse(row[3].ToString(), out 资产总额);
                            model1.资产总额 = 资产总额;
                        }

                        if (row[5] != null && row[5].ToString() != "")
                        {
                            double.TryParse(row[5].ToString(), out 资金余额);
                            model1.资金余额 = 资金余额;
                        }
                        if (row[7] != null && row[7].ToString() != "")
                        {
                            model1.资金资产比例 = row[7].ToString();
                        }
                        model1.时间 = currentDT;

                        #region 正规基金产品（今年收益率+ 单位净值 ，同时出现在一行）

                        if (row[8].ToString() == "今年收益率" && row[10].ToString() == "单位净值")
                        {
                            double 单位净值 = 0;
                            if (row[9] != null && row[9].ToString() != "")
                            {
                                model1.今年收益率 = row[9].ToString();
                            }
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString(), out 单位净值);
                                model1.单位净值 = 单位净值;
                            }
                        }

                        #endregion

                        #region 一行中有“今年收益率”参数，无“单位净值”参数，“今年收益率”和其值间隔两列
                        if (row[8].ToString() == "今年收益率" && row[10].ToString() != "单位净值")
                        {
                            if (row[9] != null && row[9].ToString() != "")
                            {
                                model1.今年收益率 = row[9].ToString();
                            }
                        }
                        #endregion

                        #region 一行中有“单位净值”参数，无“今年收益率”参数，“单位净值”和其值间隔一列
                        if (row[8].ToString() != "今年收益率" && row[10].ToString() == "单位净值")
                        {
                            double 单位净值 = 0;
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString(), out 单位净值);
                                model1.单位净值 = 单位净值;
                            }
                        }
                        #endregion

                        long maxID = modelBLL_基金产品每日统计.Exists(model1.产品名称, model1.时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            model1.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                            modelBLL_基金产品每日统计.Add(model1);
                        }
                        else
                        {//存在记录，则更新
                            model1.记录标识 = maxID;
                            modelBLL_基金产品每日统计.Update(model1);
                        }
                    }
                    #endregion

                    #region "股票资产总额"行， 可更新

                    else if (row[2].ToString() == "股票资产总额")  // && row[4].ToString() == "资金余额")
                    {
                        //  股票资产总额	10,829.63 	资金余额	0.30 	资金/资产比例	0.00%	今年收益率		29.26%
                        if (table.Columns.Count < 12) continue;

                        Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        model1.产品名称 = m_当前导入的产品名称;
                        model1.时间 = currentDT;

                        double 股票资产总额 = 0;
                        double 资金余额 = 0;
                        if (row[3] != null && row[3].ToString() != "")
                        {
                            double.TryParse(row[3].ToString(), out 股票资产总额);
                            model1.股票资产总额 = 股票资产总额;
                        }
                        if (row[5] != null && row[5].ToString() != "")
                        {
                            double.TryParse(row[5].ToString(), out 资金余额);
                            model1.资金余额 = 资金余额;
                        }
                        if (row[7] != null && row[7].ToString() != "")
                        {
                            model1.资金资产比例 = row[7].ToString();
                        }
                        model1.时间 = currentDT;

                        if (row[8].ToString() == "今年收益率")
                        {
                            if (row[10] != null && row[10].ToString() != "")
                            {
                                model1.今年收益率 = row[10].ToString();
                            }
                        }

                        modelBLL_基金产品每日统计.UpdatePatial2(model1);

                    }
                    #endregion

                    #endregion

                    #region 其他特殊行

                    if (row[8].ToString() == "今年最大净值" || row[8].ToString() == "今年最高净值")
                    {
                        double 今年最大净值 = 0;
                        double.TryParse(row[9].ToString(), out 今年最大净值);
                        Maticsoft.Model.绩效考核_基金产品每日统计 tempModel = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        tempModel.产品名称 = m_当前导入的产品名称;
                        tempModel.时间 = currentDT;
                        tempModel.今年最大净值 = 今年最大净值;
                        tempModel.回撤率 = row[11].ToString();
                        modelBLL_基金产品每日统计.UpdatePatial(tempModel);
                    }
                    #endregion

                }
            }
            //刷新显示记录
            // InitializeControl();

            _IsProssesing = false;

            MessageBox.Show("导入完成", "系统提示");
        }

        private void btn_导出当日投资统计汇总总表格_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls";
            sfd.FileName = string.Format("{0}年{1}月{2}投资汇总.xls", this.dateTimePicker1.Value.Year.ToString(),
                                          this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
                string sheetName = string.Format("{0}月{1}日", this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());

                Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品_modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
                Maticsoft.BLL.绩效考核_股票每日交易汇总大表 汇总大表_modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
                Maticsoft.BLL.绩效考核_基金经理净值贡献表 绩效考核_基金经理净值贡献表_modelBLL = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();

                List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品_modelList = 基金产品_modelBLL.GetModelList(string.Format(" 时间 = '{0}' ", currentDayDate));
                List<Maticsoft.Model.绩效考核_基金经理净值贡献表> 绩效考核_基金经理净值贡献表_modelList = 绩效考核_基金经理净值贡献表_modelBLL.GetModelList(string.Format(" 时间 = '{0}' ", currentDayDate));


                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();

                //创建一个工作簿
                string name = string.Format("{0}月{1}日", this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());
                excelEdit.CreateWorkSheet(name);
                //第一行写日期(A-M共有13列数据) 
                excelEdit.WriteData(currentDayDate, 1, 1);
                excelEdit.FontNameSize(1, 1, 1, 1, "宋体", 9, true);
                //当前行、当前列
                int currentRow = 2;
                int currentColumn = 1;
                //总列数
                int columnsCount = 14;

                #region // ==========以产品为循环单元，循环写入 (开始) ==========//
                //对输出产品排序；edit by qhc 20151009
                List<Maticsoft.Model.绩效考核_基金产品每日统计> ordered_基金产品_modelList = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();
                Maticsoft.BLL.绩效考核_基金产品信息表 基金产品信息表_BLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
                List<Maticsoft.Model.绩效考核_基金产品信息表> 基金产品信息表_List = 基金产品信息表_BLL.GetModelList("  输出序号>0 order by 输出序号 asc ");
                基金产品信息表_List.AddRange(基金产品信息表_BLL.GetModelList("  输出序号<=0 or 输出序号 is null "));

                foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in 基金产品信息表_List)
                {
                    for (int i = 0; i < 基金产品_modelList.Count; i++)
                    {
                        if (基金产品_modelList[i].产品名称 == model.产品名称)
                        {
                            //从原有的序列中移除对象，增加到排序过的序列中
                            ordered_基金产品_modelList.Add(基金产品_modelList[i]);
                            基金产品_modelList.RemoveAt(i);
                            break;
                        }
                    }
                }
                //将剩余的一次性加入到排序的集合中
                ordered_基金产品_modelList.AddRange(基金产品_modelList);

                for (int i = 0; i < ordered_基金产品_modelList.Count; i++)
                {
                    Maticsoft.Model.绩效考核_基金产品每日统计 model = ordered_基金产品_modelList[i];
                    #region  增加二行，写入基金产品信息
                    // 设置字体加粗 + 背景色（灰色） 
                    excelEdit.FontNameSize(currentRow, 1, currentRow + 1, columnsCount, "宋体", 9, true);
                    excelEdit.SetRangeBackground(currentRow, 1, currentRow + 1, columnsCount, Color.FromArgb(0, 165, 165, 165));

                    #region 第一行
                    //第一、二、三列----合并单元格+调整背景色（黄色）
                    excelEdit.CellsUnite(currentRow, 1, currentRow + 1, 3, model.产品名称);
                    excelEdit.SetRangeBackground(currentRow, 1, currentRow + 1, 3, Color.Yellow);
                    //第四、五、六列 ----垂直方向合并单元格
                    excelEdit.CellsUnite(currentRow, 4, currentRow + 1, 4, "资产总额");
                    excelEdit.CellsUnite(currentRow, 5, currentRow + 1, 5, model.资产总额.ToString());
                    excelEdit.CellsUnite(currentRow, 6, currentRow + 1, 6, "资金余额");
                    //第七列 ----合并单元格+调整背景色（黄色）
                    excelEdit.CellsUnite(currentRow, 7, currentRow + 1, 7, model.资金余额.ToString());
                    excelEdit.SetRangeBackground(currentRow, 7, currentRow + 1, 7, Color.Yellow);
                    //第八、九列----合并单元格
                    excelEdit.CellsUnite(currentRow, 8, currentRow + 1, 8, "资金/资产比例");
                    excelEdit.CellsUnite(currentRow, 9, currentRow + 1, 9, model.资金资产比例);
                    //第10-14列，输出数据 
                    excelEdit.WriteData("今年收益率", currentRow, 10);
                    excelEdit.WriteData(model.今年收益率, currentRow, 11);
                    excelEdit.WriteData("单位净值", currentRow, 12);
                    excelEdit.WriteData(model.单位净值.ToString(), currentRow, 13);
                    excelEdit.WriteData("当日盈亏", currentRow, 14);
                    #endregion

                    #region 第二行

                    currentRow = currentRow + 1;
                    excelEdit.WriteData("今年最大净值", currentRow, 10);
                    excelEdit.WriteData(model.今年最大净值.ToString(), currentRow, 11);
                    excelEdit.WriteData("回撤率", currentRow, 12);
                    excelEdit.WriteData(model.回撤率, currentRow, 13);
                    #endregion
                    #endregion

                    #region 增加一行，写入股票信息头

                    currentRow = currentRow + 1;
                    excelEdit.WriteData("代码", currentRow, currentColumn);
                    excelEdit.WriteData("名称", currentRow, 2);
                    excelEdit.WriteData("基金经理", currentRow, 3);
                    excelEdit.WriteData("持股数量", currentRow, 4);
                    excelEdit.WriteData("持股成本", currentRow, 5);
                    excelEdit.WriteData("市场现价", currentRow, 6);
                    excelEdit.WriteData("投资成本(元)", currentRow, 7);
                    excelEdit.WriteData("今日市值(元)", currentRow, 8);
                    excelEdit.WriteData("浮盈浮亏(元)", currentRow, 9);
                    excelEdit.WriteData("投资成本占比", currentRow, 10);
                    excelEdit.WriteData("市值占比", currentRow, 11);
                    excelEdit.WriteData("浮盈浮亏率", currentRow, 12);
                    excelEdit.WriteData("本年净值贡献（元）", currentRow, 13);

                    #endregion

                    #region  增加若干行，写入股票信息内容

                    currentRow = currentRow + 1;
                    string sql = string.Format("select distinct 基金经理  from 绩效考核_股票每日交易汇总大表 where 时间 = '{0}'  and 产品名称 ='{1}' and 基金经理 is not null", currentDayDate, model.产品名称);
                    DataSet myDataSet = DbHelperSQL.Query(sql);
                    foreach (DataRow tempRow in myDataSet.Tables[0].Rows)
                    {
                        string 基金经理 = tempRow["基金经理"].ToString();
                        DataTable table = 汇总大表_modelBLL.GetOutPutTable(string.Format("时间 = '{0}' and 产品名称 ='{1}' and 基金经理='{2}' order by 基金经理 asc, 股票代码 asc", currentDayDate, model.产品名称, 基金经理));
                        if (table == null) continue;
                        if (table.Rows.Count <= 0) continue; //表格无数据，则不往下执行
                        //设置第一列为文本列；
                        excelEdit.setCellsTextFormat(currentRow, 1, table.Rows.Count + currentRow, 1);
                        excelEdit.WriteData(table, currentRow, 1);
                        // 基金经理本年净值贡献-竖向合并单元格
                        double 本年净值贡献 = 0;
                        foreach (Maticsoft.Model.绩效考核_基金经理净值贡献表 tempmodel in 绩效考核_基金经理净值贡献表_modelList)
                        {
                            if (tempmodel.基金产品 == model.产品名称 && tempmodel.基金经理 == 基金经理)
                            {
                                本年净值贡献 = tempmodel.本年净值贡献;
                                break;
                            }
                        }
                        excelEdit.CellsUnite(currentRow, 13, table.Rows.Count + currentRow - 1, 13, 本年净值贡献.ToString());
                        currentRow = table.Rows.Count + currentRow;
                        // break;
                    }

                    #endregion
                }
                #endregion
                // ==========以产品为循环单元，循环写入 (结束) ==========//

                //通用设置=字体
                int rowsCount = currentRow;

                //excelEdit.FontNameSize(1, 1, rowsCount, columnsCount, "宋体", 9, false);
                excelEdit.CellsAlignment(1, 1, rowsCount, columnsCount, ExcelHAlign.居中, ExcelVAlign.居中);

                excelEdit.SetRowHeight(1, rowsCount, 14);
                excelEdit.SetColumnWidth(1, columnsCount, 12);
                ////特殊设置 =字体
                //excelEdit.CellsAlignment(1, 1, 1, 18, ExcelHAlign.居中, ExcelVAlign.居中);
                //设置单元格边框
                excelEdit.CellsDrawFrame(1, 1, rowsCount, columnsCount);

                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }


        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            InitializeControl();
        }

        /// <summary>
        /// 2015内，获取某个交易日的上一个交易日
        /// </summary>
        private string GetJJR_LastDay(DateTime today)
        {
            string last_JJR = today.AddDays(-1).ToString("yyyy/MM/dd");
            int month = today.Month;
            int day = today.Day;
            if (month == 1) //元旦
            {
                if (day >= 1 && day <= 3)
                {
                    last_JJR = string.Format("{0}/12/31", today.Year - 1);
                }
            }
            else if (month == 2) //春节
            {
                if (day >= 18 && day <= 24)
                {
                    last_JJR = string.Format("{0}/02/17", today.Year);
                }
            }
            else if (month == 4) //清明节
            {
                if (day >= 4 && day <= 6)
                {
                    last_JJR = string.Format("{0}/04/03", today.Year);
                }
            }
            else if (month == 5) //劳动节
            {
                if (day >= 1 && day <= 3)
                {
                    last_JJR = string.Format("{0}/04/30", today.Year);
                }
            }
            else if (month == 6) //端午节
            {
                if (day >= 20 && day <= 22)
                {
                    last_JJR = string.Format("{0}/06/19", today.Year);
                }
            }
            else if (month == 9)
            {
                if (day >= 3 && day <= 5) //胜利日
                {
                    last_JJR = string.Format("{0}/09/02", today.Year);
                }
                if (day >= 26 && day <= 27)//中秋节
                {
                    last_JJR = string.Format("{0}/09/25", today.Year);
                }
            }
            else if (month == 10) //国庆节
            {
                if (day >= 1 && day <= 7)
                {
                    last_JJR = string.Format("{0}/09/30", today.Year);
                }
            }
            if (DayOfWeek.Monday == today.DayOfWeek)
                last_JJR = today.AddDays(-3).ToString("yyyy/MM/dd");

            return last_JJR;
        }


    }
}
