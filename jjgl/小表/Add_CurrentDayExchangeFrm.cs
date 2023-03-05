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

    public partial class Add_CurrentDayExchangeFrm : Form
    {
        CurrentDayExchangeListCtl m_userControl;
        public Add_CurrentDayExchangeFrm(CurrentDayExchangeListCtl _userControl)
        {
            InitializeComponent();
            this.comboBox_产品名称.SelectedIndexChanged += new EventHandler(comboBox_产品名称_SelectedIndexChanged);

            FillComboValue();
            m_userControl = _userControl;

            this.ActiveControl = this.dateTimePicker1;
            this.Load += new EventHandler(Add_CurrentDayExchangeFrm_Load);
        }

        void Add_CurrentDayExchangeFrm_Load(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void FillComboValue()
        {
            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList2 = modelBLL2.GetModelList("");
            this.comboBox_基金经理.DataSource = modelList2;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
            //if (modelList2.Count > 0)
            //    this.comboBox_基金经理.SelectedIndex = 0;

            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = modelBLL1.GetModelList("");
            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称"; 
        }


        private void btn_当日交易汇总查看_Click(object sender, EventArgs e)
        {
            if (m_userControl != null)
            {
                string 产品名称 = string.Empty;
                string 基金经理 = string.Empty;
                if (this.comboBox_产品名称.SelectedValue != null)
                    产品名称 = this.comboBox_产品名称.SelectedValue.ToString();
                if (this.comboBox_基金经理.SelectedValue != null)
                    基金经理 = this.comboBox_基金经理.SelectedValue.ToString();
                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                m_userControl.Out_ExecuteSearch("全部", "全部", this.dateTimePicker1.Value);
            }
        }


        private void btn_增加记录_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> 不计算税费集合_DIC = DataConvertor.Get不计算税费集合();

            #region 提示输入港币人民币汇率
            string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            Maticsoft.BLL.绩效考核_汇率 绩效考核_汇率BLL = new Maticsoft.BLL.绩效考核_汇率();
            Maticsoft.Model.绩效考核_汇率 绩效考核_汇率Model = 绩效考核_汇率BLL.GetModel(currentDayDate);
            double m_买入汇率 = 0;
            double m_卖出汇率 = 0;
            if (绩效考核_汇率Model == null) //汇率表中不存在该记录；
            {
                //弹出输入框，允许用户输入汇率
                Input_汇率 frm = new Input_汇率(currentDayDate);
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
            #endregion

            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
            model.产品名称 = this.comboBox_产品名称.Text.Trim();
            model.基金经理 = this.comboBox_基金经理.Text.Trim();
            model.股票代码 = this.txt_股票代码.Text.Trim();
            model.股票名称 = this.txt_股票名称.Text.Trim();

            if (model.产品名称 == "")
            {
                MessageBox.Show("产品名称不能为空", "系统提示");
                return;
            }
            if (model.股票代码 == "" || model.股票名称 == "")
            {
                MessageBox.Show("股票代码和股票名称不能为空", "系统提示");
                return;
            }
            //added by qhc
            model.是否为止损指令 = this.checkBox1.Checked;
            double 买入均价 = 0; long 今日买入股 = 0;
            double.TryParse(this.txt_买入均价.Text.Trim(), out 买入均价);
            long.TryParse(this.txt_买入股数.Text.Trim(), out 今日买入股);
           // model.买入均价 = 买入均价;
            model.今日买入股 = 今日买入股;

            double 卖出均价 = 0; long 今日卖出股 = 0;
            double.TryParse(this.txt_卖出均价.Text.Trim(), out 卖出均价);
            long.TryParse(this.txt_卖出股数.Text.Trim(), out 今日卖出股);
            //model.卖出均价 = 卖出均价;
            model.今日卖出股 = 今日卖出股;

            if (model.股票代码.Length == 4) //港股，需要乘以汇率 
            {
                model.买入均价 = 买入均价 * m_买入汇率;
                model.卖出均价 = 卖出均价 * m_卖出汇率;
            }
            else
            {
                model.买入均价 = 买入均价;
                model.卖出均价 = 卖出均价;
            }
            if (model.今日买入股 <= 0 || model.买入均价 <= 0) //只要有一个小于0，则两个值都为0；
            {
                model.今日买入股 = 0;
                model.买入均价 = 0;
            }
            if (model.今日卖出股 <= 0 || model.卖出均价 <= 0)//只要有一个小于0，则两个值都为0；
            {
                model.今日卖出股 = 0;
                model.卖出均价 = 0;
            }

            if ((model.今日买入股 <= 0 || model.买入均价 <= 0) && (model.今日卖出股 <= 0 || model.卖出均价 <= 0))
            {
                MessageBox.Show("股数和均价输入不合法", "系统提示");
                return;
            }
            #region 获取基金产品信息（20151104）
            Maticsoft.BLL.绩效考核_基金产品信息表 基金产品信息表BLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            Maticsoft.Model.绩效考核_基金产品信息表 基金产品信息表Model = 基金产品信息表BLL.GetModel(model.产品名称);
            //过户费比例 印花税 佣金 默认值都为0.001；
            double 过户费比例 = 0.001; double 印花税比例 = 0.001; double 佣金比例 = 0.001;
            if (基金产品信息表Model != null)
            {
                过户费比例 = 基金产品信息表Model.过户费比例;
                印花税比例 = 基金产品信息表Model.印花税;
                佣金比例 = 基金产品信息表Model.佣金;
            }
            if (不计算税费集合_DIC.ContainsKey(model.股票代码))
            {
                过户费比例 = 0;
                印花税比例 = 0;
                佣金比例 = 0;
            }
            #endregion

            model.买入金额 = model.今日买入股 * model.买入均价;
            model.卖出金额 = model.今日卖出股 * model.卖出均价;

            model.买入手续费 = model.买入金额 * 佣金比例;
            model.卖出手续费 = model.卖出金额 * 佣金比例;

            if (long.Parse(model.股票代码) > 600000)
            {
                model.买入过户费 = model.买入金额 * 过户费比例;
                model.卖出过户费 = model.卖出金额 * 过户费比例;

                //model.买入过户费 = model.今日买入股 * 过户费比例;
                //model.卖出过户费 = model.今日卖出股 * 过户费比例;
            }
            //只有卖出，才有“卖出印花税”，无“买入印花税”；
            model.卖出印花税 = model.卖出金额 * 印花税比例;

            model.买入清算金额 = model.买入金额 + model.买入手续费 + model.买入过户费 + model.买入印花税;
            model.卖出清算金额 = model.卖出金额 - model.卖出手续费 - model.卖出过户费 - model.卖出印花税;

            //时间不输入日期；
            model.时间 = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            long result = modelBLL.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
            if (result > 0) //存在记录，提示增加失败
            {
                if (MessageBox.Show("已经存在该记录,是否更新该记录", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    model.记录标识 = result;
                    if (modelBLL.Update(model))
                    {
                        ResetValue();
                        btn_当日交易汇总查看_Click(null, null);

                        MessageBox.Show("增加成功！", "系统提示");
                    }
                }
            }
            else //不存在记录，则增加记录
            {
                model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表");
                if (modelBLL.Add(model))
                {
                    ResetValue(); 
                    if (model.时间 == m_userControl.CurrentTime) //当前时间正好等于“小表区”显示的时间，直接增加到“小表的DataGridView中”
                    {
                        this.m_userControl.AddOneDataGridViewRow(model);
                    }
                    MessageBox.Show("增加成功！", "系统提示");
                }
            }
        }

        private void txt_股票代码_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_股票代码.Text.Trim() == "")
            {
                this.txt_股票名称.Text = "";
                return;
            }
            string 股票代码 = this.txt_股票代码.Text.Trim();
            if (MainFrm.GUPIAO_DIC.ContainsKey(股票代码))
                this.txt_股票名称.Text = MainFrm.GUPIAO_DIC[股票代码];
            else
                this.txt_股票名称.Text = "";
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.dateTimePicker1.Focused)
                {
                    this.comboBox_产品名称.Focus();
                }
                else if (this.comboBox_产品名称.Focused)
                {
                    this.comboBox_基金经理.Focus();
                }
                else if (this.comboBox_基金经理.Focused)
                {
                    this.txt_股票代码.Focus();
                }
                else if (this.txt_股票代码.Focused)
                {
                    this.txt_买入股数.Focus();
                }
                else if (this.txt_买入股数.Focused)
                {
                    this.txt_买入均价.Focus();
                }
                else if (this.txt_买入均价.Focused)
                {
                    this.txt_卖出股数.Focus();
                }
                else if (this.txt_卖出股数.Focused)
                {
                    this.txt_卖出均价.Focus();
                }
                else if (this.txt_卖出均价.Focused)
                {
                    this.dateTimePicker1.Focus();
                }
            }
        }

        #region ComboBox事件

        private void comboBox_基金经理_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string 基金经理 = string.Empty;
            //if (this.comboBox_基金经理.SelectedItem != null)
            //{
            //    Maticsoft.Model.绩效考核_基金经理信息表 tempModel = this.comboBox_基金经理.SelectedItem as Maticsoft.Model.绩效考核_基金经理信息表;
            //    基金经理 = tempModel.基金经理;
            //}
            //Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            //List<Maticsoft.Model.绩效考核_基金经理信息表> modelList1 = modelBLL1.GetModelList("");
            //foreach (Maticsoft.Model.绩效考核_基金经理信息表 model in modelList1)
            //{
            //    //由基金经理获取其管理的产品
            //    if (基金经理 == model.基金经理)
            //    {
            //        List<Maticsoft.Model.绩效考核_基金产品信息表> tempmodelList = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
            //        if (model.管理产品 != null && model.管理产品 != "")
            //        {
            //            string[] 管理产品Array = model.管理产品.Split(new char[] { ',' });
            //            foreach (string temp管理产品 in 管理产品Array)
            //            {
            //                if (temp管理产品 == "") continue;
            //                Maticsoft.Model.绩效考核_基金产品信息表 tempModel = new Maticsoft.Model.绩效考核_基金产品信息表();
            //                tempModel.产品名称 = temp管理产品;
            //                tempmodelList.Add(tempModel);
            //            }
            //        }
            //        //取消产品名称的绑定事件，避免产品名称的变化，反过来再影响基金经理；
            //        this.comboBox_产品名称.SelectedIndexChanged -= new EventHandler(comboBox_产品名称_SelectedIndexChanged);
            //        this.comboBox_产品名称.DataSource = tempmodelList;
            //        if (tempmodelList.Count > 0)
            //            this.comboBox_产品名称.SelectedIndex = 0;

            //        this.comboBox_产品名称.SelectedIndexChanged += new EventHandler(comboBox_产品名称_SelectedIndexChanged);
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// 由产品反推其被哪些基金经理所管理；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_产品名称_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Dictionary<string, List<string>> DIC_产品_基金经理List = DataConvertor.GetDictionary_产品_基金经理();

            Maticsoft.Model.绩效考核_基金产品信息表 tempModel = this.comboBox_产品名称.SelectedItem as Maticsoft.Model.绩效考核_基金产品信息表;
            if (tempModel != null)
            {
                if (DIC_产品_基金经理List.ContainsKey(tempModel.产品名称))
                {
                    List<string> 基金经理列表 = DIC_产品_基金经理List[tempModel.产品名称];
                    List<Maticsoft.Model.绩效考核_基金经理信息表> 基金经理列表_ModelList = new List<Maticsoft.Model.绩效考核_基金经理信息表>();
                    foreach (string str基金经理 in 基金经理列表)
                    {
                        基金经理列表_ModelList.Add(new Maticsoft.Model.绩效考核_基金经理信息表(str基金经理, ""));
                    }
                     
                    this.comboBox_基金经理.DataSource = 基金经理列表_ModelList;
                    if (基金经理列表_ModelList.Count > 0)
                        this.comboBox_基金经理.SelectedIndex = 0; 
                }
            }

        }

        private void btn_列出全部基金经理_Click(object sender, EventArgs e)
        { 

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList2 = modelBLL2.GetModelList("");
            this.comboBox_基金经理.DataSource = modelList2;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
             
        }

        private void btn_列出全部产品_Click(object sender, EventArgs e)
        { 

            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = modelBLL1.GetModelList("");
            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称"; 
        }

        #endregion

        private void btn_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetValue()
        {
            this.txt_股票代码.Text = "";
            this.txt_股票名称.Text = "";
            this.txt_买入股数.Text = "";
            this.txt_买入均价.Text = "";
            this.txt_卖出股数.Text = "";
            this.txt_卖出均价.Text = "";
        }


        #region old


        ///// <summary>
        ///// 增加或更新记录
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public static bool Execute_Add_股票每日交易汇总小表(Maticsoft.Model.绩效考核_交易记录表 model)
        //{
        //    Maticsoft.DAL.绩效考核_交易记录表 modelBLL = new Maticsoft.DAL.绩效考核_交易记录表();

        //    Maticsoft.Model.绩效考核_股票每日交易汇总小表 NewModel = modelBLL.Get股票每日交易汇总小表Model(model.产品名称, model.基金经理, model.股票代码, model.股票名称, model.时间);

        //    Maticsoft.BLL.绩效考核_股票每日交易汇总小表 NewModeBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
        //    bool flag = false;
        //    long result = NewModeBLL.Exists(NewModel.股票代码, NewModel.基金经理, NewModel.产品名称, model.时间);
        //    if (result > 0) //存在记录，则更新记录
        //    {
        //        NewModel.记录标识 = result;
        //        if (NewModeBLL.Update(NewModel))
        //            flag = true;
        //    }
        //    else //不存在记录，则增加记录
        //    {
        //        NewModel.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表");
        //        if (NewModeBLL.Add(NewModel))
        //            flag = true;
        //    }
        //    return flag;
        //}

        ///// <summary>
        ///// 更新或删除记录
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //private bool Execute_delete_股票每日交易汇总小表(Maticsoft.Model.绩效考核_交易记录表 model)
        //{
        //    try
        //    {
        //        //“绩效考核_交易记录表”中一条或多条记录对应 “绩效考核_股票每日交易汇总小表”中一条记录
        //        Maticsoft.DAL.绩效考核_交易记录表 modelBLL = new Maticsoft.DAL.绩效考核_交易记录表();
        //        Maticsoft.Model.绩效考核_股票每日交易汇总小表 汇总小表_Model = modelBLL.Get股票每日交易汇总小表Model(model.产品名称, model.基金经理, model.股票代码, model.股票名称, model.时间);
        //        Maticsoft.BLL.绩效考核_股票每日交易汇总小表 汇总小表_BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();

        //        long result = 汇总小表_BLL.Exists(汇总小表_Model.股票代码, 汇总小表_Model.基金经理, 汇总小表_Model.产品名称, model.时间);

        //        if (result >= 0) //存在记录
        //        {
        //            汇总小表_Model.记录标识 = result;
        //            if (汇总小表_Model.今日买入股 == 0 && 汇总小表_Model.今日卖出股 == 0)  //无买入和卖出记录，则该记录存在已经无意义，需要删除
        //            {
        //                汇总小表_BLL.Delete(result);
        //            }
        //            else //有买入或卖出记录，需要更新“股票每日交易汇总小表”内容
        //            {
        //                汇总小表_BLL.Update(汇总小表_Model);
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    //if (this.dataGridView1.SelectedRows.Count >= 1)
        //    //{
        //    //    DataGridViewRow row = this.dataGridView1.SelectedRows[0];

        //    //    long.TryParse(row.Cells["记录标识"].Value.ToString(), out m_记录标识);
        //    //    this.comboBox_产品名称.Text = row.Cells["产品名称"].Value.ToString();
        //    //    this.comboBox_基金经理.Text = row.Cells["基金经理"].Value.ToString();
        //    //    this.comboBox_交易方向.Text = row.Cells["交易方向"].Value.ToString();
        //    //    this.dateTimePicker1.Value = DateTime.Parse(row.Cells["时间"].Value.ToString());

        //    //    this.txt_股票代码.Text = row.Cells["股票代码"].Value.ToString();
        //    //    this.txt_股票名称.Text = row.Cells["股票名称"].Value.ToString();
        //    //    decimal 股数 = 0;
        //    //    decimal.TryParse(row.Cells["股数"].Value.ToString(), out 股数);
        //    //    this.num_股数.Value = 股数;
        //    //    this.txt_成交均价.Text = row.Cells["成交均价"].Value.ToString();
        //    //}

        //}

        //private void btn_修改记录_Click(object sender, EventArgs e)
        //{
        //    //if (this.dataGridView1.SelectedRows.Count <= 0)
        //    //{
        //    //    MessageBox.Show("请选择修改的记录！", "系统提示");
        //    //    return;
        //    //}
        //    //Maticsoft.BLL.绩效考核_交易记录表 modelBLL = new Maticsoft.BLL.绩效考核_交易记录表();
        //    //Maticsoft.Model.绩效考核_交易记录表 info = new Maticsoft.Model.绩效考核_交易记录表();
        //    //info.产品名称 = this.comboBox_产品名称.Text.Trim();
        //    //info.基金经理 = this.comboBox_基金经理.Text.Trim();
        //    //info.股票代码 = this.txt_股票代码.Text.Trim();
        //    //info.股票名称 = this.txt_股票名称.Text.Trim();
        //    //if (info.产品名称 == "" || info.基金经理 == "")
        //    //{
        //    //    MessageBox.Show("产品名称和基金经理不能为空", "系统提示");
        //    //    return;
        //    //}
        //    //if (info.股票代码 == "" || info.股票名称 == "")
        //    //{
        //    //    MessageBox.Show("股票代码和股票名称不能为空", "系统提示");
        //    //    return;
        //    //}
        //    //info.交易方向 = this.comboBox_交易方向.Text.Trim();
        //    //info.股数 = (long)this.num_股数.Value;
        //    //double 成交均价 = 0;
        //    //double.TryParse(this.txt_成交均价.Text.Trim(), out 成交均价);
        //    //info.成交均价 = 成交均价;
        //    //if (info.股数 <= 0 || info.成交均价 <= 0)
        //    //{
        //    //    MessageBox.Show("股数或成交均价不能小于等于0", "系统提示");
        //    //    return;
        //    //}
        //    //info.成交金额 = info.股数 * info.成交均价;
        //    //info.手续费 = info.成交金额 * (double)0.001;
        //    //info.印花税 = info.手续费;

        //    //if (info.股票代码 != null && info.股票代码 != "")
        //    //{
        //    //    if (long.Parse(info.股票代码) > 600000)
        //    //    {
        //    //        double de = (double)info.股数 * (double)0.001;
        //    //        info.过户费 = (double)Math.Round(de);
        //    //    }
        //    //}
        //    ////时间不输入日期；
        //    //info.时间 = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
        //    //info.记录标识 = m_记录标识;
        //    //if (info.记录标识 <= 0)
        //    //{
        //    //    MessageBox.Show("请选择修改的记录！", "系统提示");
        //    //    return;
        //    //}
        //    ////  info.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_交易记录表");

        //    //if (modelBLL.Update(info))
        //    //{
        //    //    SearchData();
        //    //    this.txt_股票代码.Text = "";
        //    //    this.txt_股票名称.Text = "";
        //    //    this.num_股数.Value = 0;
        //    //    this.txt_成交均价.Text = "";
        //    //    MessageBox.Show("修改成功！", "系统提示");
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("修改失败！数据库操作失败！", "系统提示");
        //    //}

        //}

        //private void button_删除记录_Click(object sender, EventArgs e)
        //{
        //    if (this.dataGridView1.SelectedRows.Count <= 0)
        //    {
        //        MessageBox.Show("请选择删除记录！", "系统提示");
        //        return;
        //    }

        //    Maticsoft.BLL.绩效考核_交易记录表 modelBLL = new Maticsoft.BLL.绩效考核_交易记录表();
        //    Maticsoft.BLL.绩效考核_股票每日交易汇总小表 汇总小表_BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
        //    int deleteRowCount = 0;
        //    if (MessageBox.Show("确认删除选中记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        string strList = string.Empty;
        //        DataGridViewSelectedRowCollection collection = this.dataGridView1.SelectedRows;
        //        for (int i = collection.Count - 1; i >= 0; i--)
        //        {
        //            long 记录标识 = 0;
        //            long.TryParse(collection[i].Cells["记录标识"].Value.ToString(), out 记录标识);
        //            Maticsoft.Model.绩效考核_交易记录表 model = modelBLL.GetModel(记录标识);
        //            if (modelBLL.Delete(记录标识)) //先删除“交易记录表”记录
        //            {
        //                if (Execute_delete_股票每日交易汇总小表(model))  //更新“绩效考核_股票每日交易汇总小表”内容
        //                {
        //                    deleteRowCount++;
        //                }
        //            }
        //        }
        //        if (deleteRowCount > 0)
        //        {
        //            SearchData();

        //            this.txt_股票代码.Text = "";
        //            this.txt_股票名称.Text = "";
        //            this.num_股数.Value = 0;
        //            this.txt_成交均价.Text = "";

        //            MessageBox.Show(string.Format("成功删除“{0}”条记录！", deleteRowCount), "系统提示");
        //        }
        //        else
        //        {
        //            MessageBox.Show("删除失败，数据库操作失败！", "系统提示");
        //        }
        //    }
        //}

        //private void button_查询记录_Click(object sender, EventArgs e)
        //{
        //    SearchData();
        //}
        #endregion
    }




}
