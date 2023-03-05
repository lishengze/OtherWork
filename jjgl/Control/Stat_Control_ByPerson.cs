using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace 基金管理
{
    public partial class Stat_Control_ByPerson : UserControl
    {
        private 当前执行动作 m_当前执行动作;
        public enum 当前执行动作
        {
            查询,
            绩效统计,
            个人净值贡献
        }

        public Stat_Control_ByPerson()
        {
            InitializeComponent();
            FillControlValue(); 
        }

        private void FillControlValue()
        { 
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            this.dateTimePicker2.Value = DateTime.Now;
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            List<Maticsoft.Model.绩效考核_基金产品信息表> modelList = new List<Maticsoft.Model.绩效考核_基金产品信息表>(){
                             new Maticsoft.Model.绩效考核_基金产品信息表("全部")};
            modelList.AddRange(modelBLL.GetModelList(""));
            this.comboBox_产品名称.DataSource = modelList;
            this.comboBox_产品名称.DisplayMember = "产品名称";
            this.comboBox_产品名称.ValueMember = "产品名称";
            if (modelList.Count > 0)
                this.comboBox_产品名称.SelectedIndex = 0;

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList1 = new List<Maticsoft.Model.绩效考核_基金经理信息表>(){
                             new Maticsoft.Model.绩效考核_基金经理信息表("全部","")};
            modelList1.AddRange(modelBLL1.GetModelList(""));
            this.comboBox_基金经理.DataSource = modelList1;
            this.comboBox_基金经理.DisplayMember = "基金经理";
            this.comboBox_基金经理.ValueMember = "基金经理";
            if (modelList1.Count > 0)
                this.comboBox_基金经理.SelectedIndex = 0;
        }

        /// <summary> 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_查询_Click(object sender, EventArgs e)
        {
            m_当前执行动作 = 当前执行动作.查询;
            this.dataGridView1.DataSource = Function_查询();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_绩效统计_Click(object sender, EventArgs e)
        {
            m_当前执行动作 = 当前执行动作.绩效统计;
            this.dataGridView1.DataSource = Function_绩效统计();
        }

        private void btn_个人净值贡献_Click(object sender, EventArgs e)
        {
            m_当前执行动作 = 当前执行动作.个人净值贡献;
            this.dataGridView1.DataSource = Function_个人净值贡献();
        }

        private DataTable Function_查询()
        {
            DataTable newtable = new DataTable();
            newtable.Columns.Add("产品名称");
            newtable.Columns.Add("时间");
            //newtable.Columns.Add("基金经理");
            newtable.Columns.Add("股票代码");
            newtable.Columns.Add("股票名称");

            newtable.Columns.Add("持股数量");
            newtable.Columns.Add("持股成本");
            newtable.Columns.Add("仓位");   //===市值占比

            string startTime = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.dateTimePicker2.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表_modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();

            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 期初_ModelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 期末_ModelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();

            string subSql1 = string.Format(" 时间 between '{0}' and  '{1}' ", startTime, endTime);
            string subSql2 = string.Format(" 时间 between '{0}' and  '{1}' ", startTime, endTime); 
            if (this.comboBox_基金经理.Text.Trim() != "全部")
            {
                subSql1 += string.Format(" and 基金经理='{0}' ", this.comboBox_基金经理.Text.Trim());
                subSql2 += string.Format(" and 基金经理='{0}' ", this.comboBox_基金经理.Text.Trim());
            }
            if (this.comboBox_产品名称.Text.Trim() != "全部")
            {
                subSql1 += string.Format(" and 基金产品='{0}'", this.comboBox_产品名称.Text.Trim());
                subSql2 += string.Format(" and 产品名称='{0}'", this.comboBox_产品名称.Text.Trim());
            }

            modelList = 大表_modelBLL.GetModelList(string.Format("{0}  order by 股票名称, 投资成本 desc", subSql2));
            期初_ModelList = 大表_modelBLL.GetModelList(subSql2);
            期末_ModelList = 大表_modelBLL.GetModelList(subSql2); 
            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL_基金经理净值贡献表 = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            List<Maticsoft.Model.绩效考核_基金经理净值贡献表> modelList_绩效考核_基金经理净值贡献表 = modelBLL_基金经理净值贡献表.GetModelList(subSql1);

            string 当前的股票名称 = string.Empty;
            if (modelList != null)
            {
                foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 model in modelList)
                {
                    DataRow newRow = newtable.NewRow();
                    newRow["产品名称"] = model.产品名称;
                    newRow["时间"] = model.时间;
                    //newRow["基金经理"] = model.基金经理;
                    newRow["股票代码"] = model.股票代码;
                    newRow["股票名称"] = model.股票名称;
                    newRow["持股数量"] = model.持股数量;
                    newRow["持股成本"] = model.持股成本;
                    newRow["仓位"] = model.市值占比;
                    当前的股票名称 = model.股票名称;

                    newtable.Rows.Add(newRow);
                }
            }
            return newtable;
        }

        private DataTable Function_绩效统计()
        {
            DataTable newtable = new DataTable();
            newtable.Columns.Add("产品名称");
            newtable.Columns.Add("股票代码");
            newtable.Columns.Add("股票名称");
            newtable.Columns.Add("最大投资金额"); //统计区间投资成本最大值
            newtable.Columns.Add("实现盈亏");  // 买卖盈亏 ==实现盈亏； 
            newtable.Columns.Add("总盈亏");  // 总盈亏 =  期末浮动盈亏+统计期间买卖盈亏-期初浮动盈亏 
            newtable.Columns.Add("总收益率"); //买卖收益率（总收益率） =买卖盈亏/最大投资金额 

            string startTime = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.dateTimePicker2.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            //给两个有值的时间默认赋值 
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 大表_modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
             
            string sql1 = string.Format("select top 1 时间 from 绩效考核_股票每日交易汇总大表 where 时间 <= '{0}'  order by 时间 desc ", startTime);
            string sql2 = string.Format("select top 1 时间 from 绩效考核_股票每日交易汇总大表 where 时间 <= '{0}'  order by 时间 desc", endTime);
            DataSet ds1 = DbHelperSQL.Query(sql1);
            DataSet ds2 = DbHelperSQL.Query(sql2);
            if (ds1 != null)
            {
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        string tempStartTime = ds1.Tables[0].Rows[0]["时间"].ToString(); 
                        if (tempStartTime != "") startTime = tempStartTime; 
                    }
                }
            }
            if (ds2 != null)
            {
                if (ds2.Tables.Count > 0)
                {
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        string tempEndTime = ds2.Tables[0].Rows[0]["时间"].ToString(); 
                        if (tempEndTime != "") endTime = tempEndTime;
                    }
                }
            }
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 期初_ModelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> 期末_ModelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
            List<string> 产品名称_List = new List<string>();
            if (this.comboBox_产品名称.Text == "全部")
            {
                string sql = string.Empty;
                if (this.comboBox_基金经理.Text == "全部")
                    sql = string.Format(" select distinct(产品名称) from 绩效考核_股票每日交易汇总大表 where 时间  between '{0}' and '{1}' ", startTime, endTime);
                else
                    sql = string.Format(" select distinct(产品名称) from 绩效考核_股票每日交易汇总大表 where 基金经理 ='{0}' and 时间 between '{1}' and '{2}'", this.comboBox_基金经理.Text.Trim(), startTime, endTime);
                DataSet ds = DbHelperSQL.Query(sql);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            产品名称_List.Add(row["产品名称"].ToString());
                        }
                    }
                }
            }
            else
            {
                产品名称_List.Add(this.comboBox_产品名称.Text);
            }
            string subSql = string.Empty;
            if (this.comboBox_基金经理.Text != "全部")
            {
                subSql += "and 基金经理 ='" + this.comboBox_基金经理.Text + "'";
            }
            期初_ModelList = 大表_modelBLL.GetModelList(string.Format("时间 = '{0}' {1}", startTime, subSql));
            期末_ModelList = 大表_modelBLL.GetModelList(string.Format("时间 = '{0}' {1}", endTime, subSql));

            foreach (string temp产品名称 in 产品名称_List)
            {
                // 股票名称,  最大投资金额,  实现盈亏
                DataTable tempTable = 大表_modelBLL.Get_统计信息(temp产品名称, this.comboBox_基金经理.Text.Trim(), startTime, endTime);
                foreach (DataRow tempRow in tempTable.Rows)
                {
                    DataRow newRow = newtable.NewRow();
                    newRow["产品名称"] = temp产品名称;
                    newRow["股票代码"] = tempRow["股票代码"].ToString();
                    string 股票名称 = tempRow["股票名称"].ToString();
                    string 股票代码 = tempRow["股票代码"].ToString();
                    newRow["股票名称"] = 股票名称;
                    newRow["最大投资金额"] = tempRow["最大投资金额"];
                    newRow["实现盈亏"] = tempRow["实现盈亏"].ToString();

                    #region 计算“总盈亏”
                    double 浮动盈亏_期初_总和 = 0; double 浮动盈亏_期末_之和 = 0;
 
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 期初_ModelList)
                    {
                        if (tempModel.股票代码 == 股票代码 && temp产品名称== tempModel.产品名称)
                        {
                            浮动盈亏_期初_总和 += tempModel.浮盈浮亏; 
                        }
                    }
                    foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 tempModel in 期末_ModelList)
                    {
                        if (tempModel.股票代码 == 股票代码 && temp产品名称 == tempModel.产品名称)
                        {
                            浮动盈亏_期末_之和 += tempModel.浮盈浮亏; 
                        }
                    }
                    double 最大投资金额 = 0;
                    double.TryParse(tempRow["最大投资金额"].ToString(), out 最大投资金额);
                    double 实现盈亏 = 0;
                    double.TryParse(tempRow["实现盈亏"].ToString(), out 实现盈亏);
                    double 总盈亏 = 实现盈亏 + 浮动盈亏_期末_之和 - 浮动盈亏_期初_总和;
                    newRow["总盈亏"] = 总盈亏.ToString();
                    #endregion

                    if (最大投资金额 != 0)
                        newRow["总收益率"] = (总盈亏 / 最大投资金额).ToString();
                    newtable.Rows.Add(newRow);
                }
            }
            return newtable;
        }

        private DataTable Function_个人净值贡献()
        {
            DataTable tempTable = new DataTable();
            string startTime = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endTime = this.dateTimePicker2.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            Maticsoft.BLL.绩效考核_基金经理净值贡献表 modelBLL = new Maticsoft.BLL.绩效考核_基金经理净值贡献表();
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();
            string subSql = string.Format(" 时间 between '{0}' and  '{1}' ", startTime, endTime);
            string subSql_大表 = string.Format(" 时间 between '{0}' and  '{1}' ", startTime, endTime);
            if (this.comboBox_基金经理.Text.Trim() != "全部")
            {
                subSql += string.Format(" and 基金经理='{0}' ", this.comboBox_基金经理.Text.Trim());
                subSql_大表 += string.Format(" and 基金经理='{0}' ", this.comboBox_基金经理.Text.Trim());
            }
            if (this.comboBox_产品名称.Text.Trim() != "全部")
            {
                subSql += string.Format(" and 基金产品='{0}'", this.comboBox_产品名称.Text.Trim());
                subSql_大表 += string.Format(" and 产品名称='{0}'", this.comboBox_产品名称.Text.Trim());
            }
            DataSet ds = modelBLL.GetList(subSql);
            List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList_大表 = modelBLL_大表.GetModelList(subSql_大表);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    tempTable = ds.Tables[0];
                    //增加“基金经理仓位”列
                    tempTable.Columns.Add("基金经理仓位");
                    //增加行记录
                    foreach (DataRow row in tempTable.Rows)
                    {
                        string 基金经理 = row["基金经理"].ToString();
                        string 时间 = row["时间"].ToString();
                        string 基金产品 = row["基金产品"].ToString();
                        double 基金经理仓位 = 0;

                        foreach (Maticsoft.Model.绩效考核_股票每日交易汇总大表 大表Model in modelList_大表)
                        {
                            if (大表Model.基金经理 == 基金经理 && 大表Model.时间 == 时间 && 大表Model.产品名称 == 基金产品)
                            {
                                基金经理仓位 += 大表Model.市值占比;
                            }
                        }
                        row["基金经理仓位"] = 基金经理仓位;
                    }
                }
            }

            return tempTable;
        }


        #region 导出功能
        
        private void btn_导出查询记录_Click(object sender, EventArgs e)
        {
            string startTime = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endTime = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (this.dateTimePicker1.Value.CompareTo(this.dateTimePicker2.Value) > 0)
            {
                MessageBox.Show("起始时间不能晚于结束时间，导出失败！", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("{0}个人记录({1}至{2}).xlsx", this.comboBox_基金经理.Text, startTime, endTime);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();
                #region
                ////创建第一个工作簿   
                DataTable table1 = Function_查询();
                CreateExcelSheet(excelEdit, "查询结果", table1);
                 
                #endregion
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        private void btn_导出绩效统计_Click(object sender, EventArgs e)
        {
            string startTime = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endTime = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (this.dateTimePicker1.Value.CompareTo(this.dateTimePicker2.Value) > 0)
            {
                MessageBox.Show("起始时间不能晚于结束时间，导出失败！", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("{0}绩效统计({1}至{2}).xlsx", this.comboBox_基金经理.Text, startTime, endTime);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();
                #region
               
                ////创建第二个工作簿  
                DataTable table2 = Function_绩效统计();
                CreateExcelSheet(excelEdit, "绩效统计", table2);

              
                #endregion
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        private void btn_导出个人净值贡献_Click(object sender, EventArgs e)
        {
            string startTime = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endTime = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (this.dateTimePicker1.Value.CompareTo(this.dateTimePicker2.Value) > 0)
            {
                MessageBox.Show("起始时间不能晚于结束时间，导出失败！", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("{0}个人净值贡献({1}至{2}).xlsx", this.comboBox_基金经理.Text, startTime, endTime);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel();
                #region
               
                ////创建第三个工作簿  
                DataTable table3 = Function_个人净值贡献();
                CreateExcelSheet(excelEdit, "个人净值贡献", table3);
                #endregion
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }
        }

        /// <summary>
        /// Excel中单元格的高度和宽度有问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_导出记录_Click(object sender, EventArgs e)
        {
            string startTime = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endTime = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (this.dateTimePicker1.Value.CompareTo(this.dateTimePicker2.Value) > 0)
            {
                MessageBox.Show("起始时间不能晚于结束时间，导出失败！", "系统提示");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.FileName = string.Format("{0}个人情况统计({1}至{2}).xlsx", this.comboBox_基金经理.Text, startTime, endTime);

            if (sfd.ShowDialog() == DialogResult.OK)
            { 
                ExcelEdit excelEdit = new ExcelEdit();
                excelEdit.CreateExcel(); 
                #region
                ////创建第一个工作簿   
                DataTable table1= Function_查询();
                CreateExcelSheet(excelEdit, "查询结果", table1);  

                ////创建第二个工作簿  
                DataTable table2 = Function_绩效统计();
                CreateExcelSheet(excelEdit, "绩效统计",table2); 
                 
                ////创建第三个工作簿  
                DataTable table3=  Function_个人净值贡献();
                CreateExcelSheet(excelEdit, "个人净值贡献", table3);
                #endregion 
                excelEdit.SaveAs(sfd.FileName);
                excelEdit.Close();
                MessageBox.Show("记录导出成功", "系统提示");
            }

        }

        public static void CreateExcelSheet(ExcelEdit excelEdit, string sheetName, DataTable table)
        {
            excelEdit.CreateWorkSheet(sheetName);

            if (sheetName == "证券持仓查询" || sheetName == "查询结果")
            {
                //设置 第三列（股票代码）为文本列； 
                excelEdit.setCells_TextFormat(1, 3, table.Rows.Count + 3, 3);
            }
            else if (sheetName == "绩效统计")
            {
                //设置 第二列（股票代码）为文本列； 
                excelEdit.setCells_TextFormat(1, 2, table.Rows.Count + 3, 2); 
            }
            if (sheetName == "证券交易查询")
            {
                //设置 第四列（股票代码）为文本列； 
                excelEdit.setCells_TextFormat(1, 4, table.Rows.Count + 3, 4);
            }
            //写入 -表头
            for (int i = 0; i < table.Columns.Count; i++)
            {
                excelEdit.WriteData(table.Columns[i].ColumnName, 1, i + 1);
            }
            //写入第三行及其他行数据 
            excelEdit.WriteData(table, 2, 1);
            SetExcel_单元格样式(excelEdit, table.Rows.Count + 1, table.Columns.Count);
        }

        public static void SetExcel_单元格样式(ExcelEdit excelEdit, int rowsCount, int columnsCount)
        {
            #region 设置表格样式
            //设置字体 
            excelEdit.FontNameSize(1, 1, rowsCount, columnsCount, "宋体", 9);
            //设置表头加粗；
            excelEdit.FontStyle(1, 1, 1, columnsCount, true, false, UnderlineStyle.无下划线); 
            //设置单元格边框
            excelEdit.CellsDrawFrame(1, 1, rowsCount, columnsCount);
            //设置行高
            excelEdit.SetRowHeight(1, rowsCount, 16);
            //设置列宽
            excelEdit.SetColumnWidth(1, columnsCount, 10); 
            #endregion
        }

        

        #endregion

        //#region old 

        //private void FillColumn()
        //{

        //    System.Windows.Forms.DataGridViewTextBoxColumn 产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    产品名称.HeaderText = "产品名称";
        //    产品名称.Name = "产品名称";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 股票代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    股票代码.HeaderText = "股票代码";
        //    股票代码.Name = "股票代码";
        //    System.Windows.Forms.DataGridViewTextBoxColumn 股票名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    股票名称.HeaderText = "股票名称";
        //    股票名称.Name = "股票名称";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 持股数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    持股数量.HeaderText = "持股数量";
        //    持股数量.Name = "持股数量";
        //    System.Windows.Forms.DataGridViewTextBoxColumn 持股成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    持股成本.HeaderText = "持股成本";
        //    持股成本.Name = "持股成本";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 市场现价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    市场现价.HeaderText = "市场现价";
        //    市场现价.Name = "市场现价";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 投资成本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    投资成本.HeaderText = "投资成本(元)";
        //    投资成本.Name = "投资成本";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 今日市值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    今日市值.HeaderText = "今日市值(元)";
        //    今日市值.Name = "今日市值";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 浮盈浮亏 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    浮盈浮亏.HeaderText = "浮盈浮亏";
        //    浮盈浮亏.Name = "浮盈浮亏";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 投资成本占比 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    投资成本占比.HeaderText = "投资成本占比";
        //    投资成本占比.Name = "投资成本占比";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 市值占比 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    市值占比.HeaderText = "市值占比";
        //    市值占比.Name = "市值占比";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 浮盈浮亏率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    浮盈浮亏率.HeaderText = "浮盈浮亏率";
        //    浮盈浮亏率.Name = "浮盈浮亏率";

        //    System.Windows.Forms.DataGridViewTextBoxColumn 本年净值贡献 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    本年净值贡献.HeaderText = "本年净值贡献(元)";
        //    本年净值贡献.Name = "本年净值贡献";

        //    this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        //        产品名称,股票代码,股票名称,	持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,本年净值贡献});

        //}


        //private void ReadData()
        //{
        //    string fileName = Application.StartupPath + "//历史记录.txt";
        //    if (System.IO.File.Exists(fileName))
        //    {
        //        try
        //        {
        //            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName))
        //            {
        //                string lineString = string.Empty;
        //                while ((lineString = reader.ReadLine()) != "")
        //                {
        //                    if (lineString == null) break;
        //                    if (lineString == "") break;
        //                    string[] strArray = lineString.Split(new char[] { ',' });

        //                    int index = this.dataGridView1.Rows.Add();
        //                    this.dataGridView1.Rows[index].Cells["产品名称"].Value = strArray[0];
        //                    this.dataGridView1.Rows[index].Cells["股票代码"].Value = strArray[1];
        //                    this.dataGridView1.Rows[index].Cells["股票名称"].Value = strArray[2];
        //                    this.dataGridView1.Rows[index].Cells["持股数量"].Value = strArray[3];
        //                    this.dataGridView1.Rows[index].Cells["持股成本"].Value = strArray[4];
        //                    this.dataGridView1.Rows[index].Cells["市场现价"].Value = strArray[5];
        //                    this.dataGridView1.Rows[index].Cells["投资成本"].Value = strArray[6];
        //                    this.dataGridView1.Rows[index].Cells["今日市值"].Value = strArray[7];
        //                    this.dataGridView1.Rows[index].Cells["浮盈浮亏"].Value = strArray[8];
        //                    this.dataGridView1.Rows[index].Cells["投资成本占比"].Value = strArray[9];
        //                    this.dataGridView1.Rows[index].Cells["市值占比"].Value = strArray[10];
        //                    this.dataGridView1.Rows[index].Cells["浮盈浮亏率"].Value = strArray[11];
        //                    this.dataGridView1.Rows[index].Cells["本年净值贡献"].Value = strArray[12];
        //                }
        //            }

        //        }
        //        catch
        //        {
        //            AddOneRecord();
        //        }
        //    }
        //    else
        //    {
        //        AddOneRecord();
        //    }

        //}


        //private void AddOneRecord()
        //{
        //    string[] strArray1 = new string[]{
        //             //string.Format("{0},090005,大成货币A, 4,500,000 , 1.00 ,1.00, 4,500,000.00 , 4,500,000.00 , -   ,10.06%,10.06%,0.00%",_name),
        //             //string.Format("{0},300215,电科院（夏）, 41,045 , 25.19 , 24.93 , 1,033,768.56 , 1,023,251.85 , -10,516.71 ,2.31%,2.29%,-1.02%",_name),
        //             //string.Format("{0},002104,恒宝股份（夏）, 130,100 , 16.30 , 16.06 , 2,120,588.81 , 2,089,406.00 , -31,182.81 ,4.74%,4.67%,-1.47%",_name),
        //             //string.Format("{0},300269,联建光电（夏）, 281,182 , 20.40 , 28.10 , 5,735,055.73 , 7,901,214.20 , 2,166,158.47 ,12.82%,17.66%,37.77%",_name),
        //             //string.Format("{0},002063,远光软件（徐）, 80,125 , 19.02 , 18.33 , 1,523,800.06 , 1,468,691.25 , -55,108.81 ,3.41%,3.28%,-3.62%" ,_name)
        //    };

        //    for (int i = 0; i < strArray1.Length; i++)
        //    {
        //        string[] strArray = strArray1[i].Split(new char[] { ',' });

        //        int index = this.dataGridView1.Rows.Add();
        //        this.dataGridView1.Rows[index].Cells["产品名称"].Value = strArray[0];
        //        this.dataGridView1.Rows[index].Cells["股票代码"].Value = strArray[1];
        //        this.dataGridView1.Rows[index].Cells["股票名称"].Value = strArray[2];
        //        this.dataGridView1.Rows[index].Cells["持股数量"].Value = strArray[3];
        //        this.dataGridView1.Rows[index].Cells["持股成本"].Value = strArray[4];
        //        this.dataGridView1.Rows[index].Cells["市场现价"].Value = strArray[5];
        //        this.dataGridView1.Rows[index].Cells["投资成本"].Value = strArray[6];
        //        this.dataGridView1.Rows[index].Cells["今日市值"].Value = strArray[7];
        //        this.dataGridView1.Rows[index].Cells["浮盈浮亏"].Value = strArray[8];
        //        this.dataGridView1.Rows[index].Cells["投资成本占比"].Value = strArray[9];
        //        this.dataGridView1.Rows[index].Cells["市值占比"].Value = strArray[10];
        //        this.dataGridView1.Rows[index].Cells["浮盈浮亏率"].Value = strArray[11];
        //        this.dataGridView1.Rows[index].Cells["本年净值贡献"].Value = strArray[12];
        //    }

        //}


        //#endregion

    }
}
