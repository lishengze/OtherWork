using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:绩效考核_股票每日交易汇总小表
    /// </summary>
    public partial class 绩效考核_股票每日交易汇总小表
    {
        public 绩效考核_股票每日交易汇总小表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 记录标识)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_股票每日交易汇总小表");
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
            string sql = string.Format("select 记录标识 from 绩效考核_股票每日交易汇总小表 where 股票代码='{0}' and 基金经理='{1}' and 产品名称='{2}' and 时间 = '{3}'", 股票代码, 基金经理, 产品名称, 开始时间);
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
        public bool Add(Maticsoft.Model.绩效考核_股票每日交易汇总小表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 绩效考核_股票每日交易汇总小表(");
            strSql.Append("记录标识,股票代码,基金经理,产品名称,股票名称,时间,今日买入股,买入均价,买入金额,今日卖出股,卖出均价,卖出金额,买入手续费,买入过户费,买入印花税,卖出手续费,卖出过户费,卖出印花税,买入清算金额,卖出清算金额,是否为止损指令)");
            strSql.Append(" values (");
            strSql.Append("@记录标识,@股票代码,@基金经理,@产品名称,@股票名称,@时间,@今日买入股,@买入均价,@买入金额,@今日卖出股,@卖出均价,@卖出金额,@买入手续费,@买入过户费,@买入印花税,@卖出手续费,@卖出过户费,@卖出印花税,@买入清算金额,@卖出清算金额,@是否为止损指令)");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8),
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@股票名称", SqlDbType.VarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@今日买入股", SqlDbType.BigInt,8),
					new SqlParameter("@买入均价", SqlDbType.Float,8),
					new SqlParameter("@买入金额", SqlDbType.Float,8),
					new SqlParameter("@今日卖出股", SqlDbType.BigInt,8),
					new SqlParameter("@卖出均价", SqlDbType.Float,8),
					new SqlParameter("@卖出金额", SqlDbType.Float,8),
					new SqlParameter("@买入手续费", SqlDbType.Float,8),
					new SqlParameter("@买入过户费", SqlDbType.Float,8),
					new SqlParameter("@买入印花税", SqlDbType.Float,8),
					new SqlParameter("@卖出手续费", SqlDbType.Float,8),
					new SqlParameter("@卖出过户费", SqlDbType.Float,8),
					new SqlParameter("@卖出印花税", SqlDbType.Float,8),
					new SqlParameter("@买入清算金额", SqlDbType.Float,8),
					new SqlParameter("@卖出清算金额", SqlDbType.Float,8),
					new SqlParameter("@是否为止损指令", SqlDbType.Bit,1)
                                        
                                        };
            parameters[0].Value = model.记录标识;
            parameters[1].Value = model.股票代码;
            parameters[2].Value = model.基金经理;
            parameters[3].Value = model.产品名称;
            parameters[4].Value = model.股票名称;
            parameters[5].Value = model.时间;
            parameters[6].Value = model.今日买入股;
            parameters[7].Value = model.买入均价;
            parameters[8].Value = model.买入金额;
            parameters[9].Value = model.今日卖出股;
            parameters[10].Value = model.卖出均价;
            parameters[11].Value = model.卖出金额;
            parameters[12].Value = model.买入手续费;
            parameters[13].Value = model.买入过户费;
            parameters[14].Value = model.买入印花税;
            parameters[15].Value = model.卖出手续费;
            parameters[16].Value = model.卖出过户费;
            parameters[17].Value = model.卖出印花税;
            parameters[18].Value = model.买入清算金额;
            parameters[19].Value = model.卖出清算金额;
            parameters[20].Value = model.是否为止损指令;

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
        public bool Update(Maticsoft.Model.绩效考核_股票每日交易汇总小表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_股票每日交易汇总小表 set ");
            strSql.Append("股票代码=@股票代码,");
            strSql.Append("基金经理=@基金经理,");
            strSql.Append("产品名称=@产品名称,");
            strSql.Append("股票名称=@股票名称,");
            strSql.Append("时间=@时间,");
            strSql.Append("今日买入股=@今日买入股,");
            strSql.Append("买入均价=@买入均价,");
            strSql.Append("买入金额=@买入金额,");
            strSql.Append("今日卖出股=@今日卖出股,");
            strSql.Append("卖出均价=@卖出均价,");
            strSql.Append("卖出金额=@卖出金额,");
            strSql.Append("买入手续费=@买入手续费,");
            strSql.Append("买入过户费=@买入过户费,");
            strSql.Append("买入印花税=@买入印花税,");
            strSql.Append("卖出手续费=@卖出手续费,");
            strSql.Append("卖出过户费=@卖出过户费,");
            strSql.Append("卖出印花税=@卖出印花税,");
            strSql.Append("买入清算金额=@买入清算金额,");
            strSql.Append("卖出清算金额=@卖出清算金额,");
            strSql.Append("是否为止损指令=@是否为止损指令");
            
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@股票代码", SqlDbType.VarChar,6),
					new SqlParameter("@基金经理", SqlDbType.NVarChar,50),
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@股票名称", SqlDbType.VarChar,50),
					new SqlParameter("@时间", SqlDbType.NVarChar,50),
					new SqlParameter("@今日买入股", SqlDbType.BigInt,8),
					new SqlParameter("@买入均价", SqlDbType.Float,8),
					new SqlParameter("@买入金额", SqlDbType.Float,8),
					new SqlParameter("@今日卖出股", SqlDbType.BigInt,8),
					new SqlParameter("@卖出均价", SqlDbType.Float,8),
					new SqlParameter("@卖出金额", SqlDbType.Float,8),
					new SqlParameter("@买入手续费", SqlDbType.Float,8),
					new SqlParameter("@买入过户费", SqlDbType.Float,8),
					new SqlParameter("@买入印花税", SqlDbType.Float,8),
					new SqlParameter("@卖出手续费", SqlDbType.Float,8),
					new SqlParameter("@卖出过户费", SqlDbType.Float,8),
					new SqlParameter("@卖出印花税", SqlDbType.Float,8),
					new SqlParameter("@买入清算金额", SqlDbType.Float,8),
					new SqlParameter("@卖出清算金额", SqlDbType.Float,8),
					new SqlParameter("@是否为止损指令", SqlDbType.Bit,1),
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = model.股票代码;
            parameters[1].Value = model.基金经理;
            parameters[2].Value = model.产品名称;
            parameters[3].Value = model.股票名称;
            parameters[4].Value = model.时间;
            parameters[5].Value = model.今日买入股;
            parameters[6].Value = model.买入均价;
            parameters[7].Value = model.买入金额;
            parameters[8].Value = model.今日卖出股;
            parameters[9].Value = model.卖出均价;
            parameters[10].Value = model.卖出金额;
            parameters[11].Value = model.买入手续费;
            parameters[12].Value = model.买入过户费;
            parameters[13].Value = model.买入印花税;
            parameters[14].Value = model.卖出手续费;
            parameters[15].Value = model.卖出过户费;
            parameters[16].Value = model.卖出印花税;
            parameters[17].Value = model.买入清算金额;
            parameters[18].Value = model.卖出清算金额;
            parameters[19].Value = model.是否为止损指令;
            parameters[20].Value = model.记录标识;

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
            strSql.Append("delete from 绩效考核_股票每日交易汇总小表 ");
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
            strSql.Append("delete from 绩效考核_股票每日交易汇总小表 ");
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
        public Maticsoft.Model.绩效考核_股票每日交易汇总小表 GetModel(long 记录标识)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 记录标识,股票代码,基金经理,产品名称,股票名称,时间,今日买入股,买入均价,买入金额,今日卖出股,卖出均价,卖出金额,买入手续费,买入过户费,买入印花税,卖出手续费,卖出过户费,卖出印花税,买入清算金额,卖出清算金额,是否为止损指令 from 绩效考核_股票每日交易汇总小表 ");
            strSql.Append(" where 记录标识=@记录标识 ");
            SqlParameter[] parameters = {
					new SqlParameter("@记录标识", SqlDbType.BigInt,8)};
            parameters[0].Value = 记录标识;

            Maticsoft.Model.绩效考核_股票每日交易汇总小表 model = new Maticsoft.Model.绩效考核_股票每日交易汇总小表();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["记录标识"] != null && ds.Tables[0].Rows[0]["记录标识"].ToString() != "")
                {
                    model.记录标识 = long.Parse(ds.Tables[0].Rows[0]["记录标识"].ToString());
                }
                if (ds.Tables[0].Rows[0]["股票代码"] != null && ds.Tables[0].Rows[0]["股票代码"].ToString() != "")
                {
                    model.股票代码 = ds.Tables[0].Rows[0]["股票代码"].ToString();
                }
                if (ds.Tables[0].Rows[0]["基金经理"] != null && ds.Tables[0].Rows[0]["基金经理"].ToString() != "")
                {
                    model.基金经理 = ds.Tables[0].Rows[0]["基金经理"].ToString();
                }
                if (ds.Tables[0].Rows[0]["产品名称"] != null && ds.Tables[0].Rows[0]["产品名称"].ToString() != "")
                {
                    model.产品名称 = ds.Tables[0].Rows[0]["产品名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["股票名称"] != null && ds.Tables[0].Rows[0]["股票名称"].ToString() != "")
                {
                    model.股票名称 = ds.Tables[0].Rows[0]["股票名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["时间"] != null && ds.Tables[0].Rows[0]["时间"].ToString() != "")
                {
                    model.时间 = ds.Tables[0].Rows[0]["时间"].ToString();
                }
                if (ds.Tables[0].Rows[0]["今日买入股"] != null && ds.Tables[0].Rows[0]["今日买入股"].ToString() != "")
                {
                    model.今日买入股 = long.Parse(ds.Tables[0].Rows[0]["今日买入股"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入均价"] != null && ds.Tables[0].Rows[0]["买入均价"].ToString() != "")
                {
                    model.买入均价 = double.Parse(ds.Tables[0].Rows[0]["买入均价"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入金额"] != null && ds.Tables[0].Rows[0]["买入金额"].ToString() != "")
                {
                    model.买入金额 = double.Parse(ds.Tables[0].Rows[0]["买入金额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["今日卖出股"] != null && ds.Tables[0].Rows[0]["今日卖出股"].ToString() != "")
                {
                    model.今日卖出股 = long.Parse(ds.Tables[0].Rows[0]["今日卖出股"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出均价"] != null && ds.Tables[0].Rows[0]["卖出均价"].ToString() != "")
                {
                    model.卖出均价 = double.Parse(ds.Tables[0].Rows[0]["卖出均价"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出金额"] != null && ds.Tables[0].Rows[0]["卖出金额"].ToString() != "")
                {
                    model.卖出金额 = double.Parse(ds.Tables[0].Rows[0]["卖出金额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入手续费"] != null && ds.Tables[0].Rows[0]["买入手续费"].ToString() != "")
                {
                    model.买入手续费 = double.Parse(ds.Tables[0].Rows[0]["买入手续费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入过户费"] != null && ds.Tables[0].Rows[0]["买入过户费"].ToString() != "")
                {
                    model.买入过户费 = double.Parse(ds.Tables[0].Rows[0]["买入过户费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入印花税"] != null && ds.Tables[0].Rows[0]["买入印花税"].ToString() != "")
                {
                    model.买入印花税 = double.Parse(ds.Tables[0].Rows[0]["买入印花税"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出手续费"] != null && ds.Tables[0].Rows[0]["卖出手续费"].ToString() != "")
                {
                    model.卖出手续费 = double.Parse(ds.Tables[0].Rows[0]["卖出手续费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出过户费"] != null && ds.Tables[0].Rows[0]["卖出过户费"].ToString() != "")
                {
                    model.卖出过户费 = double.Parse(ds.Tables[0].Rows[0]["卖出过户费"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出印花税"] != null && ds.Tables[0].Rows[0]["卖出印花税"].ToString() != "")
                {
                    model.卖出印花税 = double.Parse(ds.Tables[0].Rows[0]["卖出印花税"].ToString());
                }
                if (ds.Tables[0].Rows[0]["买入清算金额"] != null && ds.Tables[0].Rows[0]["买入清算金额"].ToString() != "")
                {
                    model.买入清算金额 = double.Parse(ds.Tables[0].Rows[0]["买入清算金额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["卖出清算金额"] != null && ds.Tables[0].Rows[0]["卖出清算金额"].ToString() != "")
                {
                    model.卖出清算金额 = double.Parse(ds.Tables[0].Rows[0]["卖出清算金额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["是否为止损指令"] != null && ds.Tables[0].Rows[0]["是否为止损指令"].ToString() != "")
                {
                    bool flag = false;
                    bool.TryParse(ds.Tables[0].Rows[0]["是否为止损指令"].ToString(), out flag);
                    model.是否为止损指令 = flag;
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
            strSql.Append("select 记录标识,产品名称,基金经理,股票代码,股票名称,时间,今日买入股,买入均价,买入金额,今日卖出股,卖出均价,卖出金额,买入手续费,买入过户费,买入印花税,卖出手续费,卖出过户费,卖出印花税,买入清算金额,卖出清算金额,是否为止损指令 from 绩效考核_股票每日交易汇总小表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        
        #endregion  Method
    }
}

