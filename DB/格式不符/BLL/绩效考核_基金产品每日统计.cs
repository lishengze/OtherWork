using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using Maticsoft.DBUtility;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_基金产品每日统计_格式不符
	/// </summary>
	public partial class 绩效考核_基金产品每日统计_格式不符
	{
		private readonly Maticsoft.DAL.绩效考核_基金产品每日统计_格式不符 dal=new Maticsoft.DAL.绩效考核_基金产品每日统计_格式不符();
		public 绩效考核_基金产品每日统计_格式不符()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long 记录标识)
		{
			return dal.Exists(记录标识);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public long Exists( string 产品名称, string 时间)
        {
            return dal.Exists( 产品名称, 时间);
        } 

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_基金产品每日统计 model)
		{
			return dal.Update(model);
		}
        
        
       
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long 记录标识)
		{
			
			return dal.Delete(记录标识);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string 记录标识list )
		{
			return dal.DeleteList(记录标识list );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金产品每日统计 GetModel(long 记录标识)
		{ 
			return dal.GetModel(记录标识);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表-有限的列
        /// </summary>
        public DataSet GetList_SelectColumn(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 时间,产品名称,资产总额 as 总资产,单位净值,资金资产比例 FROM 绩效考核_基金产品每日统计_格式不符 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            } 

            return DbHelperSQL.Query(strSql.ToString());
        }
		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品每日统计> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
         
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金产品每日统计> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_基金产品每日统计> modelList = new List<Maticsoft.Model.绩效考核_基金产品每日统计>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_基金产品每日统计 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_基金产品每日统计();
					if(dt.Rows[n]["记录标识"]!=null && dt.Rows[n]["记录标识"].ToString()!="")
					{
						model.记录标识=long.Parse(dt.Rows[n]["记录标识"].ToString());
					}
					if(dt.Rows[n]["产品名称"]!=null && dt.Rows[n]["产品名称"].ToString()!="")
					{
					model.产品名称=dt.Rows[n]["产品名称"].ToString();
					}
					if(dt.Rows[n]["资产总额"]!=null && dt.Rows[n]["资产总额"].ToString()!="")
					{
						model.资产总额=double.Parse(dt.Rows[n]["资产总额"].ToString());
					}
					if(dt.Rows[n]["资金余额"]!=null && dt.Rows[n]["资金余额"].ToString()!="")
					{
						model.资金余额=double.Parse(dt.Rows[n]["资金余额"].ToString());
					}
					if(dt.Rows[n]["资金资产比例"]!=null && dt.Rows[n]["资金资产比例"].ToString()!="")
					{
                        model.资金资产比例 = dt.Rows[n]["资金资产比例"].ToString();
					}
					if(dt.Rows[n]["今年收益率"]!=null && dt.Rows[n]["今年收益率"].ToString()!="")
					{
                        model.今年收益率 = dt.Rows[n]["今年收益率"].ToString();
					}
					if(dt.Rows[n]["单位净值"]!=null && dt.Rows[n]["单位净值"].ToString()!="")
					{
						model.单位净值=double.Parse(dt.Rows[n]["单位净值"].ToString());
					}

                    if (dt.Rows[n]["今年最大净值"] != null && dt.Rows[n]["今年最大净值"].ToString() != "")
                    {
                        model.今年最大净值 = double.Parse(dt.Rows[n]["今年最大净值"].ToString());
                    }
                    if (dt.Rows[n]["回撤率"] != null && dt.Rows[n]["回撤率"].ToString() != "")
                    {
                        model.回撤率 = dt.Rows[n]["回撤率"].ToString();
                    }  
					if(dt.Rows[n]["时间"]!=null && dt.Rows[n]["时间"].ToString()!="")
					{
						model.时间=dt.Rows[n]["时间"].ToString();
					} 
                    if (dt.Rows[n]["基金份额"] != null && dt.Rows[n]["基金份额"].ToString() != "")
                    {
                        model.基金份额 = double.Parse(dt.Rows[n]["基金份额"].ToString());
                    }
                    if (dt.Rows[n]["基准日净值"] != null && dt.Rows[n]["基准日净值"].ToString() != "")
                    {
                        model.基准日净值 = double.Parse(dt.Rows[n]["基准日净值"].ToString());
                    }
                    if (dt.Rows[n]["申购赎回调整数"] != null && dt.Rows[n]["申购赎回调整数"].ToString() != "")
                    {
                        model.申购赎回调整数 = double.Parse(dt.Rows[n]["申购赎回调整数"].ToString());
                    }
                    if (dt.Rows[n]["股票资产总额"] != null && dt.Rows[n]["股票资产总额"].ToString() != "")
                    {
                        model.股票资产总额 = double.Parse(dt.Rows[n]["股票资产总额"].ToString());
                    }
                    if (dt.Rows[n]["期货资产总额"] != null && dt.Rows[n]["期货资产总额"].ToString() != "")
                    {
                        model.期货资产总额 = double.Parse(dt.Rows[n]["期货资产总额"].ToString());
                    }
                    if (dt.Rows[n]["期货资金余额"] != null && dt.Rows[n]["期货资金余额"].ToString() != "")
                    {
                        model.期货资金余额 = double.Parse(dt.Rows[n]["期货资金余额"].ToString());
                    }
                    if (dt.Rows[n]["期货今年收益率"] != null && dt.Rows[n]["期货今年收益率"].ToString() != "")
                    {
                        model.期货今年收益率 = double.Parse(dt.Rows[n]["期货今年收益率"].ToString());
                    }
                    
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

	 

		#endregion  Method
	}
}

