using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:绩效考核_汇率
	/// </summary>
	public partial class 绩效考核_汇率
	{
		public 绩效考核_汇率()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 时间)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_汇率");
			strSql.Append(" where 时间=@时间 ");
			SqlParameter[] parameters = {
					new SqlParameter("@时间", SqlDbType.NVarChar,50)};
			parameters[0].Value = 时间;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_汇率 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 绩效考核_汇率(");
            strSql.Append("时间,买入汇率,卖出汇率)");
			strSql.Append(" values (");
            strSql.Append("@时间,@买入汇率,@卖出汇率)");
			SqlParameter[] parameters = {
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@买入汇率", SqlDbType.Float,8),
					new SqlParameter("@卖出汇率", SqlDbType.Float,8)};
			parameters[0].Value = model.时间;
            parameters[1].Value = model.买入汇率;
            parameters[2].Value = model.卖出汇率; 
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
		public bool Update(Maticsoft.Model.绩效考核_汇率 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 绩效考核_汇率 set ");
            strSql.Append("买入汇率=@买入汇率,");
            strSql.Append("卖出汇率=@卖出汇率");
			strSql.Append(" where 时间=@时间 ");
			SqlParameter[] parameters = {
					new SqlParameter("@买入汇率", SqlDbType.Float,8),
					new SqlParameter("@卖出汇率", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.买入汇率;
            parameters[1].Value = model.卖出汇率;
			parameters[2].Value = model.时间;

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
		public bool Delete(string 时间)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_汇率 ");
			strSql.Append(" where 时间=@时间 ");
			SqlParameter[] parameters = {
					new SqlParameter("@时间", SqlDbType.NVarChar,50)};
			parameters[0].Value = 时间;

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
		public Maticsoft.Model.绩效考核_汇率 GetModel(string 时间)
		{ 
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 时间,买入汇率,卖出汇率 from 绩效考核_汇率 ");
			strSql.Append(" where 时间=@时间 ");
			SqlParameter[] parameters = {
					new SqlParameter("@时间", SqlDbType.NVarChar,50)};
			parameters[0].Value = 时间;

			Maticsoft.Model.绩效考核_汇率 model=new Maticsoft.Model.绩效考核_汇率();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["时间"]!=null && ds.Tables[0].Rows[0]["时间"].ToString()!="")
				{
					model.时间=ds.Tables[0].Rows[0]["时间"].ToString();
				}
                if (ds.Tables[0].Rows[0]["买入汇率"] != null && ds.Tables[0].Rows[0]["买入汇率"].ToString() != "")
				{
                    double 买入汇率 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["买入汇率"].ToString(), out 买入汇率);
                    model.买入汇率 = 买入汇率;
                }
                if (ds.Tables[0].Rows[0]["卖出汇率"] != null && ds.Tables[0].Rows[0]["卖出汇率"].ToString() != "")
                {
                    double 卖出汇率 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["卖出汇率"].ToString(), out 卖出汇率);
                    model.卖出汇率 = 卖出汇率;
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
            strSql.Append("select 时间,买入汇率,卖出汇率 ");
			strSql.Append(" FROM 绩效考核_汇率 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
 

		#endregion  Method
	}
}

