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
    public partial class frmAppend : Form
    {
        public frmAppend()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("注意：信息不完整！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                using (SqlConnection con = new SqlConnection("server=.;pwd=" + strpwd + ";uid=" + struser + ";database=master"))
                {
                    try
                    {
                        string[] getInfo = new string[2];
                        string mdfpath = textBox1.Text.Trim();//mdf路径
                        string DataName = mdfpath.Substring(mdfpath.LastIndexOf("\\")+1,mdfpath.Length-mdfpath.LastIndexOf("\\")-1);
                        DataName = DataName.Remove(DataName.LastIndexOf("_"));
                        string logName =mdfpath.Remove(mdfpath.LastIndexOf("\\"))+"\\"+DataName + "_log.ldf";
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("sp_attach_db @dbname='" + DataName + "',");
                        sb.Append("@filename1='" + mdfpath + "'");
                        if (System.IO.File.Exists(logName))
                        {
                            sb.Append(",@filename2='" + logName + "'");
                        }
                        else
                        {
                            MessageBox.Show("注意：缺少必备的log文件！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        cmd.CommandText = sb.ToString();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("提示：附加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        getInfo[0] = mdfpath.Substring(mdfpath.LastIndexOf("\\") + 1, mdfpath.Length - mdfpath.LastIndexOf("\\") - 1);
                        getInfo[1] = mdfpath;
                        ListViewItem lvi = new ListViewItem(getInfo, "info");
                        listView1.Items.Add(lvi);
                    }
                    catch (Exception ety)
                    {
                        MessageBox.Show(ety.Message);
                    }

                }
            }
        }

        private void frmAppend_Load(object sender, EventArgs e)
        {

        }
    }
}