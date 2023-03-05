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
    public partial class 小表数据审查_修改 : Form
    {
        private Maticsoft.Model.绩效考核_股票每日交易汇总小表 m_当前交易股票model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
        

        public 小表数据审查_修改(Maticsoft.Model.绩效考核_股票每日交易汇总小表 _model)
        { 
            InitializeComponent();
            this.m_当前交易股票model = _model;
            this.txt_旧_股票名称.Text = _model.股票名称;
            this.txt_旧_基金产品名称.Text = _model.产品名称; 
        }
        Maticsoft.BLL.绩效考核_股票每日交易汇总小表 股票每日交易汇总小表BLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();

        private void btn_股票名称_修改一条记录_Click(object sender, EventArgs e)
        { 
            if( this.txt_新_股票名称.Text.Trim()=="")
            {
                MessageBox.Show("新股票名称不允许为空！","系统提示");
                return;
            }
            m_当前交易股票model.股票名称 = this.txt_新_股票名称.Text;
            if (股票每日交易汇总小表BLL.Update(m_当前交易股票model))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        private void btn_股票名称_修改所有记录_Click(object sender, EventArgs e)
        {
            string sql = string.Format("update 绩效考核_股票每日交易汇总小表 set  股票名称='{0}' where 股票名称 ='{1}'", this.txt_新_股票名称.Text, this.txt_旧_股票名称.Text.Trim());
            try
            {
                DbHelperSQL.GetSingle(sql);
                this.DialogResult = System.Windows.Forms.DialogResult.OK; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "系统提示");
            }
        }

        private void btn_基金产品_修改一条记录_Click(object sender, EventArgs e)
        {
            if (this.txt_新_基金产品名称.Text.Trim() == "")
            {
                MessageBox.Show("新基金产品名称不允许为空！", "系统提示");
                return;
            }
            m_当前交易股票model.产品名称 = this.txt_新_基金产品名称.Text;
            if (股票每日交易汇总小表BLL.Update(m_当前交易股票model))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btn_基金产品_修改所有记录_Click(object sender, EventArgs e)
        {
            string sql = string.Format("update 绩效考核_股票每日交易汇总小表 set  产品名称='{0}' where 产品名称 ='{1}'", this.txt_新_基金产品名称.Text, this.txt_旧_基金产品名称.Text.Trim());
            try
            {
                DbHelperSQL.GetSingle(sql);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "系统提示");
            }
        } 

    }
}
