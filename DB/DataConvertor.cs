using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection; 
using System.IO;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace DB
{ 
    public class DataConvertor
    {
        public static Maticsoft.Model.绩效考核_用户信息表 Pub_登录用户信息;

        public static string Pub_超级管理员用户名 = "admin";

        /// <summary>
        /// 获取每年的最后一个交易日
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string Get最后一个交易日时间(int year)
        {
            string 最后一个交易日时间 = string.Format("{0}/12/31", year);
            return 最后一个交易日时间;
        }


        public static Dictionary<string, List<string>> GetDictionary_产品_基金经理()
        {
            #region 获取产品-基金经理对应关系

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList1 = modelBLL1.GetModelList("");
            Dictionary<string, List<string>> DIC_产品_基金经理List = new Dictionary<string, List<string>>();
            foreach (Maticsoft.Model.绩效考核_基金经理信息表 model in modelList1)
            {
                if (model.管理产品 != null && model.管理产品 != "")
                {
                    string[] 管理产品Array = model.管理产品.Split(new char[] { ',' });
                    foreach (string temp管理产品 in 管理产品Array)
                    {
                        if (temp管理产品 == "") continue;
                        if (DIC_产品_基金经理List.ContainsKey(temp管理产品))
                        {
                            if (!DIC_产品_基金经理List[temp管理产品].Contains(model.基金经理))
                            {
                                DIC_产品_基金经理List[temp管理产品].Add(model.基金经理);
                            }
                        }
                        else
                        {
                            DIC_产品_基金经理List.Add(temp管理产品, new List<string>() { model.基金经理 });
                        }
                    }
                }
            }
            return DIC_产品_基金经理List;
            #endregion
        }


        public static double Get_本年净值贡献(string 产品名称, string 基金经理, string 计算期间_起始时间,string 当前时间,string 基准日_时间,
            List<Maticsoft.Model.绩效考核_申购赎回调整历史表> 申购赎回调整历史表_modelList, double 基金产品_基金份额)  
        {
            double 本年净值贡献 = 0;
            Maticsoft.BLL.绩效考核_股票每日交易汇总大表 modelBLL_大表股票 = new Maticsoft.BLL.绩效考核_股票每日交易汇总大表();

            double 计算期间总买卖盈亏 = modelBLL_大表股票.Get_期间买卖总盈亏(产品名称, 基金经理, 计算期间_起始时间, 当前时间);
            double 当天总浮动盈亏 = modelBLL_大表股票.Get_期间总浮盈浮亏(产品名称, 基金经理, 当前时间, 当前时间);
            double 基准日前一日总浮动盈亏 = modelBLL_大表股票.Get_期间总浮盈浮亏(产品名称, 基金经理, 基准日_时间, 基准日_时间);
            double 申购赎回调整数 = 0;
            foreach (Maticsoft.Model.绩效考核_申购赎回调整历史表 TempModel in 申购赎回调整历史表_modelList)
            {
                if (TempModel.产品名称 == 产品名称 && TempModel.基金经理 == 基金经理)
                {
                    申购赎回调整数 = 申购赎回调整数 + TempModel.申购赎回调整数;
                }
            }
            
            if (基金产品_基金份额 != 0)
                本年净值贡献 = (当天总浮动盈亏 - 基准日前一日总浮动盈亏 + 计算期间总买卖盈亏 - 申购赎回调整数) / 基金产品_基金份额;

        /// if (产品名称 == "管理中心")
        /// {
        /// }
            return 本年净值贡献;
        }

        /// <summary>
        /// 获取某一年（如2015年）的基准日净值字典
        /// 键：产品名称；值：基准日净值；
        /// 规则：（1）上一年最后一个交易日出现的基金产品，取其单位净值作为基准日净值，
        ///       （2）今年最新出现的基金产品取其出现那一天的单位净值作为基准日净值；
        /// 异常情况：由于默认判断一年的12月31号为一年的最后一个交易日，如果判断失败，则直接返回空；
        /// </summary>
        /// <returns></returns>
        public static void Get基准日净值_ByYear(int year, List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList)
        {
            Maticsoft.BLL.绩效考核_基金产品每日统计 modelBLL = new Maticsoft.BLL.绩效考核_基金产品每日统计();
            string 上一年最后一个交易日 = DataConvertor.Get最后一个交易日时间(year - 1);
            List<Maticsoft.Model.绩效考核_基金产品每日统计> tempModelList = modelBLL.GetModelList(string.Format(" where 时间= '{0}'", 上一年最后一个交易日));

            //Dictionary<string, double> DIC = new Dictionary<string, double>();
            string sql = "";

        }
        public static Dictionary<string, double> Get_某时间点前的基金份额(string currentDayDate)
        { 
            Maticsoft.BLL.绩效考核_基金份额历史表 基金份额历史表_BLL = new Maticsoft.BLL.绩效考核_基金份额历史表();
            List<Maticsoft.Model.绩效考核_基金份额历史表> 基金份额历史_List = 基金份额历史表_BLL.GetModelList(string.Format("修改时间 <='{0}' order by 修改时间 desc", currentDayDate));
            Dictionary<string, double> DIC_基金份额历史 = new Dictionary<string, double>();
            foreach (Maticsoft.Model.绩效考核_基金份额历史表 tempModel in 基金份额历史_List)
            {
                if (!DIC_基金份额历史.ContainsKey(tempModel.产品名称))
                    DIC_基金份额历史.Add(tempModel.产品名称, tempModel.基金份额);
            }
            return DIC_基金份额历史; 
        }

        public static Dictionary<string, double> Get_最新的基金份额()
        {
            Maticsoft.BLL.绩效考核_基金份额历史表 基金份额历史表_BLL = new Maticsoft.BLL.绩效考核_基金份额历史表();
            List<Maticsoft.Model.绩效考核_基金份额历史表> 基金份额历史_List = 基金份额历史表_BLL.GetModelList(" 1=1 order by 修改时间 desc");
            Dictionary<string, double> DIC_基金份额历史 = new Dictionary<string, double>();
            foreach (Maticsoft.Model.绩效考核_基金份额历史表 tempModel in 基金份额历史_List)
            {
                if (!DIC_基金份额历史.ContainsKey(tempModel.产品名称))
                    DIC_基金份额历史.Add(tempModel.产品名称, tempModel.基金份额);
            }
            return DIC_基金份额历史;
        }

        public static Dictionary<string, double> Get_最新的赎回份额()
        {
            Maticsoft.BLL.绩效考核_申购赎回调整历史表 基金份额历史表_BLL = new Maticsoft.BLL.绩效考核_申购赎回调整历史表();
            List<Maticsoft.Model.绩效考核_申购赎回调整历史表> 申购赎回调整_List = 基金份额历史表_BLL.GetModelList(" 1=1 order by 修改时间 desc");
            Dictionary<string, double> DIC_基金份额历史 = new Dictionary<string, double>();
            foreach (Maticsoft.Model.绩效考核_申购赎回调整历史表 tempModel in 申购赎回调整_List)
            {
                if (!DIC_基金份额历史.ContainsKey(tempModel.产品名称))
                    DIC_基金份额历史.Add(tempModel.产品名称, tempModel.申购赎回调整数);
            }
            return DIC_基金份额历史;
        }

        public static double Get_今年最大净值(double 历史上今年最大净值, double 今日_单位净值, double 基准日净值)
        {
            double 今年最大净值 = Math.Max(历史上今年最大净值, 今日_单位净值);
            今年最大净值 = Math.Max(今年最大净值, 基准日净值);
            return 今年最大净值;
        }
        public static Dictionary<string, string> Get不计算税费集合()
        {
            //键：代码；值：名称
            Dictionary<string, string> 不计算税费集合_DIC = new Dictionary<string, string>();

            #region 现金替代物
            Maticsoft.BLL.绩效考核_现金替代物信息表 modelBLL_现金替代物信息表 = new Maticsoft.BLL.绩效考核_现金替代物信息表();
            List<Maticsoft.Model.绩效考核_现金替代物信息表> modelList_现金替代物信息表 = modelBLL_现金替代物信息表.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_现金替代物信息表 model1 in modelList_现金替代物信息表)
            {
                if (model1.现金替代物代码 != "" && model1.现金替代物名称 != "")
                {
                    if (!不计算税费集合_DIC.ContainsKey(model1.现金替代物代码))
                    {
                        不计算税费集合_DIC.Add(model1.现金替代物代码, model1.现金替代物名称);
                    }
                }
            }
            #endregion

            #region 未上市股票
            Maticsoft.BLL.绩效考核_未上市股票信息表 modelBLL_未上市股票 = new Maticsoft.BLL.绩效考核_未上市股票信息表();
            List<Maticsoft.Model.绩效考核_未上市股票信息表> modelList_未上市股票 = modelBLL_未上市股票.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_未上市股票信息表 model1 in modelList_未上市股票)
            {
                if (model1.股票代码 != "" && model1.股票名称 != "")
                {
                    if (!不计算税费集合_DIC.ContainsKey(model1.股票代码))
                    {
                        不计算税费集合_DIC.Add(model1.股票代码, model1.股票名称);
                    }
                }
            }
            #endregion

            return 不计算税费集合_DIC;
        }

        public static string Get标准化股票代码(string temp股票代码, string 股票名称, Dictionary<string, string> DockCodeName_DIC)
        {
            string 股票代码 = string.Empty;
            if (temp股票代码.Contains("HK"))
            {
                if (temp股票代码.Length >= 6)
                {
                    股票代码 = temp股票代码.Substring(2, 4);
                }
            }
            else
            {
                if (temp股票代码.Length == 6)
                {
                    股票代码 = temp股票代码;
                }
                else if (temp股票代码.Length == 4)
                {
                    if (DockCodeName_DIC.ContainsKey(temp股票代码))
                    {
                        if (DockCodeName_DIC[temp股票代码] == 股票名称)
                        {
                            股票代码 = temp股票代码;
                        }
                        else
                        {
                            股票代码 = "00" + temp股票代码;
                        }
                    }
                    else
                        股票代码 = "00" + temp股票代码;
                }
                else if (temp股票代码.Length == 5)
                {
                    股票代码 = "0" + temp股票代码;
                }
                else if (temp股票代码.Length < 4)//小于4的情况
                {
                    string ZeroStringArray = string.Empty; //增加若干个零
                    for (int j = 0; j < 6 - temp股票代码.Length; j++)
                    {
                        ZeroStringArray += "0";
                    }
                    string temp股票代码_6位 = ZeroStringArray + temp股票代码;
                    ZeroStringArray = string.Empty;
                    for (int j = 0; j < 4 - temp股票代码.Length; j++)
                    {
                        ZeroStringArray += "0";
                    }
                    string temp股票代码_4位 = ZeroStringArray + temp股票代码;

                    if (DockCodeName_DIC.ContainsKey(temp股票代码_4位))
                    {
                        if (DockCodeName_DIC[temp股票代码_4位] == 股票名称) //设置四位数和港股一致时，
                            股票代码 = temp股票代码_4位;
                        else
                            股票代码 = temp股票代码_6位;
                    }
                    else
                        股票代码 = temp股票代码_6位;
                }
            }  // if (row[0] != null && row[0].ToString() != "") 
            return 股票代码;
        }

        /// <summary>
        /// 获取股票、未上市股票、现金替代物列表
        /// </summary>
        /// <returns></returns>
        public static List<Maticsoft.Model.绩效考核_股票信息表> Get所有股票List()
        {
            Maticsoft.BLL.绩效考核_股票信息表 股票ModelBLL = new Maticsoft.BLL.绩效考核_股票信息表();
            Maticsoft.BLL.绩效考核_现金替代物信息表 现金替代物ModelBLL = new Maticsoft.BLL.绩效考核_现金替代物信息表();
            Maticsoft.BLL.绩效考核_未上市股票信息表 未上市股票ModelBLL = new Maticsoft.BLL.绩效考核_未上市股票信息表();

            List<Maticsoft.Model.绩效考核_股票信息表> 股票modelList = 股票ModelBLL.GetModelList("");
            List<Maticsoft.Model.绩效考核_现金替代物信息表> 现金替代物ModelList = 现金替代物ModelBLL.GetModelList("");
            List<Maticsoft.Model.绩效考核_未上市股票信息表> 未上市股票ModelList = 未上市股票ModelBLL.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_现金替代物信息表 model in 现金替代物ModelList)
            {
                股票modelList.Add(new Maticsoft.Model.绩效考核_股票信息表(model.现金替代物代码, model.现金替代物名称));
            }
            foreach (Maticsoft.Model.绩效考核_未上市股票信息表 model1 in 未上市股票ModelList)
            {
                股票modelList.Add(new Maticsoft.Model.绩效考核_股票信息表(model1.股票代码, model1.股票名称));
            }
            return 股票modelList;
        }
        /// <summary>
        /// 获取股票代码、股票名称字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> DIC_股票代码_股票名称()
        {
            Dictionary<string, string> DockCodeName_DIC = new Dictionary<string, string>();
            Maticsoft.BLL.绩效考核_股票信息表 modelBLL1 = new Maticsoft.BLL.绩效考核_股票信息表();
            List<Maticsoft.Model.绩效考核_股票信息表> modelList1 = modelBLL1.GetModelList("");
            foreach (Maticsoft.Model.绩效考核_股票信息表 model in modelList1)
            {
                if (!DockCodeName_DIC.ContainsKey(model.股票代码.Trim()))
                {
                    DockCodeName_DIC.Add(model.股票代码.Trim(), model.股票名称.Trim());
                }
            }
            return DockCodeName_DIC;
        }

        /// <summary>
        /// 基金产品_基金经理字典；
        /// 键为“基金产品”，值为“基金经理列表”，
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<string>> DIC_基金产品_基金经理列表()
        {
            Dictionary<string, List<string>> 基金产品_基金经理列表_DIC = new Dictionary<string, List<string>>();

            Maticsoft.BLL.绩效考核_基金经理信息表 modelBLL_基金经理信息表 = new Maticsoft.BLL.绩效考核_基金经理信息表();
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList0 = modelBLL_基金经理信息表.GetModelList("");
            List<Maticsoft.Model.绩效考核_基金经理信息表> new_modelList0 = new List<Maticsoft.Model.绩效考核_基金经理信息表>();
            foreach (Maticsoft.Model.绩效考核_基金经理信息表 tempModel in modelList0)
            {
                string[] 管理产品Array = tempModel.管理产品.Split(new char[] { ',' });
                for (int i = 0; i < 管理产品Array.Length; i++)
                {
                    if (管理产品Array[i] != "")
                    {
                        new_modelList0.Add(new Maticsoft.Model.绩效考核_基金经理信息表(tempModel.基金经理, 管理产品Array[i]));
                    }
                }
            }
            foreach (Maticsoft.Model.绩效考核_基金经理信息表 tempModel in new_modelList0)
            {
                if (!基金产品_基金经理列表_DIC.ContainsKey(tempModel.管理产品))
                {
                    基金产品_基金经理列表_DIC.Add(tempModel.管理产品, new List<string>() { tempModel.基金经理 });
                }
                else
                {
                    List<string> 基金经理列表 = 基金产品_基金经理列表_DIC[tempModel.管理产品];
                    if (!基金经理列表.Contains(tempModel.基金经理))
                    {
                        基金经理列表.Add(tempModel.基金经理);
                    }
                }
            }
            return 基金产品_基金经理列表_DIC;
        }
 
        public static DateTime GetDateTimeFromFormateString(string dateTime)
        {
            DateTime dt = DateTime.Now;
            bool flag = DateTime.TryParse(dateTime, out dt);
            if (flag)
            {
                return dt;
            }
            string[] strArray = dateTime.Split(new char[] { ',' });
            if (strArray.Length >= 3)
            {
                int year = 0;
                int month = 0;
                int day = 0;
                int.TryParse(strArray[0], out year);
                int.TryParse(strArray[1], out month);
                int.TryParse(strArray[2], out day);
                if (year > 2000 && month > 0 && month <= 12 && day > 0 && day <= 31)
                {
                    dt = new DateTime(year, month, day);
                }
            }
            return dt;
        } 

    }
}
