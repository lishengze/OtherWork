using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using DB;

namespace 基金管理
{
    public partial class Edit_ShuHui_Frm : Form
    {
        private List<Maticsoft.Model.绩效考核_申购赎回调整历史表> m_绩效考核_基金经理_产品份额表List;

        private int window_width = 0;
        //private double m_old份额 = 0;
        public Edit_ShuHui_Frm(string 产品名称, string 份额)
        {
            InitializeComponent();
            this.window_width = this.Width;
            this.txt_产品名称.ReadOnly = true;
         //   double.TryParse(份额.Trim(), out m_old份额);
            this.FormClosing += new FormClosingEventHandler(Edit_ShuHui_Frm_FormClosing);

            m_绩效考核_基金经理_产品份额表List = new List<Maticsoft.Model.绩效考核_申购赎回调整历史表>();
            this.txt_产品名称.Text = 产品名称;
          //  this.txt_份额.Text = 份额;
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 基金经理_产品份额_modelBLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
            List<Maticsoft.Model.绩效考核_申购赎回调整历史表> 基金经理_产品份额_modelList = 基金经理_产品份额_modelBLL.GetModelList("");

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList = modelBLL.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_基金经理信息表 model in modelList)
            {
                if (model.管理产品 != null && model.管理产品 != "")
                {
                    string[] 管理产品Array = model.管理产品.Split(new char[] { ',' });
                    foreach (string 管理产品 in 管理产品Array)
                    {
                        if (管理产品 == 产品名称)
                        {
                            Maticsoft.Model.绩效考核_申购赎回调整历史表 tempModel = new Maticsoft.Model.绩效考核_申购赎回调整历史表();
                            tempModel.产品名称 = 管理产品;
                            tempModel.基金经理 = model.基金经理;
                            tempModel.申购赎回调整数 = 0;
                            m_绩效考核_基金经理_产品份额表List.Add(tempModel);
                        }
                    }
                }
            }
            this.dataGridView_基金经理表.DataSource = m_绩效考核_基金经理_产品份额表List;

            this.dataGridView_基金经理表.Columns["序号"].Visible = false;
            this.dataGridView_基金经理表.Columns["产品名称"].Visible = false;
            this.dataGridView_基金经理表.Columns["赎回时间"].Visible = false;
            this.dataGridView_基金经理表.Columns["基金份额历史表序号"].Visible = false;

            this.dataGridView_基金经理表.Columns["基金经理"].Width = 90;
            this.dataGridView_基金经理表.Columns["申购赎回调整数"].Width = 130;
            Refresh_基金份额历史表();
            Refresh_申购赎回调整历史表();
        }

        void Edit_ShuHui_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //throw new NotImplementedException();
        }


        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            double 份额 = 0;
            double.TryParse(this.txt_份额.Text.Trim(), out  份额);
            if (份额 <= 0)
            {
                MessageBox.Show("基金份额输入有误！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            Maticsoft.BLL.绩效考核_基金份额历史表 基金份额历史表BLL = new Maticsoft.BLL.绩效考核_基金份额历史表();
            Maticsoft.Model.绩效考核_基金份额历史表 基金份额历史表Model = new Maticsoft.Model.绩效考核_基金份额历史表();
            基金份额历史表Model.序号 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("序号", "绩效考核_基金份额历史表");
            基金份额历史表Model.产品名称 = this.txt_产品名称.Text.Trim();
            基金份额历史表Model.基金份额 = 份额;
            基金份额历史表Model.修改时间 = this.dateTimePicker_赎回时间.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            long 基金份额历史表_主键 = 基金份额历史表BLL.Add(基金份额历史表Model);
            if (基金份额历史表_主键 > 0)
            { 
                #region 增加 “绩效考核_申购赎回调整历史表”
                List<Maticsoft.Model.绩效考核_申购赎回调整历史表> NewModelList = this.dataGridView_基金经理表.DataSource as List<Maticsoft.Model.绩效考核_申购赎回调整历史表>;
                Maticsoft.BLL.绩效考核_申购赎回调整历史表 申购赎回调整历史表_BLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
                foreach (Maticsoft.Model.绩效考核_申购赎回调整历史表 tempModel in NewModelList)
                {
                    if (tempModel.申购赎回调整数 != 0) //如果为0，则不增加
                    {
                        tempModel.序号 = DbHelperSQL.GetMaxID("序号", "绩效考核_申购赎回调整历史表");
                        tempModel.产品名称 = this.txt_产品名称.Text.Trim();
                        tempModel.基金份额历史表序号 = 基金份额历史表_主键;
                        tempModel.赎回时间 = this.dateTimePicker_赎回时间.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        申购赎回调整历史表_BLL.Add(tempModel); 
                    }
                }
                #endregion

                MessageBox.Show("赎回份额修改成功！", "系统提示");

                this.txt_份额.Text = "";
                foreach (DataGridViewRow row in dataGridView_基金经理表.Rows)
                {
                    row.Cells["申购赎回调整数"].Value = 0;
                }
                Refresh_基金份额历史表();
                Refresh_申购赎回调整历史表(); 
            }
            else
                MessageBox.Show("操作失败！，数据库写入失败！", "系统提示");

        }

        private void Refresh_基金份额历史表()
        {
            Maticsoft.BLL.绩效考核_基金份额历史表 modelBLL = new Maticsoft.BLL.绩效考核_基金份额历史表();
            DataSet ds = modelBLL.GetList(string.Format(" 产品名称='{0}'", this.txt_产品名称.Text.Trim()));
            if (ds != null)
            {
                this.dataGridView_基金份额历史表.DataSource = ds.Tables[0];
                this.dataGridView_基金份额历史表.Columns["序号"].Visible = false;
                this.dataGridView_基金份额历史表.Columns["产品名称"].Visible = false;
            }
        }

        private void Refresh_申购赎回调整历史表()
        {
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 modelBLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
            DataSet ds = modelBLL.GetList(string.Format(" 产品名称='{0}'", this.txt_产品名称.Text.Trim()));
            if (ds != null)
            {
                this.dataGridView_申购赎回调整数历史表.DataSource = ds.Tables[0];

                this.dataGridView_申购赎回调整数历史表.Columns["序号"].Visible = false;
                this.dataGridView_申购赎回调整数历史表.Columns["产品名称"].Visible = false;
                //this.dataGridView_申购赎回调整数历史表.Columns["赎回时间"].Visible = false;
                this.dataGridView_申购赎回调整数历史表.Columns["基金份额历史表序号"].Visible = false;

                this.dataGridView_申购赎回调整数历史表.Columns["基金经理"].Width = 90;
                this.dataGridView_申购赎回调整数历史表.Columns["申购赎回调整数"].Width = 130;
            }
        }

        private void btn_查看历史份额_Click(object sender, EventArgs e)
        {
            if (this.btn_查看历史份额.Text == "查看历史")
            {
                this.btn_查看历史份额.Text = "折叠";
                this.Size = new Size(this.window_width * 2 + 20, this.Height);
            }
            else if (this.btn_查看历史份额.Text == "折叠")
            {
                this.btn_查看历史份额.Text = "查看历史";
                this.Size = new Size(this.window_width, this.Height);
            }
        }

        private void tsButton_删除基金份额历史_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_基金份额历史表.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_基金份额历史表 modelBLL = new Maticsoft.BLL.绩效考核_基金份额历史表();
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 modelBLL1 = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();

            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_基金份额历史表.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    long 序号 = 0;
                    long.TryParse(collection[i].Cells["序号"].Value.ToString(), out 序号);
                    if (modelBLL.Delete(序号))
                    {
                        modelBLL1.Delete_By基金份额历史表序号(序号);
                        this.dataGridView_基金份额历史表.Rows.Remove(collection[i]);
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    MessageBox.Show("成功删除记录！", "系统提示");
                    this.Refresh_申购赎回调整历史表();
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }



        private void tsButton_删除申购赎回调整数_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_申购赎回调整数历史表.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 modelBLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();

            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_申购赎回调整数历史表.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    long 序号 = 0;
                    long.TryParse(collection[i].Cells["序号"].Value.ToString(), out 序号);
                    if (modelBLL.Delete(序号))
                    {
                        this.dataGridView_申购赎回调整数历史表.Rows.Remove(collection[i]);
                        deletedCount++;
                    }
                }
                if (deletedCount > 0)
                {
                    MessageBox.Show(string.Format("成功删除“{0}”条记录！", deletedCount), "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }



        private void dataGridView_基金份额历史表_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_基金份额历史表.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView_基金份额历史表.SelectedRows[0];
                long 序号 = 0;
                long.TryParse(row.Cells["序号"].Value.ToString(), out 序号);

                Maticsoft.BLL.绩效考核_申购赎回调整历史表 modelBLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
                DataSet ds = modelBLL.GetList(string.Format(" 产品名称='{0}' and 基金份额历史表序号='{1}'", this.txt_产品名称.Text.Trim(), 序号));
                if (ds != null)
                {
                    this.dataGridView_申购赎回调整数历史表.DataSource = ds.Tables[0];

                    this.dataGridView_申购赎回调整数历史表.Columns["序号"].Visible = false;
                    this.dataGridView_申购赎回调整数历史表.Columns["产品名称"].Visible = false;
                    //this.dataGridView_申购赎回调整数历史表.Columns["赎回时间"].Visible = false;
                    this.dataGridView_申购赎回调整数历史表.Columns["基金份额历史表序号"].Visible = false;

                    this.dataGridView_申购赎回调整数历史表.Columns["基金经理"].Width = 90;
                    this.dataGridView_申购赎回调整数历史表.Columns["申购赎回调整数"].Width = 130;
                }

            }

        }

        private int m_导入新增count_申购赎回历史表 = 0;
        private int m_导入更新count_申购赎回历史表 = 0;

        private int m_导入新增count_基金份额历史表 = 0;
        private int m_导入更新count_基金份额历史表 = 0;

        /// <summary>
        /// 导入Excel表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsButton_导入_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Maticsoft.BLL.绩效考核_申购赎回调整历史表 modelBLL_申购赎回历史表 = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
                Maticsoft.BLL.绩效考核_基金份额历史表 modelBLL_基金份额历史表 = new Maticsoft.BLL.绩效考核_基金份额历史表();

                m_导入新增count_申购赎回历史表 = 0;
                m_导入更新count_申购赎回历史表 = 0;

                m_导入新增count_基金份额历史表 = 0;
                m_导入更新count_基金份额历史表 = 0;

                DataSet ds1 = ExcelReader.GetDataSetFromExcel(ofd.FileName, 0);
                List<Maticsoft.Model.绩效考核_申购赎回调整历史表> modelList_申购赎回表 = new List<Maticsoft.Model.绩效考核_申购赎回调整历史表>();
                List<Maticsoft.Model.绩效考核_基金份额历史表> modelList_基金份额历史 = new List<Maticsoft.Model.绩效考核_基金份额历史表>();
                foreach (DataTable table in ds1.Tables)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Maticsoft.Model.绩效考核_申购赎回调整历史表 model_申购赎回表 = new Maticsoft.Model.绩效考核_申购赎回调整历史表();
                        model_申购赎回表.产品名称 = table.Rows[i]["产品名称"].ToString().Trim();
                        model_申购赎回表.基金经理 = table.Rows[i]["基金经理"].ToString().Trim();
                        double 申购赎回调整数 = 0;
                        double.TryParse(table.Rows[i]["申购赎回调整数"].ToString().Trim(), out 申购赎回调整数);
                        model_申购赎回表.申购赎回调整数 = 申购赎回调整数;
                        string str = table.Rows[i]["赎回时间"].ToString();
                        string[] strArray = str.Split(new char[] { ' ' });
                        if (strArray.Length > 0)
                            str = strArray[0];
                        model_申购赎回表.赎回时间 = DataConvertor.GetDateTimeFromFormateString(str).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        double 基金历史份额 = 0;
                        double.TryParse(table.Rows[i]["基金历史份额"].ToString().Trim(), out 基金历史份额);

                        modelList_申购赎回表.Add(model_申购赎回表);

                        #region 更新“基金份额历史表”
                        Maticsoft.Model.绩效考核_基金份额历史表 tempModel = new Maticsoft.Model.绩效考核_基金份额历史表();
                        tempModel.产品名称 = model_申购赎回表.产品名称;
                        tempModel.基金份额 = 基金历史份额;
                        tempModel.修改时间 = model_申购赎回表.赎回时间;
                        long maxID = modelBLL_基金份额历史表.Exists(tempModel.产品名称, tempModel.修改时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            tempModel.序号 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("序号", "绩效考核_基金份额历史表");
                            if (modelBLL_基金份额历史表.Add(tempModel) > -1)
                                m_导入新增count_基金份额历史表++;
                        }
                        else
                        {//存在记录，则更新
                            model_申购赎回表.序号 = maxID;
                            if (modelBLL_基金份额历史表.Update(tempModel))
                                m_导入更新count_基金份额历史表++;
                        }
                        model_申购赎回表.基金份额历史表序号 = tempModel.序号;
                        #endregion

                    }
                }

                #region 更新“申购赎回历史表”
                foreach (Maticsoft.Model.绩效考核_申购赎回调整历史表 model_申购赎回表 in modelList_申购赎回表)
                {
                    if (model_申购赎回表.产品名称 != "" && model_申购赎回表.基金经理 != "" && model_申购赎回表.赎回时间 != "")
                    {
                        long maxID = modelBLL_申购赎回历史表.Exists(model_申购赎回表.基金经理, model_申购赎回表.产品名称, model_申购赎回表.赎回时间);
                        if (maxID < 0)
                        {//不存在记录，则 增加 
                            model_申购赎回表.序号 = Maticsoft.DBUtility.DbHelperSQL.GetMaxID("序号", "绩效考核_申购赎回调整历史表");
                            if (modelBLL_申购赎回历史表.Add(model_申购赎回表))
                                m_导入新增count_申购赎回历史表++;
                        }
                        else
                        {//存在记录，则更新
                            model_申购赎回表.序号 = maxID;
                            if (modelBLL_申购赎回历史表.Update(model_申购赎回表))
                                m_导入更新count_申购赎回历史表++;
                        }
                    }
                }
                #endregion

                // dateTimePicker1_ValueChanged(null, null);
                MessageBox.Show(string.Format("导入完成,申购赎回历史表新增“{0}”条记录，更新“{1}”条记录；基金份额历史表新增“{2}”条记录，更新“{3}”条记录。",
                    m_导入新增count_申购赎回历史表, m_导入更新count_申购赎回历史表, m_导入新增count_基金份额历史表, m_导入更新count_基金份额历史表), "系统提示");
            }
        }



    }
}
