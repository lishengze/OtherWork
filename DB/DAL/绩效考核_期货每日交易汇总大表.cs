using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:绩效考核_期货每日交易汇总大表
    /// </summary>
    public partial class 绩效考核_期货每日交易汇总大表
    {
        public 绩效考核_期货每日交易汇总大表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_期货每日交易汇总大表");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录,返回记录的标识
        /// </summary>
        public long Exists(string 期货代码, string 基金经理, string 产品名称, string 时间)
        {
            long result = 0;
            string  sql = string.Format("select 记录标识 from 绩效考核_期货每日交易汇总大表 where 期货代码='{0}' and 产品名称='{1}' and 时间 = '{2}' and 基金经理='{3}'", 期货代码, 产品名称, 时间, 基金经理);
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
        public bool Add(Maticsoft.Model.绩效考核_期货每日交易汇总大表 model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 绩效考核_期货每日交易汇总大表(");
            strSql.Append("记录标识,产品名称,基金经理,期货代码,期货名称,卖持量,卖持仓成本,市场现价,合约成本,持仓保证金,当日盈亏,总盈亏,时间)");
            strSql.Append(" values (");
            strSql.Append("@记录标识,@产品名称,@基金经理,@期货代码,@期货名称,@卖持量,@卖持仓成本,@市场现价,@合约成本,@持仓保证金,@当日盈亏,@总盈亏,@时间)");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@期货代码", SqlDbType.VarChar,50),
					new SqlParameter("@期货名称", SqlDbType.VarChar,50),
					new SqlParameter("@卖持量", SqlDbType.Float,8),
					new SqlParameter("@卖持仓成本", SqlDbType.Float,8),
					new SqlParameter("@市场现价", SqlDbType.Float,8),
					new SqlParameter("@合约成本", SqlDbType.Float,8),
					new SqlParameter("@持仓保证金", SqlDbType.Float,8), 
					new SqlParameter("@当日盈亏", SqlDbType.Float,8),
					new SqlParameter("@总盈亏", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50)  
                                        };
            parameters[0].Value = model.记录标识;
            parameters[1].Value = model.产品名称;
            parameters[2].Value = model.基金经理;
            parameters[3].Value = model.期货代码;
            parameters[4].Value = model.期货名称;
            parameters[5].Value = model.卖持量;
            parameters[6].Value = model.卖持仓成本;
            parameters[7].Value = model.市场现价;
            parameters[8].Value = model.合约成本;
            parameters[9].Value = model.持仓保证金;
            parameters[10].Value = model.当日盈亏;
            parameters[11].Value = model.总盈亏;
            parameters[12].Value = model.时间; 
             
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
        public bool Update(Maticsoft.Model.绩效考核_期货每日交易汇总大表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_期货每日交易汇总大表 set "); 
             
            strSql.Append("产品名称=@产品名称,");
            strSql.Append("基金经理=@基金经理,");
            strSql.Append("期货代码=@期货代码,");
            strSql.Append("期货名称=@期货名称,");  
            strSql.Append("卖持量=@卖持量,");
            strSql.Append("卖持仓成本=@卖持仓成本,");
            strSql.Append("市场现价=@市场现价,");
            strSql.Append("合约成本=@合约成本,");
            strSql.Append("持仓保证金=@持仓保证金,"); 
            strSql.Append("当日盈亏=@当日盈亏,");
            strSql.Append("总盈亏=@总盈亏,");
            strSql.Append("时间=@时间 "); 

            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@期货代码", SqlDbType.NVarChar,50),
					new SqlParameter("@期货名称", SqlDbType.VarChar,50), 
					new SqlParameter("@卖持量", SqlDbType.Float,8),
					new SqlParameter("@卖持仓成本", SqlDbType.Float,8),
					new SqlParameter("@市场现价", SqlDbType.Float,8),
					new SqlParameter("@合约成本", SqlDbType.Float,8),
					new SqlParameter("@持仓保证金", SqlDbType.Float,8),
					new SqlParameter("@当日盈亏", SqlDbType.Float,8), 
					new SqlParameter("@总盈亏", SqlDbType.Float,8), 
					new SqlParameter("@时间", SqlDbType.NVarChar,50), 
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)  
                                        };
            parameters[0].Value = model.产品名称;
            parameters[1].Value = model.基金经理;
            parameters[2].Value = model.期货代码;
            parameters[3].Value = model.期货名称;
            parameters[4].Value = model.卖持量;
            parameters[5].Value = model.卖持仓成本;
            parameters[6].Value = model.市场现价;
            parameters[7].Value = model.合约成本;
            parameters[8].Value = model.持仓保证金;
            parameters[9].Value = model.当日盈亏; 
            parameters[10].Value = model.总盈亏;
            parameters[11].Value = model.时间; 
            parameters[12].Value = model.记录标识;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 绩效考核_期货每日交易汇总大表 ");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

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
        public Maticsoft.Model.绩效考核_期货每日交易汇总大表 GetModel(long 记录标识)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 记录标识,产品名称,基金经理,期货代码,期货名称,卖持量,卖持仓成本,市场现价,合约成本,持仓保证金,当日盈亏,总盈亏,时间  from 绩效考核_期货每日交易汇总大表 ");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            Maticsoft.Model.绩效考核_期货每日交易汇总大表 model = new Maticsoft.Model.绩效考核_期货每日交易汇总大表();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["记录标识"] != null && ds.Tables[0].Rows[0]["记录标识"].ToString() != "")
                {
                    model.记录标识 = long.Parse(ds.Tables[0].Rows[0]["记录标识"].ToString());
                }
                if (ds.Tables[0].Rows[0]["产品名称"] != null && ds.Tables[0].Rows[0]["产品名称"].ToString() != "")
                {
                    model.产品名称 = ds.Tables[0].Rows[0]["产品名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["基金经理"] != null && ds.Tables[0].Rows[0]["基金经理"].ToString() != "")
                {
                    model.基金经理 = ds.Tables[0].Rows[0]["基金经理"].ToString();
                }
                if (ds.Tables[0].Rows[0]["期货代码"] != null && ds.Tables[0].Rows[0]["期货代码"].ToString() != "")
                {
                    model.期货代码 = ds.Tables[0].Rows[0]["期货代码"].ToString();
                }
                if (ds.Tables[0].Rows[0]["期货名称"] != null && ds.Tables[0].Rows[0]["期货名称"].ToString() != "")
                {
                    model.期货名称 = ds.Tables[0].Rows[0]["期货名称"].ToString();
                } 
                if (ds.Tables[0].Rows[0]["卖持量"] != null && ds.Tables[0].Rows[0]["卖持量"].ToString() != "")
                {
                    model.卖持量 = double.Parse(ds.Tables[0].Rows[0]["卖持量"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖持仓成本"] != null && ds.Tables[0].Rows[0]["卖持仓成本"].ToString() != "")
                {
                    model.卖持仓成本 = double.Parse(ds.Tables[0].Rows[0]["卖持仓成本"].ToString());
                }
                if (ds.Tables[0].Rows[0]["市场现价"] != null && ds.Tables[0].Rows[0]["市场现价"].ToString() != "")
                {
                    model.市场现价 = double.Parse(ds.Tables[0].Rows[0]["市场现价"].ToString());
                } 
                if (ds.Tables[0].Rows[0]["合约成本"] != null && ds.Tables[0].Rows[0]["合约成本"].ToString() != "")
                {
                    model.合约成本 = double.Parse(ds.Tables[0].Rows[0]["合约成本"].ToString());
                }
                if (ds.Tables[0].Rows[0]["持仓保证金"] != null && ds.Tables[0].Rows[0]["持仓保证金"].ToString() != "")
                {
                    model.持仓保证金 = double.Parse(ds.Tables[0].Rows[0]["持仓保证金"].ToString());
                } 
                if (ds.Tables[0].Rows[0]["当日盈亏"] != null && ds.Tables[0].Rows[0]["当日盈亏"].ToString() != "")
                {
                    model.当日盈亏 = double.Parse(ds.Tables[0].Rows[0]["当日盈亏"].ToString());
                }
                if (ds.Tables[0].Rows[0]["总盈亏"] != null && ds.Tables[0].Rows[0]["总盈亏"].ToString() != "")
                {
                    model.总盈亏 = double.Parse(ds.Tables[0].Rows[0]["总盈亏"].ToString());
                }
                if (ds.Tables[0].Rows[0]["时间"] != null && ds.Tables[0].Rows[0]["时间"].ToString() != "")
                {
                    model.时间 = ds.Tables[0].Rows[0]["时间"].ToString();
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
            strSql.Append("select 记录标识,产品名称,基金经理,期货代码,期货名称,卖持量,卖持仓成本,市场现价,合约成本,持仓保证金,当日盈亏,总盈亏,时间 FROM 绩效考核_期货每日交易汇总大表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
        
      
        #endregion  Method
    }
}

