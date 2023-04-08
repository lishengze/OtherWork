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
    /// <summary>
    /// 每日交易汇总（一种产品）
    /// </summary>
    public partial class HistoryExchange_SubPanel : UserControl
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        private string m_cp_name;
        /// <summary>
        /// 当前时间
        /// </summary>
        private DateTime m_Currenttime;
        private Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> m_DIC_产品名称_Model = new Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表>();
        private Dictionary<string, double> m_今年最大净值_DIC = new Dictionary<string, double>();
        private List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> m_小表情况List = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
        private double m_股票资产总额 = 0;
        public HistoryExchange_SubPanel(string name, DateTime dt, TabControl tabControl,
            Dictionary<string, Maticsoft.Model.绩效考核_基金产品信息表> _DIC_产品名称_Model, Dictionary<string, double> _今年最大净值_DIC,
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList_小表, double  _股票资产总额)
        {
            InitializeComponent();
            m_cp_name = name;
            m_Currenttime = dt;
            m_tabControl = tabControl;
            m_DIC_产品名称_Model = _DIC_产品名称_Model;
            m_今年最大净值_DIC = _今年最大净值_DIC;
            m_股票资产总额 = _股票资产总额;
            RefreshDataGridView();

            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 tempModel in modelList_小表)
            {
                if (tempModel.产品名称 == m_cp_name)
                {
                    m_小表情况List.Add(tempModel);
                }
            }
            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户" || DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
            {
                this.btn_保存修改.Visible = false;
                this.txt_资金余额.ReadOnly = true;
            }
        }

        public string ParseDouble(string data) {
            double result = 0.0;
            if (Double.TryParse(data, out result)) {
                return result.ToString("f2");
            }
            return "0.00";
        }

        public string ParsePercentDouble(string data) {
            double result = 0.0;
            if (Double.TryParse(data, out result)) {
                return result.ToString("P");
            }
            return "0.0%";
        }


        private void RefreshDataGridView()
        {
            string currentDayDate = this.m_Currenttime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            #region dataGridView1

            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            DataSet ds = modelBLL.GetList(string.Format("时间 = '{0}' and 产品名称 ='{1}'", currentDayDate, m_cp_name));

            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_基金经理净值贡献表> modelList_绩效考核_基金经理净值贡献表 = modelBLL_基金经理净值贡献表.GetModelList(string.Format(" 时间 = '{0}'", currentDayDate));

            if (ds != null && ds.Tables != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    table.Columns.Add("本年净值贡献");

                    foreach (DataRow row in table.Rows)
                    {
                        string 基金经理 = row["基金经理"].ToString();
                        string 时间 = row["时间"].ToString();
                        string 产品名称 = row["产品名称"].ToString();
                        foreach (Maticsoft.Model.绩效考核_基金经理净值贡献表 tempModel in modelList_绩效考核_基金经理净值贡献表)
                        {
                            if (tempModel.基金产品 == 产品名称 && tempModel.时间 == 时间 && tempModel.基金经理 == 基金经理)
                            {
                                row["本年净值贡献"] = tempModel.本年净值贡献.ToString("f4");
                                break;
                            }
                        }

                        #region 调整显示的小数位数
                        //调整 参数的显示位数 （只显示 小数点后两位 ） 
                        // row["持股成本"] = Convert.ToDouble(row["持股成本"].ToString()).ToString("f2");//保留小数点后两位
                        // row["投资成本"] = Convert.ToDouble(row["投资成本"].ToString()).ToString("f2");//保留小数点后两位
                        // row["今日市值"] = Convert.ToDouble(row["今日市值"].ToString()).ToString("f2");//保留小数点后两位
                        // row["浮盈浮亏"] = Convert.ToDouble(row["浮盈浮亏"].ToString()).ToString("f2");//保留小数点后两位
                        // row["当日盈亏"] = Convert.ToDouble(row["当日盈亏"].ToString()).ToString("f2");

                        row["当日盈亏"] = ParseDouble(row["当日盈亏"].ToString());
                        row["浮盈浮亏"] = ParseDouble(row["浮盈浮亏"].ToString());
                        row["今日市值"] = ParseDouble(row["今日市值"].ToString());
                        row["投资成本"] = ParseDouble(row["投资成本"].ToString());
                        row["持股成本"] = ParseDouble(row["持股成本"].ToString());

    
                        row["浮盈浮亏率"] = ParsePercentDouble(row["浮盈浮亏率"].ToString());
                        row["市值占比"] = ParsePercentDouble(row["市值占比"].ToString());
                        row["投资成本占比"] = ParsePercentDouble(row["投资成本占比"].ToString());
                        
                        #endregion

                    }
                    this.dataGridView1.DataSource = table;
                    this.dataGridView1.Columns["记录标识"].Visible = false;
                    this.dataGridView1.Columns["买卖累计盈亏"].Visible = false;
                    this.dataGridView1.Columns["今日均价"].Visible = false;
                    this.dataGridView1.Columns["是否修改过持股数量和持股成本"].Visible = false;
                }
            }
            #endregion

            #region 填充textbox

            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = modelBLL1.GetModelList(string.Format(" 时间 = '{0}' and 产品名称 ='{1}'", currentDayDate, m_cp_name));
            if (modelList.Count > 0)
            {
                this.txt_资金余额.TextChanged -= new System.EventHandler(this.txt_资金余额_TextChanged);

                this.txt_单位净值.Text = modelList[0].单位净值.ToString();
                if (modelList[0].回撤率 != null)
                    this.txt_回撤率.Text = modelList[0].回撤率;
                if (modelList[0].今年收益率 != null)
                    this.txt_今年收益率.Text = modelList[0].今年收益率;
                this.txt_今年最大净值.Text = modelList[0].今年最大净值.ToString();
                this.txt_资产总额.Text = modelList[0].资产总额.ToString();
                this.txt_资金余额.Text = modelList[0].资金余额.ToString();
                this.txt_资金资产比例.Text = modelList[0].资金资产比例;

                this.txt_基准日净值.Text = modelList[0].基准日净值.ToString();
                this.txt_基金份额.Text = modelList[0].基金份额.ToString();
                this.txt_股票总市值.Text = (m_股票资产总额 / 10000.0).ToString();
                this.txt_资金余额.TextChanged += new System.EventHandler(this.txt_资金余额_TextChanged);
            }
            #endregion
        }
        private TabControl m_tabControl;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "浮盈浮亏率")
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string 基金经理 = row.Cells["基金经理"].Value.ToString();
                string 股票代码 = row.Cells["股票代码"].Value.ToString();
                double 浮盈浮亏率_NUM = 0;
                string 浮盈浮亏率 = row.Cells["浮盈浮亏率"].Value.ToString().Replace("%","");
                double.TryParse(浮盈浮亏率, out 浮盈浮亏率_NUM);
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 tempModel in m_小表情况List)
                {
                    if (tempModel.基金经理 == 基金经理 && tempModel.股票代码 == 股票代码)
                    {
                        if (浮盈浮亏率_NUM > 0)
                            e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btn_保存修改_Click(object sender, EventArgs e)
        {
            string currentDayDate = this.m_Currenttime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            foreach (System.Windows.Forms.Control subsubctl in this.m_tabControl.Controls)
            {
                TabPage page = subsubctl as TabPage;
                if (page != null)
                {
                    foreach (UserControl uc in page.Controls)
                    {
                        HistoryExchange_SubPanel txtBox = uc as HistoryExchange_SubPanel;
                        if (txtBox != null)
                        {
                            txtBox.Execute_Save(currentDayDate, txtBox.m_cp_name);
                        }
                    }
                }
            }
            MessageBox.Show("保存完成！", "系统提示");
        }

        public void Execute_Save(string currentDayDate, string 产品名称)
        {
            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = modelBLL1.GetModelList(string.Format(" 时间 = '{0}' and 产品名称 ='{1}'", currentDayDate, 产品名称));
            Maticsoft.Model.绩效考核_基金产品每日统计 model = null;
            if (modelList.Count > 0)
            {
                model = modelList[0];
            }
            else
            {
                model = new Maticsoft.Model.绩效考核_基金产品每日统计();
            }
            model.产品名称 = m_cp_name;
            model.时间 = currentDayDate;

            double 单位净值 = 0;
            double.TryParse(this.txt_单位净值.Text.Trim(), out 单位净值);
            model.单位净值 = 单位净值;

            model.回撤率 = this.txt_回撤率.Text.Trim();
            model.今年收益率 = this.txt_今年收益率.Text.Trim();

            double 资产总额, 资金余额;
            double.TryParse(this.txt_资产总额.Text.Trim(), out 资产总额);
            model.资产总额 = 资产总额;
            double.TryParse(this.txt_资金余额.Text.Trim(), out 资金余额);
            model.资金余额 = 资金余额;
            model.资金资产比例 = this.txt_资金资产比例.Text.Trim();

            double 今年最大净值, 基金份额, 基准日净值;
            double.TryParse(this.txt_基金份额.Text.Trim(), out 基金份额);
            model.基金份额 = 基金份额;
            double.TryParse(this.txt_基准日净值.Text.Trim(), out 基准日净值);
            model.基准日净值 = 基准日净值;
            double.TryParse(this.txt_今年最大净值.Text.Trim(), out 今年最大净值);
            model.今年最大净值 = 今年最大净值;

            bool flag = false;
            try
            {
                if (modelList.Count > 0)
                { //存在记录，更新 
                    if (modelBLL1.Update(model))
                        flag = true;
                }
                else
                { //记录不存在，新增 
                    long maxID = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                    model.记录标识 = maxID;
                    if (modelBLL1.Add(model))
                        flag = true;
                }
                if (flag)
                {  //added by qhc--20151010,更新该基金下的每支股票投资成本占比和市值占比参数；
                    Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL2 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
                    List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList2 = modelBLL2.GetModelList(string.Format(" 时间 = '{0}' and 产品名称 ='{1}'", currentDayDate, m_cp_name));
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model_股票每日交易汇总大表 in modelList2)
                    {
                        double 投资成本占比 = 0;
                        if (model.资产总额 != 0)
                            投资成本占比 = (model_股票每日交易汇总大表.投资成本 / model.资产总额) / 10000;
                        model_股票每日交易汇总大表.投资成本占比 = 投资成本占比;

                        double 市值占比 = 0;
                        if (model.资产总额 != 0)
                            市值占比 = (model_股票每日交易汇总大表.今日市值 / model.资产总额) / 10000;
                        if (市值占比 != 0)
                            model_股票每日交易汇总大表.市值占比 = 市值占比;

                        modelBLL2.Update(model_股票每日交易汇总大表);
                    }
                    if (modelList2.Count > 0)
                        this.RefreshDataGridView();
                }

                // MessageBox.Show("保存成功！", "系统提示");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("保存失败！", "系统提示");
            }
        }

        private void txt_资金余额_TextChanged(object sender, EventArgs e)
        {
            string currentDayDate = this.m_Currenttime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 今日大表BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();

            //5个自变量，从现有输入中获取
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 今日大表_resultList = 今日大表BLL.GetModelList(string.Format(" 时间 = '{0}' and 产品名称 ='{1}'", currentDayDate, m_cp_name));
            double 今日市值_total = 0;
            foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in 今日大表_resultList)
            {
                今日市值_total += model.今日市值;
            }
            double 资金余额 = 0; double 基金份额 = 0; double 基准日净值 = 0; double 今年最大净值 = 0;
            double.TryParse(this.txt_资金余额.Text.Trim(), out 资金余额);
            double.TryParse(this.txt_基金份额.Text.Trim(), out 基金份额);
            double.TryParse(this.txt_基准日净值.Text.Trim(), out 基准日净值);

            //5个因变量，通过5个自变量计算获取
            double 资产总额 = 资金余额 + 今日市值_total / 10000.0;
            this.txt_资产总额.Text = 资产总额.ToString();

            if (资产总额 != 0)
                this.txt_资金资产比例.Text = (资金余额 / 资产总额).ToString();

            double 单位净值 = 0;
            if (基金份额 != 0)
                单位净值 = 资产总额 / (基金份额 / 10000.0);
            this.txt_单位净值.Text = 单位净值.ToString();

            double temp今年最大净值 = 0;
            if (m_今年最大净值_DIC.ContainsKey(m_cp_name))
                temp今年最大净值 = m_今年最大净值_DIC[m_cp_name];
            今年最大净值 = DataConvertor.Get_今年最大净值(temp今年最大净值, 单位净值, 基准日净值);

            this.txt_基金份额.Text = 基金份额.ToString();
            this.txt_基准日净值.Text = 基准日净值.ToString();
            this.txt_今年最大净值.Text = 今年最大净值.ToString();

            if (基准日净值 != 0)
                this.txt_今年收益率.Text = (单位净值 / 基准日净值 - 1).ToString();
            if (今年最大净值 != 0)
                this.txt_回撤率.Text = (单位净值 / 今年最大净值 - 1).ToString();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户" || DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
                return;
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (row != null)
            {
                long 记录标识 = 0;
                long.TryParse(row.Cells["记录标识"].Value.ToString(), out 记录标识);
                if (记录标识 > 0)
                {
                    Maticsoft.Model.绩效考核_股票每日交易汇总大表 汇总大表model = modelBLL_股票每日交易汇总大表.GetModel(记录标识);
                    
                    if (汇总大表model != null)
                    { 
                        编辑大表_Info infoFrm = new 编辑大表_Info(汇总大表model,m_Currenttime);
                        if (infoFrm.ShowDialog() == DialogResult.OK)
                        {
                            RefreshDataGridView();

                            MessageBox.Show("更新成功","系统提示");
                        }
                    }
                }
            }
        }
    }
}
