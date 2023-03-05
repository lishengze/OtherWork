using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace 基金管理
{
    public partial class 大表数据审查_修改 : Form
    { 
        public 大表数据审查_修改(string 产品名称,string 股票名称, 大表数据审查_查询操作 查询操作)
        { 
            InitializeComponent();
            if (查询操作 == 大表数据审查_查询操作.查询大表产品信息 || 查询操作 == 大表数据审查_查询操作.大表产品信息表_产品名称异常记录)
            { 
                this.txt_旧_基金产品名称.Text = 产品名称;
                btn_股票名称_修改所有记录.Enabled = false;
            }
            else
            {  
                this.txt_旧_股票名称.Text =  股票名称;
                this.txt_旧_基金产品名称.Text = 产品名称; 
            }
        }
         
         
        private void btn_股票名称_修改所有记录_Click(object sender, EventArgs e)
        {
            string sql1 = string.Format("update 绩效考核_股票每日交易汇总大表 set  股票名称='{0}' where 股票名称 ='{1}'", this.txt_新_股票名称.Text, this.txt_旧_股票名称.Text.Trim());
           
            try
            {
                DbHelperSQL.GetSingle(sql1);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "系统提示");
            }
        }
        private void btn_基金产品_修改所有记录_Click(object sender, EventArgs e)
        {
            string sql1 = string.Format("update 绩效考核_基金产品每日统计 set  产品名称='{0}' where 产品名称 ='{1}'", this.txt_新_基金产品名称.Text, this.txt_旧_基金产品名称.Text.Trim());
            string sql2 = string.Format("update 绩效考核_股票每日交易汇总大表 set  产品名称='{0}' where 产品名称 ='{1}'", this.txt_新_基金产品名称.Text, this.txt_旧_基金产品名称.Text.Trim());
            
            try
            {
                DbHelperSQL.GetSingle(sql1);
                DbHelperSQL.GetSingle(sql2);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "系统提示");
            }
        } 
    }
}
