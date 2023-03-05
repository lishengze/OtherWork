using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using DB;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:绩效考核_基金产品信息表
    /// </summary>
    public partial class 绩效考核_基金产品信息表
    {
        public 绩效考核_基金产品信息表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 产品名称)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 绩效考核_基金产品信息表");
            strSql.Append(" where 产品名称=@产品名称 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100)};
            parameters[0].Value = 产品名称;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金产品信息表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 绩效考核_基金产品信息表(");
            strSql.Append("产品名称,佣金,印花税,过户费比例,赎回份额,基准日净值,输出序号)");
            strSql.Append(" values (");
            strSql.Append("@产品名称,@佣金,@印花税,@过户费比例,@赎回份额,@基准日净值,@输出序号)");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100),
					new SqlParameter("@佣金", SqlDbType.Float,8),
					new SqlParameter("@印花税", SqlDbType.Float,8),
					new SqlParameter("@过户费比例", SqlDbType.Float,8),
					//new SqlParameter("@份额", SqlDbType.Float,8),
					new SqlParameter("@赎回份额", SqlDbType.Float,8),
					new SqlParameter("@基准日净值", SqlDbType.Float,8),
					new SqlParameter("@输出序号", SqlDbType.Int,4)
                                        
                                        };
            parameters[0].Value = model.产品名称;
            parameters[1].Value = model.佣金;
            parameters[2].Value = model.印花税;
            parameters[3].Value = model.过户费比例;
            // parameters[4].Value = model.份额;
            parameters[4].Value = model.赎回份额;
            parameters[5].Value = model.基准日净值;
            parameters[6].Value = model.输出序号;
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
        public bool Update(Maticsoft.Model.绩效考核_基金产品信息表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_基金产品信息表 set ");
            strSql.Append("佣金=@佣金,");
            strSql.Append("印花税=@印花税,");
            strSql.Append("过户费比例=@过户费比例,");
            // strSql.Append("份额=@份额,");
            strSql.Append("赎回份额=@赎回份额,");
            strSql.Append("基准日净值=@基准日净值,");
            strSql.Append("输出序号=@输出序号");

            strSql.Append(" where 产品名称=@产品名称 ");
            SqlParameter[] parameters = {
					new SqlParameter("@佣金", SqlDbType.Float,8),
					new SqlParameter("@印花税", SqlDbType.Float,8),
					new SqlParameter("@过户费比例", SqlDbType.Float,8),
					//new SqlParameter("@份额", SqlDbType.Float,8), 
					new SqlParameter("@赎回份额", SqlDbType.Float,8), 
					new SqlParameter("@基准日净值", SqlDbType.Float,8),
					new SqlParameter("@输出序号", SqlDbType.Int,4), 
                     
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.佣金;
            parameters[1].Value = model.印花税;
            parameters[2].Value = model.过户费比例;
            //parameters[3].Value = model.份额;
            parameters[3].Value = model.赎回份额;
            parameters[4].Value = model.基准日净值;
            parameters[5].Value = model.输出序号;
            parameters[6].Value = model.产品名称;

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
        public bool Delete(string 产品名称)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 绩效考核_基金产品信息表 ");
            strSql.Append(" where 产品名称=@产品名称 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100)};
            parameters[0].Value = 产品名称;

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
        public bool DeleteList(string 产品名称list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 绩效考核_基金产品信息表 ");
            strSql.Append(" where 产品名称 in (" + 产品名称list + ")  ");
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
        public Maticsoft.Model.绩效考核_基金产品信息表 GetModel(string 产品名称)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 产品名称,佣金,印花税,份额=0,过户费比例,赎回份额,基准日净值,输出序号 from 绩效考核_基金产品信息表 ");
            strSql.Append(" where 产品名称=@产品名称 ");
            SqlParameter[] parameters = {
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100)};
            parameters[0].Value = 产品名称;

            Maticsoft.Model.绩效考核_基金产品信息表 model = new Maticsoft.Model.绩效考核_基金产品信息表();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["产品名称"] != null && ds.Tables[0].Rows[0]["产品名称"].ToString() != "")
                {
                    model.产品名称 = ds.Tables[0].Rows[0]["产品名称"].ToString();
                }
                if (ds.Tables[0].Rows[0]["佣金"] != null && ds.Tables[0].Rows[0]["佣金"].ToString() != "")
                {
                    model.佣金 = double.Parse(ds.Tables[0].Rows[0]["佣金"].ToString());
                }
                if (ds.Tables[0].Rows[0]["印花税"] != null && ds.Tables[0].Rows[0]["印花税"].ToString() != "")
                {
                    model.印花税 = double.Parse(ds.Tables[0].Rows[0]["印花税"].ToString());
                }
                if (ds.Tables[0].Rows[0]["过户费比例"] != null && ds.Tables[0].Rows[0]["过户费比例"].ToString() != "")
                {
                    model.过户费比例 = double.Parse(ds.Tables[0].Rows[0]["过户费比例"].ToString());
                }
                if (ds.Tables[0].Rows[0]["份额"] != null && ds.Tables[0].Rows[0]["份额"].ToString() != "")
                {
                    model.份额 = double.Parse(ds.Tables[0].Rows[0]["份额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["赎回份额"] != null && ds.Tables[0].Rows[0]["赎回份额"].ToString() != "")
                {
                    model.赎回份额 = double.Parse(ds.Tables[0].Rows[0]["赎回份额"].ToString());
                }
                if (ds.Tables[0].Rows[0]["基准日净值"] != null && ds.Tables[0].Rows[0]["基准日净值"].ToString() != "")
                {
                    model.基准日净值 = double.Parse(ds.Tables[0].Rows[0]["基准日净值"].ToString());
                }
                if (ds.Tables[0].Rows[0]["输出序号"] != null && ds.Tables[0].Rows[0]["输出序号"].ToString() != "")
                {
                    model.输出序号 = int.Parse(ds.Tables[0].Rows[0]["输出序号"].ToString());
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
        public DataTable GetList(string strWhere)
        {
            DataTable table = new DataTable();
            Dictionary<string, double> DIC = DataConvertor.Get_最新的基金份额();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 产品名称,佣金,印花税,过户费比例,赎回份额,基准日净值,输出序号 ");
            strSql.Append(" FROM 绩效考核_基金产品信息表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0)
            {
                table = ds.Tables[0];
                table.Columns.Add("份额", typeof(double));
                foreach (DataRow row in table.Rows)
                {
                    string 产品名称 = row["产品名称"].ToString();
                    if (DIC.ContainsKey(产品名称))
                        row["份额"] = DIC[产品名称];
                }
            }
            return table;
        }



        #endregion  Method
    }
}

