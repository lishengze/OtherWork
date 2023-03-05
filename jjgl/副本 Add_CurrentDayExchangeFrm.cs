using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 基金管理
{

    public partial class Add_CurrentDayExchangeFrm : Form
    {
        MainFrm m_MainFrm;
        public Add_CurrentDayExchangeFrm(MainFrm frm)
        {
            InitializeComponent();
            FillComboValue();
            m_MainFrm = frm;

            this.Load += new EventHandler(Add_CurrentDayExchangeFrm_Load);
        }

        void Add_CurrentDayExchangeFrm_Load(object sender, EventArgs e)
        {
            SearchData();
            //throw new NotImplementedException();
        }

        private void SearchData()
        {

            Maticsoft.BLL.绩效考核_交易记录表 modelBLL = new Maticsoft.BLL.绩效考核_交易记录表();

            string 产品名称 = this.comboBox_产品名称.SelectedValue.ToString();
            string 基金经理 = this.comboBox_基金经理.SelectedValue.ToString();
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string nextDayDate = this.dateTimePicker1.Value.AddDays(1).ToString("yyyy/MM/dd"); 
            DataSet ds = modelBLL.GetList(string.Format(" 产品名称='{0}'  and 基金经理='{1}' and 时间 between '{2}' and '{3}'", 产品名称, 基金经理, currentDayDate, nextDayDate));

            if (ds != null && ds.Tables.Count > 0)
                this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void FillComboValue()
        {
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = modelBLL1.GetModelList("");
            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";
            if (modelList1.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList2 = modelBLL2.GetModelList("");
            this.comboBox_基金经理.DataSource = modelList2;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
            if (modelList2.Count > 0)
                this.comboBox_基金经理.SelectedIndex = 0;
        }

        private void Submit()
        {
            Maticsoft.BLL.绩效考核_交易记录表 modelBLL = new Maticsoft.BLL.绩效考核_交易记录表();
            List<DataGridViewRow> submitRowList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                Maticsoft.Model.绩效考核_交易记录表 info = new Maticsoft.Model.绩效考核_交易记录表();
                info.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_交易记录表");
                info.产品名称 = this.comboBox_产品名称.Text;
                info.基金经理 = this.comboBox_基金经理.Text;

                if (row.Cells["股票代码"].Value != null)
                {
                    info.股票代码 = row.Cells["股票代码"].Value.ToString();
                }
                if (row.Cells["股票名称"].Value != null)
                {
                    info.股票名称 = row.Cells["股票名称"].Value.ToString();
                }
                if (row.Cells["交易方向"].Value != null)
                {
                    info.交易方向 = row.Cells["交易方向"].Value.ToString();
                }
                long 股数 = 0;
                if (row.Cells["股数"].Value != null)
                {
                    long.TryParse(row.Cells["股数"].Value.ToString(), out 股数);
                    info.股数 = 股数;
                }
                double 成交均价 = 0;
                if (row.Cells["成交均价"].Value != null)
                {
                    double.TryParse(row.Cells["成交均价"].Value.ToString(), out 成交均价);
                    info.成交均价 = 成交均价;
                }
                double 成交金额 = 0;
                if (row.Cells["成交金额"].Value != null)
                {
                    double.TryParse(row.Cells["成交金额"].Value.ToString(), out 成交金额);
                    info.成交金额 = 成交金额;
                }
                if (info.成交金额 != null)
                {
                    info.手续费 = info.成交金额 * (double)0.001;
                    info.印花税 = info.手续费;
                }
                if (info.股票代码 != null && int.Parse(info.股票代码) < 600000)
                {
                    if (info.股数 != null)
                    {
                        double de = (double)info.股数 * (double)0.001;
                        info.过户费 = (double)Math.Round(de);
                    }
                }
                info.时间 = this.dateTimePicker1.Value;

                if (info.股票代码 != "" && info.股票名称 != "" && info.交易方向 != "" &&
                     info.股数 > 0 && info.成交均价 > 0 && info.成交金额 > 0)
                { //要素完整，给予增加
                    modelBLL.Add(info);
                    submitRowList.Add(row);
                    //  m_MainFrm.m_control1.Refresh(listInfo);
                }
            } //end foreach
            if (submitRowList.Count > 0)
            { //存在增加成功的记录
                foreach (DataGridViewRow row in submitRowList)
                {//清理增加窗口中插入成功的数据 
                    this.dataGridView1.Rows.Remove(row);
                }
                //刷新当日交易记录表
                m_MainFrm.m_control1.ExecuteSearch();
            }
        }

        private void btn_提交_Click(object sender, EventArgs e)
        {
            Submit();
            // this.Close();
        }

        /// <summary>
        /// 自动计算总价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "股数" || dataGridView1.Columns[e.ColumnIndex].Name == "成交均价")
            {
                if (this.dataGridView1.SelectedCells != null)
                {
                    if (this.dataGridView1.SelectedCells.Count <= 0) return;
                    DataGridViewRow row = this.dataGridView1.SelectedCells[0].OwningRow;
                    if (row.Cells["股数"].Value != null && row.Cells["成交均价"].Value != null)
                    {
                        string 股数 = row.Cells["股数"].Value.ToString();
                        string 均价 = row.Cells["成交均价"].Value.ToString();
                        double 股数_double = 0; double 均价_double = 0;
                        double.TryParse(股数, out 股数_double);
                        double.TryParse(均价, out 均价_double);
                        double 成交金额 = 股数_double * 均价_double;
                        row.Cells["成交金额"].Value = 成交金额.ToString();
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "股票代码")
            {
                if (this.dataGridView1.SelectedCells != null)
                {
                    if (this.dataGridView1.SelectedCells.Count <= 0) return;
                    DataGridViewRow row = this.dataGridView1.SelectedCells[0].OwningRow;
                    if (row.Cells["股票代码"].Value != null)
                    {
                        string 股票代码 = row.Cells["股票代码"].Value.ToString();
                        if (MainFrm.GUPIAO_DIC.ContainsKey(股票代码))
                            row.Cells["股票名称"].Value = MainFrm.GUPIAO_DIC[股票代码];
                    }
                }
            }
        }

        private void btn_当日交易汇总查看_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 1)
            //{
            //    if (MessageBox.Show("存在新增的交易记录，是否提交后再查看", "系统提示", MessageBoxButtons.OKCancel)
            //        == System.Windows.Forms.DialogResult.OK)
            //    {
            //        //Submit();
            //    }
            //}
            foreach (Control ctl in this.m_MainFrm.Controls)
            {
                SplitContainer splitContainer = ctl as SplitContainer;
                if (splitContainer != null && splitContainer.Panel2 != null)
                {
                    foreach (Control subctl in splitContainer.Panel2.Controls)
                    {
                        TabControl tab = subctl as TabControl;
                        if (tab != null)
                        {
                            foreach (Control subsubctl in tab.Controls)
                            {
                                TabPage page = subsubctl as TabPage;
                                if (page != null && page.Name == "page_查看当日交易记录")
                                {
                                    tab.SelectedTab = page;
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }



    }




}
