using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;

using System.Text;
using System.Windows.Forms;
using DB;
using WAPIWrapperCSharp;

namespace 基金管理
{
    public partial class WindMain
    {
        public WindAPI m_WindAPI = null;   // wind api;
        public bool Wind_Success = false;  // 是否连接标记
        public Dictionary<string, HashSet<string>> m_usa_code_map;

        public Dictionary<string, string> m_usa_code_info_map;

        public HashSet<string> m_beijing_code_set; // 存储所有北交所代码;

        private static volatile WindMain instance;
        private static object syncRoot = new Object();

        public static WindMain Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                    if (instance == null) 
                        instance = new WindMain();
                    }
                }

                return instance;
            }
        }

        public void Run() {

        }

        public WindMain()
        {
            Console.WriteLine("初始化WindMain");
            InitWindApi();

            InitAmericanCodeMap();

            InitBeijingCodeMap();
        }

        public void ConnectWind() {
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
                        MessageBox.Show("Wind软件接口读取失败,无法获取美股信息,市价相关信息," + Environment.NewLine + "请检查Wind终端是否打开。错误码" + LogRet.ToString() + "。");
                        // return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("wind 登陆失败, 无法获取美股信息,市价相关信息, 该计算机未安装或未开启Wind软件，或未获取Wind软件授权");
                    //  return;
                }
            }
            else
            {
                ConnectWind();
            }

            if (!Wind_Success) //Wind软件未联通，则弹出提示
            {
                if (MessageBox.Show("Wind软件接入失败，无法计算今日股市的“市场现价”，确定继续吗", "系统提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
            } 
        }

        private void InitBeijingCodeMap() {

            m_beijing_code_set = new HashSet<string>();

            if (Wind_Success) {
                for (int j =0;j < 5; ++j) 
                {
                    string curr_date = DateTime.Now.ToString("yyyy-MM-dd");

                    string req_str = "date=" + curr_date + ";sectorid=1000038551000000";

                    WindData wd = m_WindAPI.wset("sectorconstituent", req_str);

                    int code_len = wd.GetCodeLength();
                    int field_len = wd.GetFieldLength();

                    object[,] data = (object[,])wd.getDataByFunc("wset", false);
                    
                    for (int i = 0; i < code_len; ++i)
                    {
                        string full_code = (string)data[i, 1];

                        string code_description =  (string)data[i, 2];

                        string[] tmp_code_list = full_code.Split('.');

                        string code = tmp_code_list[0].ToUpper();
                        string suffix = tmp_code_list[1].ToUpper();

                        if (!m_beijing_code_set.Contains(suffix))
                        {
                            m_beijing_code_set.Add(code);
                        }
                    }

                    if (m_beijing_code_set.Count > 0) break;

                    Thread.Sleep(500);
                }
            }            
        }

        private void InitAmericanCodeMap() {
            m_usa_code_map = new Dictionary<string, HashSet<string>>();
            m_usa_code_info_map = new Dictionary<string, string>();

            if (Wind_Success) {
                for (int j =0;j < 5; ++j) 
                {
                    string curr_date = DateTime.Now.ToString("yyyy-MM-dd");

                    string req_str = "date=" + curr_date + ";sectorid=1000022276000000";

                    WindData wd = m_WindAPI.wset("sectorconstituent", req_str);

                    int code_len = wd.GetCodeLength();
                    int field_len = wd.GetFieldLength();

                    object[,] data = (object[,])wd.getDataByFunc("wset", false);

                    for (int i = 0; i < code_len; ++i)
                    {
                        string full_code = (string)data[i, 1];

                        string code_description =  (string)data[i, 2];

                        string[] tmp_code_list = full_code.Split('.');

                        string code = tmp_code_list[0].ToUpper();
                        string suffix = tmp_code_list[1].ToUpper();

                        if (!m_usa_code_map.ContainsKey(suffix))
                        {
                            m_usa_code_map.Add(suffix, new HashSet<string>());
                        }

                        m_usa_code_map[suffix].Add(code.ToUpper());

                        if (!m_usa_code_info_map.ContainsKey(full_code)) {
                            m_usa_code_info_map.Add(full_code, code_description);
                        }
                    }

                    if (m_usa_code_map.Count > 0 ||m_usa_code_info_map.Count >0) break;

                    Thread.Sleep(500);
                }
            }

        }
        

        public bool IsAmericanCode(string code) {
            if(m_usa_code_info_map.Count > 0) {
                return m_usa_code_info_map.ContainsKey(code);
            }
            return false;
        }

        public bool IsBeijingCode(string code) {
            if(m_beijing_code_set.Count > 0) {
                return m_beijing_code_set.Contains(code);
            }
            return false;
        }        

        public bool IsChineseCode(string code)
        {
            return code.Length == 6;
        }

        public bool IsHKCode(string code)
        {
            return code.Length == 4;
        }

        public bool IsValidCode(string code) {
            return IsChineseCode(code) || IsHKCode(code) || IsAmericanCode(code);
        }
        public WindData GetNewClosePriceData(string windCodes, string options) {
            InitWindApi();
            return m_WindAPI.wsq(windCodes, "rt_last", options);
        }

        public WindData GetCurrentClosePriceData(string windCodes, string indicators, 
                            string startTime, string endTime, string options) {
            InitWindApi();
            return m_WindAPI.wsd(windCodes, indicators, startTime, endTime, options);          
        }
    }
}