using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.IO;

namespace 基金管理
{
    public partial class DeleteDataFrm : Form
    {
        public DeleteDataFrm()
        {
            InitializeComponent();
            this.Load += new EventHandler(DeleteDataFrm_Load);
            this.dateTimePicker2.Value = System.DateTime.Now;
            this.dateTimePicker1.Value = System.DateTime.Now.AddDays(-30); 

        }
         

        private void btn_清理大表数据_Click(object sender, EventArgs e)
        {

            string startDateTime = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endDateTime = this.dateTimePicker2.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            //、绩效考核_股票每日交易汇总大表、绩效考核_基金产品每日统计、绩效考核_基金经理净值贡献表
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_大表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表(); 
            string sql1 = string.Format("delete from 绩效考核_股票每日交易汇总大表 where 时间 between '{0}' and '{1}'", startDateTime, endDateTime);
            string sql2 = string.Format("delete from 绩效考核_基金产品每日统计 where 时间 between '{0}' and '{1}'", startDateTime, endDateTime);
            string sql3 = string.Format("delete from 绩效考核_基金经理净值贡献表 where 时间 between '{0}' and '{1}'", startDateTime, endDateTime);
            string sql4 = string.Format("delete from 绩效考核_股票每日价格记录表 where 时间 between '{0}' and '{1}'", startDateTime, endDateTime);
            try
            {
                DbHelperSQL.ExecuteSql(sql1 + ";" + sql2 + ";" + sql3 + ";" + sql4);
                MessageBox.Show("删除成功！", "系统提示");
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败！", "系统提示");
            }
        }

        private void btn_清理小表数据_Click(object sender, EventArgs e)
        {
            string startDateTime = this.dateTimePicker1.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string endDateTime = this.dateTimePicker2.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);


            Maticsoft.BLL.绩效考核_股票每日交易汇总小表 modelBLL_小表 = new Maticsoft.BLL.绩效考核_股票每日交易汇总小表();
            string sql1 = string.Format("delete from 绩效考核_股票每日交易汇总小表 where 时间 between '{0}' and '{1}'", startDateTime, endDateTime);
            
            try
            {
                DbHelperSQL.ExecuteSql(sql1);
                MessageBox.Show("删除成功！", "系统提示");
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败！", "系统提示");
            }
        }

        public string strserver = "";
        public string struser = "";
        public string strpwd = "";
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void DeleteDataFrm_Load(object sender, EventArgs e)
        {
            // <add key="ConnectionString" value="server=.;uid=sa;password=sa123456;database=jjgl;"/> 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DbHelperSQL.connectionString;
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("sp_helpdb", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (sdr[0].ToString() == "master" || sdr[0].ToString() == "model" || sdr[0].ToString() == "msdb" || sdr[0].ToString() == "Northwind" || sdr[0].ToString() == "pubs" || sdr[0].ToString() == "tempdb")
                    { }
                    else
                    {
                        cbbData.Items.Add(sdr[0].ToString());
                    }
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBackupName.Text.Trim() == "" || txtPath.Text.Trim() == "" || cbbData.Text.Trim() == "")
                {
                    MessageBox.Show("注意：信息不完整！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string filepath = txtPath.Text.Trim() + "\\" + txtBackupName.Text.Trim() + ".bak";
                    if (!File.Exists(filepath))
                    {
                        SqlConnection con = new SqlConnection();		//利用代码实现连接数据库 
                        con.ConnectionString = DbHelperSQL.connectionString;// "server=.;uid=" + struser + ";pwd=" + strpwd + ";database='" + cbbData.Text.Trim() + "'";
                        con.Open();
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "BACKUP DATABASE " + cbbData.Text.Trim() + " TO DISK = '" + filepath + "'";
                        com.Connection = con;							//连接
                        com.ExecuteNonQuery();						    //执行
                        con.Close();
                        MessageBox.Show("提示：数据库备份成功！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("注意：请重新命名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("注意：备份失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }
        

    }
}
