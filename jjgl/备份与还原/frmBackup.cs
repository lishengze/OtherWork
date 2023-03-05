using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Maticsoft.DBUtility;
namespace SQL_Distill
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }
        public string strserver="";
        public string struser="";
        public string strpwd="";
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackup_Load(object sender, EventArgs e)
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