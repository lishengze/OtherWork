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
    public partial class Edit_Password : Form
    {

        public Edit_Password( )
        {
            InitializeComponent();
            
            //this.txt_新密码.Text = m_今日大表Model.持股数量.ToString();
            //this.txt_新密码确认.Text = m_今日大表Model.持股成本.ToString();
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            if (this.txt_用户名.Text.Trim() != DataConvertor.Pub_超级管理员用户名)
            {
                MessageBox.Show("输入的超级管理员用户名有误！", "系统提示");
                return;
            }
            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表();
            Maticsoft.Model.绩效考核_用户信息表 model = modelBLL.GetModel(DataConvertor.Pub_超级管理员用户名);
            if (model != null) //数据库中存在该记录
            {
                
                if (this.txt_用户名.Text.Trim() == "")
                {
                    MessageBox.Show("用户名不能为空！", "系统提示");
                    return;
                }
                if (this.txt_原始密码.Text.Trim() == "")
                {
                    MessageBox.Show("用户原始密码不能为空", "系统提示");
                    return;
                } 

                if (this.txt_原始密码.Text.Trim() != model.用户密码)
                {
                    MessageBox.Show("用户原始密码不正确！", "系统提示");
                    return;
                }
                if (this.txt_新密码.Text.Trim() == "")
                {
                    MessageBox.Show("用户新密码不能为空", "系统提示");
                    return;
                }
                if (this.txt_新密码确认.Text.Trim() == "")
                {
                    MessageBox.Show("新密码确认不能为空", "系统提示");
                    return;
                }
                if (this.txt_新密码.Text.Trim() != this.txt_新密码确认.Text.Trim())
                {
                    MessageBox.Show("新密码两次输入的不一致！", "系统提示");
                    return;
                }
                model.用户密码 = this.txt_新密码.Text.Trim();
                if (modelBLL.Update(model))
                {
                    MessageBox.Show("超级管理员密码修改成功！", "系统提示");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败，数据库操作失败！", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("数据库中超级管理员信息丢失，请联系系统开发人员！", "系统提示");
            }
        } 

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

    }
}
