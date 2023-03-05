using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:绩效考核_用户信息表
	/// </summary>
	public partial class 绩效考核_用户信息表
	{
		public 绩效考核_用户信息表()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 用户名)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_用户信息表");
			strSql.Append(" where 用户名=@用户名 ");
			SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.NVarChar,50)};
			parameters[0].Value = 用户名;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        	/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string 用户名, string 用户密码)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 绩效考核_用户信息表");
            strSql.Append(" where 用户名=@用户名 and 用户密码=@用户密码 ");
			SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.NVarChar,50), 
					new SqlParameter("@用户密码", SqlDbType.NVarChar,50) 
                                        };
            parameters[0].Value = 用户名;
            parameters[1].Value = 用户密码; 
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
         

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_用户信息表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 绩效考核_用户信息表(");
            strSql.Append("用户名,用户密码,用户姓名,角色)");
			strSql.Append(" values (");
            strSql.Append("@用户名,@用户密码,@用户姓名,@角色)");
			SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.NVarChar,50),
					new SqlParameter("@用户密码", SqlDbType.NVarChar,50),
					new SqlParameter("@用户姓名", SqlDbType.NVarChar,50),
					new SqlParameter("@角色", SqlDbType.NVarChar,10) 
                                        };
			parameters[0].Value = model.用户名;
            parameters[1].Value = model.用户密码;
            parameters[2].Value = model.用户姓名;
            parameters[3].Value = model.角色;

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
		public bool Update(Maticsoft.Model.绩效考核_用户信息表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 绩效考核_用户信息表 set ");
            strSql.Append("用户密码=@用户密码,");
            strSql.Append("用户姓名=@用户姓名,");
            strSql.Append("角色=@角色");
			strSql.Append(" where 用户名=@用户名 ");
			SqlParameter[] parameters = {
					new SqlParameter("@用户密码", SqlDbType.NVarChar,50),
					new SqlParameter("@用户姓名", SqlDbType.NVarChar,50),
					new SqlParameter("@角色", SqlDbType.NVarChar,10),
					new SqlParameter("@用户名", SqlDbType.NVarChar,50) 
                                        };
			parameters[0].Value = model.用户密码;
            parameters[1].Value = model.用户姓名;
            parameters[2].Value = model.角色;
            parameters[3].Value = model.用户名;
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
		public bool Delete(string 用户名)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_用户信息表 ");
			strSql.Append(" where 用户名=@用户名 ");
			SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.NVarChar,50)};
			parameters[0].Value = 用户名;

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
		public bool DeleteList(string 用户名list )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 绩效考核_用户信息表 ");
			strSql.Append(" where 用户名 in ("+用户名list + ")  ");
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
		public Maticsoft.Model.绩效考核_用户信息表 GetModel(string 用户名)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 用户名,用户密码,用户姓名,角色 from 绩效考核_用户信息表 ");
			strSql.Append(" where 用户名=@用户名 ");
			SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.NVarChar,50)};
			parameters[0].Value = 用户名;

			Maticsoft.Model.绩效考核_用户信息表 model=new Maticsoft.Model.绩效考核_用户信息表();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["用户名"]!=null && ds.Tables[0].Rows[0]["用户名"].ToString()!="")
				{
					model.用户名=ds.Tables[0].Rows[0]["用户名"].ToString();
				}
				if(ds.Tables[0].Rows[0]["用户密码"]!=null && ds.Tables[0].Rows[0]["用户密码"].ToString()!="")
				{
					model.用户密码=ds.Tables[0].Rows[0]["用户密码"].ToString();
                }
                if (ds.Tables[0].Rows[0]["用户姓名"] != null && ds.Tables[0].Rows[0]["用户姓名"].ToString() != "")
                {
                    model.用户姓名 = ds.Tables[0].Rows[0]["用户姓名"].ToString();
                }
                if (ds.Tables[0].Rows[0]["角色"] != null && ds.Tables[0].Rows[0]["角色"].ToString() != "")
                {
                    model.角色 = ds.Tables[0].Rows[0]["角色"].ToString();
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
            strSql.Append("select 用户名,用户密码,用户姓名,角色 ");
			strSql.Append(" FROM 绩效考核_用户信息表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		} 

		#endregion  Method
	}
}

