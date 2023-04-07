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
using DB;

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
            //更新“基金产品”字典；
            RefreshJJCP_DIC();
            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户" || DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
            {
                this.btn_导入历史投资统计汇总总表格.Visible = false;
                this.btn_生成当日投资统计汇总.Visible = false;
                this.btn_生成最新汇总.Visible = false;

                this.btn_生成指定时间统计汇总.Visible = false;
                this.btn_管理未成功导入数据.Visible = false;
            }
            if (DataConvertor.Pub_登录用户信息.角色 == "超级管理员")
            {
                this.btn_导入历史投资汇总至缓存区.Visible = true;
                this.btn_查看缓存区和成果区对比情况.Visible = true;
            }
            else
            {
                this.btn_导入历史投资汇总至缓存区.Visible = false;
                this.btn_查看缓存区和成果区对比情况.Visible = false;
            }
        }

        private List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList_是否包括止损指令 = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
        /// <summary>
        /// 在生成当日投资汇总统计时需要获取UseControl下用户设置的数据，
        /// </summary>
        private List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品每日统计_ModelList_From手动录入 = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();

        private void InitializeControl()
        {
            //清理所有TabPage页面
            this.tabControl1.Controls.Clear();
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string sql = string.Format("select distinct(产品名称) from 绩效考核_股票每日交易汇总小表 where 时间 = '{0}' union select distinct(产品名称) from 绩效考核_基金产品每日统计 where 时间 = '{0}'", currentDayDate);

            #region 获取小表信息
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList_小表 = modelBLL_小表.GetModelList(" 是否为止损指令 =1");
            modelList_是否包括止损指令 = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in modelList_小表)
            {
                bool modelExist = false;
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 newModel in modelList_是否包括止损指令)
                {
                    if (newModel.产品名称 == model.产品名称 && newModel.股票代码 == model.股票代码 && newModel.基金经理 == model.基金经理)
                    {
                        modelExist = true;
                        break;
                    }
                }
                if (!modelExist)
                    modelList_是否包括止损指令.Add(model);
            }
            #endregion

            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                #region 获取字典信息
                Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> DIC_产品名称_Model = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();

                Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
                List<Maticsoft.Model.绩效考核_基金产品信息表> modelList = modelBLL.GetModelList("");
                foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in modelList)
                {
                    if (!DIC_产品名称_Model.ContainsKey(model.产品名称))
                        DIC_产品名称_Model.Add(model.产品名称, model);
                }
                //时间=从今年年初到今天这个时间段内的最大净值；   
                string thisYearStart = string.Format("{0}/01/01", dateTimePicker1.Value.Year.ToString());
                Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品ModelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
                Dictionary<string, double> 今年最大净值_DIC = 基金产品ModelBLL.Get_今年最大净值(thisYearStart, this.dateTimePicker1.Value.AddDays(-1).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));

                #endregion

                #region 计算每日每个产品的股票资产总额；
                string sql1 = string.Format("select 产品名称,sum(今日市值) as 股票资产总额 from 绩效考核_股票每日交易汇总大表 where 时间 = '{0}' group by 产品名称 ", currentDayDate);
                Dictionary<string, double> DIC_产品名称_股票资产总额 = new Dictionary<string, double>();
                DataSet ds1 = DbHelperSQL.Query(sql1);
                if (ds1 != null)
                {
                    if (ds1.Tables.Count > 0)
                    {
                        DataTable tempTable = ds1.Tables[0];
                        foreach (DataRow row in tempTable.Rows)
                        {
                            double 股票资产总额 = 0;
                            string 产品名称 = row["产品名称"].ToString();
                            double.TryParse(row["股票资产总额"].ToString(), out 股票资产总额);
                            if (!DIC_产品名称_股票资产总额.ContainsKey(产品名称))
                            {
                                DIC_产品名称_股票资产总额.Add(产品名称, 股票资产总额);
                            }
                        }
                    }
                }
                #endregion
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string 产品名称 = row["产品名称"].ToString();
                    double 股票资产总额 = 0;
                    if (DIC_产品名称_股票资产总额.ContainsKey(产品名称))
                        股票资产总额 = DIC_产品名称_股票资产总额[产品名称];
                    AddtabPage(产品名称, DIC_产品名称_Model, 今年最大净值_DIC, modelList_是否包括止损指令, 股票资产总额);
                }
            }
        }

        private void AddtabPage(string name, Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> DIC_产品名称_Model,
            Dictionary<string, double> 今年最大净值_DIC, List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList_小表, double 股票资产总额)
        {
            System.Windows.Forms.TabPage tabPage1 = new TabPage();
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Name = name;
            //tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1465, 628);
            //tabPage1.TabIndex = 0;
            tabPage1.Text = name;
            tabPage1.UseVisualStyleBackColor = true;

            HistoryExchange_SubPanel subPanel1 = new HistoryExchange_SubPanel(name, this.dateTimePicker1.Value,
                this.tabControl1, DIC_产品名称_Model, 今年最大净值_DIC, modelList_小表, 股票资产总额);
            subPanel1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(subPanel1);

            this.tabControl1.Controls.Add(tabPage1);
            this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }

        /// <summary>
        /// 默认切换Tab时焦点直接定位至“资金余额”一栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control subsubctl in this.tabControl1.Controls)
            {
                TabPage page = subsubctl as TabPage;
                if (page != null)
                {
                    foreach (UserControl uc in page.Controls)
                    {
                        foreach (System.Windows.Forms.Control ctl in uc.Controls)
                        {
                            Panel tempPanel = ctl as Panel;
                            if (tempPanel != null)
                            {
                                foreach (System.Windows.Forms.Control subcontrol in tempPanel.Controls)
                                {
                                    TextBox txtBox = subcontrol as TextBox;
                                    if (txtBox != null)
                                    {
                                        if (txtBox.Name == "txt_资金余额")
                                        {
                                            txtBox.Focus();
                                            txtBox.SelectAll();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public enum NewOrCurrent
        {
            New, //最新价格
            Current //当前日期的价格
        }
        
        // private string GetAmericanCode(string code)
        // {
        //     string rst = code.ToUpper();
        //     foreach (var key in m_usa_code_map.Keys)
        //     {
        //         if (m_usa_code_map[key].Contains(rst))
        //         {
        //             rst += "." + key;
        //             break;
        //         }
        //     }            
        //     return rst;
        // }

        /// <summary>
        /// 获取当日收盘价
        /// </summary>
        /// <param name="今日大表Model"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private double GetClosePrice(Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model, string date)
        {

            string windCodes = string.Empty;
            string indicators, startTime, endTime, options;

            if (WindMain.Instance.IsAmericanCode(今日大表Model.股票代码))
            {
                windCodes = 今日大表Model.股票代码;
                
                // windCodes = GetAmericanCode(今日大表Model.股票代码);
            }
            else if (WindMain.Instance.IsChineseCode(今日大表Model.股票代码)) //股票6位为大陆股票，4位为港股
            {
                if (今日大表Model.股票代码.Substring(0, 1) == "6" || 今日大表Model.股票代码.Substring(0, 2) == "51")
                    //>6打头,51打头,后缀为SH上交
                    windCodes = 今日大表Model.股票代码 + ".SH";
                else //其他为sz 深交发行
                    windCodes = 今日大表Model.股票代码 + ".SZ";
            }
            else if (WindMain.Instance.IsHKCode(今日大表Model.股票代码))
            {
                windCodes = 今日大表Model.股票代码 + ".HK";
            } else {
                MessageBox.Show("无法识别的股票代码: " + 今日大表Model.股票代码);
                return 0;
            }

            LOG.Instance.Info("此次股票: " + windCodes);

            indicators = "close";
            startTime = date.Trim() + " 8:00:00";//开盘时间 9点
            endTime = date.Trim() + " 17:00:00"; //收盘时间 16点
            options = "Fill=Previous";

            WindData wd = new WindData();
            string strKey = string.Empty;
            if (m_Eum_NewOrCurrent == NewOrCurrent.New)
            {
                // wd = m_WindAPI.wsq(windCodes, "rt_last", options);
                wd = WindMain.Instance.GetNewClosePriceData(windCodes, options);
                strKey = "wsq";
            }
            else if (m_Eum_NewOrCurrent == NewOrCurrent.Current)
            {
                // wd = m_WindAPI.wsd(windCodes, indicators, startTime, endTime, options);
                wd = WindMain.Instance.GetCurrentClosePriceData(windCodes, indicators, startTime, endTime, options);
                strKey = "wsd";
            }
            if (wd.errorCode == 0) //0表示执行成功，负值表示执行失败
            {

                object[,] odata = (object[,])wd.getDataByFunc(strKey, false);
                double 市场现价 = 0;
                if (odata.Length >= 0)
                {
                    double.TryParse(string.Format("{0}", odata[0, 0]), out 市场现价);
                }

                LOG.Instance.Info("此次股票: " + windCodes + ",市场现价: " + Convert.ToString(市场现价)); //市场现价格 股票代码 开盘时间 收

                if (WindMain.Instance.IsAmericanCode(今日大表Model.股票代码)) {
                    市场现价 *= m_sell_CNY;
                }
                else if (WindMain.Instance.IsHKCode(今日大表Model.股票代码)) //如果为港股，则需要乘以当日汇率
                {
                    市场现价 = 市场现价 * m_卖出汇率;
                } 
                return 市场现价;
            } else {
                MessageBox.Show("获取市价失败: " + 今日大表Model.股票代码);
            }
            return 0;
        }


        private int m_生成记录数_增加 = 0;
        private int m_生成记录数_更新 = 0;

        // private WindAPI m_WindAPI = null;

        // private Dictionary<string, HashSet<string>> m_usa_code_map;

        //private Dictionary<string, string> m_usa_code_info_map;

        private double m_买入汇率 = 0;
        private double m_卖出汇率 = 0;

        private double m_buy_CNY = -1;

        private double m_sell_CNY = -1;

        private NewOrCurrent m_Eum_NewOrCurrent = NewOrCurrent.New;
        /// <summary>
        /// 先计算每个股票的基本信息，然后计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        public void btn_生成当日投资统计汇总_Click(object sender, EventArgs e)
        {
            m_Eum_NewOrCurrent = NewOrCurrent.Current;
            当日投资汇总Or最新投资汇总();
        }

        private void btn_生成最新汇总_Click(object sender, EventArgs e)
        {
            m_Eum_NewOrCurrent = NewOrCurrent.New;
            当日投资汇总Or最新投资汇总();
        }

        /// <summary>
        /// falg==true，最新
        /// flag==false，当日投资汇总
        /// </summary>
        /// <param name="flag"></param>
        private void 当日投资汇总Or最新投资汇总()
        {
            if (MessageBox.Show("确定生成当日投资统计汇总吗？", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                return;
            }
            ExecuteCurrentTJHZ(this.dateTimePicker1.Value); 
            InitializeControl();

            if (m_生成记录数_增加 + m_生成记录数_更新 > 0)
                MessageBox.Show(string.Format("“股票每日交易汇总大表”中增加“{0}”条记录，更新“{0}”条记录！", m_生成记录数_增加, m_生成记录数_更新), "系统提示");
            else
                MessageBox.Show("成功失败！", "系统提示");
        }

         
        public void ExecuteCurrentTJHZ(DateTime day)
        {
            string currentDayDate = day.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_大表股票 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_大表基金产品 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表ModelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            Maticsoft.BLL.绩效考核_基金产品信息表 基金产品信息表_BLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            Maticsoft.BLL.绩效考核_基金份额历史表 基金份额历史表_BLL = new Maticsoft.BLL.绩效考核_基金份额历史表();

            #region 已经生成过今日汇总并做过余额、的修改，再次生成时，需要保留上一次生成时的一些参数；
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 今日基金产品List = modelBLL_大表基金产品.GetModelList(string.Format(" 时间= '{0}'", currentDayDate));
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今日股票大表List = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));
            // List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今日股票大表_调整过持股数量和成本_List = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}' and 是否修改过持股数量和持股成本 = {1}", currentDayDate, 1));

            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今日股票大表_调整过持股数量和成本_List = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate ));

            Dictionary<string, Maticsoft.Model.绩效考核_基金产品每日统计> DIC_产品名称_产品每日统计 = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品每日统计>();

            foreach (Maticsoft.Model.绩效考核_基金产品每日统计 今日基金产品model in 今日基金产品List)
            {
                if (!DIC_产品名称_产品每日统计.ContainsKey(今日基金产品model.产品名称))
                {
                    DIC_产品名称_产品每日统计.Add(今日基金产品model.产品名称, 今日基金产品model);
                }
            }

            //默认不存储今日的“基金份额”、“申购赎回调整数” 
            //bool flag是否保留_基金份额_申购赎回调整数 = false;
            //if (今日基金产品List.Count > 0 && 今日股票大表List.Count > 0)
            //{
            //    if (MessageBox.Show("当日投资统计汇总已经有值，重新生成当日投资汇总统计是否保留已有的“基金份额”和“申购赎回调整数”？", "系统提示",
            //                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //    {
            //        flag是否保留_基金份额_申购赎回调整数 = true;
            //    }
            //}

            #endregion

            #region 现金替代物和未上市股票
            Dictionary<string, string> DIC_现金替代物 = new Dictionary<string, string>();
            Maticsoft.BLL.绩效考核_现金替代物信息表 modelBLL_现金替代物信息表 = new Maticsoft.BLL.绩效考核_现金替代物信息表();
            List<Maticsoft.Model.绩效考核_现金替代物信息表> 现金替代物List = modelBLL_现金替代物信息表.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_现金替代物信息表 model in 现金替代物List)
            {
                if (!DIC_现金替代物.ContainsKey(model.现金替代物代码))
                {
                    DIC_现金替代物.Add(model.现金替代物代码, model.现金替代物名称);
                }
            }

            Dictionary<string, string> DIC_未上市股票 = new Dictionary<string, string>();
            Maticsoft.BLL.绩效考核_未上市股票信息表 modelBLL_未上市股票 = new Maticsoft.BLL.绩效考核_未上市股票信息表();
            List<Maticsoft.Model.绩效考核_未上市股票信息表> 未上市股票List = modelBLL_未上市股票.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_未上市股票信息表 model in 未上市股票List)
            {
                if (!DIC_未上市股票.ContainsKey(model.股票代码))
                {
                    DIC_未上市股票.Add(model.股票代码, model.股票名称);
                }
            }
            #endregion

            #region 提示输入港币人民币汇率

            Maticsoft.BLL.绩效考核_汇率 绩效考核_汇率BLL = new Maticsoft.BLL.绩效考核_汇率();
            Maticsoft.Model.绩效考核_汇率 绩效考核_汇率Model = 绩效考核_汇率BLL.GetModel(currentDayDate);
            
            m_买入汇率 = 0;
            m_卖出汇率 = 0;
            if (绩效考核_汇率Model == null) //汇率表中不存在该记录；
            {
                //弹出输入框，允许用户输入汇率
                Input_汇率 frm = new Input_汇率(currentDayDate, " HK Stock Market");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m_买入汇率 = frm.港币人民币买入汇率;
                    m_卖出汇率 = frm.港币人民币卖出汇率;
                    绩效考核_汇率BLL.Add(new Maticsoft.Model.绩效考核_汇率(currentDayDate, m_买入汇率, m_卖出汇率));
                }
                else
                { //不选择年份，结束导入动作 
                    return;
                }
            }
            else//汇率表中存在该记录；
            {
                m_买入汇率 = 绩效考核_汇率Model.买入汇率;
                m_卖出汇率 = 绩效考核_汇率Model.卖出汇率;
                绩效考核_汇率BLL.Update(new Maticsoft.Model.绩效考核_汇率(currentDayDate, m_买入汇率, m_卖出汇率));
            }

            string amax_exchange_rate_key = currentDayDate + "_USA";
            Maticsoft.Model.绩效考核_汇率 amax_rate_model = 绩效考核_汇率BLL.GetModel(amax_exchange_rate_key);
            if (amax_rate_model == null) {
                //弹出输入框，允许用户输入汇率
                Input_美元汇率 frm = new Input_美元汇率(currentDayDate, " American Stock Market");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m_buy_CNY = frm.BuyCny;
                    m_sell_CNY = frm.SellCny;
                    绩效考核_汇率BLL.Add(new Maticsoft.Model.绩效考核_汇率(amax_exchange_rate_key, m_buy_CNY, m_sell_CNY));
                }
                else
                { //不选择年份，结束导入动作 
                    return;
                }                
            }
            else
            {
                m_buy_CNY = amax_rate_model.买入汇率;
                m_sell_CNY = amax_rate_model.卖出汇率;
                绩效考核_汇率BLL.Update(new Maticsoft.Model.绩效考核_汇率(amax_exchange_rate_key, m_buy_CNY, m_sell_CNY));                
            }
            #endregion

            //市场现价放在内存中，加快Wind获取市场现价（收盘价）的效率
            Dictionary<string, double> DIC_股票代码_市场现价 = new Dictionary<string, double>();
            RefreshJJCP_DIC();
            m_生成记录数_更新 = 0;
            m_生成记录数_增加 = 0;
            GetModelValue();
            //获取上一个交易日
            string yestoryDayDate = string.Empty;
            if (DayOfWeek.Monday == day.DayOfWeek) //今天为周一，上个交易日前移3天
                yestoryDayDate = day.AddDays(-3).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            else if (DayOfWeek.Sunday == day.DayOfWeek) //今天为周日，上个交易日前移2天
                yestoryDayDate = day.AddDays(-2).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            else    //否则前移一天
                yestoryDayDate = day.AddDays(-1).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> DIC_基金产品信息表 = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();
            List<Maticsoft.Model.绩效考核_基金产品信息表> 基金产品信息表_List = 基金产品信息表_BLL.GetModelList("");
            Dictionary<string, double> DIC_基金份额 = DataConvertor.Get_某时间点前的基金份额(currentDayDate);
            //将列表转化为字典，便于后面遍历；
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in 基金产品信息表_List)
            {
                //给基金产品修改基金份额；
                if (DIC_基金份额.ContainsKey(model.产品名称))
                    model.份额 = DIC_基金份额[model.产品名称];
                //增加到字典中
                if (!DIC_基金产品信息表.ContainsKey(model.产品名称))
                    DIC_基金产品信息表.Add(model.产品名称, model);
            }
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 昨天大表_resultList = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}'", yestoryDayDate));
            if (昨天大表_resultList.Count <= 0) //无相关记录，则弹出确认前一个交易日时间窗口
            {
                确认上个交易日日期frm frm = new 确认上个交易日日期frm(day);
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
                yestoryDayDate = frm.上个交易日日期.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                昨天大表_resultList = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}'", yestoryDayDate));
            }
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> 今天小表_resultList = 小表ModelBLL.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今天大表_resultList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();

            DIC_产品名称_基金份额 = DataConvertor.Get_某时间点前的基金份额(currentDayDate);
            if (昨天大表_resultList.Count <= 0)
            {
                if (MessageBox.Show("无上一个交易日投资统计汇总大表记录，生成今日投资统计汇总数据不准确，确定继续吗？", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
            }
            //清理上次计算的大表数据
            string sql1 = string.Format("delete from 绩效考核_股票每日交易汇总大表 where 时间 = '{0}'", currentDayDate);
            string sql2 = string.Format("delete from 绩效考核_基金产品每日统计 where 时间 = '{0}' ", currentDayDate);
            string sql3 = string.Format("delete from 绩效考核_基金经理净值贡献表 where 时间 = '{0}'", currentDayDate);
            int result = DbHelperSQL.ExecuteSql(sql1 + ";" + sql2 + ";" + sql3);

            bool Wind软件_Success = false;

            // #region 初始化Wind软件

            // if (m_WindAPI == null)
            // {
            //     try
            //     {
            //         m_WindAPI = new WindAPI();
            //         int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
            //         if (LogRet == 0)
            //         {
            //             if (!m_WindAPI.isconnected())
            //             {
            //                 MessageBox.Show("Wind软件接口读取失败", "系统提示");
            //                 //return;
            //             }
            //             Wind软件_Success = true;
            //         }
            //         else
            //         {
            //             MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
            //             // return;
            //         }

            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
            //         //  return;
            //     }
            // }
            // else
            // {
            //     if (!Wind软件_Success)
            //     {
            //         try
            //         {
            //             int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
            //             if (LogRet == 0)
            //             {
            //                 if (!m_WindAPI.isconnected())
            //                 {
            //                     MessageBox.Show("Wind软件接口读取失败", "系统提示");
            //                     //return;
            //                 }
            //                 Wind软件_Success = true;
            //             }
            //             else
            //             {
            //                 MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
            //                 // return;
            //             }
            //         }
            //         catch (Exception ex)
            //         {
            //             MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
            //             //  return;
            //         }
            //     }
            // }
            // if (!Wind软件_Success) //Wind软件未联通，则弹出提示
            // {
            //     if (MessageBox.Show("Wind软件接入失败，无法计算今日股市的“市场现价”，确定继续吗", "系统提示",
            //         MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            //     {
            //         return;
            //     }
            // } 
            // else
            // {
            //     InitAmericanCodeMap();
            // }
            // #endregion

            #region 增加  股票每日交易汇总大表 步骤1
            m_昨天大表_今日无交易_resultList.Clear();
            //默认将昨日大表中所有记录作为今日大表中无交易的记录；后面通过“Get昨日Model”函数，去掉今日有交易的记录，剩下昨日汇总表中今日无交易的记录；
            m_昨天大表_今日无交易_resultList.AddRange(昨天大表_resultList);

            #region 处理今日有交易的股票记录

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 今天小表model in 今天小表_resultList)
            {
                if (!DIC_产品名称_基金产品信息.ContainsKey(今天小表model.产品名称)) //added by qhc(20160108信息表中不存在的产品，不再生成该产品的数据)
                {
                    continue;
                }
                Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
                今日大表Model.今日汇总小表 = 今天小表model;
                今日大表Model.时间 = currentDayDate;
                今日大表Model.产品名称 = 今天小表model.产品名称;
                今日大表Model.基金经理 = 今天小表model.基金经理;
                今日大表Model.股票代码 = 今天小表model.股票代码;
                今日大表Model.股票名称 = 今天小表model.股票名称;
                今日大表Model.昨日汇总大表 = Get昨日Model(今日大表Model.产品名称, 今日大表Model.股票代码, 今日大表Model.基金经理);
                double 今日变化 = 今天小表model.今日买入股 - 今天小表model.今日卖出股;


                #region 计算“持股数量”、“持股成本”、“投资成本”

                //added by qhc（20160823）
                //flag 默认用户未调整过“持股数量”和“持股成本”
                bool flag = false;
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 今日股票大表_调整过持股数量和成本_List)
                {
                    if (今日大表Model.产品名称 == tempModel.产品名称 && 今日大表Model.基金经理 == tempModel.基金经理 && 今日大表Model.股票代码 == tempModel.股票代码)
                    {
                        // 用户调整过“持股数量”和“持股成本”，使用调整过的“持股数量”、“持股成本”、“投资成本”
                        flag = true;
                        今日大表Model.持股数量 = tempModel.持股数量;
                        今日大表Model.持股成本 = tempModel.持股成本;
                        今日大表Model.投资成本 = tempModel.投资成本;
                        break;
                    }
                }
                if (!flag)   // 用户未调整过“持股数量”和“持股成本”，则“持股数量”、“持股成本”、“投资成本”需要重新计算
                {
                    //“持股数量” 相当于小表中的“ 累计余股”
                    if (今日大表Model.昨日汇总大表 == null)
                        今日大表Model.持股数量 = 今日变化;
                    else
                        今日大表Model.持股数量 = 今日大表Model.昨日汇总大表.持股数量 + 今日变化;

                    if (今日大表Model.昨日汇总大表 != null)
                        今日大表Model.投资成本 = 今日大表Model.昨日汇总大表.投资成本 + 今天小表model.买入清算金额 - 今天小表model.今日卖出股 * 今日大表Model.昨日汇总大表.持股成本;
                    else
                        今日大表Model.投资成本 = 今天小表model.买入清算金额;

                    if (今日大表Model.持股数量 != 0)
                        今日大表Model.持股成本 = 今日大表Model.投资成本 / 今日大表Model.持股数量;
                }

                #endregion

                if (今日大表Model.昨日汇总大表 != null)
                {
                    // [QHC:ERROR] ?为何今日均价用昨日的投资成本除以昨日的持股数量？
                    if (今日大表Model.昨日汇总大表.持股数量 != 0)
                        今日大表Model.今日均价 = 今日大表Model.昨日汇总大表.投资成本 / 今日大表Model.昨日汇总大表.持股数量;
                }
                if (今日大表Model.股票名称 == "老板电器")
                {
 
                }
                if (DIC_股票代码_市场现价.ContainsKey(今日大表Model.股票代码)) //字典里存在，直接取字典里的数值
                {
                    今日大表Model.市场现价 = DIC_股票代码_市场现价[今日大表Model.股票代码];
                }
                else//字典里不存在，通过函数求取该值，并存放到字典中
                {
                    今日大表Model.市场现价 = Get市场现价(今日大表Model, Wind软件_Success, DIC_现金替代物, DIC_未上市股票);
                    DIC_股票代码_市场现价.Add(今日大表Model.股票代码, 今日大表Model.市场现价);
                }
                今日大表Model.今日市值 = 今日大表Model.持股数量 * 今日大表Model.市场现价;
                今日大表Model.浮盈浮亏 = 今日大表Model.今日市值 - 今日大表Model.投资成本;
                if (今日大表Model.投资成本 != 0)
                {
                    if (Math.Abs(今日大表Model.浮盈浮亏) < 0.0001) //若浮盈浮亏很小，则直接设置为0
                        今日大表Model.浮盈浮亏率 = 0;
                    else
                        今日大表Model.浮盈浮亏率 = 今日大表Model.浮盈浮亏 / 今日大表Model.投资成本;
                }

                //计算“当日盈亏”===20151104 当日盈亏(“实现盈亏”)= （卖出价格-投资成本）*股数 
                double temp今日卖出均价 = 0;
                if (今日大表Model.今日汇总小表.今日卖出股 != 0)
                {
                    temp今日卖出均价 = 今日大表Model.今日汇总小表.卖出清算金额 / 今日大表Model.今日汇总小表.今日卖出股;
                }
                if (今日大表Model.昨日汇总大表 != null)
                {
                    今日大表Model.当日盈亏 = (temp今日卖出均价 - 今日大表Model.昨日汇总大表.持股成本) * 今日大表Model.今日汇总小表.今日卖出股;
                }
                if (this.Update大表股票(今日大表Model, modelBLL_大表股票))
                    今天大表_resultList.Add(今日大表Model);
                //以下注释掉的字段等待计算完基金产品的统计信息后，再更新
                //private double _投资成本占比;
                //private double _市值占比; 
                //private double _本年净值贡献;   
            }
            #endregion

            #region add 20150815（处理今天没有交易的股票记录）
            // 20151001 今日无交易时，持股数量/持股成本/投资成本以及由三这个参数推导出的参数值不变，其他参数是变化的； 
            //20151010--今天没有交易的股票记录，是否不需要更新“今日盈亏”参数？？？？？？？？？
            for (int i = 0; i < m_昨天大表_今日无交易_resultList.Count; i++)
            {
                Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model = m_昨天大表_今日无交易_resultList[i];
                if (!DIC_产品名称_基金产品信息.ContainsKey(今日大表Model.产品名称)) //added by qhc(20160108信息表中不存在的产品，不再生成该产品的数据)
                {
                    continue;
                }

                //added by qhc（20160823）
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 今日股票大表_调整过持股数量和成本_List)
                {
                    if (今日大表Model.产品名称 == tempModel.产品名称 && 今日大表Model.基金经理 == tempModel.基金经理 && 今日大表Model.股票代码 == tempModel.股票代码)
                    {
                        今日大表Model.持股数量 = tempModel.持股数量;
                        今日大表Model.持股成本 = tempModel.持股成本;
                        今日大表Model.投资成本 = tempModel.投资成本;
                        break;
                    }
                }

                //added by qhc(20151119) ==昨日大表中卖空的股票，不再增加到今日大表中
                if (今日大表Model.持股数量 == 0)
                    continue;
                #region 给变化的参数重新赋值

                今日大表Model.时间 = currentDayDate;
                if (DIC_股票代码_市场现价.ContainsKey(今日大表Model.股票代码)) //字典里存在，直接取字典里的数值
                {
                    今日大表Model.市场现价 = DIC_股票代码_市场现价[今日大表Model.股票代码];
                }
                else//字典里不存在，通过函数求取该值，并存放到字典中
                {
                    今日大表Model.市场现价 = Get市场现价(今日大表Model, Wind软件_Success, DIC_现金替代物, DIC_未上市股票);
                    DIC_股票代码_市场现价.Add(今日大表Model.股票代码, 今日大表Model.市场现价);
                }
                //今日无交易时，“持股数量”、“持股成本” 不变
                今日大表Model.今日市值 = 今日大表Model.持股数量 * 今日大表Model.市场现价;
                今日大表Model.浮盈浮亏 = 今日大表Model.今日市值 - 今日大表Model.投资成本;
                if (今日大表Model.投资成本 != 0)
                {
                    if (Math.Abs(今日大表Model.浮盈浮亏) < 0.0001) //若浮盈浮亏很小，则直接设置为0
                        今日大表Model.浮盈浮亏率 = 0;
                    else
                        今日大表Model.浮盈浮亏率 = 今日大表Model.浮盈浮亏 / 今日大表Model.投资成本;
                }
                //今日无交易时，当日盈亏（即“实现盈亏”）=0
                今日大表Model.当日盈亏 = 0;
                #endregion

                if (this.Update大表股票(今日大表Model, modelBLL_大表股票))
                    今天大表_resultList.Add(今日大表Model);
            }
            #endregion

            #endregion

            #region 增加 基金产品每日统计  步骤2

            #region 今日有交易记录的产品

            //？？【QHC】疑问：基准日是什么时间？？？-- 上一年的最后一天为基准日 
            string 基准日_时间 = DataConvertor.Get最后一个交易日时间(day.Year - 1);
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品List = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 基准日_基金产品List = modelBLL_大表基金产品.GetModelList(string.Format(" 时间= '{0}'", 基准日_时间));
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 上一个交易日_基金产品List = modelBLL_大表基金产品.GetModelList_上一个交易日(currentDayDate);

            List<string> 今日有交易产品_List = new List<string>();
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
            {
                if (!今日有交易产品_List.Contains(model.产品名称))
                {
                    今日有交易产品_List.Add(model.产品名称);
                }
            }
            //时间=从今年年初到今天这个时间段内的最大净值；
            string thisYearStart = string.Format("{0}/01/01", day.Year.ToString());
            Dictionary<string, double> 今年最大净值_DIC = modelBLL_大表基金产品.Get_今年最大净值(thisYearStart, currentDayDate);

            foreach (string temp产品 in 今日有交易产品_List)
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
                基金产品Model.产品名称 = temp产品;

                //edit by qhc(20151008)从“绩效考核_基金产品信息表”中获取基金的份额； 
                if (DIC_产品名称_基金份额.ContainsKey(基金产品Model.产品名称))
                {
                    基金产品Model.基金份额 = DIC_产品名称_基金份额[基金产品Model.产品名称];
                }
                //if (flag是否保留_基金份额_申购赎回调整数) //已经有过计算，再次计算是保留第一次计算时使用的“基金份额”
                //{
                //    基金产品Model.基金份额 = DIC_产品名称_产品每日统计[基金产品Model.产品名称].基金份额;
                //}

                #region 基准日净值

                //=============默认取“绩效考核_基金产品管理表”中基金产品的基准日净值；==============//
                //= 如果不存在该基金产品，则取上一年12月31日存在的基金产品的单位净值作为基准日净值======// 
                if (DIC_基金产品信息表.ContainsKey(基金产品Model.产品名称))
                    基金产品Model.基准日净值 = DIC_基金产品信息表[基金产品Model.产品名称].基准日净值;
                else
                {
                    foreach (Maticsoft.Model.绩效考核_基金产品每日统计 tempModel in 基准日_基金产品List)
                    {
                        if (tempModel.产品名称 == 基金产品Model.产品名称)
                        {
                            基金产品Model.基准日净值 = tempModel.单位净值;
                            break;
                        }
                    }
                }

                #endregion

                #region 计算“资金余额”
                if (DIC_产品名称_产品每日统计.Count > 0)//已经存在今日记录
                {
                    if (DIC_产品名称_产品每日统计.ContainsKey(基金产品Model.产品名称))
                        基金产品Model.资金余额 = DIC_产品名称_产品每日统计[基金产品Model.产品名称].资金余额;
                }
                else//第一次计算，还不存在今日记录
                {
                    foreach (Maticsoft.Model.绩效考核_基金产品每日统计 上一个交易日_基金产品model in 上一个交易日_基金产品List)
                    {
                        if (上一个交易日_基金产品model.产品名称 == 基金产品Model.产品名称)
                        {
                            基金产品Model.资金余额 = 上一个交易日_基金产品model.资金余额;
                            break;
                        }
                    }
                }
                #endregion
                               
                基金产品Model.资产总额 = 基金产品Model.资金余额 + 今日市值_total / 10000.0;
                if (基金产品Model.基金份额 != 0)
                    基金产品Model.单位净值 = 基金产品Model.资产总额 / (基金产品Model.基金份额 / 10000.0);

                if (基金产品Model.基准日净值 != 0)
                    基金产品Model.今年收益率 = (基金产品Model.单位净值 / 基金产品Model.基准日净值 - 1).ToString();

                if (基金产品Model.产品名称 != "")
                {
                    double temp今年最大净值 = 0;
                    if (今年最大净值_DIC.ContainsKey(基金产品Model.产品名称))
                    {
                        temp今年最大净值 = 今年最大净值_DIC[基金产品Model.产品名称];
                    }
                    基金产品Model.今年最大净值 = DataConvertor.Get_今年最大净值(temp今年最大净值, 基金产品Model.单位净值, 基金产品Model.基准日净值);
                }

                if (基金产品Model.今年最大净值 != 0)
                {
                    基金产品Model.回撤率 = (基金产品Model.单位净值 / 基金产品Model.今年最大净值 - 1).ToString();
                }
                基金产品Model.时间 = currentDayDate;
                if (基金产品Model.资产总额 != 0)
                    基金产品Model.资金资产比例 = (基金产品Model.资金余额 / 基金产品Model.资产总额).ToString();

                if (this.Update基金产品(基金产品Model, modelBLL_大表基金产品))
                    基金产品List.Add(基金产品Model);
            }
            #endregion

            #region 今日无交易的产品，基金产品仍然沿用昨日的信息
            //从上一日基金产品中排除“今日有交易产品”，即“今日无交易产品” 
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 上一日_基金产品List = modelBLL_大表基金产品.GetModelList(string.Format(" 时间= '{0}'", yestoryDayDate));
            foreach (Maticsoft.Model.绩效考核_基金产品每日统计 上一日_基金产品 in 上一日_基金产品List)
            {
                Maticsoft.Model.绩效考核_基金产品每日统计 今日_基金产品 = 上一日_基金产品;
                今日_基金产品.时间 = currentDayDate;
                if (!今日有交易产品_List.Contains(今日_基金产品.产品名称))
                {
                    if (this.Update基金产品(今日_基金产品, modelBLL_大表基金产品))
                        基金产品List.Add(今日_基金产品);
                }
            }
            #endregion

            #region 管理该产品的基金经理将该产品下的所有股票卖空，则在股票大表中留下记录 added by qhc(20160120)
            //“绩效考核_股票每日交易汇总大表”中只需要保留“产品名称”、“基金经理”、“时间”、“个人净值贡献”
            Dictionary<string, List<string>> DIC_产品_基金经理List = DataConvertor.GetDictionary_产品_基金经理();

            //将今日增加过的“产品和基金经理”从字典中清理掉
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
            {
                if (DIC_产品_基金经理List.ContainsKey(model.产品名称))
                {
                    List<string> 基金经理List = DIC_产品_基金经理List[model.产品名称];
                    if (基金经理List.Contains(model.基金经理))
                    {
                        基金经理List.Remove(model.基金经理);
                    }
                    if (基金经理List.Count <= 0)
                        DIC_产品_基金经理List.Remove(model.产品名称);
                }
            }

            foreach (KeyValuePair<string, List<string>> keyValue in DIC_产品_基金经理List)
            {
                foreach (string temp基金经理 in keyValue.Value)
                {
                    Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
                    今日大表Model.产品名称 = keyValue.Key;
                    今日大表Model.基金经理 = temp基金经理;
                    今日大表Model.时间 = currentDayDate;
                    if (this.Update大表股票(今日大表Model, modelBLL_大表股票))
                        今天大表_resultList.Add(今日大表Model);
                }
            }

            #endregion

            #endregion

            #region 更新  股票每日交易汇总大表  步骤3

            //以下更新以下字段： 
            //private double _投资成本占比;
            //private double _市值占比;   

            //edit by qhc （20151010）--所有记录都需要更新以下参数（投资成本占比、市值占比、本年净值贡献）； 
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
                    model.投资成本占比 = 投资成本占比;

                    double 市值占比 = 0;
                    if (temp基金产品1.资产总额 != 0)
                        市值占比 = (model.今日市值 / temp基金产品1.资产总额) / 10000;
                    model.市值占比 = 市值占比;

                    modelBLL_大表股票.Update(model);
                }
              
            }

                      #endregion

           
            #region   "本年净值贡献" 步骤4
            //--由于净值贡献需要基金产品+基金经理购买股票情况的综合信息，因此放在最后单独计算
            string 计算期间_起始时间 = string.Format("{0}/01/01", day.Year);

            Maticsoft.BLL.绩效考核_申购赎回调整历史表 申购赎回调整历史表_BLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
            List<Maticsoft.Model.绩效考核_申购赎回调整历史表> 申购赎回调整历史表_modelList = 申购赎回调整历史表_BLL.GetModelList(string.Format(" 赎回时间 between '{0}' and '{1}'", 计算期间_起始时间, currentDayDate));

            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 基准日_股票每日交易汇总_resultList = modelBLL_大表股票.GetModelList(string.Format(" 时间 = '{0}'", 基准日_时间));
            if (基准日_股票每日交易汇总_resultList.Count <= 0)
            {
                MessageBox.Show(string.Format("基准日时间：“{0}”交易汇总大表无相关记录，“本年净值贡献”不能有效计算", 基准日_时间), "系统提示");
            }

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今天大表_resultList)
            { //[ADDED == ] 
                if (model.基金经理 != "" && model.时间 != "" && model.产品名称 != "")
                {  //added by qhc (绩效考核_基金经理净值贡献表 ) 

                    double 基金产品_基金份额 = 0;
                    foreach (Maticsoft.Model.绩效考核_基金产品每日统计 基金产品model in 基金产品List)
                    {
                        if (基金产品model.产品名称 == model.产品名称)
                        {
                            基金产品_基金份额 = 基金产品model.基金份额;
                            break;
                        }
                    }

                    // 计算“本年净值贡献” //今日的买卖盈亏和浮动盈亏都会对“本年净值贡献”有影响
                    model.本年净值贡献 = DataConvertor.Get_本年净值贡献(model.产品名称, model.基金经理, 计算期间_起始时间, currentDayDate, 基准日_时间, 申购赎回调整历史表_modelList, 基金产品_基金份额);

                    Maticsoft.Model.绩效考核_基金经理净值贡献表 model_基金经理净值贡献表 = new Maticsoft.Model.绩效考核_基金经理净值贡献表(model.基金经理, model.时间, model.产品名称, model.本年净值贡献);
                    if (modelBLL_基金经理净值贡献表.Exists(model.基金经理, model.时间, model.产品名称))
                    {
                        modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
                    }
                    else
                    {
                        modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
                    }
                }
            }

            #endregion
        }

        private bool Update大表股票(Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model,
                            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_大表股票)
        {
            bool flag = false;
            if (今日大表Model.产品名称 != "")
            {
                long maxID = modelBLL_大表股票.Exists(今日大表Model.股票代码, 今日大表Model.基金经理, 今日大表Model.产品名称, 今日大表Model.时间);
                if (maxID <= 0)
                { //今天没有交易，则增加交易记录
                    今日大表Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                    if (modelBLL_大表股票.Add(今日大表Model))
                    {
                        m_生成记录数_增加++;
                    }
                }
                else
                { //存在，则更新
                    今日大表Model.记录标识 = maxID;
                    if (modelBLL_大表股票.Update(今日大表Model))
                    {
                        m_生成记录数_更新++;
                    }
                }
                flag = true;
            }
            return flag;
        }

        private bool Update基金产品(Maticsoft.Model.绩效考核_基金产品每日统计 基金产品Model,
                           Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_大表基金产品)
        {
            if (DIC_产品名称_基金产品信息.ContainsKey(基金产品Model.产品名称)) //added by qhc(20160108信息表中不存在的产品，不再生成该产品的数据)
            {
                long maxID = modelBLL_大表基金产品.Exists(基金产品Model.产品名称, 基金产品Model.时间);
                if (maxID <= 0)
                { //不存在，则增加
                    基金产品Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                    if (modelBLL_大表基金产品.Add(基金产品Model))
                        return true;
                }
                else
                { //存在，则更新
                    基金产品Model.记录标识 = maxID;
                    if (modelBLL_大表基金产品.Update(基金产品Model))
                        return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 获取“市场现价”分为三种情况：
        /// （1）普通股票：市场现价为收盘价，只要当日的收盘价为0，则表示当日停盘，一直获取上一日的收盘价格，直到获取到不为0的收盘价为至；
        /// （2）现金替代物：市场现价为持股成本
        /// （3）未上市股票：先获取一次收盘价，若不为0，市场现价为收盘价（表示该股票已经上市）；否则市场现价为持股成本
        /// </summary>
        /// <param name="今日大表Model"></param>
        /// <param name="Wind软件_Success"></param>
        /// <param name="DIC_现金替代物"></param>
        /// <param name="DIC_未上市股票"></param>
        /// <returns></returns>
        private double Get市场现价(Maticsoft.Model.绩效考核_股票每日交易汇总大表 今日大表Model, bool Wind软件_Success,
            Dictionary<string, string> DIC_现金替代物, Dictionary<string, string> DIC_未上市股票)
        {
            int max = 0;
            double m_市场现价 = 0;
            #region 通过Wind软件开放的接口，获取市场现价（即股市每日的收盘价）

            //如果属于“现金替代物”，则等于输入的买入价格；否则通过Wind获取最新值
            if (DIC_现金替代物.ContainsKey(今日大表Model.股票代码))
            {
                m_市场现价 = 今日大表Model.持股成本;
            }
            else
            {
                if (Wind软件_Success) //Wind软件联通，以下操作有意义
                {
                    if (DIC_未上市股票.ContainsKey(今日大表Model.股票代码)) //未上市股票
                    {
                        m_市场现价 = GetClosePrice(今日大表Model, 今日大表Model.时间);
                        if (m_市场现价 == 0)
                            m_市场现价 = 今日大表Model.持股成本;
                    }
                    else //普通股票
                    {
                        m_市场现价 = GetClosePrice(今日大表Model, 今日大表Model.时间);
                        DateTime lastDayDate = this.dateTimePicker1.Value.AddDays(-1);
                        while (m_市场现价 == 0) //一直获取上一日的市场现价，直到获取到的市场现价不为0为止；
                        {
                            m_市场现价 = GetClosePrice(今日大表Model, lastDayDate.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                            if (m_市场现价 != 0)
                                break;
                            if (max > 5) //获取超过5次，则不再继续获取
                                break;
                            lastDayDate = lastDayDate.AddDays(-1);
                            max++;
                        }
                    }
                }
            }
            #endregion

            return m_市场现价;
        }

        /// <summary>
        /// 获取SubPanel中输入的数值
        /// </summary>
        private void GetModelValue()
        {
            基金产品每日统计_ModelList_From手动录入.Clear();

            foreach (System.Windows.Forms.Control subsubctl in this.tabControl1.Controls)
            {
                TabPage page = subsubctl as TabPage;
                if (page != null)
                {
                    Maticsoft.Model.绩效考核_基金产品每日统计 model = new Maticsoft.Model.绩效考核_基金产品每日统计();
                    model.产品名称 = page.Name;
                    foreach (UserControl uc in page.Controls)
                    {
                        foreach (System.Windows.Forms.Control ctl in uc.Controls)
                        {
                            Panel tempPanel = ctl as Panel;
                            if (tempPanel != null)
                            {
                                foreach (System.Windows.Forms.Control subcontrol in tempPanel.Controls)
                                {
                                    TextBox txtBox = subcontrol as TextBox;
                                    if (txtBox != null)
                                    {
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
                    基金产品每日统计_ModelList_From手动录入.Add(model);
                }  //if (page != null)

            }
        }

        //private Maticsoft.Model.绩效考核_基金产品每日统计 GetModelValueFromModelList(string 产品名称)
        //{
        //    foreach (Maticsoft.Model.绩效考核_基金产品每日统计 tempmodel in this.基金产品每日统计_ModelList_From手动录入)
        //    {
        //        if (tempmodel.产品名称 == 产品名称)
        //        {
        //            return tempmodel;
        //        }
        //    }
        //    return new Maticsoft.Model.绩效考核_基金产品每日统计();
        //}

        private List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> m_昨天大表_今日无交易_resultList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();

        /// <summary> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Maticsoft.Model.绩效考核_股票每日交易汇总大表 Get昨日Model(string 产品名称, string 股票代码, string 基金经理)
        {
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempmodel in m_昨天大表_今日无交易_resultList)
            {
                if (tempmodel.产品名称 == 产品名称 && tempmodel.股票代码 == 股票代码 && tempmodel.基金经理 == 基金经理)
                {
                    m_昨天大表_今日无交易_resultList.Remove(tempmodel);
                    return tempmodel;
                }
            }
            return null;
        }

        /// <summary>
        ///  “产品名称-产品信息”字典
        /// </summary>
        public static Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> DIC_产品名称_基金产品信息 = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();
        /// <summary>
        /// 产品名称-某时间段前的基金份额
        /// </summary>
        public static Dictionary<string, double> DIC_产品名称_基金份额 = new Dictionary<string, double>();

        /// <summary>
        /// 更新基金产品字典；
        /// </summary>
        private void RefreshJJCP_DIC()
        {
            DIC_产品名称_基金产品信息.Clear();
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList2 = modelBLL2.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金产品信息表 model in modelList2)
            {
                if (model.产品名称 != "")
                {
                    if (!DIC_产品名称_基金产品信息.ContainsKey(model.产品名称.Trim()))
                    {
                        DIC_产品名称_基金产品信息.Add(model.产品名称.Trim(), model);
                    }
                }
            }
        }

        private void btn_导入历史投资统计汇总总表格_Click(object sender, EventArgs e)
        {
            if (_IsProssesing)
            {
                MessageBox.Show("正在导入历史投资统计汇总。。。", "系统提示");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(btn_导入历史投资统计汇总总表格_EventHandler));
                thread.Start(new Paramter1(ofd.FileName, true));
            }
        }

        /// <summary>
        /// 是否执行中，“导入历史投资统计汇总总表格”
        /// false：执行完成或未执行
        /// true：执行中
        /// </summary>
        private bool _IsProssesing = false;

        private string m_当前导入的产品名称 = string.Empty;
        private int m_导入股票新增count = 0;
        private int m_导入股票更新count = 0;

        private int m_导入期货新增count = 0;
        private int m_导入期货更新count = 0;

        Maticsoft.BLL.绩效考核_股票每日交易汇总大表_格式不符 大表股票_格式不符modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表_格式不符();
        Maticsoft.BLL.绩效考核_基金产品每日统计_格式不符 大表基金产品_格式不符modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计_格式不符();

        private int m_未正确导入记录Count = 0;
        private List<DateTime> m_时间列表 = new List<DateTime>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="是否导入成果库"> 导入成果库True，导入临时库False</param>
        private void btn_导入历史投资统计汇总总表格_EventHandler(object paramerter)
        {
            Paramter1 para1 = paramerter as Paramter1;

            _IsProssesing = true;
            m_导入股票新增count = 0;
            m_导入股票更新count = 0;
            m_导入期货新增count = 0;
            m_导入期货更新count = 0;
            m_未正确导入记录Count = 0;
            m_时间列表.Clear();

            Dictionary<string, string> DIC_不计算税费集合 = DataConvertor.Get不计算税费集合();
            Maticsoft.BLL.临时缓存区_绩效考核_基金产品每日统计 临时缓存区_modelBLL_基金产品每日统计 = new Maticsoft.BLL.临时缓存区_绩效考核_基金产品每日统计();
            Maticsoft.BLL.临时缓存区_绩效考核_股票每日交易汇总大表 临时缓存区_modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.临时缓存区_绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.临时缓存区_绩效考核_基金经理净值贡献表 临时缓存区_modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.临时缓存区_绩效考核_基金经理净值贡献表();

            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_基金产品每日统计 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();


            #region 更新字典
            //更新“基金产品”字典；
            RefreshJJCP_DIC();
            //键为“基金产品”，值为“基金经理列表”，
            Dictionary<string, List<string>> 基金产品_基金经理列表_DIC = DataConvertor.DIC_基金产品_基金经理列表();
            //更新“股票信息”字典
            Dictionary<string, string> DockCodeName_DIC = DataConvertor.DIC_股票代码_股票名称();
            #endregion

            DataSet ds = ExcelReader.GetDataSetFromExcel(para1.Filename, 0);
            DataSet ds_允许有文字列 = ExcelReader.GetDataSetFromExcel(para1.Filename, 1);

            if (ds.Tables.Count <= 0)
            {
                _IsProssesing = false;
                return;
            }
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
            //？？【QHC】疑问：基准日是什么时间？？？-- 上一年的最后一天为基准日 
            string 基准日_时间 = DataConvertor.Get最后一个交易日时间(年_INT - 1);
            List<Maticsoft.Model.绩效考核_基金产品每日统计> 基准日_基金产品List = modelBLL_基金产品每日统计.GetModelList(string.Format(" 时间= '{0}'", 基准日_时间));

            for (int m = 0; m < ds.Tables.Count; m++)
            {
                DataTable table = ds.Tables[m];//已经自动去除了空行；在Excel基础上进行了处理，如小数为真实的位数
                DataTable table_允许有文字列 = ds_允许有文字列.Tables[m];//与Excel实际显示数据一致；小数只是显示的位数；
                if (table_允许有文字列.Rows.Count > 0) //除去第一行（为空行）
                    table_允许有文字列.Rows.RemoveAt(0);
                if (table_允许有文字列.Rows.Count != table.Rows.Count)
                    continue; //两个table行数不等，则不再继续执行 
                if (table.Rows.Count < 2) //只有一行或0行时，不再继续读取
                    continue;
                List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 股票每日交易汇总大表_modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
                Maticsoft.BLL.绩效考核_期货每日交易汇总大表 期货每日交易汇总大表_ModelBLL = new Maticsoft.BLL.绩效考核_期货每日交易汇总大表();

                #region 通过table文件名获取日期

                string oldName = table_允许有文字列.TableName;
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

                if (月_INT > 12 || 月_INT < 1 || 日_INT > 31 || 日_INT < 1)
                {
                    // LogOperator.WriteLogFile(string.Format("Excel中名称为“{0}”的工作表转换日期格式时失败,该工作表内容导入失败！",oldName));
                    MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
                    _IsProssesing = false;
                    return;
                }
                DateTime dt = new DateTime(年_INT, int.Parse(月), int.Parse(日));
                string currentDT = dt.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                m_时间列表.Add(dt);
                #endregion

                DIC_产品名称_基金份额 = DataConvertor.Get_某时间点前的基金份额(currentDT);
                //清理导入的当日不符合格式的临时缓存表记录
                int rows1 = DbHelperSQL.ExecuteSql(string.Format("delete from 绩效考核_基金产品每日统计_格式不符  where 时间= '{0}'", currentDT));
                int rows2 = DbHelperSQL.ExecuteSql(string.Format("delete from 绩效考核_股票每日交易汇总大表_格式不符  where 时间= '{0}'", currentDT));

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    DataRow row_允许有文字 = table_允许有文字列.Rows[i];

                    #region 股票行 ----[绩效考核_股票每日交易汇总大表]

                    if (row_允许有文字[0].ToString() == "代码" && row_允许有文字[1].ToString() == "名称")
                    {
                        continue;
                    }
                    else if (row_允许有文字[1].ToString() != "") //第二列，"名称"列有值，证明该行为股票行
                    {
                        if (row.ItemArray.Length < 13) continue;
                        Maticsoft.Model.绩效考核_股票每日交易汇总大表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();

                        model.时间 = currentDT;

                        #region  取 基金经理+股票名称

                        string 基金经理简称 = string.Empty;
                        if (row[1] != null && row[1].ToString() != "")
                        {
                            model.产品名称 = m_当前导入的产品名称;
                            string row1 = row[1].ToString().Trim().Replace(" ", "");
                            if (row1.Contains("（") || row1.Contains("("))
                            {
                                string[] Str_Array = row1.ToString().Split(new char[] { '（', '(' });
                                if (Str_Array.Length == 1) //（徐）
                                {
                                    基金经理简称 = Str_Array[0].Substring(0, 1);
                                }
                                else if (Str_Array.Length > 1) //东江环保（徐）
                                {
                                    model.股票名称 = Str_Array[0];
                                    基金经理简称 = Str_Array[1].Substring(0, 1);
                                }
                            }
                            else
                            {
                                if (row1.Length == 1) //徐 == 只有姓名
                                {
                                    基金经理简称 = row1;
                                }
                                else //东江环保 ==只有产品名称
                                {
                                    model.股票名称 = row1;
                                }
                            }
                        }
                        //若基金经理有简称，则直接通过字典查找全程；否则可通过基金产品查询对应的基金经理
                        if (基金经理简称.Length >= 1)
                        {
                            if (MainFrm.JIJINJINGLI_DIC.ContainsKey(基金经理简称))
                                model.基金经理 = MainFrm.JIJINJINGLI_DIC[基金经理简称];
                        }
                        else //edit by qhc(20151014)
                        {
                            if (基金产品_基金经理列表_DIC.ContainsKey(model.产品名称))
                            {
                                model.基金经理 = 基金产品_基金经理列表_DIC[model.产品名称][0];
                            }
                            else
                                model.基金经理 = string.Empty;
                        }
                        #endregion

                        #region 取股票代码，股票代码经常不够4位或6位，因此需要补位
                        // //edit by qhc （20151009）
                        if (row[0] != null && row[0].ToString() != "")
                        {
                            string temp股票代码 = row[0].ToString().Trim();

                            #region 期货
                            if (temp股票代码.Contains("IF"))
                            {
                                Maticsoft.Model.绩效考核_期货每日交易汇总大表 期货每日交易汇总Model = new Maticsoft.Model.绩效考核_期货每日交易汇总大表();
                                期货每日交易汇总Model.产品名称 = m_当前导入的产品名称;
                                期货每日交易汇总Model.时间 = currentDT;
                                期货每日交易汇总Model.基金经理 = "";
                                期货每日交易汇总Model.期货代码 = temp股票代码;
                                if (row[1] != null && row[1].ToString() != "")
                                {
                                    期货每日交易汇总Model.期货名称 = row[1].ToString().Trim();
                                }
                                double 卖持量, 卖持仓成本, 市场现价_期货, 合约成本, 持仓保证金, 当日盈亏_期货, 总盈亏;
                                if (row[2] != null && row[2].ToString() != "")
                                {
                                    double.TryParse(row[2].ToString(), out 卖持量);
                                    期货每日交易汇总Model.卖持量 = 卖持量;
                                }
                                if (row[3] != null && row[3].ToString() != "")
                                {
                                    double.TryParse(row[3].ToString(), out 卖持仓成本);
                                    期货每日交易汇总Model.卖持仓成本 = 卖持仓成本;
                                }
                                if (row[4] != null && row[4].ToString() != "")
                                {
                                    double.TryParse(row[4].ToString(), out 市场现价_期货);
                                    期货每日交易汇总Model.市场现价 = 市场现价_期货;
                                }
                                if (row[5] != null && row[5].ToString() != "")
                                {
                                    double.TryParse(row[5].ToString(), out 合约成本);
                                    期货每日交易汇总Model.合约成本 = 合约成本;
                                }
                                if (row[6] != null && row[6].ToString() != "")
                                {
                                    double.TryParse(row[6].ToString(), out 持仓保证金);
                                    期货每日交易汇总Model.持仓保证金 = 持仓保证金;
                                }
                                if (row[7] != null && row[7].ToString() != "")
                                {
                                    double.TryParse(row[7].ToString(), out 当日盈亏_期货);
                                    期货每日交易汇总Model.当日盈亏 = 当日盈亏_期货;
                                }
                                if (row[8] != null && row[8].ToString() != "")
                                {
                                    double.TryParse(row[8].ToString(), out 总盈亏);
                                    期货每日交易汇总Model.总盈亏 = 总盈亏;
                                }
                                long maxID = 期货每日交易汇总大表_ModelBLL.Exists(期货每日交易汇总Model.期货代码,
                                    期货每日交易汇总Model.基金经理, 期货每日交易汇总Model.产品名称, 期货每日交易汇总Model.时间);
                                if (maxID < 0)
                                {//不存在记录，则 增加 
                                    期货每日交易汇总Model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_期货每日交易汇总大表");
                                    if (期货每日交易汇总大表_ModelBLL.Add(期货每日交易汇总Model))
                                        m_导入期货新增count++;
                                }
                                else
                                {//存在记录，则更新
                                    期货每日交易汇总Model.记录标识 = maxID;
                                    if (期货每日交易汇总大表_ModelBLL.Update(期货每日交易汇总Model))
                                        m_导入期货更新count++;
                                }
                                continue;

                            }
                            #endregion

                            #region 股票
                            else
                            {
                                model.股票代码 = DataConvertor.Get标准化股票代码(temp股票代码, model.股票名称, DockCodeName_DIC);
                            }
                            #endregion
                        }
                        #endregion

                        //added by qhc(20151114) ==现金替代物，未上市股票，两种情况下没对应的基金经理
                        if (DIC_不计算税费集合.ContainsKey(model.股票代码))
                            model.基金经理 = string.Empty;

                        if (model.股票名称.Contains("GC") || model.股票代码.Contains("GC") || model.股票代码 == "204001")
                            continue;
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
                        {
                            string str = row[8].ToString().Trim();
                            model.投资成本占比 = this.Get带百分号的实际值_Double(str);
                        }
                        if (row[9] != null && row[9].ToString() != "")
                        {
                            string str = row[9].ToString().Trim();
                            model.市值占比 = this.Get带百分号的实际值_Double(str);
                        }
                        if (row[10] != null && row[10].ToString() != "")
                        {
                            string str = row[10].ToString().Trim();
                            model.浮盈浮亏率 = this.Get带百分号的实际值_Double(str);
                        }

                        #region 存储“本年净值贡献”

                        double 本年净值贡献 = 0;
                        if (row[11] != null && row[11].ToString() != "")
                        {
                            double.TryParse(row[11].ToString(), out 本年净值贡献);
                            model.本年净值贡献 = 本年净值贡献;
                        }
                        if (本年净值贡献 != 0)
                        {
                            if (model.基金经理 != "" && currentDT != "" && m_当前导入的产品名称 != "")
                            {
                                Maticsoft.Model.绩效考核_基金经理净值贡献表 model_基金经理净值贡献表 = new Maticsoft.Model.绩效考核_基金经理净值贡献表(model.基金经理, currentDT, m_当前导入的产品名称, model.本年净值贡献);
                                if (para1.Flag)
                                {
                                    if (modelBLL_基金经理净值贡献表.Exists(model.基金经理, currentDT, m_当前导入的产品名称))
                                    {
                                        modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
                                    }
                                    else
                                    {
                                        modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
                                    }
                                }
                                else
                                {
                                    if (临时缓存区_modelBLL_基金经理净值贡献表.Exists(model.基金经理, currentDT, m_当前导入的产品名称))
                                    {
                                        临时缓存区_modelBLL_基金经理净值贡献表.Update(model_基金经理净值贡献表);
                                    }
                                    else
                                    {
                                        临时缓存区_modelBLL_基金经理净值贡献表.Add(model_基金经理净值贡献表);
                                    }
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
                        #region 剔除重复值

                        //=====added by qhc(20151022),解决同一个产品下，基金经理和股票名称一致时，将持股数据和成本加和======//
                        bool isExist = false;
                        foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 oldModel in 股票每日交易汇总大表_modelList)
                        {
                            if (oldModel.产品名称 == model.产品名称 && oldModel.基金经理 == model.基金经理 && oldModel.股票代码 == model.股票代码)
                            {
                                oldModel.持股数量 += model.持股数量;
                                oldModel.投资成本 += model.投资成本;
                                if (oldModel.持股数量 != 0)
                                    oldModel.持股成本 = oldModel.投资成本 / oldModel.持股数量;

                                oldModel.今日市值 = oldModel.持股数量 * oldModel.市场现价;
                                oldModel.浮盈浮亏 = oldModel.今日市值 - oldModel.投资成本;
                                if (oldModel.投资成本 != 0)
                                    oldModel.浮盈浮亏率 = oldModel.浮盈浮亏 / oldModel.投资成本;

                                //最新调整===20151104 当日盈亏(“实现盈亏”)= （卖出价格-投资成本）*股数 
                                if (oldModel.昨日汇总大表 != null && oldModel.今日汇总小表 != null)
                                {
                                    double temp今日卖出均价 = 0;
                                    if (oldModel.今日汇总小表.今日卖出股 != 0)
                                    {
                                        temp今日卖出均价 = oldModel.今日汇总小表.卖出清算金额 / oldModel.今日汇总小表.今日卖出股;
                                    }
                                    oldModel.当日盈亏 = (temp今日卖出均价 - oldModel.昨日汇总大表.持股成本) * oldModel.今日汇总小表.今日卖出股;
                                }

                                oldModel.投资成本占比 += model.投资成本占比;
                                oldModel.市值占比 += model.市值占比;
                                //本年净值贡献 不需要调整 
                                isExist = true;
                                break;
                            }
                        }
                        if (!isExist)
                            股票每日交易汇总大表_modelList.Add(model);

                        #endregion
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
                    else if (row_允许有文字[2].ToString() == "资产总额")  // && row[4].ToString() == "资金余额")
                    {
                        if (table.Columns.Count < 12) continue;

                        Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        if (row[0] != null || row[0].ToString() != "")
                        {
                            model1.产品名称 = row[0].ToString();
                            m_当前导入的产品名称 = model1.产品名称;
                            if (DIC_产品名称_基金份额.ContainsKey(model1.产品名称))
                            {
                                model1.基金份额 = DIC_产品名称_基金份额[model1.产品名称];
                            }

                            #region 基准日净值 //edit by qhc(20160110)
                            if (System.DateTime.Now.Year != 年_INT)
                            //导入不是今年的数据，则通过函数取基准日净值，因为“绩效考核_基金产品信息表”中存储的基准日净值，是相对于今年的
                            {
                                foreach (Maticsoft.Model.绩效考核_基金产品每日统计 基准日Model in 基准日_基金产品List)
                                {
                                    if (基准日Model.产品名称 == model1.产品名称)
                                    {
                                        model1.基准日净值 = 基准日Model.单位净值;
                                        break;
                                    }
                                }
                                if (model1.基准日净值 == 0) //如果未取到“基准日净值”，则取今年第一次出现的单位净值作为基准日净值；
                                {
                                    string 今年第一个交易日时间 = string.Format("{0}/01/01", 年_INT);
                                    model1.基准日净值 = modelBLL_基金产品每日统计.Get指定时间段内第一次出现该产品的单位净值(今年第一个交易日时间, currentDT, model1.产品名称);
                                }
                            }
                            else //先从“绩效考核_基金产品信息表”取基准日净值，若不存在该基金产品记录，则从“绩效考核_基金产品每日统计”上一年最后一个交易日取基准日净值
                            {
                                if (DIC_产品名称_基金产品信息.ContainsKey(model1.产品名称))
                                    model1.基准日净值 = DIC_产品名称_基金产品信息[model1.产品名称].基准日净值;
                                else
                                {
                                    foreach (Maticsoft.Model.绩效考核_基金产品每日统计 基准日Model in 基准日_基金产品List)
                                    {
                                        if (基准日Model.产品名称 == model1.产品名称)
                                        {
                                            model1.基准日净值 = 基准日Model.单位净值;
                                            break;
                                        }
                                    }
                                }
                            }
                            #endregion
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
                            string str = row[7].ToString().Trim();
                            model1.资金资产比例 = this.Get带百分号的实际值_String(str);
                        }
                        model1.时间 = currentDT;

                        #region 正规基金产品（今年收益率+ 单位净值 ，同时出现在一行）

                        if (row_允许有文字[8].ToString() == "今年收益率" && row_允许有文字[10].ToString() == "单位净值")
                        {
                            if (row[9] != null && row[9].ToString() != "")
                            {
                                model1.今年收益率 = this.Get带百分号的实际值_String(row[9].ToString().Trim());
                            }
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double 单位净值 = 0;
                                double.TryParse(row[11].ToString(), out 单位净值);
                                model1.单位净值 = 单位净值;
                            }
                        }

                        #endregion

                        #region 一行中有“今年收益率”参数，无“单位净值”参数，“今年收益率”和其值间隔两列
                        else if (row_允许有文字[8].ToString() == "今年收益率" && row_允许有文字[10].ToString() != "单位净值")
                        {
                            if (row[9] != null && row[9].ToString() != "")
                            {
                                model1.今年收益率 = this.Get带百分号的实际值_String(row[9].ToString().Trim());
                            }
                            //added by qhc（20151125）-针对有“今年收益率”文字和数值有的错行，有的没有错行情况
                            if (row[9].ToString().Trim() == "")
                            {
                                model1.今年收益率 = this.Get带百分号的实际值_String(row[10].ToString().Trim());
                            }
                        }
                        #endregion

                        #region 一行中有“单位净值”参数，无“今年收益率”参数，“单位净值”和其值间隔一列
                        else if (row_允许有文字[8].ToString() != "今年收益率" && row_允许有文字[10].ToString() == "单位净值")
                        {
                            double 单位净值 = 0;
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString(), out 单位净值);
                                model1.单位净值 = 单位净值;
                            }
                        }
                        #endregion

                        #region added by qhc(20160110)
                        if (model1.基准日净值 == 0) //历史上未出现过该基金产品，基准日净值就是今日的单位净值
                        {
                            if (model1.单位净值 != 0)
                                model1.基准日净值 = model1.单位净值;
                        }
                        #endregion
                        if (para1.Flag) //导入至产品库中；
                        {   //时间 、 产品名称不允许导入,如果为空，则写入至临时库中 
                            if (model1.产品名称.Trim() != "" || model1.时间 == "")
                            {
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
                            else //不符合规范数据，added by qhc（20151221）
                            {
                                model1.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计_格式不符");
                                if (大表基金产品_格式不符modelBLL.Add(model1))
                                    m_未正确导入记录Count++;
                            }
                        }
                        else //导入至临时库中；
                        { //时间 、 产品名称不允许导入,如果为空，则写入至临时库中 
                            if (model1.产品名称.Trim() != "" || model1.时间 == "")
                            {
                                long maxID = 临时缓存区_modelBLL_基金产品每日统计.Exists(model1.产品名称, model1.时间);
                                if (maxID < 0)
                                {//不存在记录，则 增加 
                                    model1.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "临时缓存区_绩效考核_基金产品每日统计");
                                    临时缓存区_modelBLL_基金产品每日统计.Add(model1);
                                }
                                else
                                {//存在记录，则更新
                                    model1.记录标识 = maxID;
                                    临时缓存区_modelBLL_基金产品每日统计.Update(model1);
                                }
                            }
                            else //不符合规范数据，added by qhc（20151221）
                            {
                                model1.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计_格式不符");
                                if (大表基金产品_格式不符modelBLL.Add(model1))
                                    m_未正确导入记录Count++;
                            }
                        }

                    }
                    #endregion

                    #region "股票资产总额"行， 可更新

                    else if (row_允许有文字[2].ToString() == "股票资产总额")  // && row[4].ToString() == "资金余额")
                    {
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
                            string str = row[7].ToString().Trim();
                            model1.资金资产比例 = this.Get带百分号的实际值_String(str);
                        }
                        if (row_允许有文字[8].ToString() == "今年收益率")
                        {
                            if (row[10] != null && row[10].ToString() != "")
                            {
                                model1.今年收益率 = this.Get带百分号的实际值_String(row[10].ToString().Trim());
                            }
                        }
                        if (para1.Flag)
                        {
                            modelBLL_基金产品每日统计.UpdatePatial2(model1);
                        }
                        else
                        {
                            临时缓存区_modelBLL_基金产品每日统计.UpdatePatial2(model1);
                        }

                    }
                    #endregion

                    #region "期货资产总额"行， 可更新

                    else if (row_允许有文字[2].ToString() == "期货资产总额")
                    {
                        if (table.Columns.Count < 12) continue;

                        Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        model1.产品名称 = m_当前导入的产品名称;
                        model1.时间 = currentDT;

                        double 期货资产总额 = 0;
                        double 期货资金余额 = 0;
                        double 期货今年收益率 = 0;
                        if (row[3] != null && row[3].ToString() != "")
                        {
                            double.TryParse(row[3].ToString(), out 期货资产总额);
                            model1.期货资产总额 = 期货资产总额;
                        }
                        if (row[5] != null && row[5].ToString() != "")
                        {
                            double.TryParse(row[5].ToString(), out 期货资金余额);
                            model1.期货资金余额 = 期货资金余额;
                        }
                        if (row_允许有文字[8].ToString() == "今年收益率")
                        {
                            if (row[10] != null && row[10].ToString() != "")
                            {
                                double.TryParse(row[10].ToString(), out 期货今年收益率);
                                model1.期货今年收益率 = 期货今年收益率;
                            }
                        }
                        if (para1.Flag)
                            modelBLL_基金产品每日统计.UpdatePatial_期货资产(model1);
                        else
                            临时缓存区_modelBLL_基金产品每日统计.UpdatePatial_期货资产(model1);
                    }
                    #endregion

                    #region “今年最高净值（今年最大净值）”+“回撤率” 行

                    if (row_允许有文字[8].ToString() == "今年最大净值" || row_允许有文字[8].ToString() == "今年最高净值")
                    {
                        double 今年最大净值 = 0;
                        double.TryParse(row[9].ToString(), out 今年最大净值);
                        Maticsoft.Model.绩效考核_基金产品每日统计 tempModel = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        tempModel.产品名称 = m_当前导入的产品名称;
                        tempModel.时间 = currentDT;
                        tempModel.今年最大净值 = 今年最大净值;
                        tempModel.回撤率 = this.Get带百分号的实际值_String(row[11].ToString().Trim());
                        if (para1.Flag)
                            modelBLL_基金产品每日统计.UpdatePatial(tempModel);
                        else
                            临时缓存区_modelBLL_基金产品每日统计.UpdatePatial(tempModel);
                    }
                    #endregion

                    #region  存在“今年盈亏金额”行

                    if (row_允许有文字[4].ToString() == "资金余额" && row_允许有文字[10].ToString() == "今年盈亏金额")
                    {
                        Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                        model1.产品名称 = m_当前导入的产品名称;
                        model1.时间 = currentDT;

                        double 资金余额 = 0;
                        double 今年最大净值 = 0;
                        if (row[5] != null && row[5].ToString() != "")
                        {
                            double.TryParse(row[5].ToString().Trim(), out 资金余额);
                            model1.资金余额 = 资金余额;
                        }
                        if (row[7] != null && row[7].ToString() != "")
                        {
                            string str = row[7].ToString().Trim();
                            model1.资金资产比例 = this.Get带百分号的实际值_String(str);
                        }
                        if (row[8] != null && row[8].ToString() != "")
                        {
                            double.TryParse(row[8].ToString().Trim(), out 今年最大净值);
                            model1.今年最大净值 = 今年最大净值;
                        }
                        if (para1.Flag)
                            modelBLL_基金产品每日统计.UpdatePatial3(model1);
                        else
                            临时缓存区_modelBLL_基金产品每日统计.UpdatePatial3(model1);
                    }
                    #endregion

                    #endregion

                }//读取完成Excel内容

                #region edit by qhc(20151022) ===更新“股票每日交易汇总大表”
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 股票每日交易汇总大表_modelList)
                {
                    if (model.产品名称 != "")  //符合规范
                    {
                        if (model.持股数量 != 0 && model.股票代码 == "")  //股票未卖空，但是股票代码为空，这是明显不符合规范
                        { //不符合规范数据，added by qhc（20151221）
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表_格式不符");
                            if (大表股票_格式不符modelBLL.Add(model))
                                m_未正确导入记录Count++;
                        }
                        else
                        {
                            if (para1.Flag)
                            {
                                long maxID = modelBLL_股票每日交易汇总大表.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                                if (maxID < 0)
                                {//不存在记录，则 增加 
                                    model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                                    if (modelBLL_股票每日交易汇总大表.Add(model))
                                        m_导入股票新增count++;
                                }
                                else
                                {//存在记录，则更新
                                    model.记录标识 = maxID;
                                    if (modelBLL_股票每日交易汇总大表.Update(model))
                                        m_导入股票更新count++;
                                }
                            }
                            else
                            {
                                long maxID = 临时缓存区_modelBLL_股票每日交易汇总大表.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                                if (maxID < 0)
                                {//不存在记录，则 增加 
                                    model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "临时缓存区_绩效考核_股票每日交易汇总大表");
                                    if (临时缓存区_modelBLL_股票每日交易汇总大表.Add(model))
                                        m_导入股票新增count++;
                                }
                                else
                                {//存在记录，则更新
                                    model.记录标识 = maxID;
                                    if (临时缓存区_modelBLL_股票每日交易汇总大表.Update(model))
                                        m_导入股票更新count++;
                                }
                            }
                        }
                    }
                    else //不符合规范数据，added by qhc（20151221）
                    {
                        model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表_格式不符");
                        if (大表股票_格式不符modelBLL.Add(model))
                            m_未正确导入记录Count++;
                    }
                }
                #endregion

            } //  for (int m = 0; m < ds.Tables.Count; m++)

            //刷新显示记录-不能使用，独立线程操作控件会报错误；
            //InitializeControl(); 
            _IsProssesing = false;

            if (m_导入股票新增count + m_导入股票更新count > 0)
            {
                string contentText = string.Format("导入完成,“股票每日交易汇总大表”中新增“{0}”条记录，更新“{1}”条记录 \n\r “期货每日交易汇总大表”中新增“{2}”条记录，更新“{3}”条记录\n\r ",
                                                    m_导入股票新增count, m_导入股票更新count, m_导入期货新增count, m_导入期货更新count);
                if (m_未正确导入记录Count > 0)
                {
                    contentText = string.Format(contentText + "未正确导入的记录有“{0}”条，确定查看未正确导入的记录吗？", m_未正确导入记录Count);
                    ShowDialog(contentText);
                }
                else
                {
                    MessageBox.Show(contentText, "系统提示");
                }
            }
            else
            {
                if (m_未正确导入记录Count > 0)
                {
                    string contentText = string.Format("导入失败！未正确导入的记录有“{0}”条，确定查看未正确导入的记录吗？", m_未正确导入记录Count);
                    ShowDialog(contentText);
                }
                else
                {
                    MessageBox.Show("导入失败！", "系统提示");
                }
            }
        }

        private void ShowDialog(string contentText)
        {
            if (MessageBox.Show(contentText, "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_时间列表.Sort();
                if (m_时间列表.Count == 1)
                {
                    CurrentDayExchangeListCtl_大表未导入 frm = new CurrentDayExchangeListCtl_大表未导入(m_时间列表[0], m_时间列表[0]);
                    frm.ShowDialog();
                }
                else if (m_时间列表.Count > 1)
                {
                    CurrentDayExchangeListCtl_大表未导入 frm = new CurrentDayExchangeListCtl_大表未导入(m_时间列表[0], m_时间列表[m_时间列表.Count - 1]);
                    frm.ShowDialog();
                }
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_导出当日投资统计汇总总表格_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("{0}年{1}月{2}日投资汇总.xlsx", this.dateTimePicker1.Value.Year.ToString(),
                                          this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                string sheetName = string.Format("{0}月{1}日", this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());

                Maticsoft.BLL.绩效考核_基金产品每日统计 基金产品_modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
                Maticsoft.BLL.绩效考核_股票每日交易汇总大表 股票汇总大表_modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
                Maticsoft.BLL.绩效考核_期货每日交易汇总大表 期货汇总大表_modelBLL = new Maticsoft.BLL.绩效考核_期货每日交易汇总大表();
                Maticsoft.BLL.绩效考核_基金经理净值贡献表 绩效考核_基金经理净值贡献表_modelBLL = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();

                List<Maticsoft.Model.绩效考核_基金产品每日统计> 基金产品_modelList = 基金产品_modelBLL.GetModelList(string.Format(" 时间 = '{0}' ", currentDayDate));
                List<Maticsoft.Model.绩效考核_基金经理净值贡献表> 绩效考核_基金经理净值贡献表_modelList = 绩效考核_基金经理净值贡献表_modelBLL.GetModelList(string.Format(" 时间 = '{0}' ", currentDayDate));
                Dictionary<string, List<string>> DIC_产品_基金经理List = DataConvertor.GetDictionary_产品_基金经理();

                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();

                //创建一个工作簿
                string name = string.Format("{0}月{1}日", this.dateTimePicker1.Value.Month.ToString(), this.dateTimePicker1.Value.Day.ToString());
                excelEdit.CreateWorkSheet(name);

                //总列数
                int columnsCount = 13;
                //当前行 
                int currentRow = 1;
                //第一行写日期(A-M共有13列数据) 
                excelEdit.WriteData(currentDayDate, 1, 1);
                excelEdit.FontStyle(1, 1, 1, 1, true, false, UnderlineStyle.无下划线);
                #region // ==========以产品为循环单元，循环写入 (开始) ==========//

                #region 对输出产品排序；edit by qhc 20151009
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
                #endregion

                for (int i = 0; i < ordered_基金产品_modelList.Count; i++)
                {
                    Maticsoft.Model.绩效考核_基金产品每日统计 model = ordered_基金产品_modelList[i];
                    //add 基金产品类型判断（20151124）
                    bool 股票期货混合型产品 = false;
                    if (model.产品名称 == "自营" || model.产品名称 == "量化一号")
                    {
                        股票期货混合型产品 = true;
                    }

                    #region  增加二行，写入基金产品信息

                    if (股票期货混合型产品)
                    {
                        #region 第一行
                        currentRow = currentRow + 1;
                        // 设置字体加粗 + 背景色（灰色） 
                        excelEdit.FontStyle(currentRow, 1, currentRow + 1, columnsCount, true, false, UnderlineStyle.无下划线);
                        excelEdit.SetRangeBackground(currentRow, 1, currentRow + 1, columnsCount, Color.FromArgb(0, 165, 165, 165));

                        //第一、二列----合并单元格+调整背景色（黄色） 
                        excelEdit.CellsUnite(currentRow, 1, currentRow, 2, model.产品名称);
                        excelEdit.SetRangeBackground(currentRow, 1, currentRow, 2, Color.Yellow);

                        //第三、四列  
                        excelEdit.WriteData("资产总额", currentRow, 3);
                        excelEdit.WriteData(model.资产总额.ToString(), currentRow, 4);
                        excelEdit.setCells_NumberFormat(currentRow, 4, currentRow, 4, 2);

                        excelEdit.WriteData("单位净值", currentRow, 11);
                        excelEdit.WriteData(model.单位净值.ToString(), currentRow, 12);
                        excelEdit.setCells_NumberFormat(currentRow, 12, currentRow, 12, 4);
                        // 调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 12, currentRow, 12, Color.Yellow);
                        excelEdit.WriteData("当日盈亏", currentRow, 13);

                        #endregion

                        #region 第二行

                        currentRow = currentRow + 1;
                        //第一列
                        excelEdit.WriteData("股票", currentRow, 1);
                        //第三、四列  
                        excelEdit.WriteData("股票资产总额", currentRow, 3);
                        excelEdit.WriteData(model.股票资产总额.ToString(), currentRow, 4);
                        excelEdit.setCells_NumberFormat(currentRow, 4, currentRow, 4, 2);
                        //第五、六列   
                        excelEdit.WriteData("资金余额", currentRow, 5);
                        excelEdit.WriteData(model.资金余额.ToString(), currentRow, 6);
                        excelEdit.setCells_NumberFormat(currentRow, 6, currentRow, 6, 2);
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 6, currentRow, 6, Color.Yellow);

                        //第七、八列----合并单元格
                        excelEdit.WriteData("资金/资产比例", currentRow, 7);
                        excelEdit.WriteData(model.资金资产比例, currentRow, 8);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 8, currentRow, 8);

                        //第9、11列，输出数据    
                        excelEdit.WriteData("今年收益率", currentRow, 9);
                        excelEdit.WriteData(model.今年收益率, currentRow, 11);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 11, currentRow, 11);
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 11, currentRow, 11, Color.Yellow);
                        #endregion
                    }
                    else
                    {
                        #region 第一行
                        currentRow = currentRow + 1;
                        // 设置字体加粗 + 背景色（灰色） 
                        excelEdit.FontStyle(currentRow, 1, currentRow + 1, columnsCount, true, false, UnderlineStyle.无下划线);
                        excelEdit.SetRangeBackground(currentRow, 1, currentRow + 1, columnsCount, Color.FromArgb(0, 165, 165, 165));

                        //第一、二列----合并单元格+调整背景色（黄色）
                        excelEdit.CellsUnite(currentRow, 1, currentRow + 1, 2, model.产品名称);
                        excelEdit.SetRangeBackground(currentRow, 1, currentRow + 1, 2, Color.Yellow);

                        //第三、四、五列 ----垂直方向合并单元格
                        excelEdit.CellsUnite(currentRow, 3, currentRow + 1, 3, "资产总额");
                        excelEdit.CellsUnite(currentRow, 4, currentRow + 1, 4, model.资产总额);
                        excelEdit.setCells_NumberFormat(currentRow, 4, currentRow + 1, 4, 2);
                        excelEdit.CellsUnite(currentRow, 5, currentRow + 1, 5, "资金余额");

                        //第六列 ----合并单元格+调整背景色（黄色）
                        excelEdit.CellsUnite(currentRow, 6, currentRow + 1, 6, model.资金余额);
                        excelEdit.SetRangeBackground(currentRow, 6, currentRow + 1, 6, Color.Yellow);
                        excelEdit.setCells_NumberFormat(currentRow, 6, currentRow + 1, 6, 2);

                        //第七、八列----合并单元格
                        excelEdit.CellsUnite(currentRow, 7, currentRow + 1, 7, "资金/资产比例");
                        double 资金资产比例 = 0;
                        double.TryParse(model.资金资产比例, out 资金资产比例);
                        excelEdit.CellsUnite(currentRow, 8, currentRow + 1, 8, 资金资产比例);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 8, currentRow + 1, 8);

                        //第9-13列，输出数据  
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 10, currentRow, 10, Color.Yellow);
                        excelEdit.SetRangeBackground(currentRow, 12, currentRow, 12, Color.Yellow);

                        excelEdit.WriteData("今年收益率", currentRow, 9);
                        excelEdit.WriteData(model.今年收益率, currentRow, 10);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 10, currentRow, 10);

                        excelEdit.WriteData("单位净值", currentRow, 11);
                        excelEdit.WriteData(model.单位净值.ToString(), currentRow, 12);
                        excelEdit.setCells_NumberFormat(currentRow, 12, currentRow, 12, 4);

                        excelEdit.WriteData("当日盈亏", currentRow, 13);

                        #endregion

                        #region 第二行

                        currentRow = currentRow + 1;
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 10, currentRow, 10, Color.Yellow);
                        excelEdit.SetRangeBackground(currentRow, 12, currentRow, 12, Color.Yellow);

                        excelEdit.WriteData("今年最大净值", currentRow, 9);
                        //保留小数点后两位
                        excelEdit.WriteData(model.今年最大净值.ToString("f4"), currentRow, 10);

                        excelEdit.WriteData("回撤率", currentRow, 11);

                        double 回撤率_数字 = 0;
                        double.TryParse(model.回撤率, out 回撤率_数字);
                        //自动加%，并且保留小数点后两位
                        excelEdit.WriteData(回撤率_数字.ToString("P"), currentRow, 12);

                        #endregion
                    }
                    #endregion

                    #region 写入股票信息

                    #region 增加一行，写入股票信息头

                    currentRow = currentRow + 1;
                    excelEdit.WriteData("代码", currentRow, 1);
                    excelEdit.WriteData("名称", currentRow, 2);
                    //  excelEdit.WriteData("基金经理", currentRow, 3);
                    excelEdit.WriteData("持股数量", currentRow, 3);
                    excelEdit.WriteData("持股成本", currentRow, 4);
                    excelEdit.WriteData("市场现价", currentRow, 5);
                    excelEdit.WriteData("投资成本(元)", currentRow, 6);
                    excelEdit.WriteData("今日市值(元)", currentRow, 7);
                    excelEdit.WriteData("浮盈浮亏(元)", currentRow, 8);
                    excelEdit.WriteData("投资成本占比", currentRow, 9);
                    excelEdit.WriteData("市值占比", currentRow, 10);
                    excelEdit.WriteData("浮盈浮亏率", currentRow, 11);
                    excelEdit.WriteData("本年净值贡献（元）", currentRow, 12);

                    #endregion

                    int tempCurrentCount = currentRow;

                    #region  增加若干行，写入股票信息内容

                    double total_投资成本 = 0; double total_今日市值 = 0; double total_浮盈浮亏 = 0;
                    double total_投资成本占比 = 0; double total_市值占比 = 0; double total_浮盈浮亏率 = 0;
                    double total_当日盈亏 = 0;

                    //基金经理若需要排序，需要在此处调整；
                    string sql = string.Format("select distinct 基金经理  from 绩效考核_股票每日交易汇总大表 where 时间 = '{0}'  and 产品名称 ='{1}'", currentDayDate, model.产品名称);
                    DataSet myDataSet = DbHelperSQL.Query(sql);

                    foreach (DataRow tempRow in myDataSet.Tables[0].Rows) //以单个基金经理位单位进行轮询
                    {
                        string 基金经理 = tempRow["基金经理"].ToString();
                        DataTable table股票汇总大表_By基金经理 = 股票汇总大表_modelBLL.GetOutPutTable(string.Format("时间 = '{0}' and 产品名称 ='{1}' and 基金经理='{2}' order by 基金经理 asc, 股票代码 asc", currentDayDate, model.产品名称, 基金经理));
                        if (table股票汇总大表_By基金经理 == null) continue;
                        if (table股票汇总大表_By基金经理.Rows.Count <= 0) continue; //表格无数据，则不往下执行

                        #region 调整原始表格中数据的格式

                        //edit by qhc（20151101） 
                        foreach (DataRow row in table股票汇总大表_By基金经理.Rows)
                        {
                            if (基金经理 != "")
                            { //名称 是指“股票名称”
                                row["名称"] = row["名称"].ToString() + string.Format("({0})", 基金经理.Substring(0, 1));
                            }
                            double 投资成本_Num = 0; double 今日市值_Num = 0; double 浮盈浮亏_Num = 0; double 当日盈亏_Num = 0;
                            double.TryParse(row["投资成本"].ToString(), out 投资成本_Num);
                            double.TryParse(row["今日市值"].ToString(), out 今日市值_Num);
                            double.TryParse(row["浮盈浮亏"].ToString(), out 浮盈浮亏_Num);
                            double.TryParse(row["当日盈亏"].ToString(), out 当日盈亏_Num);

                            double 投资成本占比_Num = 0; double 市值占比_Num = 0; double 浮盈浮亏率_Num = 0;
                            double.TryParse(row["投资成本占比"].ToString(), out 投资成本占比_Num);
                            double.TryParse(row["市值占比"].ToString(), out 市值占比_Num);
                            double.TryParse(row["浮盈浮亏率"].ToString(), out 浮盈浮亏率_Num);

                            total_投资成本 += 投资成本_Num;
                            total_今日市值 += 今日市值_Num;
                            total_浮盈浮亏 += 浮盈浮亏_Num;
                            total_投资成本占比 += 投资成本占比_Num;
                            total_市值占比 += 市值占比_Num;
                            // total_浮盈浮亏率 += 浮盈浮亏率_Num;
                            total_当日盈亏 += 当日盈亏_Num;
                        }// ==调整原始表格中数据的格式 End
                        #endregion

                        table股票汇总大表_By基金经理.Columns.Remove("基金经理");//删除“基金经理”列，edit by qhc（20151027）

                        //设置第一列为文本列；
                        excelEdit.setCells_TextFormat(currentRow, 1, table股票汇总大表_By基金经理.Rows.Count + currentRow, 1);
                        //向下滚动一行
                        currentRow = currentRow + 1;
                        excelEdit.WriteData(table股票汇总大表_By基金经理, currentRow, 1);

                        #region added by qhc “浮盈浮亏率”列需要标红的行（>0标红，<=0颜色不变）
                        List<int> 应该标红行 = new List<int>();
                        for (int x = 0; x < table股票汇总大表_By基金经理.Rows.Count; x++)
                        { //产品名称、股票代码、基金经理 
                            string 股票代码 = table股票汇总大表_By基金经理.Rows[x]["代码"].ToString();
                            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 tempModel in modelList_是否包括止损指令)
                            {
                                if (model.产品名称 == tempModel.产品名称 && 股票代码 == tempModel.股票代码 && 基金经理 == tempModel.基金经理)
                                {
                                    int tempCurrentRow = currentRow + x;
                                    excelEdit.FontColor(tempCurrentRow, 11, tempCurrentRow, 11, ColorIndex.红色);
                                    break;
                                }
                            }
                        }
                        #endregion
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
                        //基金经理有值时需要合并，无值时不需要合并
                        if (基金经理 != "")
                        {
                            string result_本年净值贡献 = 本年净值贡献.ToString("f4");
                            excelEdit.CellsUnite(currentRow, 12, currentRow + table股票汇总大表_By基金经理.Rows.Count - 1, 12, result_本年净值贡献);
                        }
                        currentRow = currentRow + table股票汇总大表_By基金经理.Rows.Count - 1;
                    }
                    //added by qhc(20151126)
                    //管理该产品的基金经理，没有被剔除。说明基金经理将该产品下所有股票卖空，要留有一行空记录，如（徐)+“个人净值贡献”
                    //if (myDataSet.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (string 产品下所有股票卖空_基金经理 in All基金经理List)
                    //    {
                    //        if (产品下所有股票卖空_基金经理.Length < 1) continue;
                    //        currentRow = currentRow + 1;
                    //        string 格式化基金经理简称 = string.Format("（{0}）", 产品下所有股票卖空_基金经理.Substring(0, 1));
                    //        excelEdit.WriteData(格式化基金经理简称, currentRow, 2); 
                    //    }
                    //}

                    //股票信息内容为空，则空一行
                    if (myDataSet.Tables[0].Rows.Count == 0)
                        currentRow = currentRow + 1;

                    #endregion

                    #region 增加一行，写入股票合计信息
                    currentRow = currentRow + 1;
                    // 设置字体加粗 + 背景色（灰色） 
                    excelEdit.FontStyle(currentRow, 1, currentRow, columnsCount, true, false, UnderlineStyle.无下划线);
                    excelEdit.SetRangeBackground(currentRow, 1, currentRow, columnsCount, Color.FromArgb(0, 165, 165, 165));

                    if (股票期货混合型产品)
                    {
                        excelEdit.WriteData("股票合计", currentRow, 1);
                    }
                    else
                    {
                        excelEdit.WriteData("合计", currentRow, 1);
                    }
                    if (total_投资成本 != 0) //为0时，不写入任何值至单元格，留空单元格
                        excelEdit.WriteData(total_投资成本.ToString(), currentRow, 6);
                    if (total_今日市值 != 0)
                        excelEdit.WriteData(total_今日市值.ToString(), currentRow, 7);
                    if (total_浮盈浮亏 != 0)
                        excelEdit.WriteData(total_浮盈浮亏.ToString(), currentRow, 8);
                    if (total_投资成本占比 != 0)
                        excelEdit.WriteData(total_投资成本占比.ToString(), currentRow, 9);
                    if (total_市值占比 != 0)
                        excelEdit.WriteData(total_市值占比.ToString(), currentRow, 10);
                    if (total_投资成本 != 0)
                        total_浮盈浮亏率 = total_浮盈浮亏 / total_投资成本;
                    if (total_浮盈浮亏率 != 0)
                        excelEdit.WriteData(total_浮盈浮亏率.ToString(), currentRow, 11);
                    if (total_当日盈亏 != 0)
                        excelEdit.WriteData(total_当日盈亏.ToString(), currentRow, 13);

                    #endregion

                    #region 格式化显示

                    excelEdit.setCells_NumberFormat(tempCurrentCount, 3, currentRow, 3, 0);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 4, currentRow, 4, 2);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 5, currentRow, 5, 2);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 6, currentRow, 6, 2);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 7, currentRow, 7, 2);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 8, currentRow, 8, 2);
                    excelEdit.setCells_PercentFormat(tempCurrentCount, 9, currentRow, 9);
                    excelEdit.setCells_PercentFormat(tempCurrentCount, 10, currentRow, 10);
                    excelEdit.setCells_PercentFormat(tempCurrentCount, 11, currentRow, 11);
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 12, currentRow, 12, 4);

                    //added by qhc(20160703) 
                    excelEdit.setCells_NumberFormat(tempCurrentCount, 13, currentRow, 13, 2);

                    #endregion

                    #endregion

                    #region  写入期货信息

                    if (股票期货混合型产品)
                    {
                        #region 增加一行，写入基金产品信息

                        currentRow = currentRow + 1;
                        // 设置字体加粗 + 背景色（灰色） 
                        excelEdit.FontStyle(currentRow, 1, currentRow, columnsCount, true, false, UnderlineStyle.无下划线);
                        excelEdit.SetRangeBackground(currentRow, 1, currentRow, columnsCount, Color.FromArgb(0, 165, 165, 165));
                        //第一 列 
                        excelEdit.WriteData("股指期货", currentRow, 1);
                        //第三、四列  
                        excelEdit.WriteData("期货资产总额", currentRow, 3);
                        excelEdit.WriteData(model.期货资产总额.ToString(), currentRow, 4);
                        excelEdit.setCells_NumberFormat(currentRow, 4, currentRow, 4, 2);
                        //第五、六列   
                        excelEdit.WriteData("资金余额", currentRow, 5);
                        excelEdit.WriteData(model.期货资金余额.ToString(), currentRow, 6);
                        excelEdit.setCells_NumberFormat(currentRow, 6, currentRow, 6, 2);
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 6, currentRow, 6, Color.Yellow);
                        //第七、八列----合并单元格
                        excelEdit.WriteData("资金/资产比例", currentRow, 7);
                        double 期货资金资产比例 = 0;
                        if (model.期货资产总额 != 0)
                            期货资金资产比例 = model.期货资金余额 / model.期货资产总额;
                        excelEdit.WriteData(期货资金资产比例.ToString(), currentRow, 8);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 8, currentRow, 8);

                        //第9、11列，输出数据    
                        excelEdit.WriteData("今年收益率", currentRow, 9);
                        excelEdit.WriteData(model.期货今年收益率.ToString(), currentRow, 11);
                        //百分号后保留两位小数
                        excelEdit.setCells_PercentFormat(currentRow, 11, currentRow, 11);
                        //调整背景色（黄色）
                        excelEdit.SetRangeBackground(currentRow, 11, currentRow, 11, Color.Yellow);
                        #endregion

                        #region 增加一行，写入期货信息头

                        currentRow = currentRow + 1;
                        excelEdit.WriteData("代码", currentRow, 1);
                        excelEdit.WriteData("名称", currentRow, 2);
                        excelEdit.WriteData("卖持量（手）", currentRow, 3);
                        excelEdit.WriteData("卖持仓成本", currentRow, 4);
                        excelEdit.WriteData("市场现价", currentRow, 5);
                        excelEdit.WriteData("合约成本", currentRow, 6);
                        excelEdit.WriteData("持仓保证金", currentRow, 7);
                        excelEdit.WriteData("当日盈亏", currentRow, 8);
                        excelEdit.WriteData("总盈亏", currentRow, 9);
                        excelEdit.WriteData("校验", currentRow, 13);

                        #endregion

                        int tempCurrentCount1 = currentRow;

                        #region  增加若干行，写入期货信息内容

                        currentRow = currentRow + 1;
                        DataTable tempTable = 期货汇总大表_modelBLL.GetDataTable_SelectColumn(string.Format(" 时间 = '{0}' and 产品名称='{1}'", currentDayDate, model.产品名称));
                        if (tempTable.Rows.Count > 0)
                        {
                            excelEdit.WriteData(tempTable, currentRow, 1);
                            currentRow = currentRow + tempTable.Rows.Count - 1;
                        }
                        #endregion

                        #region 格式化显示
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 3, currentRow, 3, 0);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 4, currentRow, 4, 2);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 5, currentRow, 5, 2);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 6, currentRow, 6, 2);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 7, currentRow, 7, 2);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 8, currentRow, 8, 2);
                        excelEdit.setCells_NumberFormat(tempCurrentCount1, 9, currentRow, 9, 2);
                        #endregion
                    }
                    #endregion

                }
                #endregion
                // ==========以产品为循环单元，循环写入 (结束) ==========//

                //通用设置=字体
                int rowsCount = currentRow;
                //设置字体 
                excelEdit.FontNameSize(1, 1, rowsCount, columnsCount, "宋体", 9);
                //设置对齐方式
                excelEdit.CellsAlignment(1, 1, rowsCount, columnsCount, ExcelHAlign.居中, ExcelVAlign.居中);
                //设置单元格边框
                excelEdit.CellsDrawFrame(1, 1, rowsCount, columnsCount);
                //设置行高
                excelEdit.SetRowHeight(1, rowsCount, 16);
                //设置列宽
                excelEdit.SetColumnWidth(1, 1, 9);
                excelEdit.SetColumnWidth(2, 2, 12);
                excelEdit.SetColumnWidth(3, 5, 10);
                excelEdit.SetColumnWidth(6, 8, 13);
                excelEdit.SetColumnWidth(9, 11, 10);
                excelEdit.SetColumnWidth(12, 12, 12);
                excelEdit.SetColumnWidth(13, 13, 10);

                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        private string Get带百分号的实际值_String(string str)
        {
            double result = 0;
            if (str.Contains("%")) //含百分号
            {
                double.TryParse(str.Substring(0, str.Length - 1), out result);
                return (result / 100.0f).ToString();
            }
            else
            {
                double.TryParse(str, out result);
                return result.ToString();
            }
        }

        private double Get带百分号的实际值_Double(string str)
        {
            double result = 0;
            if (str.Contains("%")) //含百分号
            {
                double.TryParse(str.Substring(0, str.Length - 1), out result);
                result = result / 100.0f;
            }
            else
            {
                double.TryParse(str, out result);
            }
            return result;
        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {
            InitializeControl();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                InitializeControl();
            }
        }

        private void btn_导入历史投资汇总至缓存区_Click(object sender, EventArgs e)
        {
            if (_IsProssesing)
            {
                MessageBox.Show("正在导入历史投资统计汇总。。。", "系统提示");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(btn_导入历史投资统计汇总总表格_EventHandler));
                thread.Start(new Paramter1(ofd.FileName, false));
            }
        }

        private void btn_查看缓存区和成果区对比情况_Click(object sender, EventArgs e)
        {
            CurrentDayExchangeHZCtl_记录对比 frm = new CurrentDayExchangeHZCtl_记录对比();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void btn_管理未成功导入数据_Click(object sender, EventArgs e)
        {
            CurrentDayExchangeListCtl_大表未导入 frm = new CurrentDayExchangeListCtl_大表未导入(DateTime.Now.AddMonths(-1), DateTime.Now);
            frm.ShowDialog();
        }

        private void btn_生成指定时间统计汇总_Click(object sender, EventArgs e)
        {
            select_start_end frm = new select_start_end();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.successfule)
                {
                    while (true)
                    {
                        this.ExecuteCurrentTJHZ(frm.m_startDT);

                        string m_startDT = frm.m_startDT.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        string m_endDT = frm.m_endDT.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                        if (m_startDT == m_endDT)
                            break;
                        frm.m_startDT = frm.m_startDT.AddDays(1);
                    } 
                }
            }
            MessageBox.Show("生成完毕！", "系统提示");
        }


    }

    public class Paramter1
    {
        private string _filename = string.Empty;

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        private bool _flag = false;

        /// <summary>
        /// 导入成果库为True，导入到临时库为False
        /// </summary>
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public Paramter1(string filename, bool flag)
        {
            this._filename = filename;
            this._flag = flag;
        }
    }
}
