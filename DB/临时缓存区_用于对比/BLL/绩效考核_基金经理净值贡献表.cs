using System;
using System.Data;
using System.Collections.Generic; 
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 临时缓存区_绩效考核_基金经理净值贡献表
	/// </summary>
	public partial class 临时缓存区_绩效考核_基金经理净值贡献表
	{
		private readonly Maticsoft.DAL.临时缓存区_绩效考核_基金经理净值贡献表 dal=new Maticsoft.DAL.临时缓存区_绩效考核_基金经理净值贡献表();
		public 临时缓存区_绩效考核_基金经理净值贡献表()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 基金经理,string 时间,string 基金产品)
		{
			return dal.Exists(基金经理,时间,基金产品);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.绩效考核_基金经理净值贡献表 model)
		{
		   return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_基金经理净值贡献表 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string 基金经理,string 时间,string 基金产品)
		{
			
			return dal.Delete(基金经理,时间,基金产品);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金经理净值贡献表 GetModel(string 基金经理,string 时间,string 基金产品)
		{
			
			return dal.GetModel(基金经理,时间,基金产品);
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
		public List<Maticsoft.Model.绩效考核_基金经理净值贡献表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金经理净值贡献表> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_基金经理净值贡献表> modelList = new List<Maticsoft.Model.绩效考核_基金经理净值贡献表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_基金经理净值贡献表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_基金经理净值贡献表();
					if(dt.Rows[n]["基金经理"]!=null && dt.Rows[n]["基金经理"].ToString()!="")
					{
					model.基金经理=dt.Rows[n]["基金经理"].ToString();
					}
					if(dt.Rows[n]["时间"]!=null && dt.Rows[n]["时间"].ToString()!="")
					{
					model.时间=dt.Rows[n]["时间"].ToString();
					}
					if(dt.Rows[n]["基金产品"]!=null && dt.Rows[n]["基金产品"].ToString()!="")
					{
					model.基金产品=dt.Rows[n]["基金产品"].ToString();
					}
					if(dt.Rows[n]["本年净值贡献"]!=null && dt.Rows[n]["本年净值贡献"].ToString()!="")
					{
						model.本年净值贡献=double.Parse(dt.Rows[n]["本年净值贡献"].ToString());
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

