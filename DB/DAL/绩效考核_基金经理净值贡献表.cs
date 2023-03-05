using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:绩效考核_基金经理净值贡献表
	/// </summary>
	public partial class 绩效考核_基金经理净值贡献表
	{
		public 绩效考核_基金经理净值贡献表()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 基金经理,string 时间,string 基金产品)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_基金经理净值贡献表");
			strSql.Append(" where 基金经理=@基金经理 and 时间=@时间 and 基金产品=@基金产品 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金产品", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;
			parameters[1].Value = 时间;
			parameters[2].Value = 基金产品;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.绩效考核_基金经理净值贡献表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 绩效考核_基金经理净值贡献表(");
			strSql.Append("基金经理,时间,基金产品,本年净值贡献)");
			strSql.Append(" values (");
			strSql.Append("@基金经理,@时间,@基金产品,@本年净值贡献)");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金产品", SqlDbType.NVarChar,50),
					new SqlParameter("@本年净值贡献", SqlDbType.Float,8)};
			parameters[0].Value = model.基金经理;
			parameters[1].Value = model.时间;
			parameters[2].Value = model.基金产品;
			parameters[3].Value = model.本年净值贡献;
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
		public bool Update(Maticsoft.Model.绩效考核_基金经理净值贡献表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 绩效考核_基金经理净值贡献表 set ");
			strSql.Append("本年净值贡献=@本年净值贡献");
			strSql.Append(" where 基金经理=@基金经理 and 时间=@时间 and 基金产品=@基金产品 ");
			SqlParameter[] parameters = {
					new SqlParameter("@本年净值贡献", SqlDbType.Float,8),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金产品", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.本年净值贡献;
			parameters[1].Value = model.基金经理;
			parameters[2].Value = model.时间;
			parameters[3].Value = model.基金产品;

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
		public bool Delete(string 基金经理,string 时间,string 基金产品)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_基金经理净值贡献表 ");
			strSql.Append(" where 基金经理=@基金经理 and 时间=@时间 and 基金产品=@基金产品 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金产品", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;
			parameters[1].Value = 时间;
			parameters[2].Value = 基金产品;

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金经理净值贡献表 GetModel(string 基金经理,string 时间,string 基金产品)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 基金经理,时间,基金产品,本年净值贡献 from 绩效考核_基金经理净值贡献表 ");
			strSql.Append(" where 基金经理=@基金经理 and 时间=@时间 and 基金产品=@基金产品 ");
			SqlParameter[] parameters = {
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@基金产品", SqlDbType.NVarChar,50)};
			parameters[0].Value = 基金经理;
			parameters[1].Value = 时间;
			parameters[2].Value = 基金产品;

			Maticsoft.Model.绩效考核_基金经理净值贡献表 model=new Maticsoft.Model.绩效考核_基金经理净值贡献表();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["基金经理"]!=null && ds.Tables[0].Rows[0]["基金经理"].ToString()!="")
				{
					model.基金经理=ds.Tables[0].Rows[0]["基金经理"].ToString();
				}
				if(ds.Tables[0].Rows[0]["时间"]!=null && ds.Tables[0].Rows[0]["时间"].ToString()!="")
				{
					model.时间=ds.Tables[0].Rows[0]["时间"].ToString();
				}
				if(ds.Tables[0].Rows[0]["基金产品"]!=null && ds.Tables[0].Rows[0]["基金产品"].ToString()!="")
				{
					model.基金产品=ds.Tables[0].Rows[0]["基金产品"].ToString();
				}
				if(ds.Tables[0].Rows[0]["本年净值贡献"]!=null && ds.Tables[0].Rows[0]["本年净值贡献"].ToString()!="")
				{
					model.本年净值贡献=double.Parse(ds.Tables[0].Rows[0]["本年净值贡献"].ToString());
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
			strSql.Append("select 基金经理,时间,基金产品,本年净值贡献 ");
			strSql.Append(" FROM 绩效考核_基金经理净值贡献表 ");
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
			strSql.Append(" 基金经理,时间,基金产品,本年净值贡献 ");
			strSql.Append(" FROM 绩效考核_基金经理净值贡献表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "绩效考核_基金经理净值贡献表";
			parameters[1].Value = "基金产品";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

