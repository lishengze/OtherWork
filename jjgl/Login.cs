using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace 基金管理
{
    public partial class Login : Form
    {
        private BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器 
        private string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ui.xml";
        public Login()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Login_Paint);
            this.Load += new EventHandler(Login_Load);
            
        }

        void Login_Load(object sender, EventArgs e)
        {
            if(File.Exists(path))
            {
                Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                try
                {
                    Maticsoft.Model.绩效考核_用户信息表 model = (Maticsoft.Model.绩效考核_用户信息表)binFormat.Deserialize(fStream);//反序列化对象
                    if (model != null)
                    {
                        this.checkBox1.Checked = true;
                        this.txt_用户名.Text = model.用户名;
                        this.txt_密码.Text = model.用户密码;

                        fStream.Close();
                        fStream.Dispose();
                    }
                    else
                    {
                        fStream.Close();
                        fStream.Dispose();
                        if (System.IO.File.Exists(path))
                        {
                            //删除文件
                            System.IO.File.Delete(path);
                        }
                    }
                }
                catch (Exception)
                {
                    fStream.Close();
                    fStream.Dispose();
                    if (System.IO.File.Exists(path))
                    {
                        //删除文件
                        System.IO.File.Delete(path);
                    }
                }
               
            }
         
            //throw new NotImplementedException();
        }

        void Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawLine(new Pen(Color.FromArgb(100, 180, 180, 180)), new Point(20, 45), new Point(335, 45));

            //throw new NotImplementedException();
        } 
        private void btn_登录_Click(object sender, EventArgs e)
        {
            this.lbl_Error_用户名.Text = "";
            this.lbl_Error_密码.Text = "";
             
            if (this.txt_用户名.Text.Trim() == "")
            {
                this.lbl_Error_用户名.Text ="用户名不能为空";
                return;
            }
            if (this.txt_密码.Text.Trim() == "")
            {
                this.lbl_Error_密码.Text = "用户密码不能为空";
                return;
            }

            Maticsoft.BLL.绩效考核_用户信息表 modelBLL = new Maticsoft.BLL.绩效考核_用户信息表(); 
            if (modelBLL.Exists(this.txt_用户名.Text.Trim(), this.txt_密码.Text.Trim()))
            {
                 Maticsoft.Model.绩效考核_用户信息表 model  =modelBLL.GetModel(this.txt_用户名.Text.Trim());
                 if (model != null)
                 {
                     MainFrm mainFrm = new MainFrm(model);
                     mainFrm.Show();
                      
                     this.Hide();
                     JLInfo(model);
                 }
            }
            else
            {
                MessageBox.Show("登录失败，不存在该用户名或用户密码输入错误！", "系统提示");
            }
        }

        private void JLInfo(Maticsoft.Model.绩效考核_用户信息表  model)
        {  
            if ((this.checkBox1.Checked))
            {
                using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    binFormat.Serialize(fStream, model);
                }
            }
            else
            {
                if (System.IO.File.Exists(path))
                {
                    //删除文件
                    System.IO.File.Delete(path);
                }
            }
        }

        private void btn_重置_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.txt_密码.Text = "";
            //this.txt_用户名.Text = "";
        }
         
        private void txt_密码_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_登录_Click(null, null);
            }
        }
    }
}
