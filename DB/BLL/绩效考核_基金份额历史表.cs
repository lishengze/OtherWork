using System;
using System.Data;
using System.Collections.Generic;

using Maticsoft.Model;
using Maticsoft.DBUtility;
namespace Maticsoft.BLL
{
    /// <summary>
    /// 绩效考核_基金份额历史表
    /// </summary>
    public partial class 绩效考核_基金份额历史表
    {
        private readonly Maticsoft.DAL.绩效考核_基金份额历史表 dal = new Maticsoft.DAL.绩效考核_基金份额历史表();
        public 绩效考核_基金份额历史表()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long 序号)
        {
            return dal.Exists(序号);
        }
        /// <summary>
        /// 是否存在该记录,返回记录的标识
        /// </summary>
        public long Exists(string 产品名称, string 修改时间)
        {
            long result = 0;
            string sql = string.Format("select 序号 from 绩效考核_基金份额历史表 where 产品名称='{0}' and 修改时间 = '{1}'", 产品名称, 修改时间);
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
        public long Add(Maticsoft.Model.绩效考核_基金份额历史表 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.绩效考核_基金份额历史表 model)
        {  
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long 代码)
        {

            return dal.Delete(代码);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.绩效考核_基金份额历史表 GetModel(long 代码)
        {
            return dal.GetModel(代码);
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
        public List<Maticsoft.Model.绩效考核_基金份额历史表> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.绩效考核_基金份额历史表> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.绩效考核_基金份额历史表> modelList = new List<Maticsoft.Model.绩效考核_基金份额历史表>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.绩效考核_基金份额历史表 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.绩效考核_基金份额历史表();
                    if (dt.Rows[n]["序号"] != null && dt.Rows[n]["序号"].ToString() != "")
                    {
                        long 序号 = 0;
                        long.TryParse(dt.Rows[n]["序号"].ToString(), out 序号);
                        model.序号 = 序号;
                    }
                    if (dt.Rows[n]["产品名称"] != null && dt.Rows[n]["产品名称"].ToString() != "")
                    {
                        model.产品名称 = dt.Rows[n]["产品名称"].ToString();
                    }
                    if (dt.Rows[n]["基金份额"] != null && dt.Rows[n]["基金份额"].ToString() != "")
                    {
                        double 基金份额 = 0;
                        double.TryParse(dt.Rows[n]["基金份额"].ToString(), out 基金份额);
                        model.基金份额 = 基金份额;
                    }
                    if (dt.Rows[n]["修改时间"] != null && dt.Rows[n]["修改时间"].ToString() != "")
                    {
                        model.修改时间 = dt.Rows[n]["修改时间"].ToString();
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

