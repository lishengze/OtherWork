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
    /// 每日交易记录
    /// </summary>
    public partial class CurrentDayExchangeListCtl : UserControl
    {

        public DataGridView MyDataGridView
        {
            get
            {
                return this.dataGridView1;
            }
        }

        public string CurrentTime
        {
            get
            {
                return this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
        }
        public CurrentDayExchangeListCtl()
        {
            InitializeComponent();

            this.dateTimePicker1.Value = System.DateTime.Now;
            FillInitValue1();

            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户")
            {
                this.btn_导入历史记录.Visible = false;
                this.btn_管理未成功导入数据.Visible = false;
            }
        }

        private void FillInitValue1()
        {
            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList2 = new List<Maticsoft.Model.绩效考核_基金经理信息表>();
            modelList2.Add(new Maticsoft.Model.绩效考核_基金经理信息表("全部", "全部"));
            modelList2.AddRange(modelBLL2.GetModelList(""));

            this.comboBox_基金经理.DataSource = modelList2;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
            if (modelList2.Count > 0)
                this.comboBox_基金经理.SelectedIndex = 0;


            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
            modelList1.Add(new Maticsoft.Model.绩效考核_基金产品信息表("全部"));
            modelList1.AddRange(modelBLL1.GetModelList(""));

            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";

            if (modelList1.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Pre_ExecuteSearch();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pre_ExecuteSearch();
        }

        private void comboBox_基金经理_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pre_ExecuteSearch();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            Pre_ExecuteSearch();
        }

        private void Pre_ExecuteSearch()
        {
            if (this.comboBox_产品名称.SelectedItem != null && this.comboBox_基金经理.SelectedItem != null)
            {
                string 产品名称 = string.Empty;
                string 基金经理 = string.Empty;
                Maticsoft.Model.绩效考核_基金产品信息表 model1 = this.comboBox_产品名称.SelectedItem as Maticsoft.Model.绩效考核_基金产品信息表;
                if (model1 != null)
                    产品名称 = model1.产品名称;

                Maticsoft.Model.绩效考核_基金经理信息表 model2 = this.comboBox_基金经理.SelectedItem as Maticsoft.Model.绩效考核_基金经理信息表;
                if (model2 != null)
                    基金经理 = model2.基金经理;

                string currentDayDate = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                ExecuteSearch(产品名称, 基金经理, currentDayDate);
            }
        }

        public void Out_ExecuteSearch(string 产品名称, string 基金经理, DateTime dt)
        {
            this.comboBox_产品名称.Text = 产品名称;
            this.comboBox_基金经理.Text = 基金经理;
            this.dateTimePicker1.Value = dt;

            string currentDayDate = dt.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            ExecuteSearch(产品名称, 基金经理, currentDayDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate">当前时间</param>
        /// <param name="cpmc"></param>
        private void ExecuteSearch(string 产品名称, string 基金经理, string currentDayDate)
        {
            List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> 小表汇总_List = new List<Maticsoft.Model.绩效考核_股票每日交易汇总小表>();
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 小表汇总BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();

            string subSql = string.Format("  产品名称='{0}'  and 基金经理='{1}' and 时间 = '{2}'", 产品名称, 基金经理, currentDayDate);

            if (产品名称 == "全部" && 基金经理 != "全部")
            {
                subSql = string.Format(" 基金经理='{0}' and 时间 = '{1}' ", 基金经理, currentDayDate);
            }
            else if (产品名称 != "全部" && 基金经理 == "全部")
            {
                subSql = string.Format("  产品名称='{0}'  and 时间 = '{1}' ", 产品名称, currentDayDate);
            }
            else if (产品名称 == "全部" && 基金经理 == "全部")
            {
                subSql = string.Format("   时间 = '{0}' ", currentDayDate);
            }
            DataSet ds = 小表汇总BLL.GetList(subSql);
            if (ds != null && ds.Tables.Count > 0)
                this.dataGridView1.DataSource = ds.Tables[0];

            //this.dataGridView1.Columns["是否为止损指令"].Visible = false;
        }

        public void AddOneDataGridViewRow(Maticsoft.Model.绩效考核_股票每日交易汇总小表 model)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataTable table = this.dataGridView1.DataSource as DataTable;
                this.dataGridView1.DataSource = null; //解除绑定 
                DataRow row = table.NewRow();
                row["记录标识"] = model.记录标识;
                row["股票代码"] = model.股票代码;
                row["基金经理"] = model.基金经理;
                row["产品名称"] = model.产品名称;
                row["股票名称"] = model.股票名称;
                row["时间"] = model.时间;
                row["今日买入股"] = model.今日买入股;
                row["买入均价"] = model.买入均价;
                row["买入金额"] = model.买入金额;
                row["今日卖出股"] = model.今日卖出股;
                row["卖出均价"] = model.卖出均价;
                row["卖出金额"] = model.卖出金额;
                row["买入手续费"] = model.买入手续费;
                row["买入过户费"] = model.买入过户费;
                row["买入印花税"] = model.买入印花税;
                row["卖出手续费"] = model.卖出手续费;
                row["卖出过户费"] = model.卖出过户费;
                row["卖出印花税"] = model.卖出印花税;
                row["买入清算金额"] = model.买入清算金额;
                row["卖出清算金额"] = model.卖出清算金额;
                table.Rows.Add(row);
                this.dataGridView1.DataSource = table;
            }
            else
                Pre_ExecuteSearch();
        }

        private void btn_导出当日记录_Click(object sender, EventArgs e)
        {
            小表_导出历史记录 frm = new 小表_导出历史记录(this.dateTimePicker1.Value);
            frm.ShowDialog();
        }

        private Maticsoft.BLL.绩效考核_股票每日交易汇总小表_格式不符 小表_格式不符modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表_格式不符();
        private int m_导入新增count = 0;
        private int m_导入更新count = 0;
        private string m_当前导入的基金经理 = string.Empty;
        private int m_未正确导入记录Count = 0;
        private List<DateTime> m_时间列表 = new List<DateTime>();
        /// <summary>
        /// 导入小表记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_导入历史记录_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                m_导入新增count = 0;
                m_导入更新count = 0;
                m_时间列表.Clear();
                m_未正确导入记录Count = 0;
                m_当前导入的基金经理 = string.Empty;

                string 基金产品 = string.Empty;
                Input_ProductName frm = new Input_ProductName();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    基金产品 = frm.基金产品;
                }
                else
                { //不选择基金产品，结束导入动作 
                    MessageBox.Show("未选择基金产品，导入失败！", "系统提示");
                    return;
                }
                //更新“股票信息”字典
                Dictionary<string, string> DockCodeName_DIC = DataConvertor.DIC_股票代码_股票名称();

                DataSet ds1 = ExcelReader.GetDataSetFromExcel(ofd.FileName, 1);
                foreach (DataTable table in ds1.Tables)
                {
                    #region 获取年月日
                    string currentDT = string.Empty;

                    string 年 = string.Empty;
                    string 月 = string.Empty;
                    string 日 = string.Empty;
                    int 年_INT = 0; int 月_INT = 0; int 日_INT = 0;

                    #region 通过table文件名获取 月份+日期

                    string[] names = table.TableName.Split(new char[] { '月' });
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
                    int.TryParse(月, out 月_INT);
                    int.TryParse(日, out 日_INT);

                    #endregion

                    #region 读取第二行，获取年份
                    if (table.Rows.Count > 2)
                    {
                        DataRow row = table.Rows[1];
                        if (row[3].ToString() == "日期" || row[4].ToString() == "日期") //  && row1 == "今日操作记录"
                        {
                            string 旧日期格式 = string.Empty;
                            if (row[3].ToString() == "日期") 旧日期格式 = row[4].ToString();
                            else if (row[4].ToString() == "日期") 旧日期格式 = row[5].ToString();
                            if (旧日期格式.Length == 8)
                            {
                                //int 月_INT = 0; int 日_INT = 0;
                                int.TryParse(旧日期格式.Substring(0, 4), out 年_INT);
                                //int.TryParse(旧日期格式.Substring(4, 2), out 月_INT);
                                // int.TryParse(旧日期格式.Substring(6, 2), out 日_INT); 
                            }
                        }
                    }
                    #endregion

                    if (年_INT < 2000 || 月_INT > 12 || 月_INT < 1 || 日_INT > 31 || 日_INT < 1)
                    {
                        MessageBox.Show("导入失败, Excel中日期读取失败或日期不合法", "系统提示");
                        return;
                    }
                    DateTime dt = new DateTime(年_INT, 月_INT, 日_INT);
                    currentDT = dt.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    m_时间列表.Add(dt);

                    //清理导入的当日不符合格式的临时缓存表记录
                    int rows2 = DbHelperSQL.ExecuteSql(string.Format("delete from 绩效考核_股票每日交易汇总小表_格式不符  where 时间= '{0}'", currentDT));

                    #endregion

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];
                        string row0 = row[0].ToString();
                        string row1 = row[1].ToString();
                        string row2 = row[2].ToString();
                        string row3 = row[3].ToString();

                        #region 遇到最新组合状况文字，则读取完成
                        if (row0 == "最新组合状况" || row1 == "最新组合状况" ||
                            row2 == "最新组合状况" || row3 == "最新组合状况")
                        {
                            break;
                        }
                        #endregion

                        #region 股票行 ----[绩效考核_股票每日交易汇总小表]
                        if (row1 == "序号" && row2 == "股票代码" && row3 == "股票名称") //第一、第二、第三行都不能为空，则是实际数据部分
                        {
                            continue;
                        }
                        else if (row1 != "" && row2 != "" && row3 != "")
                        {
                            Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();

                            //row[0] 为基金经理行
                            if (row0.Trim() != "")
                                m_当前导入的基金经理 = row0.Trim();
                            //row[1] 为序号行，不需要解析
                            if (row[3] != null && row[3].ToString() != "")
                            {
                                string 基金经理简称 = string.Empty;
                                //东江环保（徐）
                                string[] 股票名称Array = row[3].ToString().Split(new char[] { '（', '(' });
                                if (股票名称Array.Length >= 1)
                                {
                                    model.股票名称 = 股票名称Array[0].Replace(" ", "");
                                }
                                if (股票名称Array.Length >= 2)
                                {
                                    基金经理简称 = 股票名称Array[1].Substring(0, 1);
                                }
                                if (基金经理简称.Length >= 1) //人福医药（夏)，股票名称后面带有基金经理的，优先用这个
                                {
                                    if (MainFrm.JIJINJINGLI_DIC.ContainsKey(基金经理简称))
                                        model.基金经理 = MainFrm.JIJINJINGLI_DIC[基金经理简称];
                                    else if (MainFrm.JIJINJINGLI_DIC.ContainsValue(m_当前导入的基金经理))
                                        model.基金经理 = m_当前导入的基金经理;
                                }
                                else // 股票名称后面不带有基金经理的，用第一行读取的基金经理
                                {
                                    if (MainFrm.JIJINJINGLI_DIC.ContainsValue(m_当前导入的基金经理))
                                        model.基金经理 = m_当前导入的基金经理;
                                }
                            }
                            if (row[2] != null && row[2].ToString() != "")
                            {
                                string temp股票代码 = row[2].ToString().Trim();
                                model.股票代码 = DataConvertor.Get标准化股票代码(temp股票代码, model.股票名称, DockCodeName_DIC);
                            }

                            long 今日买入股 = 0; double 买入均价 = 0; double 买入金额 = 0;
                            long 今日卖出股 = 0; double 卖出均价 = 0; double 卖出金额 = 0;

                            if (row[4] != null && row[4].ToString() != "")
                            {
                                long.TryParse(row[4].ToString().Replace(",", ""), out 今日买入股);
                                model.今日买入股 = 今日买入股;
                            }
                            if (今日买入股 != 0)
                            {
                                if (row[5] != null && row[5].ToString() != "")
                                {
                                    double.TryParse(row[5].ToString().Replace(",", ""), out 买入均价);
                                    model.买入均价 = 买入均价;
                                }
                                if (row[6] != null && row[6].ToString() != "")
                                {
                                    double.TryParse(row[6].ToString().Replace(",", ""), out 买入金额);
                                    model.买入金额 = 买入金额;
                                }
                            }
                            if (row[7] != null && row[7].ToString() != "")
                            {
                                long.TryParse(row[7].ToString().Replace(",", ""), out 今日卖出股);
                                model.今日卖出股 = 今日卖出股;
                            }
                            if (今日卖出股 != 0)
                            {
                                if (row[8] != null && row[8].ToString() != "")
                                {
                                    double.TryParse(row[8].ToString().Replace(",", ""), out 卖出均价);
                                    model.卖出均价 = 卖出均价;
                                }
                                if (row[9] != null && row[9].ToString() != "")
                                {
                                    double.TryParse(row[9].ToString().Replace(",", ""), out 卖出金额);
                                    model.卖出金额 = 卖出金额;
                                }
                            }
                            if (model.今日买入股 == 0 && model.今日卖出股 == 0)
                                continue; //全部为0，则该条记录无效 

                            double 买入手续费 = 0; double 买入过户费 = 0; double 买入印花税 = 0; double 买入清算金额 = 0;
                            double 卖出手续费 = 0; double 卖出过户费 = 0; double 卖出印花税 = 0; double 卖出清算金额 = 0;
                            if (row[10] != null && row[10].ToString() != "")
                            {
                                double.TryParse(row[10].ToString().Replace(",", ""), out 买入手续费);
                                model.买入手续费 = 买入手续费;
                            }
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString().Replace(",", ""), out 买入过户费);
                                model.买入过户费 = 买入过户费;
                            }
                            if (row[12] != null && row[12].ToString() != "")
                            {
                                double.TryParse(row[12].ToString().Replace(",", ""), out 买入印花税);
                                model.买入印花税 = 买入印花税;
                            }

                            if (row[13] != null && row[13].ToString() != "")
                            {
                                double.TryParse(row[13].ToString().Replace(",", ""), out 卖出手续费);
                                model.卖出手续费 = 卖出手续费;
                            }
                            if (row[14] != null && row[14].ToString() != "")
                            {
                                double.TryParse(row[14].ToString().Replace(",", ""), out 卖出过户费);
                                model.卖出过户费 = 卖出过户费;
                            }
                            if (row[15] != null && row[15].ToString() != "")
                            {
                                double.TryParse(row[15].ToString().Replace(",", ""), out 卖出印花税);
                                model.卖出印花税 = 卖出印花税;
                            }

                            if (row[16] != null && row[16].ToString() != "")
                            {
                                double.TryParse(row[16].ToString().Replace(",", ""), out 买入清算金额);
                                model.买入清算金额 = 买入清算金额;
                            }
                            if (row[17] != null && row[17].ToString() != "")
                            {
                                double.TryParse(row[17].ToString().Replace(",", ""), out 卖出清算金额);
                                model.卖出清算金额 = 卖出清算金额;
                            }

                            model.时间 = currentDT;
                            model.产品名称 = 基金产品;
                            if (model.股票代码 == "" && model.产品名称 == "")
                            {
                                continue;
                            }
                            else if (model.股票代码 != "" && model.产品名称 != "") // model.基金经理 != "" &&,一般情况下新产品没有对应的基金经理
                            {
                                long maxID = modelBLL_股票每日交易汇总小表.Exists(model.股票代码, model.基金经理, model.产品名称, model.时间);
                                if (maxID < 0)
                                {//不存在记录，则 增加 
                                    model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表");
                                    if (modelBLL_股票每日交易汇总小表.Add(model))
                                        m_导入新增count++;
                                }
                                else
                                {//存在记录，则更新
                                    model.记录标识 = maxID;
                                    if (modelBLL_股票每日交易汇总小表.Update(model))
                                        m_导入更新count++;
                                }
                            }
                            else //不符合规范数据，added by qhc（20151221）
                            {
                                model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表_格式不符 ");
                                if (小表_格式不符modelBLL.Add(model))
                                    m_未正确导入记录Count++;
                            }
                        }
                        #endregion
                    }
                }
                dateTimePicker1_ValueChanged(null, null);

                if (m_导入新增count + m_导入更新count > 0)
                {
                    string contentText = string.Format("导入完成,新增“{0}”条记录，更新“{1}”条记录", m_导入新增count, m_导入更新count);
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
        }

        private void ShowDialog(string contentText)
        {
            if (MessageBox.Show(contentText, "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                m_时间列表.Sort();
                if (m_时间列表.Count == 1)
                {
                    CurrentDayExchangeListCtl_小表未导入 frm1 = new CurrentDayExchangeListCtl_小表未导入(m_时间列表[0], m_时间列表[0]);
                    frm1.ShowDialog();
                }
                else if (m_时间列表.Count > 1)
                {
                    CurrentDayExchangeListCtl_小表未导入 frm1 = new CurrentDayExchangeListCtl_小表未导入(m_时间列表[0], m_时间列表[m_时间列表.Count - 1]);
                    frm1.ShowDialog();
                }
            }
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户")
                return;
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (row != null)
            {
                long 记录标识 = 0;
                long.TryParse(row.Cells["记录标识"].Value.ToString(), out 记录标识);
                if (记录标识 > 0)
                {
                    Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = modelBLL_股票每日交易汇总小表.GetModel(记录标识);
                    if (model != null)
                    {
                        Edit_Info infoFrm = new Edit_Info(model);
                        if (infoFrm.ShowDialog() == DialogResult.OK)
                        {
                            FillInitValue1();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (DataConvertor.Pub_登录用户信息.角色 == "普通用户")
                return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            }
        }

        private void tsmi_删除_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();

            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView1.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    long 记录标识 = 0;
                    long.TryParse(collection[i].Cells["记录标识"].Value.ToString(), out 记录标识);
                    if (modelBLL.Delete(记录标识))
                    {
                        this.dataGridView1.Rows.Remove(collection[i]);
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewCheckBoxCell cell = dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
            if (cell != null)
            { 
                DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
                long 记录标识 = 0;
                long.TryParse(dr.Cells["记录标识"].Value.ToString(), out 记录标识);
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = modelBLL.GetModel(记录标识);
                if (model != null)
                {
                    model.是否为止损指令 =(cell.EditingCellFormattedValue.ToString()=="True"?true:false);
                    modelBLL.Update(model);
                }
            }
        }

        private void btn_管理未成功导入数据_Click(object sender, EventArgs e)
        {
            CurrentDayExchangeListCtl_小表未导入 frm = new CurrentDayExchangeListCtl_小表未导入(DateTime.Now.AddMonths(-1), DateTime.Now);
            frm.ShowDialog(); 
        }

    }

}
