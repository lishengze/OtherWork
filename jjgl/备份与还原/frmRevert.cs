using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SQL_Distill
{
    public partial class frmRevert : Form
    {
        public frmRevert()
        {
            InitializeComponent();
        }
        public string strserver = "";
        public string struser = "";
        public string strpwd = "";
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRevert_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=" + strserver + ";DataBase=master;uid=" + struser + ";pwd=" + strpwd);
            conn.ConnectionString = Maticsoft.DBUtility.DbHelperSQL.connectionString;
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
                        comboBox1.Items.Add(sdr[0].ToString());
                    }
                }
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text.Trim() == "" || textBox1.Text.Trim() == "")
            {
                MessageBox.Show("注意：信息不完整！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string path = textBox1.Text.Trim();//获得备份路径及数据库名称
                string dbname = comboBox1.Text.Trim();
               // string SqlStr1 = "Server=.;database='" + dbname + "';Uid="+struser+";Pwd="+strpwd;

                string SqlStr2 = "use master restore database " + dbname + " from disk='" + path + "'";
                string single = "alter database " + dbname + " set single_user with rollback immediate " + SqlStr2;
                using (SqlConnection con = new SqlConnection(Maticsoft.DBUtility.DbHelperSQL.connectionString))
                {
                    con.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(single, con);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("还原数据成功");
                    }
                    catch
                    {
                        MessageBox.Show("还原失败，请确保还原项与库对应");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}