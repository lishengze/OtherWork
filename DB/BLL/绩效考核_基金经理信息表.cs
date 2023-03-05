using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// 绩效考核_基金经理信息表
    /// </summary>
    public partial class 绩效考核_基金经理信息表
    {
        private readonly Maticsoft.DAL.绩效考核_基金经理信息表 dal = new Maticsoft.DAL.绩效考核_基金经理信息表();
        public 绩效考核_基金经理信息表()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 基金经理)
        {
            return dal.Exists(基金经理);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.绩效考核_基金经理信息表 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.绩效考核_基金经理信息表 model)
        {
            return dal.Update(model);
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
        public bool DeleteList(string 基金经理list)
        {
            return dal.DeleteList(基金经理list);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.绩效考核_基金经理信息表 GetModel(string 基金经理)
        { 
            return dal.GetModel(基金经理);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_基金经理信息表> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_基金经理信息表> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.绩效考核_基金经理信息表> modelList = new List<Maticsoft.Model.绩效考核_基金经理信息表>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.绩效考核_基金经理信息表 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.绩效考核_基金经理信息表();
                    if (dt.Rows[n]["基金经理"] != null && dt.Rows[n]["基金经理"].ToString() != "")
                    {
                        model.基金经理 = dt.Rows[n]["基金经理"].ToString();
                    }
                    if (dt.Rows[n]["管理产品"] != null && dt.Rows[n]["管理产品"].ToString() != "")
                    {
                        model.管理产品 = dt.Rows[n]["管理产品"].ToString();
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

