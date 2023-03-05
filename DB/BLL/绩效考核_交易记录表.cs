using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using Maticsoft.DBUtility;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_交易记录表
	/// </summary>
	public partial class 绩效考核_交易记录表
	{
		private readonly Maticsoft.DAL.绩效考核_交易记录表 dal=new Maticsoft.DAL.绩效考核_交易记录表();
		public 绩效考核_交易记录表()
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
        /// 是否存在该记录,返回记录的标识
        /// </summary>
        public long Exists(string 股票代码, string 基金经理, string 产品名称, string 交易方向, string 时间)
        {
            long result = 0;
            string sql = string.Format("select 记录标识 from 绩效考核_交易记录表 where 股票代码='{0}' and 基金经理='{1}' and 产品名称='{2}' and 交易方向='{3}' and 时间 = '{4}'", 股票代码, 基金经理, 产品名称, 交易方向, 时间);
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
        public bool Add(Maticsoft.Model.绩效考核_交易记录表 model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_交易记录表 model)
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
		public Maticsoft.Model.绩效考核_交易记录表 GetModel(long 记录标识)
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
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_交易记录表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_交易记录表> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_交易记录表> modelList = new List<Maticsoft.Model.绩效考核_交易记录表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_交易记录表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_交易记录表();
					if(dt.Rows[n]["记录标识"]!=null && dt.Rows[n]["记录标识"].ToString()!="")
					{
						model.记录标识=long.Parse(dt.Rows[n]["记录标识"].ToString());
					}
					if(dt.Rows[n]["产品名称"]!=null && dt.Rows[n]["产品名称"].ToString()!="")
					{
					model.产品名称=dt.Rows[n]["产品名称"].ToString();
					}
					if(dt.Rows[n]["基金经理"]!=null && dt.Rows[n]["基金经理"].ToString()!="")
					{
					model.基金经理=dt.Rows[n]["基金经理"].ToString();
					}
					if(dt.Rows[n]["股票代码"]!=null && dt.Rows[n]["股票代码"].ToString()!="")
					{
					model.股票代码=dt.Rows[n]["股票代码"].ToString();
					}
					if(dt.Rows[n]["股票名称"]!=null && dt.Rows[n]["股票名称"].ToString()!="")
					{
					model.股票名称=dt.Rows[n]["股票名称"].ToString();
					}
					if(dt.Rows[n]["交易方向"]!=null && dt.Rows[n]["交易方向"].ToString()!="")
					{
					model.交易方向=dt.Rows[n]["交易方向"].ToString();
					}
					if(dt.Rows[n]["股数"]!=null && dt.Rows[n]["股数"].ToString()!="")
					{
						model.股数=long.Parse(dt.Rows[n]["股数"].ToString());
					}
					if(dt.Rows[n]["成交均价"]!=null && dt.Rows[n]["成交均价"].ToString()!="")
					{
						model.成交均价=double.Parse(dt.Rows[n]["成交均价"].ToString());
					}
					if(dt.Rows[n]["成交金额"]!=null && dt.Rows[n]["成交金额"].ToString()!="")
					{
						model.成交金额=double.Parse(dt.Rows[n]["成交金额"].ToString());
					}
					if(dt.Rows[n]["手续费"]!=null && dt.Rows[n]["手续费"].ToString()!="")
					{
						model.手续费=double.Parse(dt.Rows[n]["手续费"].ToString());
					}
					if(dt.Rows[n]["过户费"]!=null && dt.Rows[n]["过户费"].ToString()!="")
					{
						model.过户费=double.Parse(dt.Rows[n]["过户费"].ToString());
					}
					if(dt.Rows[n]["印花税"]!=null && dt.Rows[n]["印花税"].ToString()!="")
					{
						model.印花税=double.Parse(dt.Rows[n]["印花税"].ToString());
					}
					if(dt.Rows[n]["时间"]!=null && dt.Rows[n]["时间"].ToString()!="")
					{
						model.时间=dt.Rows[n]["时间"].ToString();
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

