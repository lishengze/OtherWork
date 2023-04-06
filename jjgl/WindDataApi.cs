using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using DB;
using WAPIWrapperCSharp;

namespace �������
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
                    int LogRet = (int)m_WindAPI.start("", "", 2000); //2��û�����ӣ����ؼ�¼
                    if (LogRet == 0)
                    {
                        if (!m_WindAPI.isconnected())
                        {
                            MessageBox.Show("Wind����ӿڶ�ȡʧ��", "ϵͳ��ʾ");
                            //return;
                        }
                        Wind_Success = true;
                    }
                    else
                    {
                        MessageBox.Show("Wind����ӿڶ�ȡʧ�ܣ�" + Environment.NewLine + "����Wind�ն��Ƿ�򿪡�������" + LogRet.ToString() + "��");
                        // return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("��½ʧ�ܣ��ü����δ��װ��δ����Wind�������δ��ȡWind�����Ȩ");
                    //  return;
                }
            }
            else
            {
                if (!Wind_Success)
                {
                    try
                    {
                        int LogRet = (int)m_WindAPI.start("", "", 2000); //2��û�����ӣ����ؼ�¼
                        if (LogRet == 0)
                        {
                            if (!m_WindAPI.isconnected())
                            {
                                MessageBox.Show("Wind����ӿڶ�ȡʧ��", "ϵͳ��ʾ");
                                //return;
                            }
                            Wind_Success = true;
                        }
                        else
                        {
                            MessageBox.Show("Wind����ӿڶ�ȡʧ�ܣ�" + Environment.NewLine + "����Wind�ն��Ƿ�򿪡�������" + LogRet.ToString() + "��");
                            // return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("��½ʧ�ܣ��ü����δ��װ��δ����Wind�������δ��ȡWind�����Ȩ");
                        //  return;
                    }
                }
            }
            if (!Wind_Success) //Wind���δ��ͨ���򵯳���ʾ
            {
                if (MessageBox.Show("Wind�������ʧ�ܣ��޷�������չ��еġ��г��ּۡ���ȷ��������", "ϵͳ��ʾ",
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