using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_汇率
	/// </summary>
	public partial class 绩效考核_汇率
	{
		private readonly Maticsoft.DAL.绩效考核_汇率 dal=new Maticsoft.DAL.绩效考核_汇率();
		public 绩效考核_汇率()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 时间)
		{
			return dal.Exists(时间);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_汇率 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_汇率 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string 时间)
		{
			
			return dal.Delete(时间);
		}
		 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_汇率 GetModel(string 时间)
		{
			
			return dal.GetModel(时间);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_汇率> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_汇率> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_汇率> modelList = new List<Maticsoft.Model.绩效考核_汇率>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_汇率 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_汇率();
                    if (dt.Rows[n]["时间"] != null && dt.Rows[n]["时间"].ToString() != "")
					{
                        model.时间 = dt.Rows[n]["时间"].ToString();
					}
                    if (dt.Rows[n]["买入汇率"] != null && dt.Rows[n]["买入汇率"].ToString() != "")
					{
                        double 买入汇率 = 0;
                        double.TryParse(dt.Rows[n]["买入汇率"].ToString(), out 买入汇率);
                        model.买入汇率 = 买入汇率;
                    }
                    if (dt.Rows[n]["卖出汇率"] != null && dt.Rows[n]["卖出汇率"].ToString() != "")
                    {
                        double 卖出汇率 = 0;
                        double.TryParse(dt.Rows[n]["卖出汇率"].ToString(), out 卖出汇率);
                        model.卖出汇率 = 卖出汇率;
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

