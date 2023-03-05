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
    public partial class Edit_Info : Form
    {
        private Maticsoft.Model.绩效考核_股票每日交易汇总小表 m_当前交易股票model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
        public Maticsoft.Model.绩效考核_股票每日交易汇总小表 Model
        {
            get { return m_当前交易股票model; }
        }

        public Edit_Info(Maticsoft.Model.绩效考核_股票每日交易汇总小表 _model)
        {
            InitializeComponent();
            this.m_当前交易股票model = _model;
            this.txt_买入股数.Text = m_当前交易股票model.今日买入股.ToString();
            this.txt_买入均价.Text = m_当前交易股票model.买入均价.ToString();
            this.txt_卖出股数.Text = m_当前交易股票model.今日卖出股.ToString();
            this.txt_卖出均价.Text = m_当前交易股票model.卖出均价.ToString();
        }

        private void btn_确定_Click(object sender, EventArgs e)
        {
            //卖出 没有过户费 
            #region 获取基金产品信息（20151104）
            Dictionary<string, string> 不计算税费集合_DIC = DataConvertor.Get不计算税费集合();
            
            Maticsoft.BLL.绩效考核_基金产品信息表 基金产品信息表BLL = new Maticsoft.BLL.绩效考核_基金产品信息表();
            Maticsoft.Model.绩效考核_基金产品信息表 基金产品信息表Model = 基金产品信息表BLL.GetModel(m_当前交易股票model.产品名称);
            //过户费比例 印花税 佣金 默认值都为0.001；
            double 过户费比例 = 0.001; double 印花税比例 = 0.001; double 佣金比例 = 0.001;
            if (基金产品信息表Model != null)
            {
                过户费比例 = 基金产品信息表Model.过户费比例;
                印花税比例 = 基金产品信息表Model.印花税;
                佣金比例 = 基金产品信息表Model.佣金;
            }
            if (不计算税费集合_DIC.ContainsKey(m_当前交易股票model.股票代码))
            {
                过户费比例 = 0;
                印花税比例 = 0;
                佣金比例 = 0;
            }

            #endregion

            Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
            model.产品名称 = m_当前交易股票model.产品名称;
            model.股票代码 = m_当前交易股票model.股票代码;
            model.产品名称 = m_当前交易股票model.产品名称;
            model.时间 = m_当前交易股票model.时间;
            model.股票名称 = m_当前交易股票model.股票名称;
            model.基金经理 = m_当前交易股票model.基金经理;
            model.记录标识 = m_当前交易股票model.记录标识;

            long 买入股数 = 0; double 买入均价 = 0;
            long 卖出股数 = 0; double 卖出均价 = 0;
            long.TryParse(this.txt_买入股数.Text.Trim(), out 买入股数);
            double.TryParse(this.txt_买入均价.Text.Trim(), out 买入均价);
            long.TryParse(this.txt_卖出股数.Text.Trim(), out 卖出股数);
            double.TryParse(this.txt_卖出均价.Text.Trim(), out 卖出均价);
            model.今日买入股 = 买入股数;
            model.买入均价 = 买入均价;
            model.今日卖出股 = 卖出股数;
            model.卖出均价 = 卖出均价;

            if (model.今日买入股 <= 0 || model.买入均价<=0)
            {
                model.今日买入股 = 0;
                model.买入均价 = 0;
            }
            if (model.今日卖出股 <= 0 || model.卖出均价 <= 0)
            {
                model.今日卖出股 = 0;
                model.卖出均价 = 0;
            }

            if ((model.今日买入股 <= 0 || model.买入均价 <= 0) && (model.今日卖出股 <= 0 || model.卖出均价 <= 0))
            {
                MessageBox.Show("股数和均价输入不合法", "系统提示");
                return;
            } 
            model.买入金额 = model.今日买入股 * model.买入均价;
            model.卖出金额 = model.今日卖出股 * model.卖出均价;

            model.买入手续费 = model.买入金额 * 佣金比例;
            model.卖出手续费 = model.卖出金额 * 佣金比例;

            if (long.Parse(model.股票代码) > 600000)
            {
                model.买入过户费 = model.买入金额 * 过户费比例;
                model.卖出过户费 = model.卖出金额 * 过户费比例;
                // model.买入过户费 = info.买入金额 * 过户费比例;
                // model.卖出过户费 = info.卖出金额 * 过户费比例;
            }
            //只有卖出，才有“卖出印花税”，无“买入印花税”；
            model.卖出印花税 = model.卖出金额 * 印花税比例;
            model.买入清算金额 = model.买入金额 + model.买入手续费 + model.买入过户费 + model.买入印花税;
            model.卖出清算金额 = model.卖出金额 - model.卖出手续费 - model.卖出过户费 - model.卖出印花税;

            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            if (modelBLL.Update(model))
            {
                MessageBox.Show("修改成功！", "系统提示");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("修改失败，数据库操作失败！", "系统提示");
            }  
        }


        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_卖出均价_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
