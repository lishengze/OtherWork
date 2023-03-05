using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using DB;

namespace 基金管理
{
    public partial class MainFrm : Form
    {
        public CurrentDayExchangeListCtl m_control1; 
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        /// <summary>
        /// 股票字典（股票代码+股票名称）
        /// </summary>
        public static Dictionary<string, string> GUPIAO_DIC = new Dictionary<string, string>();

        /// <summary>
        /// 基金经理（简称+全称）
        /// </summary>
        public static Dictionary<string, string> JIJINJINGLI_DIC = new Dictionary<string, string>();

        private MethodInvoker mi = null;

        public MainFrm(Maticsoft.Model.绩效考核_用户信息表 用户信息)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(MainFrm_FormClosed);
            if (用户信息.角色 == "" || 用户信息.角色 == null)
                用户信息.角色 = "普通用户";

            DataConvertor.Pub_登录用户信息 = 用户信息;
            this.label_CurrentDate.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();


            this.lbl_登录人姓名.Text = DataConvertor.Pub_登录用户信息.用户姓名;
            mi = new MethodInvoker(RefreshTimerLabel);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;

            FillDictionary();

            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户" || DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
            {
                this.btn_增加当日交易记录.Visible = false;
                this.btn_更改产品设置.Visible = false;
                this.btn_系统管理.Visible = false;
                this.btn_数据维护.Visible = false;
                if (DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
                {
                    this.btn_查看当日交易记录.Visible = false;
                }
            }
            if (DataConvertor.Pub_登录用户信息.用户名 != DataConvertor.Pub_超级管理员用户名)
            { 
                this.btn_小表数据审查.Visible = false;
                this.btn_大表数据审查.Visible = false;
            }

            m_control1 = new CurrentDayExchangeListCtl();
            this.page_查看当日交易记录.Controls.Add(m_control1);
            m_control1.Dock = DockStyle.Fill;

            HistoryExchangeCtl historyExchangeCtl = new HistoryExchangeCtl();
            this.page_交易汇总查询.Controls.Add(historyExchangeCtl);
            historyExchangeCtl.Dock = DockStyle.Fill;

            Stat_Control stat_HistoryData = new Stat_Control();
            stat_HistoryData.Dock = DockStyle.Fill;
            this.page_基金产品查询.Controls.Add(stat_HistoryData);

            Stat仓位_Control stat仓位_Control = new Stat仓位_Control();
            this.page_仓位统计.Controls.Add(stat仓位_Control);
            stat仓位_Control.Dock = DockStyle.Fill;

            Stat_Control_ByPerson stat_HistoryData_ByPerson = new Stat_Control_ByPerson();
            this.page_基金经理绩效统计.Controls.Add(stat_HistoryData_ByPerson);
            stat_HistoryData_ByPerson.Dock = DockStyle.Fill;

            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户" || DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
            {
                this.tabControl1.Controls.Remove(page_更改产品设置);
                this.tabControl1.Controls.Remove(page_系统管理);
                if (DataConvertor.Pub_登录用户信息.角色 == "市场部用户")
                {
                    this.tabControl1.Controls.Remove(page_查看当日交易记录);
                }
            }
            else
            {
                ManagerCtl mnagerCtl = new ManagerCtl();
                this.page_更改产品设置.Controls.Add(mnagerCtl);
                mnagerCtl.Dock = DockStyle.Fill;

                SystemManagerCtl systemManagerCtl = new SystemManagerCtl();
                this.page_系统管理.Controls.Add(systemManagerCtl);
                systemManagerCtl.Dock = DockStyle.Fill; 
            }

            if (DataConvertor.Pub_登录用户信息.用户名 != DataConvertor.Pub_超级管理员用户名)
            {
                this.tabControl1.Controls.Remove(page_小表数据审查);
                this.tabControl1.Controls.Remove(page_大表数据审查);
            }
            else
            {
                CurrentDayExchangeListCtl_小表数据审查 小表数据审查_Ctl = new CurrentDayExchangeListCtl_小表数据审查();
                this.page_小表数据审查.Controls.Add(小表数据审查_Ctl);
                小表数据审查_Ctl.Dock = DockStyle.Fill;

                CurrentDayExchangeListCtl_大表数据审查 大表数据审查_Ctl = new CurrentDayExchangeListCtl_大表数据审查();
                this.page_大表数据审查.Controls.Add(大表数据审查_Ctl);
                大表数据审查_Ctl.Dock = DockStyle.Fill;
            }
        }

        void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //  this.BeginInvoke(mi);  
        }

        private void RefreshTimerLabel()
        {
            this.label_CurrentDate.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void FillDictionary()
        {
            #region 普通股票
            Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
            List<Maticsoft.Model.绩效考核_股票信息表> modelList = modelBLL.GetModelList("");

            foreach (Maticsoft.Model.绩效考核_股票信息表 model in modelList)
            {
                if (model.股票代码.Length == 6 || model.股票代码.Length == 4)
                {
                    if (model.股票代码 != "" && model.股票名称 != "")
                    {
                        if (!GUPIAO_DIC.ContainsKey(model.股票代码))
                        {
                            GUPIAO_DIC.Add(model.股票代码, model.股票名称);
                        }
                    }
                }
            }

            #endregion

            #region 现金替代物
            Maticsoft.BLL.绩效考核_现金替代物信息表 modelBLL_现金替代物信息表 = new Maticsoft.BLL.绩效考核_现金替代物信息表();
            List<Maticsoft.Model.绩效考核_现金替代物信息表> modelList_现金替代物信息表 = modelBLL_现金替代物信息表.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_现金替代物信息表 model in modelList_现金替代物信息表)
            {
                if (model.现金替代物代码 != "" && model.现金替代物名称 != "")
                {
                    if (!GUPIAO_DIC.ContainsKey(model.现金替代物代码))
                    {
                        GUPIAO_DIC.Add(model.现金替代物代码, model.现金替代物名称);
                    }
                }
            }

            #endregion

            #region 未上市股票
            Maticsoft.BLL.绩效考核_未上市股票信息表 modelBLL_未上市股票 = new Maticsoft.BLL.绩效考核_未上市股票信息表();
            List<Maticsoft.Model.绩效考核_未上市股票信息表> modelList_未上市股票 = modelBLL_未上市股票.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_未上市股票信息表 model in modelList_未上市股票)
            {
                if (model.股票代码 != "" && model.股票名称 != "")
                {
                    if (!GUPIAO_DIC.ContainsKey(model.股票代码))
                    {
                        GUPIAO_DIC.Add(model.股票代码, model.股票名称);
                    }
                }
            }

            #endregion

            #region 基金经理
            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList1 = modelBLL1.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金经理信息表 model in modelList1)
            {
                if (model.基金经理.Length > 1)
                {
                    string jc = model.基金经理.Substring(0, 1);
                    if (!JIJINJINGLI_DIC.ContainsKey(jc))
                    {
                        JIJINJINGLI_DIC.Add(jc, model.基金经理);
                    }
                }
            }
            #endregion
        }
         
        private void btn_增加当日交易记录_Click(object sender, EventArgs e)
        {
            Add_CurrentDayExchangeFrm frm = new Add_CurrentDayExchangeFrm(m_control1);
            frm.ShowDialog(); 
        }
        private void btn_查看当日交易记录_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_查看当日交易记录;
        }
        private void btn_交易汇总查询_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_交易汇总查询;
        }
        private void btn_历史数据查询统计_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_基金产品查询;
        }
        private void btn_更改产品设置_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_更改产品设置;
        }
        private void btn_仓位统计_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_仓位统计;
        }
        private void btn_基金经理绩效统计_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_基金经理绩效统计;
        }

        private void btn_清理数据_Click(object sender, EventArgs e)
        {
            DeleteDataFrm frm = new DeleteDataFrm();
            frm.ShowDialog();
        }

        private void btn_系统管理_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_系统管理;
        }


        private void btn_大表数据审查_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_大表数据审查;
        }

        private void btn_小表数据审查_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.page_小表数据审查;
        }


    }
}
