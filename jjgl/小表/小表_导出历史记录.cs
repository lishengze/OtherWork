using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class 小表_导出历史记录 : Form
    {
        public 小表_导出历史记录(DateTime dt1)
        {
            InitializeComponent();
            this.dateTime_end.Value = dt1;
            this.dateTime_start.Value = dt1.AddMonths(-1);

            FillInitValue1();
        }


        private void FillInitValue1()
        {  
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList1 = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
           // modelList1.Add(new Maticsoft.Model.绩效考核_基金产品信息表("全部"));
            modelList1.AddRange(modelBLL1.GetModelList(""));

            this.comboBox_产品名称.DataSource = modelList1;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";

            if (modelList1.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;
        }
        private DateTime m_currentDateTime;
        private void btn_导出当日记录_Click(object sender, EventArgs e)
        {
            if (this.dateTime_end.Value < this.dateTime_start.Value)
            {
                MessageBox.Show("起始时间不能早于结束时间，导出失败！", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            string startTime = this.dateTime_start.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.dateTime_end.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string 产品名称 = this.comboBox_产品名称.Text.Trim();

            if (产品名称=="")
            {
                MessageBox.Show("产品名称为空，导出失败！", "系统提示");
                return;
            }

            sfd.FileName = string.Format("{0}交易记录({1}-{2}).xlsx", 产品名称, this.dateTime_start.Value.ToString("yyyyMMdd"), this.dateTime_end.Value.ToString("yyyyMMdd"));
            sfd.Filter = "*.xlsx|*.xlsx";
            m_currentDateTime=  this.dateTime_start.Value;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL1 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
                
                ExcelEdit excelEdit = new ExcelEdit();

                excelEdit.CreateExcel();
                while (m_currentDateTime.CompareTo(this.dateTime_end.Value) <= 0) //以天为单位，导出每一天的交易记录，每天的记录形成一个Sheet
                {
                    List<Maticsoft.Model.绩效考核_股票每日交易汇总小表> modelList = modelBLL1.GetModelList(string.Format("产品名称 = '{0}' and 时间 = '{1}'  order by 基金经理",
                        产品名称, m_currentDateTime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)));
                    if (modelList.Count <= 0)
                    { 
                        //向后推移一天
                        m_currentDateTime = m_currentDateTime.AddDays(1);
                        continue;
                    }
                    List<string> list_基金经理 = new List<string>();
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in modelList)
                    {
                        if (!list_基金经理.Contains(model.基金经理))
                            list_基金经理.Add(model.基金经理);
                    }
                    int current_基金经理_开始行 = 0;

                    //创建一个工作簿
                    string name = string.Format("{0}月{1}日", m_currentDateTime.Month, m_currentDateTime.Day);
                    excelEdit.CreateWorkSheet(name);
                    //当前行 
                    int currentRow = 1;

                    //设置第3列为文本列；
                    excelEdit.setCells_TextFormat(1, 3, modelList.Count+3, 3);


                    //写入第一行数据
                    excelEdit.CellsUnite(currentRow, 1, currentRow, 18, "自营证券投资统计表");
                    excelEdit.FontStyle(currentRow, 1, currentRow, 18, true, false, UnderlineStyle.无下划线);
                    excelEdit.CellsAlignment(currentRow, 1, currentRow, 18, ExcelHAlign.居中, ExcelVAlign.居中);
                    //写入第二行数据 -  设置字体加粗 + 背景色（黄色）
                    currentRow++;
                    excelEdit.FontStyle(currentRow, 2, currentRow, 5, true, false, UnderlineStyle.无下划线);
                    excelEdit.SetRangeBackground(currentRow, 2, currentRow, 5, Color.Yellow);
                    excelEdit.CellsUnite(currentRow, 2, currentRow, 3, "今日操作记录");
                    excelEdit.WriteData("日期", currentRow, 4);
                    string currentDayDate = this.m_currentDateTime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    excelEdit.WriteData(currentDayDate, currentRow, 5);
                    //写入第三行数据-表头
                    currentRow++;
                    excelEdit.WriteData("序号", currentRow, 2);
                    excelEdit.WriteData("股票代码", currentRow, 3);
                    excelEdit.WriteData("股票名称", currentRow, 4);
                    excelEdit.WriteData("今日买入(股)", currentRow, 5);
                    excelEdit.WriteData("买入均价(元)", currentRow, 6);
                    excelEdit.WriteData("买入金额(元)", currentRow, 7);
                    excelEdit.WriteData("今日卖出(股)", currentRow, 8);
                    excelEdit.WriteData("卖出均价(元)", currentRow, 9);
                    excelEdit.WriteData("卖出金额(元)", currentRow, 10);
                    excelEdit.WriteData("买入手续费", currentRow, 11);
                    excelEdit.WriteData("买入过户费", currentRow, 12);
                    excelEdit.WriteData("买入印花税", currentRow, 13);
                    excelEdit.WriteData("卖出手续费", currentRow, 14);
                    excelEdit.WriteData("卖出过户费", currentRow, 15);
                    excelEdit.WriteData("卖出印花税", currentRow, 16);
                    excelEdit.WriteData("买入清算金额", currentRow, 17);
                    excelEdit.WriteData("卖出清算金额", currentRow, 18);
                    //currentRow++;
                    //写入第四行及四行以上数据
                    
                    foreach (string temp基金经理 in list_基金经理)
                    {
                        current_基金经理_开始行 = currentRow+1;

                        foreach (Maticsoft.Model.绩效考核_股票每日交易汇总小表 model in modelList)
                        {
                            if (temp基金经理 == model.基金经理) //选择该属于该基金经理的小表记录
                            {
                                currentRow++; 

                                #region
                                excelEdit.WriteData((currentRow-3).ToString(), currentRow, 2);
                                excelEdit.WriteData(model.股票代码, currentRow, 3);
                                string 股票名称 = model.股票名称;
                                if (model.基金经理.Length>0)
                                    股票名称 +=   string.Format("({0})", model.基金经理.Substring(0, 1));
                                excelEdit.WriteData(股票名称, currentRow, 4);
                                excelEdit.WriteData(model.今日买入股.ToString(), currentRow, 5);
                                excelEdit.WriteData(model.买入均价.ToString(), currentRow, 6);
                                excelEdit.WriteData(model.买入金额.ToString(), currentRow, 7);
                                excelEdit.WriteData(model.今日卖出股.ToString(), currentRow, 8);
                                excelEdit.WriteData(model.卖出均价.ToString(), currentRow, 9);
                                excelEdit.WriteData(model.卖出金额.ToString(), currentRow, 10); 
                                excelEdit.WriteData(model.买入手续费.ToString(), currentRow, 11);
                                excelEdit.WriteData(model.买入过户费.ToString(), currentRow, 12);
                                excelEdit.WriteData(model.买入印花税.ToString(), currentRow, 13);
                                excelEdit.WriteData(model.卖出手续费.ToString(), currentRow, 14);
                                excelEdit.WriteData(model.卖出过户费.ToString(), currentRow, 15);
                                excelEdit.WriteData(model.卖出印花税.ToString(), currentRow, 16);
                                excelEdit.WriteData(model.买入清算金额.ToString(), currentRow, 17);
                                excelEdit.WriteData(model.卖出清算金额.ToString(), currentRow, 18);
                                  
                                #endregion
                            }
                        }
                        //每个基金经理都有一个合并的列；
                        excelEdit.CellsUnite(current_基金经理_开始行, 1, currentRow, 1, temp基金经理);
                    } 

                    //通用设置
                    int columnsCount = 18;
                    int rowsCount = currentRow;
                    excelEdit.FontNameSize(3, 1, rowsCount, columnsCount, "Times New Roman", 9); 
                    //设置行高、行宽
                    excelEdit.SetRowHeight(1, rowsCount, 15);
                    excelEdit.SetColumnWidth(1, columnsCount, 12);

                    //设置单元格边框
                    excelEdit.CellsDrawFrame(1, 1, rowsCount, columnsCount);

                    //向后推移一天
                    m_currentDateTime = m_currentDateTime.AddDays(1);
                } //以天为单位，导出每一天的交易记录

                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                this.Close();
                MessageBox.Show("历史记录导出成功", "系统提示");
            }
        }

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


    }
}
