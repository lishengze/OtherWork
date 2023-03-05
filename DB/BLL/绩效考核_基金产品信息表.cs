using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using DB;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_基金产品信息表
	/// </summary>
	public partial class 绩效考核_基金产品信息表
	{
		private readonly Maticsoft.DAL.绩效考核_基金产品信息表 dal=new Maticsoft.DAL.绩效考核_基金产品信息表();
		public 绩效考核_基金产品信息表()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 产品名称)
		{
			return dal.Exists(产品名称);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金产品信息表 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Maticsoft.Model.绩效考核_基金产品信息表 model)
		{
            return dal.Update(model);
		}

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update_基准日净值(string 产品名称,double 基准日净值)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 绩效考核_基金产品信息表 set "); 
            strSql.Append("基准日净值=@基准日净值");

            strSql.Append(" where 产品名称=@产品名称 ");
            SqlParameter[] parameters = { 
					new SqlParameter("@基准日净值", SqlDbType.Float,8),  
					new SqlParameter("@产品名称", SqlDbType.NVarChar,100)};

            parameters[0].Value = 基准日净值;
            parameters[1].Value  =产品名称; 

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
			
			return dal.Delete(产品名称);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string 产品名称list )
		{
			return dal.DeleteList(产品名称list );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金产品信息表 GetModel(string 产品名称)
		{ 
			return dal.GetModel(产品名称);
		}
         
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
	 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品信息表> GetModelList(string strWhere)
		{
			DataTable table = dal.GetList(strWhere);
            return DataTableToList(table);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品信息表> DataTableToList(DataTable dt)
		{
            Dictionary<string, double> DIC_产品名称_基金份额 = DataConvertor.Get_最新的基金份额();
			List<Maticsoft.Model.绩效考核_基金产品信息表> modelList = new List<Maticsoft.Model.绩效考核_基金产品信息表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_基金产品信息表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_基金产品信息表();
					if(dt.Rows[n]["产品名称"]!=null && dt.Rows[n]["产品名称"].ToString()!="")
					{
					model.产品名称=dt.Rows[n]["产品名称"].ToString();
					}
					if(dt.Rows[n]["佣金"]!=null && dt.Rows[n]["佣金"].ToString()!="")
					{
						model.佣金=double.Parse(dt.Rows[n]["佣金"].ToString());
					}
					if(dt.Rows[n]["印花税"]!=null && dt.Rows[n]["印花税"].ToString()!="")
					{
						model.印花税=double.Parse(dt.Rows[n]["印花税"].ToString());
					}
					if(dt.Rows[n]["过户费比例"]!=null && dt.Rows[n]["过户费比例"].ToString()!="")
					{
						model.过户费比例=double.Parse(dt.Rows[n]["过户费比例"].ToString());
					}
                    if(DIC_产品名称_基金份额.ContainsKey(model.产品名称))
                    {
                        model.份额 = DIC_产品名称_基金份额[model.产品名称];
                    }
                    //if(dt.Rows[n]["份额"]!=null && dt.Rows[n]["份额"].ToString()!="")
                    //{
                    //    model.份额 = double.Parse(dt.Rows[n]["份额"].ToString());
                    //}
                    if (dt.Rows[n]["赎回份额"] != null && dt.Rows[n]["赎回份额"].ToString() != "")
					{
                        model.赎回份额 = double.Parse(dt.Rows[n]["赎回份额"].ToString());
					}
                    if (dt.Rows[n]["基准日净值"] != null && dt.Rows[n]["基准日净值"].ToString() != "")
					{
                        model.基准日净值 = double.Parse(dt.Rows[n]["基准日净值"].ToString());
                    }
                    if (dt.Rows[n]["输出序号"] != null && dt.Rows[n]["输出序号"].ToString() != "")
                    {
                        model.输出序号 = int.Parse(dt.Rows[n]["输出序号"].ToString());
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetAllList()
		{
			return GetList("");
		}
 

		#endregion  Method
	}
}

