using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:绩效考核_基金经理信息表
	/// </summary>
	public partial class 绩效考核_基金经理信息表
	{
		public 绩效考核_基金经理信息表()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 基金经理)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_基金经理信息表");
			strSql.Append(" where 基金经理=@基金经理 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金经理信息表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 绩效考核_基金经理信息表(");
			strSql.Append("基金经理,管理产品)");
			strSql.Append(" values (");
			strSql.Append("@基金经理,@管理产品)");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@管理产品", SqlDbType.NVarChar,1000)};
			parameters[0].Value = model.基金经理;
			parameters[1].Value = model.管理产品;

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
		public bool Update(Maticsoft.Model.绩效考核_基金经理信息表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 绩效考核_基金经理信息表 set ");
			strSql.Append("管理产品=@管理产品");
			strSql.Append(" where 基金经理=@基金经理 ");
			SqlParameter[] parameters = {
					new SqlParameter("@管理产品", SqlDbType.NVarChar,1000),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.管理产品;
			parameters[1].Value = model.基金经理;

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
		public bool Delete(string 基金经理)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_基金经理信息表 ");
			strSql.Append(" where 基金经理=@基金经理 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;

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
		public bool DeleteList(string 基金经理list )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_基金经理信息表 ");
			strSql.Append(" where 基金经理 in ("+基金经理list + ")  ");
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
		public Maticsoft.Model.绩效考核_基金经理信息表 GetModel(string 基金经理)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 基金经理,管理产品 from 绩效考核_基金经理信息表 ");
			strSql.Append(" where 基金经理=@基金经理 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;

			Maticsoft.Model.绩效考核_基金经理信息表 model=new Maticsoft.Model.绩效考核_基金经理信息表();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["基金经理"]!=null && ds.Tables[0].Rows[0]["基金经理"].ToString()!="")
				{
					model.基金经理=ds.Tables[0].Rows[0]["基金经理"].ToString();
				}
				if(ds.Tables[0].Rows[0]["管理产品"]!=null && ds.Tables[0].Rows[0]["管理产品"].ToString()!="")
				{
					model.管理产品=ds.Tables[0].Rows[0]["管理产品"].ToString();
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
			strSql.Append("select 基金经理,管理产品 ");
			strSql.Append(" FROM 绩效考核_基金经理信息表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" 基金经理,管理产品 ");
			strSql.Append(" FROM 绩效考核_基金经理信息表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

	 

		#endregion  Method
	}
}

