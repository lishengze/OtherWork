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
	/// 临时缓存区_绩效考核_股票每日交易汇总大表
	/// </summary>
	public partial class 临时缓存区_绩效考核_股票每日交易汇总大表
	{
		private readonly Maticsoft.DAL.临时缓存区_绩效考核_股票每日交易汇总大表 dal=new Maticsoft.DAL.临时缓存区_绩效考核_股票每日交易汇总大表();
		public 临时缓存区_绩效考核_股票每日交易汇总大表()
		{}
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
        public long Exists(string 股票代码, string 基金经理, string 产品名称, string 时间)
        {
            return dal.Exists(股票代码,   基金经理,   产品名称,  时间);
        } 
         
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model)
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string 记录标识list )
		{
			return dal.DeleteList(记录标识list );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_股票每日交易汇总大表 GetModel(long 记录标识)
		{ 
			return dal.GetModel(记录标识);
		}


        /// <summary>
		/// 得到一个对象实体--用户Excel格式数据输出
		/// </summary>
        public DataTable GetOutPutTable(string strWhere)
		{
            DataTable table = null;
            string sql = "select 股票代码 as 代码, 股票名称 as 名称, 基金经理, 持股数量, 持股成本,市场现价, 投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,本年净值贡献='',当日盈亏  from 临时缓存区_绩效考核_股票每日交易汇总大表 where " + strWhere;
		   
			Maticsoft.Model.绩效考核_股票每日交易汇总大表 model=new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
            DataSet ds = DbHelperSQL.Query(sql);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                    table = ds.Tables[0];
            } 
            return table; 

		}


        /// <summary>
        /// 获取 统计信息
		/// </summary>
        public DataTable Get_统计信息(string 产品名称, string 基金经理, string startTime, string endTime)
        {
            string sql = string.Empty;
            if(基金经理=="全部")
                sql = string.Format("SELECT  股票代码,股票名称, MAX(投资成本) as 最大投资金额, SUM(当日盈亏) as 实现盈亏 FROM 临时缓存区_绩效考核_股票每日交易汇总大表 " +
                                    " where 产品名称 = '{0}' and 时间 between '{1}' and '{2}' group by 股票代码,股票名称", 产品名称, startTime, endTime);
            else
                sql = string.Format("SELECT  股票代码,股票名称, MAX(投资成本) as 最大投资金额, SUM(当日盈亏) as 实现盈亏 FROM 临时缓存区_绩效考核_股票每日交易汇总大表 " +
                                   " where 产品名称 = '{0}' and 基金经理='{1}' and 时间 between '{2}' and '{3}' group by  股票代码,股票名称", 产品名称, 基金经理, startTime, endTime);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                   return  ds.Tables[0];
                }
            }
            return null; 
        }
         
         
        /// <summary>
        ///  获取两个时间段内所有记录 （当日盈亏1 + 当日盈亏2 + 。。。）
		/// </summary>
        public double Get_期间买卖总盈亏(string 产品名称, string  基金经理,string startTime, string endTime)
        {
            double 期间买卖总盈亏 = 0;
            string sql = string.Format("SELECT  SUM(当日盈亏)  FROM 临时缓存区_绩效考核_股票每日交易汇总大表 where 产品名称= '{0}' and 基金经理= '{1}' and 时间 between '{2}' and '{3}' ", 产品名称,基金经理, startTime, endTime);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                double.TryParse(obj.ToString(), out 期间买卖总盈亏); 
            }
            return 期间买卖总盈亏; 
        } 
        /// <summary>
        ///  获取两个时间段内所有记录 （浮盈浮亏1 + 浮盈浮亏2 + 。。。）
		/// </summary>
        public double Get_期间总浮盈浮亏(string 产品名称, string 基金经理, string startTime, string endTime)
        {
            double 期间总浮盈浮亏 = 0;
            string sql = string.Format("SELECT  SUM(浮盈浮亏)  FROM 临时缓存区_绩效考核_股票每日交易汇总大表 where 产品名称= '{0}' and 基金经理= '{1}' and 时间 between '{2}' and '{3}' ", 产品名称, 基金经理, startTime, endTime);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                double.TryParse(obj.ToString(), out 期间总浮盈浮亏); 
            }
            return 期间总浮盈浮亏;

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
        public DataSet GetList_SelectColumn(string strWhere)
        { 
            DataSet dataSet = new DataSet();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 时间,产品名称,股票代码,股票名称,基金经理,持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,当日盈亏 FROM 临时缓存区_绩效考核_股票每日交易汇总大表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        } 

	 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByTwoTable(string strWhere)
        { 
            string sql = string.Format("select t1.*,t2.本年净值贡献 from (select *  FROM 临时缓存区_绩效考核_股票每日交易汇总大表  where {0}) t1  left join 绩效考核_基金经理净值贡献表 t2  on t1.基金经理= t2.基金经理 and t1.产品名称= t2.基金产品 and t1.时间= t2.时间  order by 股票名称, 投资成本 desc ", strWhere);
            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 证券交易查询==New
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByTwoTable_证券交易查询(string startTime,string endTime,string 产品名称 )
        { 
            string subSql = "时间,产品名称,基金经理,股票代码,股票名称,持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,当日盈亏 ";
            string sql1 = "select t1.*,t2.今日买入股,t2.今日卖出股,t2.买入清算金额,t2.卖出清算金额 from " +
                        "(select {0} from 临时缓存区_绩效考核_股票每日交易汇总大表 where 时间 between '{1}' and  '{2}' and 产品名称 ='{3}') t1 left join  绩效考核_股票每日交易汇总小表 t2 " +
                        "on t1.时间 = t2.时间 and t1.产品名称= t2.产品名称 and t1.基金经理 =t2.基金经理 and t1.股票代码 =t2.股票代码 ";
            string sql = string.Format(sql1,subSql, startTime, endTime, 产品名称);
            return DbHelperSQL.Query(sql);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_股票每日交易汇总大表> modelList = new List<Maticsoft.Model.绩效考核_股票每日交易汇总大表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_股票每日交易汇总大表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
					if(dt.Rows[n]["记录标识"]!=null && dt.Rows[n]["记录标识"].ToString()!="")
					{
						model.记录标识=long.Parse(dt.Rows[n]["记录标识"].ToString());
					}
					if(dt.Rows[n]["产品名称"]!=null && dt.Rows[n]["产品名称"].ToString()!="")
					{
					model.产品名称=dt.Rows[n]["产品名称"].ToString();
					}
					if(dt.Rows[n]["基金经理"]!=null && dt.Rows[n]["基金经理"].ToString()!="")
					{
					model.基金经理=dt.Rows[n]["基金经理"].ToString();
					}
					if(dt.Rows[n]["股票代码"]!=null && dt.Rows[n]["股票代码"].ToString()!="")
					{
					model.股票代码=dt.Rows[n]["股票代码"].ToString();
					}
					if(dt.Rows[n]["股票名称"]!=null && dt.Rows[n]["股票名称"].ToString()!="")
					{
					model.股票名称=dt.Rows[n]["股票名称"].ToString();
					}
					if(dt.Rows[n]["持股数量"]!=null && dt.Rows[n]["持股数量"].ToString()!="")
					{
                        model.持股数量 = double.Parse(dt.Rows[n]["持股数量"].ToString());
					}
					if(dt.Rows[n]["持股成本"]!=null && dt.Rows[n]["持股成本"].ToString()!="")
					{
						model.持股成本=double.Parse(dt.Rows[n]["持股成本"].ToString());
					}
					if(dt.Rows[n]["市场现价"]!=null && dt.Rows[n]["市场现价"].ToString()!="")
					{
						model.市场现价=double.Parse(dt.Rows[n]["市场现价"].ToString());
					}
					if(dt.Rows[n]["投资成本"]!=null && dt.Rows[n]["投资成本"].ToString()!="")
					{
						model.投资成本=double.Parse(dt.Rows[n]["投资成本"].ToString());
					}
					if(dt.Rows[n]["今日市值"]!=null && dt.Rows[n]["今日市值"].ToString()!="")
					{
						model.今日市值=double.Parse(dt.Rows[n]["今日市值"].ToString());
					}
					if(dt.Rows[n]["浮盈浮亏"]!=null && dt.Rows[n]["浮盈浮亏"].ToString()!="")
					{
						model.浮盈浮亏=double.Parse(dt.Rows[n]["浮盈浮亏"].ToString());
					}
					if(dt.Rows[n]["投资成本占比"]!=null && dt.Rows[n]["投资成本占比"].ToString()!="")
					{
                        double 投资成本占比 = 0;
                        double.TryParse(dt.Rows[n]["投资成本占比"].ToString(),out 投资成本占比);
                        model.投资成本占比 = 投资成本占比;
					}
					if(dt.Rows[n]["市值占比"]!=null && dt.Rows[n]["市值占比"].ToString()!="")
                    {
                        double 市值占比 = 0;
                        double.TryParse(dt.Rows[n]["市值占比"].ToString(), out 市值占比);
                        model.市值占比 = 市值占比;  
					}
					if(dt.Rows[n]["浮盈浮亏率"]!=null && dt.Rows[n]["浮盈浮亏率"].ToString()!="")
                    {
                        double 浮盈浮亏率 = 0;
                        double.TryParse(dt.Rows[n]["浮盈浮亏率"].ToString(), out 浮盈浮亏率);
                        model.浮盈浮亏率 = 浮盈浮亏率;  
					}
					if(dt.Rows[n]["当日盈亏"]!=null && dt.Rows[n]["当日盈亏"].ToString()!="")
					{
						model.当日盈亏=double.Parse(dt.Rows[n]["当日盈亏"].ToString());
					}
					if(dt.Rows[n]["时间"]!=null && dt.Rows[n]["时间"].ToString()!="")
					{
                        model.时间 = dt.Rows[n]["时间"].ToString();
                    }
                    if (dt.Rows[n]["买卖累计盈亏"] != null && dt.Rows[n]["买卖累计盈亏"].ToString() != "")
                    {
                        model.买卖累计盈亏 = double.Parse(dt.Rows[n]["买卖累计盈亏"].ToString());
                    } 
                    if (dt.Rows[n]["今日均价"] != null && dt.Rows[n]["今日均价"].ToString() != "")
                    {
                        model.今日均价 = double.Parse(dt.Rows[n]["今日均价"].ToString());
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

