using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.BLL
{
    /// <summary>
    /// 绩效考核_期货每日交易汇总大表
    /// </summary>
    public partial class 绩效考核_期货每日交易汇总大表
    {
        private readonly Maticsoft.DAL.绩效考核_期货每日交易汇总大表 dal = new Maticsoft.DAL.绩效考核_期货每日交易汇总大表();
        public 绩效考核_期货每日交易汇总大表()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            return dal.Exists(记录标识);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public long Exists(string 期货代码, string 基金经理, string 产品名称, string 时间)
        {
            return dal.Exists(期货代码, 基金经理, 产品名称, 时间);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_期货每日交易汇总大表 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.绩效考核_期货每日交易汇总大表 model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long 记录标识)
        {

            return dal.Delete(记录标识);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.绩效考核_期货每日交易汇总大表 GetModel(long 记录标识)
        {
            return dal.GetModel(记录标识);
        }
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetDataTable_SelectColumn(string strWhere)
        {
            DataTable tempTable = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 期货代码 as 代码,期货名称 as 名称,卖持量,卖持仓成本,市场现价,合约成本,持仓保证金,当日盈亏,总盈亏 FROM 绩效考核_期货每日交易汇总大表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    tempTable = ds.Tables[0];
                }
            }
            return tempTable;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_期货每日交易汇总大表> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_期货每日交易汇总大表> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.绩效考核_期货每日交易汇总大表> modelList = new List<Maticsoft.Model.绩效考核_期货每日交易汇总大表>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.绩效考核_期货每日交易汇总大表 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.绩效考核_期货每日交易汇总大表();
                    if (dt.Rows[n]["记录标识"] != null && dt.Rows[n]["记录标识"].ToString() != "")
                    {
                        model.记录标识 = long.Parse(dt.Rows[n]["记录标识"].ToString());
                    }
                    if (dt.Rows[n]["产品名称"] != null && dt.Rows[n]["产品名称"].ToString() != "")
                    {
                        model.产品名称 = dt.Rows[n]["产品名称"].ToString();
                    }
                    if (dt.Rows[n]["基金经理"] != null && dt.Rows[n]["基金经理"].ToString() != "")
                    {
                        model.基金经理 = dt.Rows[n]["基金经理"].ToString();
                    }
                    if (dt.Rows[n]["期货代码"] != null && dt.Rows[n]["期货代码"].ToString() != "")
                    {
                        model.期货代码 = dt.Rows[n]["期货代码"].ToString();
                    }
                    if (dt.Rows[n]["期货名称"] != null && dt.Rows[n]["期货名称"].ToString() != "")
                    {
                        model.期货名称 = dt.Rows[n]["期货名称"].ToString();
                    }
                    if (dt.Rows[n]["卖持量"] != null && dt.Rows[n]["卖持量"].ToString() != "")
                    {
                        model.卖持量 = double.Parse(dt.Rows[n]["卖持量"].ToString());
                    }
                    if (dt.Rows[n]["卖持仓成本"] != null && dt.Rows[n]["卖持仓成本"].ToString() != "")
                    {
                        model.卖持仓成本 = double.Parse(dt.Rows[n]["卖持仓成本"].ToString());
                    }
                    if (dt.Rows[n]["市场现价"] != null && dt.Rows[n]["市场现价"].ToString() != "")
                    {
                        model.市场现价 = double.Parse(dt.Rows[n]["市场现价"].ToString());
                    }
                    if (dt.Rows[n]["合约成本"] != null && dt.Rows[n]["合约成本"].ToString() != "")
                    {
                        model.合约成本 = double.Parse(dt.Rows[n]["合约成本"].ToString());
                    }
                    if (dt.Rows[n]["持仓保证金"] != null && dt.Rows[n]["持仓保证金"].ToString() != "")
                    {
                        model.持仓保证金 = double.Parse(dt.Rows[n]["持仓保证金"].ToString());
                    }
                    if (dt.Rows[n]["当日盈亏"] != null && dt.Rows[n]["当日盈亏"].ToString() != "")
                    {
                        model.当日盈亏 = double.Parse(dt.Rows[n]["当日盈亏"].ToString());
                    }
                    if (dt.Rows[n]["总盈亏"] != null && dt.Rows[n]["总盈亏"].ToString() != "")
                    {
                        model.总盈亏 = double.Parse(dt.Rows[n]["总盈亏"].ToString());
                    }
                    if (dt.Rows[n]["时间"] != null && dt.Rows[n]["时间"].ToString() != "")
                    {
                        model.时间 = dt.Rows[n]["时间"].ToString();
                    } 
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }


        #endregion  Method
    }
}

