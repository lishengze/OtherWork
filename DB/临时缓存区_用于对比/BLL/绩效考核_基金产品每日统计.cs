using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using Maticsoft.DBUtility;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 临时缓存区_绩效考核_基金产品每日统计
	/// </summary>
	public partial class 临时缓存区_绩效考核_基金产品每日统计
	{
		private readonly Maticsoft.DAL.临时缓存区_绩效考核_基金产品每日统计 dal=new Maticsoft.DAL.临时缓存区_绩效考核_基金产品每日统计();
        public 临时缓存区_绩效考核_基金产品每日统计()
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
        public long Exists( string 产品名称, string 时间)
        {
            return dal.Exists( 产品名称, 时间);
        } 

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
			return dal.Update(model);
		}
        
        	/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdatePatial(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
			return dal.UpdatePatial(model);
		}


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePatial2(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        {
            return dal.UpdatePatial2(model);
        }

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePatial_期货资产(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 临时缓存区_绩效考核_基金产品每日统计 set ");
            strSql.Append("期货资产总额=@期货资产总额,");
            strSql.Append("期货资金余额=@期货资金余额,"); 
            strSql.Append("期货今年收益率=@期货今年收益率");
            strSql.Append(" where 时间=@时间 and 产品名称=@产品名称");
        
            SqlParameter[] parameters = { 
					new SqlParameter("@期货资产总额", SqlDbType.Float,8),
					new SqlParameter("@期货资金余额", SqlDbType.Float,8), 
					new SqlParameter("@期货今年收益率", SqlDbType.Float,8), 
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100) };

            parameters[0].Value = model.期货资产总额;
            parameters[1].Value = model.期货资金余额;
            parameters[2].Value = model.期货今年收益率;
            parameters[3].Value = model.时间;
            parameters[4].Value = model.产品名称;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePatial3(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        {
            return dal.UpdatePatial3(model);
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
		public Maticsoft.Model.绩效考核_基金产品每日统计 GetModel(long 记录标识)
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
        /// 获得数据列表-有限的列
        /// </summary>
        public DataSet GetList_SelectColumn(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 时间,产品名称,资产总额 as 总资产,单位净值,资金资产比例 FROM 临时缓存区_绩效考核_基金产品每日统计 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            } 

            return DbHelperSQL.Query(strSql.ToString());
        }
		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品每日统计> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
		/// 获得上一个交易日数据
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品每日统计> GetModelList_上一个交易日(string 今日时间)
		{
            string sql = string.Format("select distinct(时间) from 临时缓存区_绩效考核_基金产品每日统计 where 时间 < '{0}' order by 时间 desc", 今日时间);
            DataSet ds =DbHelperSQL.Query(sql);
              string 时间 =string.Empty;
            if(ds!=null)
            {
                if(ds.Tables.Count>0)
                {
                    if(ds.Tables[0].Rows.Count>0)
                        时间 = ds.Tables[0].Rows[0]["时间"].ToString(); 
                }
            }
            if(时间!="")
            {
                DataSet ds1 = dal.GetList(string.Format(" 时间 = '{0}'",时间));
                return DataTableToList(ds1.Tables[0]); 
            }
            return new List<Maticsoft.Model.绩效考核_基金产品每日统计>(); 
		} 
         

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品每日统计> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_基金产品每日统计 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_基金产品每日统计();
					if(dt.Rows[n]["记录标识"]!=null && dt.Rows[n]["记录标识"].ToString()!="")
					{
						model.记录标识=long.Parse(dt.Rows[n]["记录标识"].ToString());
					}
					if(dt.Rows[n]["产品名称"]!=null && dt.Rows[n]["产品名称"].ToString()!="")
					{
					model.产品名称=dt.Rows[n]["产品名称"].ToString();
					}
					if(dt.Rows[n]["资产总额"]!=null && dt.Rows[n]["资产总额"].ToString()!="")
					{
						model.资产总额=double.Parse(dt.Rows[n]["资产总额"].ToString());
					}
					if(dt.Rows[n]["资金余额"]!=null && dt.Rows[n]["资金余额"].ToString()!="")
					{
						model.资金余额=double.Parse(dt.Rows[n]["资金余额"].ToString());
					}
					if(dt.Rows[n]["资金资产比例"]!=null && dt.Rows[n]["资金资产比例"].ToString()!="")
					{
                        model.资金资产比例 = dt.Rows[n]["资金资产比例"].ToString();
					}
					if(dt.Rows[n]["今年收益率"]!=null && dt.Rows[n]["今年收益率"].ToString()!="")
					{
                        model.今年收益率 = dt.Rows[n]["今年收益率"].ToString();
					}
					if(dt.Rows[n]["单位净值"]!=null && dt.Rows[n]["单位净值"].ToString()!="")
					{
						model.单位净值=double.Parse(dt.Rows[n]["单位净值"].ToString());
					}

                    if (dt.Rows[n]["今年最大净值"] != null && dt.Rows[n]["今年最大净值"].ToString() != "")
                    {
                        model.今年最大净值 = double.Parse(dt.Rows[n]["今年最大净值"].ToString());
                    }
                    if (dt.Rows[n]["回撤率"] != null && dt.Rows[n]["回撤率"].ToString() != "")
                    {
                        model.回撤率 = dt.Rows[n]["回撤率"].ToString();
                    }  
					if(dt.Rows[n]["时间"]!=null && dt.Rows[n]["时间"].ToString()!="")
					{
						model.时间=dt.Rows[n]["时间"].ToString();
					} 
                    if (dt.Rows[n]["基金份额"] != null && dt.Rows[n]["基金份额"].ToString() != "")
                    {
                        model.基金份额 = double.Parse(dt.Rows[n]["基金份额"].ToString());
                    }
                    if (dt.Rows[n]["基准日净值"] != null && dt.Rows[n]["基准日净值"].ToString() != "")
                    {
                        model.基准日净值 = double.Parse(dt.Rows[n]["基准日净值"].ToString());
                    }
                    if (dt.Rows[n]["申购赎回调整数"] != null && dt.Rows[n]["申购赎回调整数"].ToString() != "")
                    {
                        model.申购赎回调整数 = double.Parse(dt.Rows[n]["申购赎回调整数"].ToString());
                    }
                    if (dt.Rows[n]["股票资产总额"] != null && dt.Rows[n]["股票资产总额"].ToString() != "")
                    {
                        model.股票资产总额 = double.Parse(dt.Rows[n]["股票资产总额"].ToString());
                    }
                    if (dt.Rows[n]["期货资产总额"] != null && dt.Rows[n]["期货资产总额"].ToString() != "")
                    {
                        model.期货资产总额 = double.Parse(dt.Rows[n]["期货资产总额"].ToString());
                    }
                    if (dt.Rows[n]["期货资金余额"] != null && dt.Rows[n]["期货资金余额"].ToString() != "")
                    {
                        model.期货资金余额 = double.Parse(dt.Rows[n]["期货资金余额"].ToString());
                    }
                    if (dt.Rows[n]["期货今年收益率"] != null && dt.Rows[n]["期货今年收益率"].ToString() != "")
                    {
                        model.期货今年收益率 = double.Parse(dt.Rows[n]["期货今年收益率"].ToString());
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

