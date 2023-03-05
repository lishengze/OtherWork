using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace 基金管理
{
    public partial class ManagerCtl_Ext : UserControl
    {
        public ManagerCtl_Ext()
        {
            InitializeComponent();

            InitData();

            this.Load += new EventHandler(ManagerCtl_Load);
        }

        public string m_edit_股票 = string.Empty;
        public string m_edit_基金产品 = string.Empty;
        public string m_edit_基金经理 = string.Empty;

        void ManagerCtl_Load(object sender, EventArgs e)
        {
            this.dataGridView_产品.ClearSelection();
            this.dataGridView_股票.ClearSelection();
            this.dataGridView_基金经理.ClearSelection();

            this.txt_份额.ReadOnly = false;
        }

        private void InitData()
        {
            Refresh_股票();
            Refresh_基金产品();
            Refresh_基金经理(); 
        }

        private void Refresh_股票()
        {
            Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
            DataSet ds = modelBLL.GetAllList();
            if (ds != null && ds.Tables.Count > 0)
            {
                this.dataGridView_股票.DataSource = ds.Tables[0];
            }
            this.dataGridView_股票.ClearSelection();
        }

        private void Refresh_基金产品()
        {
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金产品信息表();
            DataSet ds1 = modelBLL1.GetAllList();
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                this.dataGridView_产品.DataSource = ds1.Tables[0];
                Refresh_dataGridView_产品_基金经理();
            }
            this.dataGridView_产品.ClearSelection();
        }

        private void Refresh_dataGridView_产品_基金经理()
        {
            DataTable oldTable = this.dataGridView_产品.DataSource as DataTable;
            DataTable table = new DataTable();
            table.Columns.Add("基金产品");
            table.Columns.Add("所占份额");
            foreach (DataRow row in oldTable.Rows)
            {
                table.Rows.Add(new string[] { row["产品名称"].ToString(), "" });
            }
            this.dataGridView_产品_基金经理.DataSource = table;
        }

        private void Refresh_基金经理()
        {
            Maticsoft.BLL.绩效考核_基金经理_产品份额表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
            List<Maticsoft.Model.绩效考核_基金经理_产品份额表> modelList1 = modelBLL1.GetModelList(" ");

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL2 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            DataSet ds2 = modelBLL2.GetAllList();

            if (ds2 != null && ds2.Tables.Count > 0)
            {
                DataTable table = ds2.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    string 基金经理 = row["基金经理"].ToString();
                    string 管理产品 = string.Empty;
                    foreach (Maticsoft.Model.绩效考核_基金经理_产品份额表 model in modelList1)
                    {
                        if (model.基金经理 == 基金经理)
                        {
                            管理产品 = 管理产品 + string.Format("{0}({1})", model.基金产品, model.所占份额) + ",";
                        }
                    }
                    if (管理产品 != "")
                    {
                        管理产品 = 管理产品.Substring(0, 管理产品.Length - 1);
                    }
                    row["管理产品"] = 管理产品;
                }
                this.dataGridView_基金经理.DataSource = ds2.Tables[0];

                //DataTable tempTable = this.dataGridView_产品.DataSource as DataTable;
                //Refresh_dataGridView_产品_基金经理(tempTable);
            }
            this.dataGridView_基金经理.Columns["管理产品"].Width = 250;
            this.dataGridView_基金经理.ClearSelection();

            //this.checkedListBox1.Items.Clear();
            //DataTable dt = this.dataGridView_产品.DataSource as DataTable;
            //foreach (DataRow row in dt.Rows)
            //{
            //    object obj = row["产品名称"];
            //    this.checkedListBox1.Items.Add(obj);
            //}
        }

        #region 股票


        private void btn_增加股票_Click(object sender, EventArgs e)
        {
            if (this.txt_股票代码.Text.Trim() == "" && this.txt_股票名称.Text.Trim() == "")
            {
                MessageBox.Show("股票代码和股票名称不能为空", "系统提示");
                return;
            }
            Maticsoft.Model.绩效考核_股票信息表 model = new Maticsoft.Model.绩效考核_股票信息表();
            model.股票代码 = this.txt_股票代码.Text.Trim();
            model.股票名称 = this.txt_股票名称.Text.Trim();
            Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
            if (!modelBLL.Exists(model.股票代码))
            {
                if (modelBLL.Add(model))
                {
                    this.txt_股票代码.Text = "";
                    this.txt_股票名称.Text = "";
                    this.Refresh_股票();
                    MessageBox.Show("股票增加成功~！", "系统提示");
                }
                else
                    MessageBox.Show("增加失败，数据库操作失败", "系统提示");
            }
            else
                MessageBox.Show(string.Format("增加失败！，存在代码为“{0}”的股票！", model.股票代码), "系统提示");

        }

        private void btn_删除股票_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_股票.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }

            Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_股票.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    string 股票代码 = collection[i].Cells["股票代码"].Value.ToString();
                    if (modelBLL.Delete(股票代码))
                    {
                        deletedCount++;
                        this.dataGridView_股票.Rows.Remove(collection[i]);
                    }
                }

                if (deletedCount > 0)
                {
                    this.txt_股票代码.Text = "";
                    this.txt_股票名称.Text = "";

                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void btn_导入股票_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件路径";
            ofd.Multiselect = false;
            ofd.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int addedCount = 0;
                int editedCount = 0;
                if (!refreshData(ofd.FileName, out addedCount, out editedCount))
                    return;

                Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
                DataSet ds = modelBLL.GetAllList();
                if (ds != null && ds.Tables.Count > 0)
                {
                    this.dataGridView_股票.DataSource = ds.Tables[0];
                }
                MessageBox.Show(string.Format("导入成功，新增股票{0}支，更新股票{1}支！", addedCount, editedCount), "系统提示");
            }
        }

        private bool refreshData(string filePath, out int addedCount, out int editedCount)
        {
            addedCount = 0;
            editedCount = 0;
            DataSet ds = DataConvertor.GetDataSetFromExcel(filePath);
            if (ds != null && ds.Tables != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        if (!table.Columns.Contains("股票代码") || !table.Columns.Contains("股票名称"))
                        {
                            MessageBox.Show("导入失败，无股票名称或股票代码列", "系统提示");
                            return false;
                        }
                        foreach (DataRow row in table.Rows)
                        {
                            string 股票代码 = string.Empty;
                            string 股票名称 = string.Empty;
                            if (row["股票代码"] != null)
                            {
                                if (row["股票代码"].ToString().Length >= 6)
                                {
                                    股票代码 = row["股票代码"].ToString().Substring(0, 6);
                                }
                            }
                            if (row["股票名称"] != null)
                            {
                                股票名称 = row["股票名称"].ToString();
                            }
                            if (股票代码 != "" && 股票名称 != "")
                            {
                                Maticsoft.Model.绩效考核_股票信息表 model = new Maticsoft.Model.绩效考核_股票信息表();
                                model.股票代码 = 股票代码;
                                model.股票名称 = 股票名称;
                                Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
                                if (modelBLL.Exists(股票代码))
                                { //存在则更新
                                    if (modelBLL.Update(model))
                                        editedCount++;
                                }
                                else
                                { //不存在则插入
                                    if (modelBLL.Add(model))
                                        addedCount++;
                                }
                            }
                        }
                    }

                }
            }

            return true;
        }

        private void btn_修改股票_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = this.dataGridView_股票.SelectedRows;
            if (collection.Count >= 1)
            {
                if (this.txt_股票代码.Text.Trim() == "" && this.txt_股票名称.Text.Trim() == "")
                {
                    MessageBox.Show("股票代码和股票名称不能为空", "系统提示");
                    return;
                }
                if (m_edit_股票 != this.txt_股票代码.Text.Trim())
                {
                    MessageBox.Show("股票代码为唯一标识，不能修改", "系统提示");
                    return;
                }

                Maticsoft.BLL.绩效考核_股票信息表 modelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
                Maticsoft.Model.绩效考核_股票信息表 model = new Maticsoft.Model.绩效考核_股票信息表();
                model.股票代码 = this.txt_股票代码.Text.Trim();
                model.股票名称 = this.txt_股票名称.Text.Trim();

                if (modelBLL.Update(model))
                {
                    DataGridViewRow row = collection[0];

                    row.Cells["股票代码"].Value = this.txt_股票代码.Text.Trim();
                    row.Cells["股票名称"].Value = this.txt_股票名称.Text.Trim();

                    this.txt_股票代码.Text = "";
                    this.txt_股票名称.Text = "";

                    MessageBox.Show("股票修改成功！", "系统提示");
                }
                else
                {
                    MessageBox.Show("股票修改失败，数据库操作失败！", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }

        }

        private void dataGridView_股票_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_股票名称.Text = "";
            this.txt_股票代码.Text = "";
            foreach (DataGridViewRow dr in this.dataGridView_股票.SelectedRows)
            {
                this.m_edit_股票 = dr.Cells["股票代码"].Value.ToString();
                this.txt_股票代码.Text = dr.Cells["股票代码"].Value.ToString();
                this.txt_股票名称.Text = dr.Cells["股票名称"].Value.ToString();
            }
        }

        #endregion

        #region 基金经理
        private void btn_增加基金经理_Click(object sender, EventArgs e)
        {
            if (this.txt_基金经理.Text.Trim() == "")
            {
                MessageBox.Show("基金经理字段不能为空", "系统提示");
                return;
            }
            Maticsoft.Model.绩效考核_基金经理信息表 model = new Maticsoft.Model.绩效考核_基金经理信息表();
            model.基金经理 = this.txt_基金经理.Text.Trim();

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金经理信息表();

            #region 检测填写是否合法
            DataTable table = this.dataGridView_产品_基金经理.DataSource as DataTable;
            List<Maticsoft.Model.绩效考核_基金经理_产品份额表> 基金经理_产品份额表_modelList = new List<Maticsoft.Model.绩效考核_基金经理_产品份额表>();
            Maticsoft.BLL.绩效考核_基金经理_产品份额表 基金经理_产品份额表_modelBLL = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();

             List<Maticsoft.Model.绩效考核_基金经理_产品份额表> old_modelList = 基金经理_产品份额表_modelBLL.GetModelList(""); 
            foreach (DataRow row in table.Rows)
            {
                Maticsoft.Model.绩效考核_基金经理_产品份额表 tempModel = new Maticsoft.Model.绩效考核_基金经理_产品份额表();
                double 所占份额 = 0;
                double.TryParse(row["所占份额"].ToString(), out 所占份额);
                tempModel.基金产品 = row["基金产品"].ToString();
                tempModel.基金经理 = this.txt_基金经理.Text.Trim();
                tempModel.所占份额 = 所占份额;
                if (所占份额 > 1 || 所占份额 < 0)
                {
                    MessageBox.Show(string.Format("“{0}”所占份额不合法！", tempModel.基金产品), "系统提示");
                    return;
                } 
                else if (所占份额 == 0)
                    continue;
                double total_份额 = tempModel.所占份额;
                foreach (Maticsoft.Model.绩效考核_基金经理_产品份额表 oldModel in old_modelList)
                {
                    if (oldModel.基金产品 == tempModel.基金产品)
                    {
                        total_份额 += oldModel.所占份额;
                    }
                }
                if (total_份额>1 )
                {
                    MessageBox.Show(string.Format("增加失败，“{0}”所占份额总计超过1！", tempModel.基金产品), "系统提示");
                    return;
                } 
                基金经理_产品份额表_modelList.Add(tempModel);
            }
            #endregion

            if (!Add_基金经理_产品份额表(基金经理_产品份额表_modelList))
            {
                MessageBox.Show("增加失败，“绩效考核_基金经理_产品份额表”操作失败！", "系统提示");
                return;
            }
            if (!modelBLL.Exists(model.基金经理))
            { //存在则更新
                if (modelBLL.Add(model))
                {
                    this.txt_基金经理.Text = "";
                    this.Refresh_基金经理();
                    MessageBox.Show("基金经理增加成功~！", "系统提示");
                }
                else
                    MessageBox.Show("增加失败，数据库操作失败", "系统提示");
            }
            else
                MessageBox.Show(string.Format("增加失败！，存在基金经理“{0}”！", model.基金经理), "系统提示");
        }



        private bool Add_基金经理_产品份额表(List<Maticsoft.Model.绩效考核_基金经理_产品份额表> modelList)
        {

            Maticsoft.BLL.绩效考核_基金经理_产品份额表 modelBLL_基金经理_产品份额表 = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
            foreach (Maticsoft.Model.绩效考核_基金经理_产品份额表 model in modelList)
            {
                if (!modelBLL_基金经理_产品份额表.Exists(model.基金经理, model.基金产品))
                {
                    modelBLL_基金经理_产品份额表.Add(model);
                }
                else
                {
                    modelBLL_基金经理_产品份额表.Update(model);
                }
            }
            return true;
        }

        private void btn_修改基金经理_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = this.dataGridView_基金经理.SelectedRows;
            if (collection.Count >= 1)
            {
                if (this.txt_基金经理.Text.Trim() == "")
                {
                    MessageBox.Show("基金经理不能为空", "系统提示");
                    return;
                }

                if (m_edit_基金经理 != this.txt_基金经理.Text.Trim())
                {
                    MessageBox.Show("基金经理为唯一标识，不能修改", "系统提示");
                    return;
                }

                Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金经理信息表();
                Maticsoft.Model.绩效考核_基金经理信息表 model = new Maticsoft.Model.绩效考核_基金经理信息表();
                model.基金经理 = this.txt_基金经理.Text.Trim();

                #region 检测填写是否合法
                DataTable table = this.dataGridView_产品_基金经理.DataSource as DataTable;
                Maticsoft.BLL.绩效考核_基金经理_产品份额表 modelBLL_基金经理_产品份额表 = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
                List<Maticsoft.Model.绩效考核_基金经理_产品份额表> 基金经理_产品份额表_modelList = new List<Maticsoft.Model.绩效考核_基金经理_产品份额表>();


                List<Maticsoft.Model.绩效考核_基金经理_产品份额表> old_modelList = modelBLL_基金经理_产品份额表.GetModelList(""); 

                foreach (DataRow row in table.Rows)
                {
                    Maticsoft.Model.绩效考核_基金经理_产品份额表 tempModel = new Maticsoft.Model.绩效考核_基金经理_产品份额表();
                    double 所占份额 = 0;
                    double.TryParse(row["所占份额"].ToString(), out 所占份额);
                    tempModel.基金产品 = row["基金产品"].ToString();
                    tempModel.基金经理 = this.txt_基金经理.Text.Trim();
                    tempModel.所占份额 = 所占份额;
                    if (所占份额 > 1 || 所占份额 < 0)
                    {
                        MessageBox.Show(string.Format("“{0}”所占份额不合法！", tempModel.基金产品), "系统提示");
                        return;
                    }
                    else if (所占份额 == 0)
                        continue;

                    double total_份额 = tempModel.所占份额;
                    foreach (Maticsoft.Model.绩效考核_基金经理_产品份额表 oldModel in old_modelList)
                    {
                        if (oldModel.基金产品 == tempModel.基金产品)
                        {
                            total_份额 += oldModel.所占份额;
                        }
                    }
                    if (total_份额 > 1)
                    {
                        MessageBox.Show(string.Format("修改失败，“{0}”所占份额总计超过1！", tempModel.基金产品), "系统提示");
                        return;
                    }

                    基金经理_产品份额表_modelList.Add(tempModel);
                }
                #endregion

                //先删除已有的数据，再重新增加数据
                if (modelBLL_基金经理_产品份额表.Delete(model.基金经理))
                {
                    if (!Add_基金经理_产品份额表(基金经理_产品份额表_modelList))
                    {
                        MessageBox.Show("增加失败，“绩效考核_基金经理_产品份额表”操作失败！", "系统提示");
                        return;
                    }
                }

                if (modelBLL.Update(model))
                {
                    DataGridViewRow row = collection[0];

                    row.Cells["基金经理"].Value = this.txt_基金经理.Text.Trim();
                    row.Cells["管理产品"].Value = model.管理产品;

                    this.txt_基金经理.Text = "";
                    this.Refresh_基金经理();
                    MessageBox.Show("基金经理修改成功！", "系统提示");
                }
                else
                {
                    MessageBox.Show("基金经理修改失败，数据库操作失败！", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }

        }

        private void btn_删除基金经理_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_基金经理.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金经理信息表();
            Maticsoft.BLL.绩效考核_基金经理_产品份额表 modelBLL_基金经理_产品份额表 = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();

            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_基金经理.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    string 基金经理 = collection[i].Cells["基金经理"].Value.ToString();
                    if (modelBLL_基金经理_产品份额表.Delete(基金经理))
                    {
                        if (modelBLL.Delete(基金经理))
                        {
                            this.dataGridView_基金经理.Rows.Remove(collection[i]);
                            deletedCount++;
                        }
                    }
                }
                if (deletedCount > 0)
                {
                    this.txt_基金经理.Text = "";
                    Refresh_基金经理();
                    this.Refresh_dataGridView_产品_基金经理();
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }


        private void dataGridView_基金经理_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_基金经理.Text = "";
            Maticsoft.BLL.绩效考核_基金经理_产品份额表 modelBLL_基金经理_产品份额表 = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
            foreach (DataGridViewRow dr in this.dataGridView_基金经理.SelectedRows)
            {
                this.m_edit_基金经理 = dr.Cells["基金经理"].Value.ToString();
                this.txt_基金经理.Text = dr.Cells["基金经理"].Value.ToString();

                DataSet ds = modelBLL_基金经理_产品份额表.GetDataSets_By基金经理(this.txt_基金经理.Text);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                        this.dataGridView_产品_基金经理.DataSource = ds.Tables[0];
                }
            }
        }
        #endregion

        #region 基金产品


        private void btn_增加产品_Click(object sender, EventArgs e)
        {
            if (this.txt_产品名称.Text.Trim() == "")
            {
                MessageBox.Show("基金产品不能为空", "系统提示");
                return;
            }

            Maticsoft.Model.绩效考核_基金产品信息表 model = new Maticsoft.Model.绩效考核_基金产品信息表();

            model.产品名称 = this.txt_产品名称.Text.Trim();
            double 佣金 = 0;
            double.TryParse(this.txt_佣金.Text.Trim(), out 佣金);
            model.佣金 = 佣金;
            if (佣金 <= 0)
            {
                MessageBox.Show("佣金不满足要求，佣金不能为非数字或不能小于等于0", "系统提示");
                return;
            }

            double 印花税 = 0;
            double.TryParse(this.txt_印花税.Text.Trim(), out 印花税);
            model.印花税 = 印花税;
            if (印花税 <= 0)
            {
                MessageBox.Show("印花税不满足要求，印花税不能为非数字或不能小于等于0", "系统提示");
                return;
            }

            double 过户费比例 = 0;
            double.TryParse(this.txt_过户费比例.Text.Trim(), out 过户费比例);
            model.过户费比例 = 过户费比例;
            if (过户费比例 < 0)
            {
                MessageBox.Show("过户费比例不满足要求，过户费比例不能为非数字或不能小于0", "系统提示");
                return;
            }

            double 份额 = 0;
            double.TryParse(this.txt_份额.Text.Trim(), out 份额);
            model.份额 = 份额;
            if (份额 < 1)
            {
                MessageBox.Show("份额不满足要求，份额不能为非数字或不能小于1", "系统提示");
                return;
            }

            double 赎回份额 = 0;
            double.TryParse(this.txt_赎回份额.Text.Trim(), out 赎回份额);
            model.赎回份额 = 赎回份额;

            double 基准日净值 = 0;
            double.TryParse(this.txt_基准日净值.Text.Trim(), out 基准日净值);
            model.基准日净值 = 基准日净值;

            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            if (!modelBLL.Exists(model.产品名称))
            { //存在则更新
                if (modelBLL.Add(model))
                {
                    this.txt_产品名称.Text = "";
                    this.txt_佣金.Text = "";
                    this.txt_印花税.Text = "";
                    this.txt_过户费比例.Text = "";
                    this.txt_份额.Text = "";
                    this.txt_赎回份额.Text = "";
                    this.txt_基准日净值.Text = "";
                    this.Refresh_基金产品();

                    MessageBox.Show("基金产品增加成功~！", "系统提示");
                }
                else
                {
                    MessageBox.Show("增加失败，数据库操作失败", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("增加失败，存在同名的产品", "系统提示");
            }

        }

        private void btn_修改产品_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection collection = this.dataGridView_产品.SelectedRows;
            if (collection.Count >= 1)
            {

                Maticsoft.Model.绩效考核_基金产品信息表 model = new Maticsoft.Model.绩效考核_基金产品信息表();

                model.产品名称 = this.txt_产品名称.Text.Trim();
                if (model.产品名称 == "")
                {
                    MessageBox.Show("基金产品名称不能为空", "系统提示");
                    return;
                }

                double 佣金 = 0;
                double.TryParse(this.txt_佣金.Text.Trim(), out 佣金);
                model.佣金 = 佣金;
                if (佣金 <= 0)
                {
                    MessageBox.Show("佣金不满足要求，佣金不能为非数字或不能小于等于0", "系统提示");
                    return;
                }

                double 印花税 = 0;
                double.TryParse(this.txt_印花税.Text.Trim(), out 印花税);
                model.印花税 = 印花税;
                if (印花税 <= 0)
                {
                    MessageBox.Show("印花税不满足要求，印花税不能为非数字或不能小于等于0", "系统提示");
                    return;
                }

                double 过户费比例 = 0;
                double.TryParse(this.txt_过户费比例.Text.Trim(), out 过户费比例);
                model.过户费比例 = 过户费比例;
                if (过户费比例 < 0)
                {
                    MessageBox.Show("过户费比例不满足要求，过户费比例不能为非数字或不能小于0", "系统提示");
                    return;
                }

                long 份额 = 0;
                long.TryParse(this.txt_份额.Text.Trim(), out 份额);
                model.份额 = 份额;
                if (份额 < 1)
                {
                    MessageBox.Show("份额不满足要求，份额不能为非数字或不能小于1", "系统提示");
                    return;
                }

                double 赎回份额 = 0;
                double.TryParse(this.txt_赎回份额.Text.Trim(), out 赎回份额);
                model.赎回份额 = 赎回份额;

                double 基准日净值 = 0;
                double.TryParse(this.txt_基准日净值.Text.Trim(), out 基准日净值);
                model.基准日净值 = 基准日净值;

                if (m_edit_基金产品 != this.txt_产品名称.Text.Trim())
                {
                    MessageBox.Show("产品名称为唯一标识，不能修改", "系统提示");
                    return;
                }

                Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
                if (modelBLL.Update(model))
                {
                    DataGridViewRow row = collection[0];
                    row.Cells["产品名称"].Value = this.txt_产品名称.Text.Trim();
                    row.Cells["佣金"].Value = this.txt_佣金.Text.Trim();
                    row.Cells["印花税"].Value = this.txt_印花税.Text.Trim();
                    row.Cells["过户费比例"].Value = this.txt_过户费比例.Text.Trim();
                    row.Cells["份额"].Value = this.txt_份额.Text.Trim();
                    row.Cells["赎回份额"].Value = this.txt_赎回份额.Text.Trim();
                    row.Cells["基准日净值"].Value = this.txt_基准日净值.Text.Trim();

                    this.txt_产品名称.Text = "";
                    this.txt_佣金.Text = "";
                    this.txt_印花税.Text = "";
                    this.txt_过户费比例.Text = "";
                    this.txt_份额.Text = "";
                    this.txt_赎回份额.Text = "";
                    this.txt_基准日净值.Text = "";

                    this.txt_份额.ReadOnly = false;
                    MessageBox.Show("基金产品修改成功！", "系统提示");
                }
                else
                {
                    MessageBox.Show("基金产品修改失败，数据库操作失败！", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }

        }

        private void btn_删除产品_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_产品.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();

            Maticsoft.BLL.绩效考核_基金经理_产品份额表 基金经理_产品份额表_modelBLL = new Maticsoft.BLL.绩效考核_基金经理_产品份额表();
            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_产品.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    string 产品名称 = collection[i].Cells["产品名称"].Value.ToString();
                    if (基金经理_产品份额表_modelBLL.Delete_By基金产品(产品名称))
                    {
                        if (modelBLL.Delete(产品名称))
                        {
                            this.dataGridView_产品.Rows.Remove(collection[i]);
                            deletedCount++;
                        }
                    }
                }
                if (deletedCount > 0)
                {
                    this.txt_产品名称.Text = "";
                    this.txt_佣金.Text = "";
                    this.txt_印花税.Text = "";
                    this.txt_过户费比例.Text = "";
                    this.txt_份额.Text = "";
                    this.txt_赎回份额.Text = "";
                    this.txt_基准日净值.Text = "";
                    this.Refresh_基金产品();
                    this.Refresh_基金经理();
                    this.Refresh_dataGridView_产品_基金经理();
                    this.txt_份额.ReadOnly = false;
                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");

            }
        }

        private void dataGridView_产品_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_产品名称.Text = "";
            this.txt_佣金.Text = "";
            this.txt_印花税.Text = "";
            this.txt_过户费比例.Text = "";
            this.txt_份额.Text = "";
            this.txt_赎回份额.Text = "";
            this.txt_基准日净值.Text = "";
            foreach (DataGridViewRow dr in this.dataGridView_产品.SelectedRows)
            {
                this.m_edit_基金产品 = dr.Cells["产品名称"].Value.ToString();
                this.txt_产品名称.Text = dr.Cells["产品名称"].Value.ToString();
                this.txt_佣金.Text = dr.Cells["佣金"].Value.ToString();
                this.txt_印花税.Text = dr.Cells["印花税"].Value.ToString();
                this.txt_过户费比例.Text = dr.Cells["过户费比例"].Value.ToString();
                this.txt_份额.Text = dr.Cells["份额"].Value.ToString();
                this.txt_赎回份额.Text = dr.Cells["赎回份额"].Value.ToString();
                this.txt_基准日净值.Text = dr.Cells["基准日净值"].Value.ToString();
                 
                this.txt_份额.ReadOnly = true;
            }
        }


        private void btn_修改赎回份额_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = this.dataGridView_产品.SelectedRows;
            if (collection.Count < 1)
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }
            else
            {
                DataGridViewRow row = collection[0];
                string 产品名称 = row.Cells["产品名称"].Value.ToString();
                Edit_ShuHui_Frm frm = new Edit_ShuHui_Frm(产品名称);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Maticsoft.BLL.绩效考核_基金产品信息表 modelBLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
                    Maticsoft.Model.绩效考核_基金产品信息表 model = new Maticsoft.Model.绩效考核_基金产品信息表();
                    model.产品名称 = 产品名称;

                    double 佣金 = 0;
                    double.TryParse(this.txt_佣金.Text.Trim(), out 佣金);
                    model.佣金 = 佣金;

                    double 印花税 = 0;
                    double.TryParse(this.txt_印花税.Text.Trim(), out 印花税);
                    model.印花税 = 印花税;

                    double 过户费比例 = 0;
                    double.TryParse(this.txt_过户费比例.Text.Trim(), out 过户费比例);
                    model.过户费比例 = 过户费比例;

                    double 份额 = 0;
                    double.TryParse(this.txt_份额.Text.Trim(), out 份额);

                    //赎回份额、份额两个参数发生变化
                    model.赎回份额 = frm.赎回份额;
                    model.份额 = 份额 - model.赎回份额;

                    double 基准日净值 = 0;
                    double.TryParse(this.txt_基准日净值.Text.Trim(), out 基准日净值);
                    model.基准日净值 = 基准日净值;

                    if (modelBLL.Update(model))
                    {
                        this.txt_产品名称.Text = "";
                        this.txt_佣金.Text = "";
                        this.txt_印花税.Text = "";
                        this.txt_过户费比例.Text = "";
                        this.txt_份额.Text = "";
                        this.txt_赎回份额.Text = "";
                        this.txt_基准日净值.Text = "";

                        Refresh_基金产品();
                        MessageBox.Show("赎回份额修改成功！", "系统提示");
                    }
                } 

            }

        }

        private void btn_重置_Click(object sender, EventArgs e)
        {
            this.txt_产品名称.Text = "";
            this.txt_佣金.Text = "";
            this.txt_印花税.Text = "";
            this.txt_过户费比例.Text = "";
            this.txt_份额.Text = "";
            this.txt_赎回份额.Text = "";
            this.txt_基准日净值.Text = "";

            this.txt_份额.ReadOnly = false;
        }


        #endregion
    }


}



