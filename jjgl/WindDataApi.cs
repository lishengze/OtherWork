using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using DB;
using WAPIWrapperCSharp;

namespace 基金管理
{
    public partial class WindMain
    {
        private WindAPI m_WindAPI = null;
        private bool Wind_Success = false;

        public WindMain()
        {
            InitWindApi();
        }

        public void InitWindApi() 
        {
        if (m_WindAPI == null)
            {
                try
                {
                    m_WindAPI = new WindAPI();
                    int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
                    if (LogRet == 0)
                    {
                        if (!m_WindAPI.isconnected())
                        {
                            MessageBox.Show("Wind软件接口读取失败", "系统提示");
                            //return;
                        }
                        Wind_Success = true;
                    }
                    else
                    {
                        MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
                        // return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
                    //  return;
                }
            }
            else
            {
                if (!Wind_Success)
                {
                    try
                    {
                        int LogRet = (int)m_WindAPI.start("", "", 2000); //2秒没有连接，返回记录
                        if (LogRet == 0)
                        {
                            if (!m_WindAPI.isconnected())
                            {
                                MessageBox.Show("Wind软件接口读取失败", "系统提示");
                                //return;
                            }
                            Wind_Success = true;
                        }
                        else
                        {
                            MessageBox.Show("Wind软件接口读取失败！" + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
                            // return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("登陆失败！该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
                        //  return;
                    }
                }
            }
            if (!Wind_Success) //Wind软件未联通，则弹出提示
            {
                if (MessageBox.Show("Wind软件接入失败，无法计算今日股市的“市场现价”，确定继续吗", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
            } 
            else
            {
                InitAmericanCodeMap();
            }
        }




    }
}