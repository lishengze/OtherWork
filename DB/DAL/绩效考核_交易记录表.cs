using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:绩效考核_交易记录表
    /// </summary>
    public partial class 绩效考核_交易记录表
    {
        public 绩效考核_交易记录表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_交易记录表");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


       

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_交易记录表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 绩效考核_交易记录表(");
            strSql.Append("记录标识,产品名称,基金经理,股票代码,股票名称,交易方向,股数,成交均价,成交金额,手续费,过户费,印花税,时间)");
            strSql.Append(" values (");
            strSql.Append("@记录标识,@产品名称,@基金经理,@股票代码,@股票名称,@交易方向,@股数,@成交均价,@成交金额,@手续费,@过户费,@印花税,@时间)");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@股票名称", SqlDbType.NVarChar,50),
					new SqlParameter("@交易方向", SqlDbType.NVarChar,50),
					new SqlParameter("@股数", SqlDbType.BigInt,8),
					new SqlParameter("@成交均价", SqlDbType.Float,8),
					new SqlParameter("@成交金额", SqlDbType.Float,8),
					new SqlParameter("@手续费", SqlDbType.Float,8),
					new SqlParameter("@过户费", SqlDbType.Float,8),
					new SqlParameter("@印花税", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.记录标识;
            parameters[1].Value = model.产品名称;
            parameters[2].Value = model.基金经理;
            parameters[3].Value = model.股票代码;
            parameters[4].Value = model.股票名称;
            parameters[5].Value = model.交易方向;
            parameters[6].Value = model.股数;
            parameters[7].Value = model.成交均价;
            parameters[8].Value = model.成交金额;
            parameters[9].Value = model.手续费;
            parameters[10].Value = model.过户费;
            parameters[11].Value = model.印花税;
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
        public bool Update(Maticsoft.Model.绩效考核_交易记录表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_交易记录表 set ");
            strSql.Append("产品名称=@产品名称,");
            strSql.Append("基金经理=@基金经理,");
            strSql.Append("股票代码=@股票代码,");
            strSql.Append("股票名称=@股票名称,");
            strSql.Append("交易方向=@交易方向,");
            strSql.Append("股数=@股数,");
            strSql.Append("成交均价=@成交均价,");
            strSql.Append("成交金额=@成交金额,");
            strSql.Append("手续费=@手续费,");
            strSql.Append("过户费=@过户费,");
            strSql.Append("印花税=@印花税,");
            strSql.Append("时间=@时间");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@股票名称", SqlDbType.NVarChar,50),
					new SqlParameter("@交易方向", SqlDbType.NVarChar,50),
					new SqlParameter("@股数", SqlDbType.BigInt,8),
					new SqlParameter("@成交均价", SqlDbType.Float,8),
					new SqlParameter("@成交金额", SqlDbType.Float,8),
					new SqlParameter("@手续费", SqlDbType.Float,8),
					new SqlParameter("@过户费", SqlDbType.Float,8),
					new SqlParameter("@印花税", SqlDbType.Float,8),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = model.产品名称;
            parameters[1].Value = model.基金经理;
            parameters[2].Value = model.股票代码;
            parameters[3].Value = model.股票名称;
            parameters[4].Value = model.交易方向;
            parameters[5].Value = model.股数;
            parameters[6].Value = model.成交均价;
            parameters[7].Value = model.成交金额;
            parameters[8].Value = model.手续费;
            parameters[9].Value = model.过户费;
            parameters[10].Value = model.印花税;
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
            strSql.Append("delete from 绩效考核_交易记录表 ");
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
            strSql.Append("delete from 绩效考核_交易记录表 ");
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
        public Maticsoft.Model.绩效考核_交易记录表 GetModel(long 记录标识)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 记录标识,产品名称,基金经理,股票代码,股票名称,交易方向,股数,成交均价,成交金额,手续费,过户费,印花税,时间 from 绩效考核_交易记录表 ");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            Maticsoft.Model.绩效考核_交易记录表 model = new Maticsoft.Model.绩效考核_交易记录表();
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
                if (ds.Tables[0].Rows[0]["交易方向"] != null && ds.Tables[0].Rows[0]["交易方向"].ToString() != "")
                {
                    model.交易方向 = ds.Tables[0].Rows[0]["交易方向"].ToString();
                }
                if (ds.Tables[0].Rows[0]["股数"] != null && ds.Tables[0].Rows[0]["股数"].ToString() != "")
                {
                    model.股数 = long.Parse(ds.Tables[0].Rows[0]["股数"].ToString());
                }
                if (ds.Tables[0].Rows[0]["成交均价"] != null && ds.Tables[0].Rows[0]["成交均价"].ToString() != "")
                {
                    model.成交均价 = double.Parse(ds.Tables[0].Rows[0]["成交均价"].ToString());
                }
                if (ds.Tables[0].Rows[0]["成交金额"] != null && ds.Tables[0].Rows[0]["成交金额"].ToString() != "")
                {
                    model.成交金额 = double.Parse(ds.Tables[0].Rows[0]["成交金额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["手续费"] != null && ds.Tables[0].Rows[0]["手续费"].ToString() != "")
                {
                    model.手续费 = double.Parse(ds.Tables[0].Rows[0]["手续费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["过户费"] != null && ds.Tables[0].Rows[0]["过户费"].ToString() != "")
                {
                    model.过户费 = double.Parse(ds.Tables[0].Rows[0]["过户费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["印花税"] != null && ds.Tables[0].Rows[0]["印花税"].ToString() != "")
                {
                    model.印花税 = double.Parse(ds.Tables[0].Rows[0]["印花税"].ToString());
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
            strSql.Append("select 记录标识,产品名称,基金经理,股票代码,股票名称,交易方向,股数,成交均价,成交金额,手续费,过户费,印花税,时间 ");
            strSql.Append(" FROM 绩效考核_交易记录表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" 记录标识,产品名称,基金经理,股票代码,股票名称,交易方向,股数,成交均价,成交金额,手续费,过户费,印花税,时间 ");
            strSql.Append(" FROM 绩效考核_交易记录表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        ///// <summary>
        ///// 从“绩效考核_交易记录表”生成“绩效考核_股票每日交易汇总小表”记录
        ///// </summary>
        ///// <param name="产品名称"></param>
        ///// <param name="基金经理"></param>
        ///// <param name="股票代码"></param>
        ///// <param name="股票名称"></param>
        ///// <param name="currentDT"></param>
        ///// <returns></returns>
        //public Maticsoft.Model.绩效考核_股票每日交易汇总小表 Get股票每日交易汇总小表Model(string 产品名称, string 基金经理, string 股票代码, string 股票名称, string currentDT)
        //{
        //    string sql = string.Format("SELECT  sum(股数) as 股数,sum(成交金额) as 成交金额, sum(手续费) as 手续费,sum(过户费) as 过户费,sum(印花税) as 印花税,交易方向 " +
        //                "FROM 绩效考核_交易记录表 where 交易方向= '买入' and 产品名称='{0}' and 基金经理='{1}' and 股票代码='{2}' and 时间 = '{3}'  " +
        //                "Group by 交易方向  union " +
        //                  "SELECT  sum(股数) as 股数,sum(成交金额) as 成交金额, sum(手续费) as 手续费,sum(过户费) as 过户费,sum(印花税) as 印花税,交易方向 " +
        //                "FROM 绩效考核_交易记录表 where 交易方向= '卖出' and 产品名称='{0}' and 基金经理='{1}' and 股票代码='{2}' and 时间 = '{3}' " +
        //                "Group by 交易方向", 产品名称, 基金经理, 股票代码, currentDT);
        //    Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
        //    DataSet ds = DbHelperSQL.Query(sql);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            if (row["交易方向"] != null && row["交易方向"].ToString() != "")
        //            {
        //                string 交易方向 = row["交易方向"].ToString();
        //                if (交易方向 == "买入")
        //                {
        //                    if (row["股数"] != null && row["股数"].ToString() != "")
        //                    {
        //                        model.今日买入股 = long.Parse(row["股数"].ToString());
        //                    }
        //                    if (row["成交金额"] != null && row["成交金额"].ToString() != "")
        //                    {
        //                        model.买入金额 = double.Parse(row["成交金额"].ToString());
        //                    }
        //                    if (row["手续费"] != null && row["手续费"].ToString() != "")
        //                    {
        //                        model.买入手续费 = double.Parse(row["手续费"].ToString());
        //                    }
        //                    if (row["过户费"] != null && row["过户费"].ToString() != "")
        //                    {
        //                        model.买入过户费 = double.Parse(row["过户费"].ToString());
        //                    }
        //                    if (row["印花税"] != null && row["印花税"].ToString() != "")
        //                    {
        //                        model.买入印花税 = double.Parse(row["印花税"].ToString());
        //                    }
        //                }
        //                else if (交易方向 == "卖出")
        //                {
        //                    if (row["股数"] != null && row["股数"].ToString() != "")
        //                    {
        //                        model.今日卖出股 = long.Parse(row["股数"].ToString());
        //                    }
        //                    if (row["成交金额"] != null && row["成交金额"].ToString() != "")
        //                    {
        //                        model.卖出金额 = double.Parse(row["成交金额"].ToString());
        //                    }
        //                    if (row["手续费"] != null && row["手续费"].ToString() != "")
        //                    {
        //                        model.卖出手续费 = double.Parse(row["手续费"].ToString());
        //                    }
        //                    if (row["过户费"] != null && row["过户费"].ToString() != "")
        //                    {
        //                        model.卖出过户费 = double.Parse(row["过户费"].ToString());
        //                    }
        //                    if (row["印花税"] != null && row["印花税"].ToString() != "")
        //                    {
        //                        model.卖出印花税 = double.Parse(row["印花税"].ToString());
        //                    }
        //                }
        //            }
        //        } 
        //    } // if (ds.Tables[0].Rows.Count > 0)
        //    //edit by qhc（20151106）
        //    model.买入清算金额 = model.买入金额 + model.买入手续费 + model.买入过户费 + model.买入印花税;
        //    model.卖出清算金额 = model.卖出金额 - model.卖出手续费 - model.卖出过户费 - model.卖出印花税;

        //    if (model.今日买入股 != 0)
        //        model.买入均价 = model.买入清算金额 / model.今日买入股;
        //    if (model.今日卖出股 != 0)
        //        model.卖出均价 = model.卖出清算金额 / model.今日卖出股;

        //    model.产品名称 = 产品名称;
        //    model.基金经理 = 基金经理;
        //    model.股票代码 = 股票代码;
        //    model.股票名称 = 股票名称;
        //    model.时间 = currentDT;

        //    return model;
        //}

        #endregion  Method
    }
}

