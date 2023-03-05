using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    /// <summary> 
    /// </summary>
    public partial class CurrentDayExchangeHZCtl_Import : UserControl
    {
        public CurrentDayExchangeHZCtl_Import()
        {
            InitializeComponent();
            //InitializeControl();
        }



        //private void InitializeControl()
        //{
        //    for (int i = 1; i < 13; i++)
        //    {
        //        this.comboBox_月.Items.Add(i.ToString());
        //    }
        //    for (int i = 1; i < 32; i++)
        //    {
        //        this.comboBox_日.Items.Add(i.ToString());
        //    }
        //}

        private string m_当前导入的产品名称 = string.Empty;
        private void btn_导入历史总表格投资统计汇总_Click(object sender, EventArgs e)
        {
             
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_基金产品每日统计 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
                Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();

                DataSet ds = DataConvertor.GetDataSetFromExcel(ofd.FileName);
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
                    }
                    int 年_INT = 0; int 月_INT = 0; int 日_INT = 0;
                    int.TryParse(月, out 月_INT);
                    int.TryParse(日, out 日_INT);
                    if (年_INT > 2050 || 年_INT < 2000)
                    {
                        Input_year frm = new Input_year();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            年_INT = frm.Year;
                        }
                        else
                            return;
                        //MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
                        //return;
                    }
                    if (月_INT > 12 || 月_INT < 1)
                    {
                        MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
                        return;
                    }
                    if (日_INT > 31 || 日_INT < 1)
                    {
                        MessageBox.Show(string.Format("导入失败, Excel中表名（{0}）转换日期格式时转换失败", oldName), "系统提示");
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
                            if (row[0] != null && row[0].ToString() != "")
                                model.股票代码 = row[0].ToString();
                            if (row[1] != null && row[1].ToString() != "")
                                model.股票名称 = row[1].ToString();

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

                            double 本年净值贡献 = 0; double 当日盈亏 = 0;
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString(), out 本年净值贡献);
                                model.本年净值贡献 = 本年净值贡献;
                            }
                            if (row[12] != null && row[12].ToString() != "")
                            {
                                double.TryParse(row[12].ToString(), out 当日盈亏);
                                model.当日盈亏 = 当日盈亏;
                            }

                            model.时间 = currentDT;
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总大表");
                            model.产品名称 = m_当前导入的产品名称;
                            if (model.股票名称.Length > 3)
                            {
                                string jc = model.股票名称.Substring(model.股票名称.Length - 2, 1);
                                if (MainFrm.JIJINJINGLI_DIC.ContainsKey(jc))
                                    model.基金经理 = MainFrm.JIJINJINGLI_DIC[jc];
                            }

                            modelBLL_股票每日交易汇总大表.Add(model);
                        }
                        #endregion

                        #region 合计行
                        else if (row[0].ToString() == "合计")
                        {
                            continue;
                        }
                        #endregion

                        #region 产品行 ---- [绩效考核_基金产品每日统计]
                        else if (row[8].ToString() == "今年最大净值")
                        {
                            DataRow preRow = table.Rows[i - 1];
                            string 产品名称 = preRow[0].ToString();
                            double 今年最大净值 = 0;
                            double.TryParse(row[9].ToString(), out 今年最大净值);
                            Maticsoft.Model.绩效考核_基金产品每日统计 tempModel = new Maticsoft.Model.绩效考核_基金产品每日统计();
                            tempModel.产品名称 = 产品名称;
                            tempModel.时间 = currentDT;
                            tempModel.今年最大净值 = 今年最大净值;
                            tempModel.回撤率 = row[11].ToString();
                            modelBLL_基金产品每日统计.UpdatePatial(tempModel);
                        }

                        else if (row[2].ToString() == "资产总额" && row[4].ToString() == "资金余额")
                        {
                            if (table.Columns.Count >= 12)
                            {
                                Maticsoft.Model.绩效考核_基金产品每日统计 model1 = new Maticsoft.Model.绩效考核_基金产品每日统计();
                                if (row[0] != null && row[0].ToString() != "")
                                {
                                    model1.产品名称 = row[0].ToString();
                                    m_当前导入的产品名称 = model1.产品名称;
                                }

                                double 资产总额 = 0; double 资金余额 = 0; double 单位净值 = 0; 
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
                                if (row[9] != null && row[9].ToString() != "")
                                {
                                    model1.今年收益率 = row[9].ToString();
                                }
                                if (row[11] != null && row[11].ToString() != "")
                                {
                                    double.TryParse(row[11].ToString(), out 单位净值);
                                    model1.单位净值 = 单位净值;
                                }
                                model1.时间 = currentDT;
                                model1.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_基金产品每日统计");
                                modelBLL_基金产品每日统计.Add(model1);
                            }
                        }
                        #endregion

                    }

                }
                //刷新显示记录
                Search();
                MessageBox.Show("导入完成", "系统提示");
            } //  end if (ofd.ShowDialog() == DialogResult.OK)
        }

        /// <summary>
        /// 删除当日股票汇总记录；；
        /// 删除当日产品记录；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_删除记录_Click(object sender, EventArgs e)
        {  
            //Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            //DataTable table_基金产品每日统计 = this.dataGridView2.DataSource as DataTable;
            //DataTable table_股票每日交易汇总大表 = this.dataGridView1.DataSource as DataTable;
            //if (table_基金产品每日统计 == null || table_股票每日交易汇总大表==null)
            //{
            //    MessageBox.Show("删除失败，当日记录获取失败！", "系统提示");
            //    return;
            //}

            //if (table_基金产品每日统计.Rows.Count <= 0 && table_股票每日交易汇总大表.Rows.Count <= 0)
            //{
            //    MessageBox.Show("删除失败，当日无记录！", "系统提示");
            //    return;
            //}
            //string 记录标识List = string.Empty;
            //foreach (DataRow row in table.Rows)
            //{
            //    if (row["记录标识"].ToString() != null)
            //    {
            //        记录标识List += row["记录标识"].ToString() + ",";
            //    }
            //}
            //if (记录标识List.Length > 0)
            //    记录标识List = 记录标识List.Substring(0, 记录标识List.Length - 1);

            //if (modelBLL_股票每日交易汇总小表.DeleteList(记录标识List))
            //{
            //    Search();
            //    MessageBox.Show("删除成功！", "系统提示");
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox_月_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox_日_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            int 年 = 0; int 月 = 0; int 日 = 0;
            //int.TryParse(this.txt_年.Text.Trim(), out 年);
            //if (this.comboBox_月.Text != null)
            //    int.TryParse(this.comboBox_月.Text, out 月);

            //if (this.comboBox_日.Text != null)
            //    int.TryParse(this.comboBox_日.Text, out 日);
            //if (年 < 2000)
            //{
            //    // MessageBox.Show("年份不合法", "系统提示");
            //    return;
            //}
            //if (月 < 1 || 月 > 12)
            //{
            //    MessageBox.Show("请选择合法月份！", "系统提示");
            //    return;
            //}
            //if (日 < 1 || 日 > 31)
            //{
            //    MessageBox.Show("请选择合法日！", "系统提示");
            //    return;
            //}

            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL_基金产品每日统计 = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_股票每日交易汇总大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            DateTime dt = new DateTime(年, 月, 日);
            string currentDT = dt.ToString("yyyy/MM/dd");

            DataSet ds_绩效考核_基金产品每日统计 = modelBLL_基金产品每日统计.GetList(string.Format(" 时间 = '{0}' ", currentDT));
            if (ds_绩效考核_基金产品每日统计 != null)
            {
                if (ds_绩效考核_基金产品每日统计.Tables.Count > 0)
                {
                    this.dataGridView2.DataSource = ds_绩效考核_基金产品每日统计.Tables[0];
                }
            }

            DataSet ds_股票每日交易汇总大表 = modelBLL_股票每日交易汇总大表.GetList(string.Format(" 时间 = '{0}'", currentDT));
            if (ds_股票每日交易汇总大表 != null)
            {
                if (ds_股票每日交易汇总大表.Tables.Count > 0)
                {
                    this.dataGridView1.DataSource = ds_股票每日交易汇总大表.Tables[0];
                }
            }

        }

    }
}
