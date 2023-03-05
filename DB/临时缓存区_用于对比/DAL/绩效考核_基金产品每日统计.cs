using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:临时缓存区_绩效考核_基金产品每日统计
	/// </summary>
	public partial class 临时缓存区_绩效考核_基金产品每日统计
	{
        public 临时缓存区_绩效考核_基金产品每日统计()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long 记录标识)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 临时缓存区_绩效考核_基金产品每日统计");
			strSql.Append(" where 记录标识=@记录标识 ");
			SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
			parameters[0].Value = 记录标识;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 是否存在该记录,返回记录的标识
        /// </summary>
        public long Exists(string 产品名称, string 开始时间)
        {
            long result = 0;
            string sql = string.Format("select 记录标识 from 临时缓存区_绩效考核_基金产品每日统计 where 产品名称='{0}' and 时间 = '{1}'", 产品名称, 开始时间);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                long.TryParse(obj.ToString(), out result);
                return result;
            }
            else
                return -1; 
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{	   
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 临时缓存区_绩效考核_基金产品每日统计(");
            strSql.Append("记录标识,产品名称,资产总额,资金余额,资金资产比例,今年收益率,单位净值,今年最大净值,回撤率,时间,基金份额,基准日净值,申购赎回调整数,股票资产总额,期货资产总额,期货资金余额,期货今年收益率)");
			strSql.Append(" values (");
            strSql.Append("@记录标识,@产品名称,@资产总额,@资金余额,@资金资产比例,@今年收益率,@单位净值,@今年最大净值,@回撤率,@时间,@基金份额,@基准日净值,@申购赎回调整数,@股票资产总额,@期货资产总额,@期货资金余额,@期货今年收益率)");
			SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@资产总额", SqlDbType.Float,8),
					new SqlParameter("@资金余额", SqlDbType.Float,8),
					new SqlParameter("@资金资产比例", SqlDbType.NVarChar,50),
					new SqlParameter("@今年收益率", SqlDbType.NVarChar,50),
					new SqlParameter("@单位净值", SqlDbType.Float,8), 
					new SqlParameter("@今年最大净值", SqlDbType.Float,8),
					new SqlParameter("@回撤率", SqlDbType.NVarChar,50), 
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金份额", SqlDbType.Float,8),
					new SqlParameter("@基准日净值", SqlDbType.Float,8),
					new SqlParameter("@申购赎回调整数", SqlDbType.Float,8),
					new SqlParameter("@股票资产总额", SqlDbType.Float,8) ,
					new SqlParameter("@期货资产总额", SqlDbType.Float,8) ,
					new SqlParameter("@期货资金余额", SqlDbType.Float,8) ,
					new SqlParameter("@期货今年收益率", SqlDbType.Float,8)  
                                        
                                        };
			parameters[0].Value = model.记录标识;
			parameters[1].Value = model.产品名称;
			parameters[2].Value = model.资产总额;
			parameters[3].Value = model.资金余额;
			parameters[4].Value = model.资金资产比例;
			parameters[5].Value = model.今年收益率;
			parameters[6].Value = model.单位净值;
            parameters[7].Value = model.今年最大净值;
            parameters[8].Value = model.回撤率;
            parameters[9].Value = model.时间;
            parameters[10].Value = model.基金份额;
            parameters[11].Value = model.基准日净值;
            parameters[12].Value = model.申购赎回调整数;
            parameters[13].Value = model.股票资产总额;
            parameters[14].Value = model.期货资产总额;
            parameters[15].Value = model.期货资金余额;
            parameters[16].Value = model.期货今年收益率;

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
		public bool Update(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 临时缓存区_绩效考核_基金产品每日统计 set ");
			strSql.Append("产品名称=@产品名称,");
			strSql.Append("资产总额=@资产总额,");
			strSql.Append("资金余额=@资金余额,");
			strSql.Append("资金资产比例=@资金资产比例,");
			strSql.Append("今年收益率=@今年收益率,");
			strSql.Append("单位净值=@单位净值,"); 
            strSql.Append("今年最大净值=@今年最大净值,");
            strSql.Append("回撤率=@回撤率,");  
			strSql.Append("时间=@时间,"); 
            strSql.Append("基金份额=@基金份额,");
            strSql.Append("基准日净值=@基准日净值,");
            strSql.Append("申购赎回调整数=@申购赎回调整数,");
            strSql.Append("股票资产总额=@股票资产总额,"); 
            strSql.Append("期货资产总额=@期货资产总额,"); 
            strSql.Append("期货资金余额=@期货资金余额,"); 
            strSql.Append("期货今年收益率=@期货今年收益率"); 
             
			strSql.Append(" where 记录标识=@记录标识 ");
			SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@资产总额", SqlDbType.Float,8),
					new SqlParameter("@资金余额", SqlDbType.Float,8),
					new SqlParameter("@资金资产比例", SqlDbType.NVarChar,50),
					new SqlParameter("@今年收益率", SqlDbType.NVarChar,50),
					new SqlParameter("@单位净值", SqlDbType.Float,8), 
					new SqlParameter("@今年最大净值", SqlDbType.Float,8),
					new SqlParameter("@回撤率", SqlDbType.NVarChar,50),  
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金份额", SqlDbType.Float,8),
					new SqlParameter("@基准日净值", SqlDbType.Float,8),
					new SqlParameter("@申购赎回调整数", SqlDbType.Float,8),  
					new SqlParameter("@股票资产总额", SqlDbType.Float,8),  
					new SqlParameter("@期货资产总额", SqlDbType.Float,8),  
					new SqlParameter("@期货资金余额", SqlDbType.Float,8),  
					new SqlParameter("@期货今年收益率", SqlDbType.Float,8), 

					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
			parameters[0].Value = model.产品名称;
			parameters[1].Value = model.资产总额;
			parameters[2].Value = model.资金余额;
			parameters[3].Value = model.资金资产比例;
			parameters[4].Value = model.今年收益率;
			parameters[5].Value = model.单位净值; 
            parameters[6].Value = model.今年最大净值;
            parameters[7].Value = model.回撤率;  
			parameters[8].Value = model.时间; 
            parameters[9].Value = model.基金份额;
            parameters[10].Value = model.基准日净值;
            parameters[11].Value = model.申购赎回调整数;
            parameters[12].Value = model.股票资产总额;
            parameters[13].Value = model.期货资产总额;
            parameters[14].Value = model.期货资金余额;
            parameters[15].Value = model.期货今年收益率;  
			parameters[16].Value = model.记录标识;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool UpdatePatial(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 临时缓存区_绩效考核_基金产品每日统计 set "); 
            strSql.Append("今年最大净值=@今年最大净值,");
            strSql.Append("回撤率=@回撤率 "); 
            strSql.Append(" where 时间=@时间 and 产品名称=@产品名称");
            SqlParameter[] parameters = { 
					new SqlParameter("@今年最大净值", SqlDbType.Float,8),
					new SqlParameter("@回撤率", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100) };
         
            parameters[0].Value = model.今年最大净值;
            parameters[1].Value = model.回撤率;
            parameters[2].Value = model.时间;  
            parameters[3].Value = model.产品名称; 
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
        /// 更新四个参数，分别是：股票资产总额、资金余额、资金资产比例、今年收益率
        /// </summary>
        public bool UpdatePatial2(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        {
              
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 临时缓存区_绩效考核_基金产品每日统计 set ");
            strSql.Append("股票资产总额=@股票资产总额,");
            strSql.Append("资金余额=@资金余额,");
            strSql.Append("资金资产比例=@资金资产比例,");
            strSql.Append("今年收益率=@今年收益率");
            strSql.Append(" where 时间=@时间 and 产品名称=@产品名称");

            SqlParameter[] parameters = { 
					new SqlParameter("@股票资产总额", SqlDbType.Float,8),
					new SqlParameter("@资金余额", SqlDbType.Float,8),
					new SqlParameter("@资金资产比例", SqlDbType.NVarChar,50),
					new SqlParameter("@今年收益率", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100) };

            parameters[0].Value = model.股票资产总额;
            parameters[1].Value = model.资金余额;
            parameters[2].Value = model.资金资产比例;
            parameters[3].Value = model.今年收益率;
            parameters[4].Value = model.时间;
            parameters[5].Value = model.产品名称;
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
        /// 更新 个参数，分别是： 
        /// </summary>
        public bool UpdatePatial3(Maticsoft.Model.绩效考核_基金产品每日统计 model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 临时缓存区_绩效考核_基金产品每日统计 set "); 
            strSql.Append("资金余额=@资金余额,");
            strSql.Append("资金资产比例=@资金资产比例,");
            strSql.Append("今年最大净值=@今年最大净值");
            strSql.Append(" where 时间=@时间 and 产品名称=@产品名称");
            SqlParameter[] parameters = {  
					new SqlParameter("@资金余额", SqlDbType.Float,8),
					new SqlParameter("@资金资产比例", SqlDbType.NVarChar,50),
					new SqlParameter("@今年最大净值", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100) };
             
            parameters[0].Value = model.资金余额;
            parameters[1].Value = model.资金资产比例;
            parameters[2].Value = model.今年最大净值;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(long 记录标识)
		{ 
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 临时缓存区_绩效考核_基金产品每日统计 ");
			strSql.Append(" where 记录标识=@记录标识 ");
			SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
			parameters[0].Value = 记录标识;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string 记录标识list )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 临时缓存区_绩效考核_基金产品每日统计 ");
			strSql.Append(" where 记录标识 in ("+记录标识list + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金产品每日统计 GetModel(long 记录标识)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from 临时缓存区_绩效考核_基金产品每日统计 ");
			strSql.Append(" where 记录标识=@记录标识 ");
			SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
			parameters[0].Value = 记录标识;

			Maticsoft.Model.绩效考核_基金产品每日统计 model=new Maticsoft.Model.绩效考核_基金产品每日统计();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["记录标识"]!=null && ds.Tables[0].Rows[0]["记录标识"].ToString()!="")
				{
					model.记录标识=long.Parse(ds.Tables[0].Rows[0]["记录标识"].ToString());
				}
				if(ds.Tables[0].Rows[0]["产品名称"]!=null && ds.Tables[0].Rows[0]["产品名称"].ToString()!="")
				{
					model.产品名称=ds.Tables[0].Rows[0]["产品名称"].ToString();
				}
				if(ds.Tables[0].Rows[0]["资产总额"]!=null && ds.Tables[0].Rows[0]["资产总额"].ToString()!="")
				{
					model.资产总额=double.Parse(ds.Tables[0].Rows[0]["资产总额"].ToString());
				}
				if(ds.Tables[0].Rows[0]["资金余额"]!=null && ds.Tables[0].Rows[0]["资金余额"].ToString()!="")
				{
					model.资金余额=double.Parse(ds.Tables[0].Rows[0]["资金余额"].ToString());
				}
				if(ds.Tables[0].Rows[0]["资金资产比例"]!=null && ds.Tables[0].Rows[0]["资金资产比例"].ToString()!="")
				{
                    model.资金资产比例 = ds.Tables[0].Rows[0]["资金资产比例"].ToString();
				}
				if(ds.Tables[0].Rows[0]["今年收益率"]!=null && ds.Tables[0].Rows[0]["今年收益率"].ToString()!="")
				{
                    model.今年收益率 = ds.Tables[0].Rows[0]["今年收益率"].ToString();
				}
				if(ds.Tables[0].Rows[0]["单位净值"]!=null && ds.Tables[0].Rows[0]["单位净值"].ToString()!="")
				{
					model.单位净值=double.Parse(ds.Tables[0].Rows[0]["单位净值"].ToString());
				} 
				if(ds.Tables[0].Rows[0]["今年最大净值"]!=null && ds.Tables[0].Rows[0]["今年最大净值"].ToString()!="")
				{
					model.今年最大净值=double.Parse(ds.Tables[0].Rows[0]["今年最大净值"].ToString());
				}
				if(ds.Tables[0].Rows[0]["回撤率"]!=null && ds.Tables[0].Rows[0]["回撤率"].ToString()!="")
				{
                    model.回撤率 = ds.Tables[0].Rows[0]["回撤率"].ToString();
				} 
				if(ds.Tables[0].Rows[0]["时间"]!=null && ds.Tables[0].Rows[0]["时间"].ToString()!="")
				{
					model.时间=ds.Tables[0].Rows[0]["时间"].ToString();
				}
                if (ds.Tables[0].Rows[0]["基金份额"] != null && ds.Tables[0].Rows[0]["基金份额"].ToString() != "")
                {
                    model.基金份额 = double.Parse(ds.Tables[0].Rows[0]["基金份额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["基准日净值"] != null && ds.Tables[0].Rows[0]["基准日净值"].ToString() != "")
                {
                    model.基准日净值 = double.Parse(ds.Tables[0].Rows[0]["基准日净值"].ToString());
                }
                if (ds.Tables[0].Rows[0]["申购赎回调整数"] != null && ds.Tables[0].Rows[0]["申购赎回调整数"].ToString() != "")
                {
                    model.申购赎回调整数 = double.Parse(ds.Tables[0].Rows[0]["申购赎回调整数"].ToString());
                }
                if (ds.Tables[0].Rows[0]["股票资产总额"] != null && ds.Tables[0].Rows[0]["股票资产总额"].ToString() != "")
                {
                    model.股票资产总额 = double.Parse(ds.Tables[0].Rows[0]["股票资产总额"].ToString());
                }

                if (ds.Tables[0].Rows[0]["期货资产总额"] != null && ds.Tables[0].Rows[0]["期货资产总额"].ToString() != "")
                {
                    model.期货资产总额 = double.Parse(ds.Tables[0].Rows[0]["期货资产总额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["期货资金余额"] != null && ds.Tables[0].Rows[0]["期货资金余额"].ToString() != "")
                {
                    model.期货资金余额 = double.Parse(ds.Tables[0].Rows[0]["期货资金余额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["期货今年收益率"] != null && ds.Tables[0].Rows[0]["期货今年收益率"].ToString() != "")
                {
                    model.期货今年收益率 = double.Parse(ds.Tables[0].Rows[0]["期货今年收益率"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select *  FROM 临时缓存区_绩效考核_基金产品每日统计 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		#endregion  Method
	}
}

