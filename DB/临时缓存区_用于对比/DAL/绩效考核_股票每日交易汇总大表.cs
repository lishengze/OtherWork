using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:临时缓存区_绩效考核_股票每日交易汇总大表
    /// </summary>
    public partial class 临时缓存区_绩效考核_股票每日交易汇总大表
    {
        public 临时缓存区_绩效考核_股票每日交易汇总大表()
        { }
        #region  Method
         
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 临时缓存区_绩效考核_股票每日交易汇总大表");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录,返回记录的标识
        /// </summary>
        public long Exists(string 股票代码, string 基金经理, string 产品名称, string 开始时间)
        {
            long result = 0;
            string  sql = string.Format("select 记录标识 from 临时缓存区_绩效考核_股票每日交易汇总大表 where 股票代码='{0}' and 产品名称='{1}' and 时间 = '{2}' and 基金经理='{3}'", 股票代码, 产品名称, 开始时间, 基金经理);
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
        public bool Add(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 临时缓存区_绩效考核_股票每日交易汇总大表(");
            strSql.Append("记录标识,产品名称,基金经理,股票代码,股票名称,持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,当日盈亏,时间,买卖累计盈亏,今日均价)");
            strSql.Append(" values (");
            strSql.Append("@记录标识,@产品名称,@基金经理,@股票代码,@股票名称,@持股数量,@持股成本,@市场现价,@投资成本,@今日市值,@浮盈浮亏,@投资成本占比,@市值占比,@浮盈浮亏率,@当日盈亏,@时间,@买卖累计盈亏,@今日均价)");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@股票名称", SqlDbType.VarChar,50),
					new SqlParameter("@持股数量", SqlDbType.Float,8),
					new SqlParameter("@持股成本", SqlDbType.Float,8),
					new SqlParameter("@市场现价", SqlDbType.Float,8),
					new SqlParameter("@投资成本", SqlDbType.Float,8),
					new SqlParameter("@今日市值", SqlDbType.Float,8),
					new SqlParameter("@浮盈浮亏", SqlDbType.Float,8),
					new SqlParameter("@投资成本占比", SqlDbType.NVarChar,50),
					new SqlParameter("@市值占比", SqlDbType.Float,8),
					new SqlParameter("@浮盈浮亏率",SqlDbType.NVarChar,50),
					new SqlParameter("@当日盈亏", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@买卖累计盈亏", SqlDbType.Float,8), 
					new SqlParameter("@今日均价", SqlDbType.Float,8)
                     
                                        };
            parameters[0].Value = model.记录标识;
            parameters[1].Value = model.产品名称;
            parameters[2].Value = model.基金经理;
            parameters[3].Value = model.股票代码;
            parameters[4].Value = model.股票名称;
            parameters[5].Value = model.持股数量;
            parameters[6].Value = model.持股成本;
            parameters[7].Value = model.市场现价;
            parameters[8].Value = model.投资成本;
            parameters[9].Value = model.今日市值;
            parameters[10].Value = model.浮盈浮亏;
            string str = model.投资成本占比.ToString();
            parameters[11].Value = str;
            parameters[12].Value = model.市值占比;
            parameters[13].Value = model.浮盈浮亏率.ToString();
            parameters[14].Value = model.当日盈亏;
            parameters[15].Value = model.时间;
            parameters[16].Value = model.买卖累计盈亏;
            parameters[17].Value = model.今日均价;

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
        public bool Update(Maticsoft.Model.绩效考核_股票每日交易汇总大表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 临时缓存区_绩效考核_股票每日交易汇总大表 set ");
            strSql.Append("产品名称=@产品名称,");
            strSql.Append("基金经理=@基金经理,");
            strSql.Append("股票代码=@股票代码,");
            strSql.Append("股票名称=@股票名称,");
            strSql.Append("持股数量=@持股数量,");
            strSql.Append("持股成本=@持股成本,");
            strSql.Append("市场现价=@市场现价,");
            strSql.Append("投资成本=@投资成本,");
            strSql.Append("今日市值=@今日市值,");
            strSql.Append("浮盈浮亏=@浮盈浮亏,");
            strSql.Append("投资成本占比=@投资成本占比,");
            strSql.Append("市值占比=@市值占比,");
            strSql.Append("浮盈浮亏率=@浮盈浮亏率,"); 
            strSql.Append("当日盈亏=@当日盈亏,");
            strSql.Append("时间=@时间,");
            strSql.Append("买卖累计盈亏=@买卖累计盈亏,");
            strSql.Append("今日均价=@今日均价");

            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@股票名称", SqlDbType.VarChar,50),
					new SqlParameter("@持股数量", SqlDbType.Float,8),
					new SqlParameter("@持股成本", SqlDbType.Float,8),
					new SqlParameter("@市场现价", SqlDbType.Float,8),
					new SqlParameter("@投资成本", SqlDbType.Float,8),
					new SqlParameter("@今日市值", SqlDbType.Float,8),
					new SqlParameter("@浮盈浮亏", SqlDbType.Float,8),
					new SqlParameter("@投资成本占比", SqlDbType.VarChar,50),
					new SqlParameter("@市值占比",SqlDbType.Float,8),
					new SqlParameter("@浮盈浮亏率",SqlDbType.VarChar,50),
					new SqlParameter("@当日盈亏", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@买卖累计盈亏", SqlDbType.Float,8),
					new SqlParameter("@今日均价", SqlDbType.Float,8),
					new SqlParameter("@记录标识", SqlDbType.BigInt,8) 

                                        };
            parameters[0].Value = model.产品名称;
            parameters[1].Value = model.基金经理;
            parameters[2].Value = model.股票代码;
            parameters[3].Value = model.股票名称;
            parameters[4].Value = model.持股数量;
            parameters[5].Value = model.持股成本;
            parameters[6].Value = model.市场现价;
            parameters[7].Value = model.投资成本;
            parameters[8].Value = model.今日市值;
            parameters[9].Value = model.浮盈浮亏;
            parameters[10].Value = model.投资成本占比.ToString();
            parameters[11].Value = model.市值占比;
            parameters[12].Value = model.浮盈浮亏率.ToString(); 
            parameters[13].Value = model.当日盈亏;
            parameters[14].Value = model.时间;
            parameters[15].Value = model.买卖累计盈亏;
            parameters[16].Value = model.今日均价;
            parameters[17].Value = model.记录标识;

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
            strSql.Append("delete from 临时缓存区_绩效考核_股票每日交易汇总大表 ");
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string 记录标识list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 临时缓存区_绩效考核_股票每日交易汇总大表 ");
            strSql.Append(" where 记录标识 in (" + 记录标识list + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.绩效考核_股票每日交易汇总大表 GetModel(long 记录标识)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 记录标识,产品名称,基金经理,股票代码,股票名称,持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,市值占比,浮盈浮亏率,当日盈亏,时间,买卖累计盈亏,今日均价  from 临时缓存区_绩效考核_股票每日交易汇总大表 ");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            Maticsoft.Model.绩效考核_股票每日交易汇总大表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总大表();
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
                if (ds.Tables[0].Rows[0]["股票代码"] != null && ds.Tables[0].Rows[0]["股票代码"].ToString() != "")
                {
                    model.股票代码 = ds.Tables[0].Rows[0]["股票代码"].ToString();
                }
                if (ds.Tables[0].Rows[0]["股票名称"] != null && ds.Tables[0].Rows[0]["股票名称"].ToString() != "")
                {
                    model.股票名称 = ds.Tables[0].Rows[0]["股票名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["持股数量"] != null && ds.Tables[0].Rows[0]["持股数量"].ToString() != "")
                {
                    model.持股数量 = double.Parse(ds.Tables[0].Rows[0]["持股数量"].ToString());
                }
                if (ds.Tables[0].Rows[0]["持股成本"] != null && ds.Tables[0].Rows[0]["持股成本"].ToString() != "")
                {
                    model.持股成本 = double.Parse(ds.Tables[0].Rows[0]["持股成本"].ToString());
                }
                if (ds.Tables[0].Rows[0]["市场现价"] != null && ds.Tables[0].Rows[0]["市场现价"].ToString() != "")
                {
                    model.市场现价 = double.Parse(ds.Tables[0].Rows[0]["市场现价"].ToString());
                }
                if (ds.Tables[0].Rows[0]["投资成本"] != null && ds.Tables[0].Rows[0]["投资成本"].ToString() != "")
                {
                    model.投资成本 = double.Parse(ds.Tables[0].Rows[0]["投资成本"].ToString());
                }
                if (ds.Tables[0].Rows[0]["今日市值"] != null && ds.Tables[0].Rows[0]["今日市值"].ToString() != "")
                {
                    model.今日市值 = double.Parse(ds.Tables[0].Rows[0]["今日市值"].ToString());
                }
                if (ds.Tables[0].Rows[0]["浮盈浮亏"] != null && ds.Tables[0].Rows[0]["浮盈浮亏"].ToString() != "")
                {
                    model.浮盈浮亏 = double.Parse(ds.Tables[0].Rows[0]["浮盈浮亏"].ToString());
                }
                if (ds.Tables[0].Rows[0]["投资成本占比"] != null && ds.Tables[0].Rows[0]["投资成本占比"].ToString() != "")
                {
                    double 投资成本占比 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["投资成本占比"].ToString(), out 投资成本占比);
                    model.投资成本占比 = 投资成本占比;   
                }
                if (ds.Tables[0].Rows[0]["市值占比"] != null && ds.Tables[0].Rows[0]["市值占比"].ToString() != "")
                {
                    double 市值占比 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["市值占比"].ToString(), out 市值占比);
                    model.市值占比 = 市值占比;    
                }
                if (ds.Tables[0].Rows[0]["浮盈浮亏率"] != null && ds.Tables[0].Rows[0]["浮盈浮亏率"].ToString() != "")
                {
                    double 浮盈浮亏率 = 0;
                    double.TryParse(ds.Tables[0].Rows[0]["浮盈浮亏率"].ToString(), out 浮盈浮亏率);
                    model.浮盈浮亏率 = 浮盈浮亏率;    
                }  
                if (ds.Tables[0].Rows[0]["当日盈亏"] != null && ds.Tables[0].Rows[0]["当日盈亏"].ToString() != "")
                {
                    model.当日盈亏 = double.Parse(ds.Tables[0].Rows[0]["当日盈亏"].ToString());
                }
                if (ds.Tables[0].Rows[0]["时间"] != null && ds.Tables[0].Rows[0]["时间"].ToString() != "")
                {
                    model.时间 = ds.Tables[0].Rows[0]["时间"].ToString();
                }
                if (ds.Tables[0].Rows[0]["买卖累计盈亏"] != null && ds.Tables[0].Rows[0]["买卖累计盈亏"].ToString() != "")
                {
                    model.买卖累计盈亏 = double.Parse(ds.Tables[0].Rows[0]["买卖累计盈亏"].ToString());
                }
                if (ds.Tables[0].Rows[0]["今日均价"] != null && ds.Tables[0].Rows[0]["今日均价"].ToString() != "")
                {
                    model.今日均价 = double.Parse(ds.Tables[0].Rows[0]["今日均价"].ToString());
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
            DataSet dataSet = new DataSet();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 记录标识,产品名称,股票代码,股票名称,基金经理,持股数量,持股成本,市场现价,投资成本,今日市值,浮盈浮亏,投资成本占比,str(市值占比,16,14) as 市值占比,浮盈浮亏率,当日盈亏,时间,买卖累计盈亏,今日均价 FROM 临时缓存区_绩效考核_股票每日交易汇总大表 ");
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

