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
    public partial class CurrentDayExchangeListCt_Import : UserControl
    {
        public CurrentDayExchangeListCt_Import()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = System.DateTime.Now;
        }

        private string m_基金经理 = string.Empty;
        private int m_导入count = 0;
        private void btn_导入历史总表格投资统计汇总_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                string currentDT = string.Empty;
                m_导入count = 0;
                DataSet ds = DataConvertor.GetDataSetFromExcel(ofd.FileName);
                foreach (DataTable table in ds.Tables)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];
                        string row0 = row[0].ToString();
                        string row1 = row[1].ToString();
                        string row2 = row[2].ToString();
                        string row3 = row[3].ToString();

                        #region 获取日期，若获取失败，则不再读取数据
                        if (row1 == "今日操作记录" && row[4].ToString() == "日期")
                        {
                            string 旧日期格式 = row[5].ToString();
                            if (旧日期格式.Length == 8)
                            {
                                int 年_INT = 0; int 月_INT = 0; int 日_INT = 0;
                                int.TryParse(旧日期格式.Substring(0, 4), out 年_INT);
                                int.TryParse(旧日期格式.Substring(4, 2), out 月_INT);
                                int.TryParse(旧日期格式.Substring(6, 2), out 日_INT);
                                if (年_INT < 2000 || 月_INT > 12 || 月_INT < 1 || 日_INT > 31 || 日_INT < 1)
                                {
                                    MessageBox.Show("导入失败, Excel中日期读取失败或日期不合法", "系统提示");
                                    return;
                                }
                                DateTime dt = new DateTime(年_INT, 月_INT, 日_INT);
                                currentDT = dt.ToString("yyyy/MM/dd");
                            }
                            else
                            {
                                MessageBox.Show("导入失败, Excel中日期读取失败或日期不合法", "系统提示");
                                return;
                            }
                        }

                        #endregion

                        #region 遇到最新组合状况文字，则读取完成
                        if (row1 == "最新组合状况")
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

                            if (row[0] != null && row[0].ToString() != "")
                            {
                                model.基金经理 = row[0].ToString();
                                m_基金经理 = model.基金经理;
                            }
                            else
                                model.基金经理 = m_基金经理;
                            //row[1] 为序号行，不需要解析
                            if (row[2] != null && row[2].ToString() != "")
                                model.股票代码 = row[2].ToString();
                            if (row[3] != null && row[2].ToString() != "")
                                model.股票名称 = row[2].ToString();

                            long 今日买入股 = 0; double 买入均价 = 0; double 买入金额 = 0;
                            long 今日卖出股 = 0; double 卖出均价 = 0; double 卖出金额 = 0;

                            if (row[4] != null && row[4].ToString() != "")
                            {
                                long.TryParse(row[4].ToString(), out 今日买入股);
                                model.今日买入股 = 今日买入股; 
                            }
                            if (row[5] != null && row[5].ToString() != "")
                            {
                                double.TryParse(row[5].ToString(), out 买入均价);
                                model.买入均价 = 买入均价;
                            } 
                            if (row[6] != null && row[6].ToString() != "")
                            {
                                double.TryParse(row[6].ToString(), out 买入金额);
                                model.买入金额 = 买入金额;
                            } 
                            if (row[7] != null && row[7].ToString() != "")
                            {
                                long.TryParse(row[7].ToString(), out 今日卖出股);
                                model.今日卖出股 = 今日卖出股;
                            }
                            if (row[8] != null && row[8].ToString() != "")
                            {
                                double.TryParse(row[8].ToString(), out 卖出均价);
                                model.卖出均价 = 卖出均价;
                            }
                            if (row[9] != null && row[9].ToString() != "")
                            {
                                double.TryParse(row[9].ToString(), out 卖出金额);
                                model.卖出金额 = 卖出金额;
                            } 

                            if (model.今日买入股 == 0 && model.买入均价 == 0 && model.买入金额 == 0 &&
                                model.今日卖出股 == 0 && model.卖出均价 == 0 && model.卖出金额 == 0)
                                continue; //全部为0，则该条记录无效 

                            double 买入手续费 = 0; double 买入过户费 = 0; double 买入印花税 = 0; double 买入清算金额 = 0;
                            double 卖出手续费 = 0; double 卖出过户费 = 0; double 卖出印花税 = 0; double 卖出清算金额 = 0;
                            if (row[10] != null && row[10].ToString() != "")
                            {
                                double.TryParse(row[10].ToString(), out 买入手续费);
                                model.买入手续费 = 买入手续费; 
                            }
                            if (row[11] != null && row[11].ToString() != "")
                            {
                                double.TryParse(row[11].ToString(), out 买入过户费);
                                model.买入过户费 = 买入过户费;
                            }
                            if (row[12] != null && row[12].ToString() != "")
                            {
                                double.TryParse(row[12].ToString(), out 买入印花税);
                                model.买入印花税 = 买入印花税;
                            }

                            if (row[13] != null && row[13].ToString() != "")
                            {
                                double.TryParse(row[13].ToString(), out 卖出手续费);
                                model.卖出手续费 = 卖出手续费;
                            }
                            if (row[14] != null && row[14].ToString() != "")
                            {
                                double.TryParse(row[14].ToString(), out 卖出过户费);
                                model.卖出过户费 = 卖出过户费;
                            }
                            if (row[15] != null && row[15].ToString() != "")
                            {
                                double.TryParse(row[15].ToString(), out 卖出印花税);
                                model.卖出印花税 = 卖出印花税;
                            }

                            if (row[16] != null && row[16].ToString() != "")
                            {
                                double.TryParse(row[16].ToString(), out 买入清算金额);
                                model.买入清算金额 = 买入清算金额;
                            }
                            if (row[17] != null && row[17].ToString() != "")
                            {
                                double.TryParse(row[17].ToString(), out 卖出清算金额);
                                model.卖出清算金额 = 卖出清算金额;
                            }

                            model.时间 = currentDT;
                            model.记录标识 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("记录标识", "绩效考核_股票每日交易汇总小表");


                            if (modelBLL_股票每日交易汇总小表.Add(model))
                                m_导入count++;
                        }
                        #endregion

                    }

                }
                dateTimePicker1_ValueChanged(null, null);
                MessageBox.Show(string.Format("导入完成,导入“{0}”条记录", m_导入count), "系统提示");
            }
        }

        private void btn_删除记录_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            DataTable table = this.dataGridView1.DataSource as DataTable;
            if (table == null || table.Rows.Count <= 0)
            {
                MessageBox.Show("当日无记录，删除失败！", "系统提示");
                return;
            }
            string 记录标识List =string.Empty;
            foreach (DataRow row in table.Rows)
            {
                if (row["记录标识"].ToString() != null)
                {
                    记录标识List += row["记录标识"].ToString() + ",";
                } 
            }
            if (记录标识List.Length > 0)
                记录标识List = 记录标识List.Substring(0, 记录标识List.Length - 1);

            if (modelBLL_股票每日交易汇总小表.DeleteList(记录标识List))
            {
                dateTimePicker1_ValueChanged(null, null);
                MessageBox.Show("删除成功！", "系统提示"); 
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_股票每日交易汇总小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            DateTime dt = this.dateTimePicker1.Value;
            string currentDT = dt.ToString("yyyy/MM/dd");

            DataSet ds_股票每日交易汇总大表 = modelBLL_股票每日交易汇总小表.GetList(string.Format(" 时间 = '{0}'", currentDT));
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
