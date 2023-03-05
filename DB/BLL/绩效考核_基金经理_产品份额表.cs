using System;
using System.Data;
using System.Collections.Generic; 
using Maticsoft.Model;
using Maticsoft.DBUtility;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 绩效考核_基金经理_产品份额表
	/// </summary>
	public partial class 绩效考核_基金经理_产品份额表
	{
		private readonly Maticsoft.DAL.绩效考核_基金经理_产品份额表 dal=new Maticsoft.DAL.绩效考核_基金经理_产品份额表();
		public 绩效考核_基金经理_产品份额表()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 基金经理,string 基金产品)
		{
			return dal.Exists(基金经理,基金产品);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.绩效考核_基金经理_产品份额表 model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.绩效考核_基金经理_产品份额表 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string 基金经理,string 基金产品)
		{ 
			return dal.Delete(基金经理,基金产品);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string 基金经理)
        { 
            return dal.Delete(基金经理);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete_By基金产品(string 基金产品)
        {
            string sql =string.Format( "delete from 绩效考核_基金经理_产品份额表 where 基金产品= '{0}'" , 基金产品);
            try
            {
                DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true; 
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.绩效考核_基金经理_产品份额表 GetModel(string 基金经理,string 基金产品)
		{
			
			return dal.GetModel(基金经理,基金产品);
		}

		 
        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public DataSet GetDataSets_By基金经理(string 基金经理)
        //{
        //    string sql = string.Format("select t1.产品名称 as 基金产品, t2.申购赎回调整数 from 绩效考核_基金产品信息表 t1 left join 绩效考核_基金经理_产品份额表 t2 on t1.产品名称=t2.基金产品 and t2.基金经理='{0}'", 基金经理);
             
        //    return DbHelperSQL.Query(sql);
        //}
         

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
		public List<Maticsoft.Model.绩效考核_基金经理_产品份额表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.绩效考核_基金经理_产品份额表> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.绩效考核_基金经理_产品份额表> modelList = new List<Maticsoft.Model.绩效考核_基金经理_产品份额表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.绩效考核_基金经理_产品份额表 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.绩效考核_基金经理_产品份额表();
					if(dt.Rows[n]["基金经理"]!=null && dt.Rows[n]["基金经理"].ToString()!="")
					{
					model.基金经理=dt.Rows[n]["基金经理"].ToString();
					}
					if(dt.Rows[n]["基金产品"]!=null && dt.Rows[n]["基金产品"].ToString()!="")
					{
					model.基金产品=dt.Rows[n]["基金产品"].ToString();
					}
                    if (dt.Rows[n]["申购赎回调整数"] != null && dt.Rows[n]["申购赎回调整数"].ToString() != "")
					{
                        model.申购赎回调整数 = double.Parse(dt.Rows[n]["申购赎回调整数"].ToString());
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

