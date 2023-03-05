using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
    /// 数据访问类:绩效考核_股票每日价格记录表
	/// </summary>
	public partial class 绩效考核_股票每日价格记录表
	{
        public 绩效考核_股票每日价格记录表()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string 股票代码, string 时间)
		{ 
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_股票每日价格记录表");
            strSql.Append(" where 股票代码=@股票代码 and 时间=@时间 ");
			SqlParameter[] parameters = {
					new SqlParameter("@股票代码", SqlDbType.NVarChar,6),
					new SqlParameter("@时间", SqlDbType.NVarChar,50) 
                                        };
            parameters[0].Value = 股票代码;
            parameters[1].Value = 时间;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_股票每日价格记录表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 绩效考核_股票每日价格记录表(");
			strSql.Append("股票代码,股票名称,时间,收盘价)");
			strSql.Append(" values (");
            strSql.Append("@股票代码,@股票名称,@时间,@收盘价)");
			SqlParameter[] parameters = {
					new SqlParameter("@股票代码", SqlDbType.NVarChar,6),
					new SqlParameter("@股票名称", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@收盘价", SqlDbType.Float,8)
                                        
                                        };
			parameters[0].Value = model.股票代码;
            parameters[1].Value = model.股票名称;
            parameters[2].Value = model.时间;
            parameters[3].Value = model.收盘价;

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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select 股票代码,股票名称,时间,收盘价 ");
			strSql.Append(" FROM 绩效考核_股票每日价格记录表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
 
		#endregion  Method
	}
}

