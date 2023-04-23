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
    public partial class SystemManagerCtl : UserControl
    {
        public SystemManagerCtl()
        {
            InitializeComponent();
            InitData();
            InitCombox();//建议使用此方法来初始化combobox，因为这样就可以在控件上使用动态
            this.Load += new EventHandler(ManagerCtl_Load);
        }
         
        public string m_edit_用户名 = string.Empty; 
        public string m_edit_汇率 = string.Empty;

        public string m_rate_type = string.Empty;

        void ManagerCtl_Load(object sender, EventArgs e)
        {
            this.dataGridView_用户.ClearSelection();
            this.dataGridView_汇率.ClearSelection();
        }

        private void InitData()
        {
            Refresh_用户();
            Refresh_汇率();
            this.cmb_角色.SelectedItem = "管理员";
            m_rate_type = "港股";
        }

        private void InitCombox() 
        {
            this.comboBox_RateType.Items.Add("港股");
            this.comboBox_RateType.Items.Add("美股");
        }

        #region 用户

        private void Refresh_用户()
        {
            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表();
            DataSet ds = modelBLL.GetAllList();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable table = ds.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    if (row["用户名"].ToString() == DataConvertor.Pub_超级管理员用户名)
                    {
                        table.Rows.Remove(row);
                        break;
                    }
                }
                this.dataGridView_用户.DataSource = ds.Tables[0];
                if (DataConvertor.Pub_超级管理员用户名 != DataConvertor.Pub_登录用户信息.用户名) //当前用户不是超级管理员用户，则不显示密码列
                {
                    this.dataGridView_用户.Columns["用户密码"].Visible = false;
                }
            }
            this.dataGridView_用户.ClearSelection();
        }

        private void btn_增加用户_Click(object sender, EventArgs e)
        {
            if (DataConvertor.Pub_登录用户信息.用户名 != DataConvertor.Pub_超级管理员用户名)
            {
                MessageBox.Show("当前用户不是超级管理员，不能增加用户！", "系统提示");
                return;
            }
            if (this.txt_用户名.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！", "系统提示");
                return;
            }
            if (this.txt_用户密码.Text.Trim() == "")
            {
                MessageBox.Show("用户密码不能为空", "系统提示");
                return;
            }

            Maticsoft.Model.绩效考核_用户信息表 model = new Maticsoft.Model.绩效考核_用户信息表();
            model.用户名 = this.txt_用户名.Text.Trim();
            model.用户密码 = this.txt_用户密码.Text.Trim();
            model.用户姓名 = this.txt_用户姓名.Text.Trim();
            model.角色 = this.cmb_角色.SelectedItem.ToString();
            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表();
            if (!modelBLL.Exists(model.用户名))
            {
                if (modelBLL.Add(model))
                {
                    this.txt_用户名.Text = "";
                    this.txt_用户密码.Text = "";
                    this.txt_用户姓名.Text = "";
                    this.Refresh_用户();
                    MessageBox.Show("用户增加成功~！", "系统提示");
                }
                else
                    MessageBox.Show("增加失败，数据库操作失败", "系统提示");
            }
            else
                MessageBox.Show(string.Format("增加失败！，已经存在用户“{0}”！", model.用户名), "系统提示");
        }

        private void btn_修改用户_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = this.dataGridView_用户.SelectedRows;
            if (collection.Count >= 1)
            {
                //当前登录用户不是超级管理员，只可以修改自己的信息 
                if (DataConvertor.Pub_登录用户信息.用户名 != DataConvertor.Pub_超级管理员用户名)
                {
                    if (m_edit_用户名 != DataConvertor.Pub_登录用户信息.用户名) //修改其他人，弹出提示
                    {
                        MessageBox.Show("非超级管理员用户不可修改其他用户信息", "系统提示");
                        return;
                    }
                    else
                        修改用户信息_Fun(collection[0]);
                }
                else
                {
                    //当前登录用户是超级管理员,允许修改所有人的信息
                    修改用户信息_Fun(collection[0]);
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }

        }

        private void 修改用户信息_Fun(DataGridViewRow row)
        {
            if (this.txt_用户名.Text.Trim() == "" || this.txt_用户密码.Text.Trim() == "")
            {
                MessageBox.Show("用户名和用户密码不能为空", "系统提示");
                return;
            }
            if (m_edit_用户名 != this.txt_用户名.Text.Trim())
            {
                MessageBox.Show("用户名为唯一标识，不能修改", "系统提示");
                return;
            }

            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表();
            Maticsoft.Model.绩效考核_用户信息表 model = new Maticsoft.Model.绩效考核_用户信息表();
            model.用户名 = this.txt_用户名.Text.Trim();
            model.用户密码 = this.txt_用户密码.Text.Trim();
            model.用户姓名 = this.txt_用户姓名.Text.Trim();
            model.角色 = this.cmb_角色.SelectedItem.ToString();
            if (modelBLL.Update(model))
            {
                row.Cells["用户名"].Value = model.用户名;
                row.Cells["用户密码"].Value = model.用户密码;
                row.Cells["用户姓名"].Value = model.用户姓名;
                row.Cells["角色"].Value = model.角色;

                this.txt_用户名.Text = "";
                this.txt_用户密码.Text = "";
                this.txt_用户姓名.Text = "";

                MessageBox.Show("用户信息修改成功！", "系统提示");
            }
            else
            {
                MessageBox.Show("用户信息修改失败，数据库操作失败！", "系统提示");
            }
        }

        private void btn_删除用户_Click(object sender, EventArgs e)
        {
            if (DataConvertor.Pub_登录用户信息.用户名 != DataConvertor.Pub_超级管理员用户名)
            {
                MessageBox.Show("当前用户不是超级管理员，不能删除用户！", "系统提示");
                return;
            }
            if (this.dataGridView_用户.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }

            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表();
            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_用户.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    string 用户名 = collection[i].Cells["用户名"].Value.ToString();
                    if (modelBLL.Delete(用户名))
                    {
                        deletedCount++;
                        this.dataGridView_用户.Rows.Remove(collection[i]);
                    }
                }

                if (deletedCount > 0)
                {
                    this.txt_用户名.Text = "";
                    this.txt_用户密码.Text = "";
                    this.txt_用户姓名.Text = "";

                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void dataGridView_用户_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_用户密码.Text = "";
            this.txt_用户名.Text = "";
            this.txt_用户姓名.Text = "";
            foreach (DataGridViewRow dr in this.dataGridView_用户.SelectedRows)
            {
                this.m_edit_用户名 = dr.Cells["用户名"].Value.ToString(); 
                this.txt_用户名.Text = m_edit_用户名;
                this.txt_用户密码.Text = "";
                this.txt_用户姓名.Text = dr.Cells["用户姓名"].Value.ToString();
                this.cmb_角色.SelectedItem = dr.Cells["角色"].Value.ToString();
            }
        }

        private void btn_重置用户_Click(object sender, EventArgs e)
        {
            this.txt_用户密码.Text = "";
            this.txt_用户名.Text = "";
            this.txt_用户姓名.Text = "";

        }

        private void btn_修改管理员密码_Click(object sender, EventArgs e)
        {
            Edit_Password edit_password = new Edit_Password();
            edit_password.ShowDialog();

        }
        #endregion

        #region 汇率

        private void Refresh_汇率()
        {
            Maticsoft.BLL.绩效考核_汇率 modelBLL = new Maticsoft.BLL.绩效考核_汇率();
            DataSet ds = modelBLL.GetAllList();
            if (ds != null && ds.Tables.Count > 0)
            {
                this.dataGridView_汇率.DataSource = ds.Tables[0];
            }
            this.dataGridView_汇率.ClearSelection();
        }

        private string getRateKey() 
        {
            string curr_date = this.datetimer_汇率_时间.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string result = curr_date;

            if ("美股" == m_rate_type) 
            {
                result = curr_date + "_USA";;
            }
            return result;
        }

        private void btn_增加汇率_Click(object sender, EventArgs e)
        {
            double 买入汇率 = 0; 
            double 卖出汇率 = 0;
            double.TryParse(this.txt_买入汇率.Text.Trim(), out 买入汇率);
            double.TryParse(this.txt_卖出汇率.Text.Trim(), out 卖出汇率);
            if (买入汇率 <= 0 && 卖出汇率 <= 0)
            {
                MessageBox.Show("买入汇率和卖出汇率不能完全为空或数值不合法！", "系统提示");
                return;
            }
            Maticsoft.Model.绩效考核_汇率 model = new Maticsoft.Model.绩效考核_汇率();
            model.时间 = getRateKey();
            model.买入汇率 = 买入汇率;
            model.卖出汇率 = 卖出汇率;
            Maticsoft.BLL.绩效考核_汇率 modelBLL = new Maticsoft.BLL.绩效考核_汇率();
            if (!modelBLL.Exists(model.时间))
            {
                if (modelBLL.Add(model))
                {
                    this.txt_买入汇率.Text = "";
                    this.txt_卖出汇率.Text = "";
                    this.Refresh_汇率();
                    MessageBox.Show(m_rate_type + "汇率增加成功！", "系统提示");
                }
                else
                    MessageBox.Show(m_rate_type+ "汇率增加失败，数据库操作失败", "系统提示");
            }
            else
                MessageBox.Show(m_rate_type + "汇率增加失败！已经存在当日汇率！", "系统提示");
        }

        private void btn_修改汇率_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = this.dataGridView_汇率.SelectedRows;
            if (collection.Count >= 1)
            {
                double 买入汇率 = 0; double 卖出汇率 = 0;
                double.TryParse(this.txt_买入汇率.Text.Trim(), out 买入汇率);
                double.TryParse(this.txt_卖出汇率.Text.Trim(), out 卖出汇率);
                if (买入汇率 <= 0 && 卖出汇率 <= 0)
                {
                    MessageBox.Show("买入汇率和卖出汇率不能完全为空或数值不合法！", "系统提示");
                    return;
                }
                Maticsoft.BLL.绩效考核_汇率 modelBLL = new Maticsoft.BLL.绩效考核_汇率();
                Maticsoft.Model.绩效考核_汇率 model = new Maticsoft.Model.绩效考核_汇率();
                model.时间 = getRateKey();
                model.买入汇率 = 买入汇率;
                model.卖出汇率 = 卖出汇率;
                if (!modelBLL.Exists(model.时间))
                {
                }
                else
                {
                    if (modelBLL.Update(model))
                    {
                        DataGridViewRow row = collection[0];

                        row.Cells["时间"].Value = model.时间;
                        row.Cells["买入汇率"].Value = this.txt_买入汇率.Text.Trim();
                        row.Cells["卖出汇率"].Value = this.txt_卖出汇率.Text.Trim();

                        this.txt_买入汇率.Text = "";
                        this.txt_卖出汇率.Text = "";

                        MessageBox.Show(m_rate_type + "汇率修改成功！", "系统提示");
                    }
                    else
                    {
                        MessageBox.Show(m_rate_type +"汇率修改失败，数据库操作失败！", "系统提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的行！", "系统提示");
            }
        }

        private void btn_删除汇率_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_汇率.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择删除记录！", "系统提示");
                return;
            }

            Maticsoft.BLL.绩效考核_汇率 modelBLL = new Maticsoft.BLL.绩效考核_汇率();
            int deletedCount = 0;
            if (MessageBox.Show("确认删除该记录吗？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection collection = this.dataGridView_汇率.SelectedRows;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    string 时间 = collection[i].Cells["时间"].Value.ToString();
                    if (modelBLL.Delete(时间))
                    {
                        deletedCount++;
                        this.dataGridView_汇率.Rows.Remove(collection[i]);
                    }
                }
                if (deletedCount > 0)
                {
                    this.txt_买入汇率.Text = "";
                    this.txt_卖出汇率.Text = "";

                    MessageBox.Show("删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void dataGridView_汇率_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_买入汇率.Text = "";
            this.txt_卖出汇率.Text = "";
            foreach (DataGridViewRow dr in this.dataGridView_汇率.SelectedRows)
            {
                this.m_edit_汇率 = dr.Cells["时间"].Value.ToString();
                DateTime dt = DateTime.Now;
                if (DateTime.TryParse(m_edit_汇率, out dt))
                    this.datetimer_汇率_时间.Value = dt;
                else
                    this.datetimer_汇率_时间.Value = DateTime.Now;
                this.txt_买入汇率.Text = dr.Cells["买入汇率"].Value.ToString();
                this.txt_卖出汇率.Text = dr.Cells["卖出汇率"].Value.ToString();
            }
        }

        private void btn_重置汇率_Click(object sender, EventArgs e)
        {
            this.txt_买入汇率.Text = "";
            this.txt_卖出汇率.Text = "";

        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            m_rate_type = combo.SelectedItem.ToString(); 
            LOG.Instance.Info("汇率类型: " + m_rate_type);
        }


    }


}



