using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_股票每日价格记录表
	/// </summary>
	public partial class 绩效考核_股票每日价格记录表
	{
		private readonly Maticsoft.DAL.绩效考核_股票每日价格记录表 dal=new Maticsoft.DAL.绩效考核_股票每日价格记录表();
		public 绩效考核_股票每日价格记录表()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 股票代码,string 时间)
		{
            return dal.Exists(股票代码, 时间);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Maticsoft.Model.绩效考核_股票每日价格记录表 model)
		{
            return dal.Add(model);
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
		public List<Maticsoft.Model.绩效考核_股票每日价格记录表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_股票每日价格记录表> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_股票每日价格记录表> modelList = new List<Maticsoft.Model.绩效考核_股票每日价格记录表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_股票每日价格记录表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_股票每日价格记录表();
					if(dt.Rows[n]["股票代码"]!=null && dt.Rows[n]["股票代码"].ToString()!="")
					{
					model.股票代码=dt.Rows[n]["股票代码"].ToString();
					}
					if(dt.Rows[n]["股票名称"]!=null && dt.Rows[n]["股票名称"].ToString()!="")
					{
					model.股票名称=dt.Rows[n]["股票名称"].ToString();
                    }
                    if (dt.Rows[n]["时间"] != null && dt.Rows[n]["时间"].ToString() != "")
                    {
                        model.时间 = dt.Rows[n]["时间"].ToString();
                    }
                    if (dt.Rows[n]["收盘价"] != null && dt.Rows[n]["收盘价"].ToString() != "")
                    {
                        double 收盘价 = 0;
                        double.TryParse( dt.Rows[n]["收盘价"].ToString(),out 收盘价);
                        model.收盘价 = 收盘价;
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

