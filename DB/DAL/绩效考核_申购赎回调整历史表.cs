using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:绩效考核_申购赎回调整历史表
    /// </summary>
    public partial class 绩效考核_申购赎回调整历史表
    {
        public 绩效考核_申购赎回调整历史表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 序号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_申购赎回调整历史表");
            strSql.Append(" where 序号=@序号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@序号", SqlDbType.VarChar,6)};
            parameters[0].Value = 序号;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 基金经理, string 产品名称)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_申购赎回调整历史表");
            strSql.Append(" where 产品名称=@产品名称 and 基金经理=@基金经理");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,50),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = 产品名称;
            parameters[1].Value = 基金经理;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_申购赎回调整历史表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 绩效考核_申购赎回调整历史表(");
            strSql.Append("序号,产品名称,基金经理,申购赎回调整数,赎回时间,基金份额历史表序号)");
            strSql.Append(" values (");
            strSql.Append("@序号,@产品名称,@基金经理,@申购赎回调整数,@赎回时间,@基金份额历史表序号)");
            SqlParameter[] parameters = {
					new SqlParameter("@序号", SqlDbType.BigInt,8),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,50),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@申购赎回调整数", SqlDbType.Float,8),
					new SqlParameter("@赎回时间", SqlDbType.NVarChar,50), 
					new SqlParameter("@基金份额历史表序号", SqlDbType.BigInt,8)
                                        };
            parameters[0].Value = model.序号;
            parameters[1].Value = model.产品名称;
            parameters[2].Value = model.基金经理;
            parameters[3].Value = model.申购赎回调整数;
            parameters[4].Value = model.赎回时间;
            parameters[5].Value = model.基金份额历史表序号;

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
        public bool Update(Maticsoft.Model.绩效考核_申购赎回调整历史表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_申购赎回调整历史表 set ");
            strSql.Append("产品名称=@产品名称,");
            strSql.Append("基金经理=@基金经理,");
            strSql.Append("申购赎回调整数=@申购赎回调整数,");
            strSql.Append("赎回时间=@赎回时间,");
            strSql.Append("基金份额历史表序号=@基金份额历史表序号");

            strSql.Append(" where 序号=@序号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,50),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@申购赎回调整数", SqlDbType.Float,8),
					new SqlParameter("@赎回时间", SqlDbType.VarChar,50),
					new SqlParameter("@基金份额历史表序号", SqlDbType.BigInt,8),
					new SqlParameter("@序号", SqlDbType.BigInt,8) 
                                        };
            parameters[0].Value = model.产品名称;
            parameters[1].Value = model.基金经理;
            parameters[2].Value = model.申购赎回调整数;
            parameters[3].Value = model.赎回时间;
            parameters[4].Value = model.基金份额历史表序号;
            parameters[5].Value = model.序号;
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
        public bool Delete(long 序号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 绩效考核_申购赎回调整历史表 ");
            strSql.Append(" where 序号=@序号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@序号", SqlDbType.BigInt,8)};
            parameters[0].Value = 序号;

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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.绩效考核_申购赎回调整历史表 GetModel(long 序号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 序号,产品名称,基金经理,申购赎回调整数,赎回时间,基金份额历史表序号 from 绩效考核_申购赎回调整历史表 ");
            strSql.Append(" where 序号=@序号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@序号", SqlDbType.BigInt,8)};
            parameters[0].Value = 序号;
            Maticsoft.Model.绩效考核_申购赎回调整历史表 model = new Maticsoft.Model.绩效考核_申购赎回调整历史表();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.序号 = 序号;
                if (ds.Tables[0].Rows[0]["产品名称"] != null && ds.Tables[0].Rows[0]["产品名称"].ToString() != "")
                {
                    model.产品名称 = ds.Tables[0].Rows[0]["产品名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["基金经理"] != null && ds.Tables[0].Rows[0]["基金经理"].ToString() != "")
                {
                    model.基金经理 = ds.Tables[0].Rows[0]["基金经理"].ToString();
                }
                if (ds.Tables[0].Rows[0]["申购赎回调整数"] != null && ds.Tables[0].Rows[0]["申购赎回调整数"].ToString() != "")
                {
                    double 申购赎回调整数 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["申购赎回调整数"].ToString(), out 申购赎回调整数);
                    model.申购赎回调整数 = 申购赎回调整数;
                }
                if (ds.Tables[0].Rows[0]["赎回时间"] != null && ds.Tables[0].Rows[0]["赎回时间"].ToString() != "")
                {
                    model.赎回时间 = ds.Tables[0].Rows[0]["赎回时间"].ToString();
                }
                if (ds.Tables[0].Rows[0]["基金份额历史表序号"] != null && ds.Tables[0].Rows[0]["基金份额历史表序号"].ToString() != "")
                {
                    long 基金份额历史表序号 = 0;
                    long.TryParse(ds.Tables[0].Rows[0]["基金份额历史表序号"].ToString(), out 基金份额历史表序号);
                    model.基金份额历史表序号 = 基金份额历史表序号;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 序号,产品名称,基金经理,申购赎回调整数,赎回时间,基金份额历史表序号 ");
            strSql.Append(" FROM 绩效考核_申购赎回调整历史表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
    }
}

